(function () {
    'use strict'

    angular.module('faster').factory('EmployeeFactory', EmployeeFactory);

    EmployeeFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

    function EmployeeFactory($http, $rootScope, SETTINGS) {
        return {            
            post: post,
            getById: getById,
            getByEmail: getByEmail,
            getByRange: getByRange,
            getCount: getCount,
            put: put,
            remove: remove
        };
        
        function getEmployee() {
            return $http.get(SETTINGS.SERVICE_URL + 'api/employee/', $rootScope.header)
        }

        function getCount(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/employee/count/' + filter.status + '/' + filter.word, $rootScope.header)
        }

        function post(employee) {
            return $http.post(SETTINGS.SERVICE_URL + 'api/employee/', employee, $rootScope.header);
        }

        function getById(id) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/employee/' + id, $rootScope.header);
        }

        function getByEmail(email) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/employee/email/' + email +'/', $rootScope.header);
        }

        function getByRange(filter) {
            return $http.get(SETTINGS.SERVICE_URL + 'api/employee/range/' + filter.skip + '/' + filter.status + '/' + filter.word, $rootScope.header)
        }

        function put(employee) {
            return $http.put(SETTINGS.SERVICE_URL + 'api/employee/' + employee.idEmployeeCompany, employee, $rootScope.header);
        }

        function remove(employee) {
            return $http.delete(SETTINGS.SERVICE_URL + 'api/employee/' + employee.idEmployeeCompany, $rootScope.header);
        }
    };

})();