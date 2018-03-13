(function () {

    'use strict';

    angular.module('faster').controller('LogoutCtrl', LogoutCtrl);

    LogoutCtrl.$inject = ['$rootScope', '$location', '$window', 'SETTINGS'];

    function LogoutCtrl($rootScope, $location, $window,SETTINGS) {

        var vm = this;

        activate();

        function activate() {
            $rootScope.user = null;
            $rootScope.token = null;            
            sessionStorage.removeItem(SETTINGS.AUTH_TOKEN);
            sessionStorage.removeItem(SETTINGS.AUTH_USER);
            $location.path('/login');
            //$window.location.href = 'http://localhost:4002/';
            $window.location.href = 'http://www.fastertecnologia.com.br/';

        };
    };
})();