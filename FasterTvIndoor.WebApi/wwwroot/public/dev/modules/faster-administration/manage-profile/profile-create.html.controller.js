(function () {

    'use strict';

    angular.module('fasterAdministration').controller('CreateProfileCtrl', CreateProfileCtrl);

    CreateProfileCtrl.$inject = ['$location', 'ProfileUserFactory', 'RedirectUserService'];

    function CreateProfileCtrl($location, ProfileUserFactory, RedirectUserService) {

        var vm = this;
        var errors = false;

        vm.errors = [];
        vm.profile = {
            profile:''
        };


        activate();

        vm.save = save;
        vm.cancel = cancel;
        vm.clearError = clearError;

        function activate() {
        }

        function save() {
            ProfileUserFactory.post(vm.profile)
                .success(success)
                .catch(fail);
            function success(response) {
                toastr.success('Perfil <strong>' + vm.profile.profile + '</strong> cadastrada com sucesso', 'Perfil Cadastrado');
                redirect();
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
            clearProfile();
            $location.path('/profile');
        }

        function clearError(error) {
            var index = vm.errors.indexOf(error);
            vm.errors.splice(index, 1);
        }

        function clearProfile() {
            vm.profile = {
                idProfileUser: 0,
                profile : ''
            }
        }
    };

})();