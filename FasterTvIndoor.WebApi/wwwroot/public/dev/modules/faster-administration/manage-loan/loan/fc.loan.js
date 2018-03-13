(function () {

    'use strict';

    angular.module('fasterAdministration').factory('ControlLoanFactory', ControlLoanFactory);

    ControlLoanFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function ControlLoanFactory($http, $rootScope, SETTINGS) {
        return {
            post: post,
            put: put,
            remove: remove,
            getById: getById,
            getByRange: getByRange,
            getCount: getCount,
            getAllControlLoanEquipment: getAllControlLoanEquipment,
            getAllControlLoanEquipmentByVideo: getAllControlLoanEquipmentByVideo
        };

        function getByRange(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/loan/range/' + filter.skip + '/' + filter.status + '/' + filter.word, $rootScope.header)
        }
        
        function getAllControlLoanEquipmentByVideo(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/loan-equipment/' + filter.status + '/' + filter.video + '/' + filter.word, $rootScope.header)
        }

        function getAllControlLoanEquipment(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/loan-equipment/' + filter.status + '/' + filter.word, $rootScope.header)
        }

        function getCount(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/loan/count/' + filter.status + '/' + filter.word, $rootScope.header)
        }

        function post(loan) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/loan/', loan, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/loan/' + id, $rootScope.header);
        }

        function put(loan) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/loan/' + loan.idControlLoan, loan, $rootScope.header);
        }

        function remove(loan) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/loan/' + loan.idControlLoan, $rootScope.header);
        }

    };

})();