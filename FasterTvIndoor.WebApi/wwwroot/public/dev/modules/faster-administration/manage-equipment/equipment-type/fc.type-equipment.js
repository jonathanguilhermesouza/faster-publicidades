(function () {

    'use strict';

    angular.module('fasterAdministration').factory('TypeEquipmentFactory', TypeEquipmentFactory);

    TypeEquipmentFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function TypeEquipmentFactory($http, $rootScope, SETTINGS) {
        return {
            getAll : getAll,
            post: post,
            put: put,
            remove: remove,
            getById: getById,           
            getByRange: getByRange,
            getCount: getCount
        };

        function getByRange(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/type-equipment/range/' + filter.skip, $rootScope.header)
        }

        function getAll() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/type-equipment/', $rootScope.header)
        }

        function getCount() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/type-equipment/count/', $rootScope.header)
        }

        function post(type) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/type-equipment/', type, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/type-equipment/' + id, $rootScope.header);
        }

        function put(type) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/type-equipment/' + type.idTypeEquipment, type, $rootScope.header);
        }

        function remove(type) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/type-equipment/' + type.idTypeEquipment, $rootScope.header);
        }
      
    };

})();