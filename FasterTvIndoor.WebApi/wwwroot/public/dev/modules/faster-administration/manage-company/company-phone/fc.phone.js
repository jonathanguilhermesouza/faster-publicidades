(function () {

    'use strict';

    angular.module('fasterAdministration').factory('PhoneCompanyFactory', PhoneCompanyFactory);

    PhoneCompanyFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function PhoneCompanyFactory($http, $rootScope, SETTINGS) {
        return {            
            put: put,
            remove: remove,
            post:post
        };
        
        function put(phone) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/company-phone/' + phone.idPhoneCompany, phone, $rootScope.header)
        }

        function post(phone) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/company-phone/', phone, $rootScope.header)
        }

        function remove(phone) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/company-phone/' + phone.idPhoneCompany, $rootScope.header);
        }
    };

})();