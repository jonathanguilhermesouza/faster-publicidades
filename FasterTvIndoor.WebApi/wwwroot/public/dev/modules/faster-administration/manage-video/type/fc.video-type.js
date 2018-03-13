(function () {

    'use strict';

    angular.module('fasterAdministration').factory('TypeVideoFactory', TypeVideoFactory);

    TypeVideoFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function TypeVideoFactory($http, $rootScope, SETTINGS) {
        return {
            getAll : getAll,
            post: post,
            put: put,
            remove: remove,
            getById: getById,           
            getByRange: getByRange,
            getCount: getCount
        };

        function getByRange(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/type-video/range/' + filter.skip +'/' + filter.word, $rootScope.header)
        }

        function getAll() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/type-video/', $rootScope.header)
        }

        function getCount(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/type-video/count/'+ filter.word, $rootScope.header)
        }

        function post(type) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/type-video/', type, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/type-video/' + id, $rootScope.header);
        }

        function put(type) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/type-video/' + type.idTypeVideo, type, $rootScope.header);
        }

        function remove(type) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/type-video/' + type.idTypeVideo, $rootScope.header);
        }
      
    };

})();