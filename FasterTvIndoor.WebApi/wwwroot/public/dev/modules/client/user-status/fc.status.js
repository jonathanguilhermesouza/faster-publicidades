(function () {

    'use strict';

    angular.module('faster').factory('StatusUserFactory', StatusUserFactory);

    StatusUserFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function StatusUserFactory($http, $rootScope, SETTINGS) {
        return {            
            getAll: getAll
        };

        function getAll() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/status-user', $rootScope.header)
        }
       
    };

})();