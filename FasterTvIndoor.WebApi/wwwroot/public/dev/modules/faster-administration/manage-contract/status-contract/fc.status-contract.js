(function () {

    'use strict';

    angular.module('faster').factory('StatusContractFactory', StatusContractFactory);

    StatusContractFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function StatusContractFactory($http, $rootScope, SETTINGS) {

        return {
            getAll: getAll
        }

        function getAll() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/status-contract', $rootScope.header);
        }

    };

})();