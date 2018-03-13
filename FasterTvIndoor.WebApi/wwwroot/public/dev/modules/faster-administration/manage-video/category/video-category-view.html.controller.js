(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ViewVideoCategoryCtrl', ViewVideoCategoryCtrl);

    ViewVideoCategoryCtrl.$inject = ['$routeParams', 'VideoCategoryFactory', 'RedirectUserService'];

    function ViewVideoCategoryCtrl($routeParams, VideoCategoryFactory, RedirectUserService) {

        var vm = this;

        vm.categoryVideo = {
            idCategoryVideo: 0,
            category: ''
        };
        var erros = false;
        var id = $routeParams.id;

        activate();

        vm.save = save;

        function activate() {
            getByIdCategoryVideo();
        }

        function getByIdCategoryVideo() {
            VideoCategoryFactory.getById(id)
                .success(success)
                .catch(fail);

            function success(response) {
                console.log(response);
                vm.categoryVideo = response;
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

        function save() {
            VideoCategoryFactory.put(vm.categoryVideo)
               .success(success)
               .catch(fail);
            function success(response) {
                toastr.success('Categoria <strong>' + vm.categoryVideo.category + '</strong> cadastrada com sucesso', 'Categoria atualizada');
            }
            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex();
                }
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao salvar dados!</strong>');
                    });
                }
                //errors = true;
                clear();
            }
        }

        function clear() {
            vm.categoryVideo = {
                idCategoryVideo: 0,
                category: ''
            }
        }

    }

})();