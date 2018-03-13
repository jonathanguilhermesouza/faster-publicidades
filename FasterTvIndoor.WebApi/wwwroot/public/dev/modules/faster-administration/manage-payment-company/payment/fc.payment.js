(function () {

    'use strict';

    angular.module('fasterAdministration').factory('PaymentFactory', PaymentFactory);

	PaymentFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

	function PaymentFactory($http, $rootScope, SETTINGS) {
		return {
			getAll: getAll,
			post: post,
			put: put,
			remove: remove,
			getByRange: getByRange,
			getById: getById,
			getByIdCompany: getByIdCompany,
			getCount: getCount
		}

		function getAll(data) {
			return $http.get(SETTINGS.SERVICE_URL + 'api/payment/', $rootScope.header);
		}

		function post(payment) {
		    return $http.post(SETTINGS.SERVICE_URL + 'api/payment/', payment, $rootScope.header);
		}

		function put(payment) {
		    return $http.put(SETTINGS.SERVICE_URL + 'api/payment/' + payment.idPaymentToCompany, payment, $rootScope.header);
		}

		function remove(payment) {
		    return $http.delete(SETTINGS.SERVICE_URL + 'api/payment/' + payment.idPaymentToCompany, $rootScope.header);
		}

		function getByRange(filter) {
		    return $http.get(SETTINGS.SERVICE_URL + 'api/payment/range/' + filter.skip + '/' + filter.word, $rootScope.header)
		}

		function getCount(filter) {
		    return $http.get(SETTINGS.SERVICE_URL + 'api/payment/count/' + filter.word, $rootScope.header)
		}

		function getById(id) {
		    return $http.get(SETTINGS.SERVICE_URL + 'api/payment/' + id, $rootScope.header);
		}

		function getByIdCompany(id) {
		    return $http.get(SETTINGS.SERVICE_URL + 'api/payment/' + id, $rootScope.header);
		}
	}

})();