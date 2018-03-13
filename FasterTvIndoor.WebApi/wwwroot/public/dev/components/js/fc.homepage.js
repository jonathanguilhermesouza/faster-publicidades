(function () {

    'use strict';

    angular.module('faster').factory('HomepageFactory', HomepageFactory);

    HomepageFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function HomepageFactory($http, $rootScope, SETTINGS) {
        return {
            post: post
        };

        function post(email) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/Homepage/', email, $rootScope.header);
        }
    };

})();