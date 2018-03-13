(function () {

    'use strict';

    angular.module('fasterAdministration').factory('YearFactory', YearFactory);

    YearFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function YearFactory($http, $rootScope, SETTINGS) {
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
            return $http.get(SETTINGS.SERVICE_URL + 'api/year', $rootScope.header)
        }

        function getByRange(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/year/range/' + filter.skip + '/' + filter.status + '/' + filter.word, $rootScope.header)
        }
        
        function getCount(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/year/count/' + filter.status + '/' + filter.word, $rootScope.header)
        }

        function post(loan) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/year/', loan, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/year/' + id, $rootScope.header);
        }

        function put(year) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/year/' + year.idYear, year, $rootScope.header);
        }

        function remove(year) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/year/' + year.idYear, $rootScope.header);
        }

    };

})();