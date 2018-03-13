(function () {
    'use strict'

    angular.module('fasterAdministration').factory('CardFactory', CardFactory);

    CardFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function CardFactory($http, $rootScope, SETTINGS) {
        return {
            get: get,            
            post: post,
            remove: remove
        };

        function get() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/card/', $rootScope.header)
        }

        function post(card) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/card/', card, $rootScope.header);
        }

        function remove(card) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/card/' + card.idNumberCard, $rootScope.header);
        }


    };

})();