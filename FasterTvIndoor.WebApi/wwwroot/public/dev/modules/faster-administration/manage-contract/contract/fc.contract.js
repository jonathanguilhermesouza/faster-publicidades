(function () {

    'use strict';

    angular.module('fasterAdministration').factory('ContractFactory', ContractFactory);

    ContractFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function ContractFactory($http, $rootScope, SETTINGS) {

        return {
            getByRange: getByRange,
            getCount: getCount,
            getById: getById,
            post: post,
            put: put,
            cancel: cancel
        }

        function getCount(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/contract/count/' + filter.status + '/' + filter.word, $rootScope.header);
        }

        function getByRange(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/contract/range/' + filter.skip + '/' + filter.status + '/' + filter.word, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/contract/' + id, $rootScope.header);
        }

        function post(contract) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/contract', contract, $rootScope.header);
        }

        function put(contract) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/contract/' + contract.idContract, contract, $rootScope.header);
        }

        function cancel(contract) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/contract/c/' + contract.idContract, contract, $rootScope.header);
        }

    };

})();