(function () {

    'use strict';

    angular.module('fasterClient').factory('VideoFactory', VideoFactory);

    VideoFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function VideoFactory($http, $rootScope, SETTINGS) {
        return {    
            getByRangeCompany: getByRangeCompany,
            getCountCompany: getCountCompany,
        };

        function getByRangeCompany(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/equipment-video/company/range/' + filter.skip + '/' + filter.id + '', $rootScope.header)
        }

        function getCountCompany(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/equipment-video/company/count/' + filter.id, $rootScope.header)
        }

    };

})();