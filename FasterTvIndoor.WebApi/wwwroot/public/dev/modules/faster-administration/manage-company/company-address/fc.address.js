(function () {

    'use strict';

    angular.module('fasterAdministration').factory('AddressCompanyFactory', AddressCompanyFactory);

    AddressCompanyFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function AddressCompanyFactory($http, $rootScope, SETTINGS) {
        return {            
            put: put,
            remove:remove
        };
        
        function put(address) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/address-company/' + address.idAddressCompany, address, $rootScope.header)
        }

        function remove(address) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/address-company/' + address.idAddressCompany, $rootScope.header);
        }
    };

})();