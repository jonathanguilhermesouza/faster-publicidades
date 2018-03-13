(function () {

    'use strict';

    angular.module('faster').controller('RegisterCtrl', RegisterCtrl)

    RegisterCtrl.$inject = ['$location', '$rootScope', 'SETTINGS', 'AccountFactory', 'RedirectUserService'];

    function RegisterCtrl($location, $rootScope, SETTINGS, AccountFactory, RedirectUserService) {
        var vm = this;        

        vm.register = {
            email: '',
            password: '',
            name: '',
            lastName: '',
            nickName:''           
        };

        vm.submit = register;

        activate();

        function activate() {
        }

        function checkProfileUser() {
            AccountFactory.getByEmail(vm.register.email)
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

        function register() {
            AccountFactory.register(vm.register)
                .success(success)
                .catch(fail);
        }

        function success(response) {

            //var user = { username: vm.register.email, password: vm.register.password };
            //AccountFactory.login(user);
           
            //$rootScope.token = response.access_token;
            //sessionStorage.setItem(SETTINGS.AUTH_TOKEN, response.access_token);
            //sessionStorage.setItem(SETTINGS.AUTH_USER, $rootScope.user);
            //checkProfileUser();
            $location.path('/login');
        }

        function fail(error) {
            var items = angular.fromJson(error.data.errors);
            angular.forEach(items, function (value, key) {
                toastr.warning(value.value, '<strong>Cadastro sem sucesso!</strong>');
            });
        }

    };

})();