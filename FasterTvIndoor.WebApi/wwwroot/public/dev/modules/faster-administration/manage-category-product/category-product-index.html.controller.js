(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ListVideoCategoryCtrl', ListVideoCategoryCtrl);

    ListVideoCategoryCtrl.$inject = ['$location', 'CategoryVideoFactory', 'RedirectUserService'];

    function ListVideoCategoryCtrl($location, CategoryVideoFactory, RedirectUserService) {

        var vm = this;

        vm.categoriesVideo = [];
        vm.categoryVideo = {
            id: 0,
            category: ''
        };
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = {
            skip: 1,
            word: null,
            status: 1
        };
        vm.range = range;
        vm.getAllCategoryVideo = getAllCategoryVideo;
        vm.removeCategoryVideo = removeCategoryProduct;

        activate();

        function range(n) {
            return new Array(n);
        }

        function activate() {
            getCountCategoryProduct();
            getAllCategoryVideo(vm.filter.skip);
        }

        function getCountCategoryProduct() {
            CategoryVideoFactory.getCount()
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

        function getAllCategoryVideo(skip) {
            vm.filter.skip = skip;
            CategoryVideoFactory.getByRange(vm.filter)
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

        function removeCategoryProduct(category) {
            loadCategory(category);
            CategoryVideoFactory.remove(vm.categoryVideo)
               .success(success)
               .catch(fail);

            function success(response) {
                toastr.success('Categoria <strong>' + response.title + '</strong> removida com sucesso', 'Sucesso');
                var index = vm.categoriesVideo.indexOf(category);
                vm.categoriesVideo.splice(index, 1);

                getCountCategoryProduct();

                if (vm.filter.skip > 1 && vm.categoriesVideo.length == 0)
                    getAllCategoryVideo(vm.filter.skip - 1);
                else
                    getAllCategoryVideo(vm.filter.skip);
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
            clearCategory();

        }
        function loadCategory(category) {
            vm.categoryVideo = category;
        }

        function clearCategory() {
            vm.categoryVideo = {
                id: 0,
                category: ''
            }
        }

    };

})();