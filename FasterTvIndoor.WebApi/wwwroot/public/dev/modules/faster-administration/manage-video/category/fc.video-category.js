(function () {

    'use strict';

    angular.module('fasterAdministration').factory('VideoCategoryFactory', VideoCategoryFactory);

    VideoCategoryFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function VideoCategoryFactory($http, $rootScope, SETTINGS) {
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
            return $http.get(SETTINGS.SERVICE_URL + 'api/category-video', $rootScope.header);
        }

        function post(category) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/category-video', category, $rootScope.header);
        }

        function put(category) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/category-video/' + category.idCategoryVideo, category, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/category-video/' + id, $rootScope.header);
        }

        function remove(category) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/category-video/' + category.idCategoryVideo, $rootScope);
        }

        function getByRange(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/category-video/range/' + filter.skip + '/' + filter.word, $rootScope.header)
        }

        function getCount(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/category-video/count/' + filter.word, $rootScope.header)
        }
    }

})();