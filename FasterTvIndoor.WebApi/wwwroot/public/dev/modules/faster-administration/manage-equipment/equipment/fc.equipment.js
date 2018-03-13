(function () {

    'use strict';

    angular.module('fasterAdministration').factory('EquipmentFactory', EquipmentFactory);

    EquipmentFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function EquipmentFactory($http, $rootScope, SETTINGS) {
        return {            
            post: post,
            put: put,
            remove: remove,
            getById: getById,           
            getByRange: getByRange,
            getCount: getCount
        };

        function getByRange(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/equipment/range/' + filter.skip + '/' + filter.status + '/' + filter.word + '', $rootScope.header)
        }

        function getCount(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/equipment/count/' + filter.status + '/' + filter.word + '', $rootScope.header)
        }

        function post(equipment) {            
            return $http.post(SETTINGS.SERVICE_URL + 'api/equipment/', equipment, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/equipment/' + id, $rootScope.header);
        }

        function put(equipment) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/equipment/' + equipment.idEquipment, equipment, $rootScope.header);
        }

        function remove(equipment) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/equipment/' + equipment.idEquipment, $rootScope.header);
        }
      
    };

})();