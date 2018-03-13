(function () {
    'use strict'

    angular.module('fasterAdministration').factory('StatusFactory', StatusFactory);

    StatusFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function StatusFactory($http, $rootScope, SETTINGS) {
        return {            
            getAll: getAll
        };

        function getAll() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/status', $rootScope.header)
        }
       
    };

})();