(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ViewProfileCtrl', ViewProfileCtrl);

    ViewProfileCtrl.$inject = ['$routeParams', 'ProfileUserFactory', 'RedirectUserService'];

    function ViewProfileCtrl($routeParams, ProfileUserFactory, RedirectUserService) {

        var vm = this;

        vm.profile = {};
        var erros = false;
        var id = $routeParams.id;

        activate();

        vm.save = save;

        function activate() {
            getByIdProfileUser();
        }

        function getByIdProfileUser() {
            ProfileUserFactory.getById(id)
                .success(success)
                .catch(fail);

            function success(response) {
                console.log(response);
                vm.profile = response;
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
            ProfileUserFactory.put(vm.profile)
               .success(success)
               .catch(fail);
            function success(response) {
                toastr.success('Perfil <strong>' + vm.profile.profile + '</strong> cadastrada com sucesso', 'Perfil Cadastrado');
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
                errors = true;
                clear();
            }
        }

        function clear() {
            vm.profile = {
                idProfileUser: 0,
                profile: ''
            }
        }

    }

})();