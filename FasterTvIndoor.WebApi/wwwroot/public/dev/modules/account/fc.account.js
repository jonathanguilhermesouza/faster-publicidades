(function () {
    'use strict'
    angular.module('faster').factory('AccountFactory', AccountFactory);

    AccountFactory.$inject = ['$rootScope', '$http', 'SETTINGS'];

    function AccountFactory($rootScope, $http, SETTINGS) {
        return {
            login: login,
            register: register,
            post: post,
            getById: getById,
            getByEmail: getByEmail,
            getByRange: getByRange,
            getCount: getCount,
            put: put
        };

        function login(data) {
            var dt = "grant_type=password&username=" + data.username + "&password=" + data.password;
            var url = SETTINGS.SERVICE_URL + 'api/security/token';
            var header = { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } };

            return $http.post(url, dt, header);
        }

        function register(user) {          
            return $http.post(SETTINGS.SERVICE_URL + 'api/user/', user, $rootScope.header)            
        }

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
            return $http.get(SETTINGS.SERVICE_URL + 'api/user/email/' + email + '/', $rootScope.header);
        }

        function getByRange(skip, id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/user/range/' + skip + '/' + id + '', $rootScope.header)
        }

        function put(user) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/user/' + user.idUser, user, $rootScope.header);
        }
    };
})();