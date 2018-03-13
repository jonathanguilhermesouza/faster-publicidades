(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ListVideoCategoryCtrl', ListVideoCategoryCtrl);

    ListVideoCategoryCtrl.$inject = ['VideoCategoryFactory', 'RedirectUserService'];

    function ListVideoCategoryCtrl(VideoCategoryFactory, RedirectUserService) {

        var vm = this;

        vm.categoriesVideo = [];
        vm.categoryVideo = {};
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = { skip: 1, status: 1, word: null };

        vm.range = range;
        vm.getByRangeCategoryVideo = getByRangeCategoryVideo;
        vm.remove = remove;

        activate();

        function range(n) {
            return new Array(n);
        }

        function activate() {
            getCountCategoryVideo();
            getByRangeCategoryVideo(vm.filter.skip);
        }

        function getCountCategoryVideo() {
            VideoCategoryFactory.getCount(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.pagination.qtdPages = Math.ceil(response / vm.pagination.take);
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex();
                }
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao recuperar dados!</strong>');
                    });
                }
            }
        }

        function getByRangeCategoryVideo(skip) {
            vm.filter.skip = skip;
            console.log(vm.filter);
            VideoCategoryFactory.getByRange(vm.filter)
                .success(success)
                .catch(fail);

            function success(response) {
                vm.categoriesVideo = response;
            }
            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex();
                }
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao recuperar dados!</strong>');
                    });
                }
            }
        }

        function remove(category) {
            loadCategoryVideo(category);
            VideoCategoryFactory.remove(vm.category)
               .success(success)
               .catch(fail);

            function success(response) {
                toastr.success('Categoria <strong>' + response.category + '</strong> removida com sucesso', 'Sucesso');
                var index = vm.categoriesVideo.indexOf(category);
                vm.categoriesVideo.splice(index, 1);
                getCountCategoryVideo();

                if (vm.filter.skip > 1 && vm.categoriesVideo.length == 0)
                    getByRangeCategoryVideo(vm.filter.skip - 1);
                else
                    getByRangeCategoryVideo(vm.filter.skip);
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex();
                }
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao remover dados!</strong>');
                    });
                }
            }
            clearCategoryVideo();
        }
        function loadCategoryVideo(category) {
            vm.CategoryVideo = category;
        }

        function clearCategoryVideo() {
            vm.CategoryVideo = {
                idCategoryVideo: 0,
                category: ''
            }
        }
    };

})();