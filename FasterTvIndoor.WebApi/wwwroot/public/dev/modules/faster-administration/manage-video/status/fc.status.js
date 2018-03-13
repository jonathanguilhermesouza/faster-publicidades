(function () {

    'use strict';

    angular.module('fasterAdministration').factory('StatusVideoFactory', StatusVideoFactory);

    StatusVideoFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function StatusVideoFactory($http, $rootScope, SETTINGS) {
        return {            
            getAll: getAll
        };

        function getAll() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/status-video', $rootScope.header)
        }
       
    };

})();