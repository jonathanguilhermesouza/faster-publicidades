(function () {

    'use strict';

    angular.module('fasterAdministration').factory('StatusControlLoanFactory', StatusControlLoanFactory);

    StatusControlLoanFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function StatusControlLoanFactory($http, $rootScope, SETTINGS) {
        return {            
            getAll: getAll
        };

        function getAll() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/status-loan', $rootScope.header)
        }
       
    };

})();