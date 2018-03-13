(function () {

    'use strict';

    angular.module('fasterClient').factory('HistoryEquipmentFactory', HistoryEquipmentFactory);

	HistoryEquipmentFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

	function HistoryEquipmentFactory($http, $rootScope, SETTINGS) {
		return {
			getAll: getAll,
			post: post,
			put: put,
			remove: remove,
			getByRangeEquipment: getByRangeEquipment,
			getByRangeCompany: getByRangeCompany,
			getById: getById,
			getCount: getCount,
			getCountByCompany: getCountByCompany
		}

		function getAll(data) {
		    return $http.get(SETTINGS.SERVICE_URL + 'api/historyequipment/', $rootScope.header);
		}

		function post(history) {
		    return $http.post(SETTINGS.SERVICE_URL + 'api/historyequipment/', history, $rootScope.header);
		}

		function put(history) {
		    return $http.put(SETTINGS.SERVICE_URL + 'api/historyequipment/' + history.idHistoryEquipment, history, $rootScope.header);
		}

		function remove(history) {
		    return $http.delete(SETTINGS.SERVICE_URL + 'api/historyequipment/' + history.idHistoryEquipment, $rootScope.header);
		}

		function getByRangeEquipment(filter) {
		    return $http.get(SETTINGS.SERVICE_URL + 'api/historyequipment/range/' + filter.skip + '/' + filter.take + '/' + filter.id, $rootScope.header)
		}

		function getByRangeCompany(filter) {
		    return $http.get(SETTINGS.SERVICE_URL + 'api/historyequipment/company/range/' + filter.skip + '/' + filter.take + '/' + filter.id, $rootScope.header)
		}

		function getCount(filter) {
		    return $http.get(SETTINGS.SERVICE_URL + 'api/historyequipment/count/' + filter.id, $rootScope.header)
		}

		function getCountByCompany(filter) {
		    return $http.get(SETTINGS.SERVICE_URL + 'api/historyequipment/company/count/' + filter.id, $rootScope.header)
		}

		function getById(id) {
		    return $http.get(SETTINGS.SERVICE_URL + 'api/historyequipment/' + id, $rootScope.header);
		}
	}

})();