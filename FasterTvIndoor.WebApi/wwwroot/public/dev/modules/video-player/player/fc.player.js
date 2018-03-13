(function () {

    'use strict';

    angular.module('fasterVideoPlayer').factory('PlayerFactory', PlayerFactory);

    PlayerFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function PlayerFactory($http, $rootScope, SETTINGS) {
        return {            
            getAll: getAll
        };
        
        function getAll() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/video/', $rootScope.header)
        }
    };

})();