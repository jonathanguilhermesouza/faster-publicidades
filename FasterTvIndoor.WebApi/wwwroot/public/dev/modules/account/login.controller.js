(function () {

    'use strict';

    angular.module('faster').controller('LoginCtrl', LoginCtrl)

    LoginCtrl.$inject = ['$location', '$rootScope', 'SETTINGS', 'AccountFactory', 'RedirectUserService'];

    function LoginCtrl($location, $rootScope, SETTINGS, AccountFactory, RedirectUserService) {

        var vm = this;

        vm.login = {
            username: '',
            password: ''
        };

        vm.submit = login;

        activate();

        function activate() {

        }

        function checkProfileUser() {
            AccountFactory.getByEmail(vm.login.username)
            .success(success)
            .catch(fail);

            function success(response) {
                $rootScope.user = {
                    name: response.name,
                    email: response.email,
                    profile: response.profileUser.profile
                };
                sessionStorage.setItem(SETTINGS.AUTH_USER, angular.toJson($rootScope.user));
                RedirectUserService.redirectToIndex();
            }

            function fail(error) {

            }
        }

        function login() {
            $rootScope.progressbar.setColor('#29abe0');
            $rootScope.progressbar.start();
            AccountFactory.login(vm.login)
            .success(success)
            .catch(fail);

            function success(response) {
                $rootScope.progressbar.complete();
                $rootScope.token = response.access_token;
                sessionStorage.setItem(SETTINGS.AUTH_TOKEN, response.access_token);
                $rootScope.header = {
                    headers: {
                        'Authorization': 'Bearer ' + response.access_token
                    }
                }
                checkProfileUser();
            }

            function fail(error) {
                $rootScope.progressbar.complete();
                toastr.error(error.data.error_description, 'Falha na autenticação');
            }
        }

    };

})();