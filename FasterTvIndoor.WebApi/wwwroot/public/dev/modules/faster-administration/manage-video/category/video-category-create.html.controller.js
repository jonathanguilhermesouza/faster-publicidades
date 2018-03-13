(function () {

    'use strict';

    angular.module('fasterAdministration').controller('CreateVideoCategoryCtrl', CreateVideoCategoryCtrl);

    CreateVideoCategoryCtrl.$inject = ['$location', 'VideoCategoryFactory', 'RedirectUserService'];

    function CreateVideoCategoryCtrl($location, VideoCategoryFactory, RedirectUserService) {

        var vm = this;
        var errors = false;

        vm.errors = [];
        vm.categoryVideo = {
            category:''
        };


        activate();

        vm.save = save;
        vm.cancel = cancel;
        vm.clearError = clearError;

        function activate() {
        }

        function save() {
            VideoCategoryFactory.post(vm.categoryVideo)
                .success(success)
                .catch(fail);
            function success(response) {
                toastr.success('Categoria <strong>' + vm.categoryVideo.category + '</strong> cadastrada com sucesso', 'Categoria Cadastrada');
                $location.path('/category-video');
            }
            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex();
                }
                else {
                    vm.errors = angular.fromJson(error.data.errors);
                    angular.forEach(vm.errors, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao salvar dados!</strong>');
                    });
                }
                errors = true;
            }
        }

        function cancel() {
            clearCategoryVideo();
            $location.path('/category-video');
        }

        function clearError(error) {
            var index = vm.errors.indexOf(error);
            vm.errors.splice(index, 1);
        }

        function clearCategoryVideo() {
            vm.categoryVideo = {
                idCategoryVideo: 0,
                category : ''
            }
        }
    };

})();