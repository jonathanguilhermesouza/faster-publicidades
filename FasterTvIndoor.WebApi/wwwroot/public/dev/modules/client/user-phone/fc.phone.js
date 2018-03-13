(function () {

    'use strict';

    angular.module('faster').factory('PhoneUserFactory', PhoneUserFactory);

    PhoneUserFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function PhoneUserFactory($http, $rootScope, SETTINGS) {
        return {            
            put: put,
            remove: remove,
            post:post
        };
        
        function put(phone) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/phone-user/' + phone.idPhoneUser, phone, $rootScope.header)
        }

        function post(phone) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/phone-user/', phone, $rootScope.header)
        }

        function remove(phone) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/phone-user/' + phone.idPhoneUser, $rootScope.header);
        }
    };

})();