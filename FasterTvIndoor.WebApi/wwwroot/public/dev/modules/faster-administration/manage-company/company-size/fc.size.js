(function () {

    'use strict';

    angular.module('fasterAdministration').factory('SizeCompanyFactory', SizeCompanyFactory);

    SizeCompanyFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function SizeCompanyFactory($http, $rootScope, SETTINGS) {
        return {            
            getAll: getAll
        };

        function getAll() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/size-company', $rootScope.header)
        }
       
    };

})();