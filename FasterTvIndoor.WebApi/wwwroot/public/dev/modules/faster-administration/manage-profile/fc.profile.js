(function () {

    'use strict';

    angular.module('fasterAdministration').factory('ProfileUserFactory', ProfileUserFactory);

    ProfileUserFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function ProfileUserFactory($http, $rootScope, SETTINGS) {
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
            return $http.get(SETTINGS.SERVICE_URL + 'api/profile', $rootScope.header);
        }

        function post(profile) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/profile', profile, $rootScope.header);
        }

        function put(profile) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/profile/' + profile.idProfileUser, profile, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/profile/' + id, $rootScope.header);
        }

        function remove(profile) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/profile/' + profile.idProfileUser, $rootScope);
        }

        function getByRange(filter) {
            console.log(filter);
            return $http.get(SETTINGS.SERVICE_URL + 'api/profile/range/' + filter.skip + '', $rootScope.header)
        }

        function getCount() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/profile/count', $rootScope.header)
        }
    }

})();