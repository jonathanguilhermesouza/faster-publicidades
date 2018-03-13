(function () {

    'use strict';

    angular.module('fasterAdministration').factory('SectorCompanyFactory', SectorCompanyFactory);

    SectorCompanyFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function SectorCompanyFactory($http, $rootScope, SETTINGS) {
        return {            
            getAll: getAll,
            getCount: getCount,
            post: post,
            put: put,
            getById: getById,
            getByRange: getByRange
        };
        
        function getAll() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/sector/', $rootScope.header)
        }

        function getByRange(skip) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/sector/range/' + skip + '', $rootScope.header)
        }

        function getCount() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/sector/count', $rootScope.header)
        }

        function post(sector) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/sector', sector, $rootScope.header);
        }

        function put(sector) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/sector/' + sector.idSectorCompany, sector, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/sector/' + id, $rootScope.header);
        }
    };

})();