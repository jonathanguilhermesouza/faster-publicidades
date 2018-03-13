(function () {

    'use strict';

    angular.module('fasterAdministration').factory('CompanyFactory', CompanyFactory);

    CompanyFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function CompanyFactory($http, $rootScope, SETTINGS) {
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
            return $http.get(SETTINGS.SERVICE_URL + 'api/company/', $rootScope.header)
        }

        function getByRange(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/company/range/' + filter.skip + '/' + filter.status + '/' + filter.word + '', $rootScope.header)
        }

        function getCount(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/company/count/' + filter.status + '/'+ filter.word, $rootScope.header)
        }

        function post(company) {            
            return $http.post(SETTINGS.SERVICE_URL + 'api/company/', company, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/company/' + id, $rootScope.header);
        }

        function put(company) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/company/' + company.idCompany, company, $rootScope.header);
        }

        function remove(company) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/company/' + company.idCompany, $rootScope.header);
        }
      
    };

})();