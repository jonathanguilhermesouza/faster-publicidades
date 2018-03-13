(function () {

    'use strict';

    angular.module('fasterAdministration').factory('VideoEquipmentFactory', VideoEquipmentFactory);

    VideoEquipmentFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function VideoEquipmentFactory($http, $rootScope, SETTINGS) {
        return {
            get: get,
            post: post,
            put: put,
            remove: remove,
            getByIdEquipment: getByIdEquipment,
            getByRange: getByRange,
            getCount: getCount,
            getIdVideoEquipment: getIdVideoEquipment
        };

        function get(data) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/equipment-video/', $rootScope.header)
        }

        function getIdVideoEquipment(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/equipment-video/id/' + filter.equipment + '/' + filter.video, $rootScope.header)
        }

        function getByRange(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/equipment-video/range/' + filter.skip + '/' + filter.word + '', $rootScope.header)
        }

        function getByRangeCompany(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/equipment-video/company/range/' + filter.skip + '/' + filter.id + '', $rootScope.header)
        }

        function getCount(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/equipment-video/count/' + filter.word, $rootScope.header)
        }

        function getCountByCompany(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/equipment-video/company/count/' + filter.id, $rootScope.header)
        }

        function post(videoEquipment) {
            console.log(videoEquipment);
            return $http.post(SETTINGS.SERVICE_URL + 'api/equipment-video/', videoEquipment, $rootScope.header);
        }

        function getByIdEquipment(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/equipment-video/equipment/' + id, $rootScope.header);
        }

        function put(videoEquipment) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/equipment-video/' + videoEquipment.idVideoEquipment, videoEquipment, $rootScope.header);
        }

        function remove(filter) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/equipment-video/' + filter.equipment + '/' + filter.video + '/' + filter.controlLoan, $rootScope.header);
        }
      
    };

})();