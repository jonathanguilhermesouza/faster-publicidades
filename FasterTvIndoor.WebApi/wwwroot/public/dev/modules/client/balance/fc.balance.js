(function () {

    'use strict';

    angular.module('fasterClient').factory('BalanceFactory', BalanceFactory);

    BalanceFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function BalanceFactory($http, $rootScope, SETTINGS) {
        return {
            getAll: getAll,
            post: post,
            getById: getById,
            put: put,
            remove: remove,
            getByRange: getByRange,
            getCount: getCount
        }

        function getAll() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/balance', $rootScope.header);
        }

        function post(balance) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/balance', balance, $rootScope.header);
        }

        function put(balance) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/balance/' + balance.idBalance, balance, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/balance/' + id, $rootScope.header);
        }

        function remove(category) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/balance/' + balance.idBalance, $rootScope);
        }

        function getByRange(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/balance/getbyrange/' + filter.skip + '/' + filter.take + '/' + filter.status + '/' + filter.id, $rootScope.header)
        }

        function getCount(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/balance/getcount/' + filter.id + '/' + filter.word, $rootScope.header)
        }
    }

})();