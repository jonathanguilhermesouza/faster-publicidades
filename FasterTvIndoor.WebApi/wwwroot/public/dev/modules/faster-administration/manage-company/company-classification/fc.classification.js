(function () {
    'use strict'

    angular.module('fasterAdministration').factory('ClassificationFactory', ClassificationFactory);

    ClassificationFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function ClassificationFactory($http, $rootScope, SETTINGS) {
        return {            
            getAll: getAll
        };
        
        function getAll() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/classification', $rootScope.header)
        }
    };

})();