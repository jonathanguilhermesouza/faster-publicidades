(function () {

    'use strict';

    angular.module('fasterAdministration').factory('MonthFactory', MonthFactory);

    MonthFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function MonthFactory($http, $rootScope, SETTINGS) {
        return {
            post: post,
            put: put,
            getAll: getAll,
            remove: remove,
            getById: getById,
            getByRange: getByRange,
            getCount: getCount
        };

        function getAll() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/month', $rootScope.header)
        }

        function getByRange(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/month/range/' + filter.skip + '/' + filter.status + '/' + filter.word, $rootScope.header)
        }

        function getCount(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/month/count/' + filter.status + '/' + filter.word, $rootScope.header)
        }

        function post(month) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/month/', month, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/month/' + id, $rootScope.header);
        }

        function put(month) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/month/' + month.idMonth, month, $rootScope.header);
        }

        function remove(month) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/month/' + month.idMonth, $rootScope.header);
        }

    };

})();