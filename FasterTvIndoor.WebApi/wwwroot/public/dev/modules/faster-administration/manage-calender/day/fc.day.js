(function () {

    'use strict';

    angular.module('fasterAdministration').factory('DayFactory', DayFactory);

    DayFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function DayFactory($http, $rootScope, SETTINGS) {
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
            return $http.get(SETTINGS.SERVICE_URL + 'api/dayofmonth', $rootScope.header)
        }

        function getByRange(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/dayofmonth/range/' + filter.skip + '/' + filter.status + '/' + filter.word, $rootScope.header)
        }

        function getCount(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/dayofmonth/count/' + filter.status + '/' + filter.word, $rootScope.header)
        }

        function post(day) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/dayofmonth/', day, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/dayofmonth/' + id, $rootScope.header);
        }

        function put(day) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/dayofmonth/' + day.idDayOfMonth, day, $rootScope.header);
        }

        function remove(day) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/dayofmonth/' + day.idDayOfMonth, $rootScope.header);
        }

    };

})();