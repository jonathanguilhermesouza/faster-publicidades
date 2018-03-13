(function () {

    'use strict';

    angular.module('faster').factory('UserFactory', UserFactory);

    UserFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function UserFactory($http, $rootScope, SETTINGS) {
        return {            
            post: post,
            getById: getById,
            getByEmail: getByEmail,
            getByRange: getByRange,
            getCount: getCount,
            put:put
        };
        
        function getUser() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/user/', $rootScope.header)
        }

        function getCount(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/user/count/' + id, $rootScope.header)
        }

        function post(user) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/user/', user, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/user/' + id, $rootScope.header);
        }

        function getByEmail(email) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/user/email/' + email +'/', $rootScope.header);
        }

        function getByRange(skip,id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/user/range/' + skip + '/' + id + '', $rootScope.header)
        }

        function put(user) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/user/' + user.idUser, user, $rootScope.header);
        }
    };

})();