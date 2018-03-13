(function () {

    'use strict';

    angular.module('fasterAdministration').factory('PlanFactory', PlanFactory);

    PlanFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function PlanFactory($http, $rootScope, SETTINGS) {
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
            return $http.get(SETTINGS.SERVICE_URL + 'api/plan', $rootScope.header);
        }

        function post(plan) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/plan', plan, $rootScope.header);
        }

        function put(plan) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/plan/' + plan.idPlan, plan, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/plan/' + id, $rootScope.header);
        }

        function remove(category) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/plan/' + category.idPlan, $rootScope);
        }

        function getByRange(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/plan/range/' + filter.skip + '/' + filter.word, $rootScope.header)
        }

        function getCount(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/plan/count/' + filter.word, $rootScope.header)
        }
    }

})();