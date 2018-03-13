(function () {

    'use strict';

    angular.module('fasterAdministration').factory('TimeVideoFactory', TimeVideoFactory);

    TimeVideoFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function TimeVideoFactory($http, $rootScope, SETTINGS) {
        return {            
            getAll: getAll,
            post: post,
            getById: getById,
            put: put,
            remove: remove,
            getByRange: getByRange,
            getCount: getCount
        };

        function getAll() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/time-video', $rootScope.header)
        }

        function post(timeVideo) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/time-video', timeVideo, $rootScope.header);
        }

        function put(timeVideo) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/time-video/' + timeVideo.idTimeVideo, timeVideo, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/time-video/' + id, $rootScope.header);
        }

        function remove(timeVideo) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/time-video/' + timeVideo.idTimeVideo, $rootScope);
        }

        function getByRange(filter) {
            console.log(filter);
            return $http.get(SETTINGS.SERVICE_URL + 'api/time-video/range/' + filter.skip, $rootScope.header)
        }

        function getCount() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/time-video/count/', $rootScope.header)
        }
       
    };

})();