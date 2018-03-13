(function () {

    'use strict';

    angular.module('fasterAdministration').factory('VideoFactory', VideoFactory);

    VideoFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function VideoFactory($http, $rootScope, SETTINGS) {
        return {
            get: get,
            post: post,
            put: put,
            remove: remove,
            getById: getById,           
            getByRange: getByRange,
            getCount: getCount,            
        };

        function get(data) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/video/', $rootScope.header)
        }

        function getByRange(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/video/range/' + filter.skip + '/' + filter.status + '/' + filter.word + '', $rootScope.header)
        }

        function getCount(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/video/count/' + filter.status + '/' + filter.word, $rootScope.header)
        }

        function post(video) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/video/', video, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/video/' + id, $rootScope.header);
        }

        function put(video) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/video/' + video.idVideo, video, $rootScope.header);
        }

        function remove(video) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/video/' + video.idVideo, $rootScope.header);
        }
      
    };

})();