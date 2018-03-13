(function () {

    'use strict';

    angular.module('fasterAdministration').factory('StatusEquipmentFactory', StatusEquipmentFactory);

    StatusEquipmentFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function StatusEquipmentFactory($http, $rootScope, SETTINGS) {
        return {            
            getAll: getAll
        };

        function getAll() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/status-equipment', $rootScope.header)
        }
       
    };

})();