(function () {
    'use strict'

    angular.module('faster').service('RedirectUserService', RedirectUserService);

    RedirectUserService.$inject = ['$window', '$rootScope'];

    function RedirectUserService($window, $rootScope) {
        
        var vm = this;
        vm.redirectToIndex = redirectToIndex;

        activate();


        function activate() {
        }

        function redirectToIndex() {
            switch ($rootScope.user.profile) {
                case 'Master':
                    //$window.location.href = 'http://localhost:4002/wwwroot/public/dev/modules/faster-administration/';
                    $window.location.href = 'http://www.fastertecnologia.com.br/wwwroot/public/dev/modules/faster-administration/';
                    break;
                case 'Cliente':
                    //$window.location.href = 'http://localhost:4002/wwwroot/public/dev/modules/client/';
                    $window.location.href = 'http://www.fastertecnologia.com.br/wwwroot/public/dev/modules/client/';
                    break;
                case 'PlayerIndoor':
                    //$window.location.href = 'http://localhost:4002/wwwroot/public/dev/modules/video-player/';
                    $window.location.href = 'http://www.fastertecnologia.com.br/wwwroot/public/dev/modules/video-player/';
                    break;
                default:
                    //$window.location.href = 'http://localhost:4002/wwwroot/public/dev/';
                    $window.location.href = 'http://www.fastertecnologia.com.br/wwwroot/public/dev/';
            }
        }
     
    };

})();