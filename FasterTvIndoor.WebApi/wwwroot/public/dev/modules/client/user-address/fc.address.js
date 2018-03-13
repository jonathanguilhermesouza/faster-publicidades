(function () {

    'use strict';

    angular.module('faster').factory('AddressUserFactory', AddressUserFactory);

    AddressUserFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function AddressUserFactory($http, $rootScope, SETTINGS) {
        return {            
            put: put,
            post:post,
            remove:remove
        };
        
        function post(address) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/address-user/', address, $rootScope.header)
        }

        function put(address) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/address-user/' + address.idAddressUser, address, $rootScope.header)
        }

        function remove(address) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/address-user/' + address.idAddressUser, $rootScope.header);
        }
    };

})();