(function () {
    'use strict'

    angular.module('fasterClient').factory('ActionFactory', ActionFactory);

    ActionFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function ActionFactory($http, $rootScope, SETTINGS) {
        return {            
            getAll: getAll
        };

        function getAll() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/action', $rootScope.header)
        }
       
    };

})();