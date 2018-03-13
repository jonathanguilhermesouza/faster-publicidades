(function () {

    'use strict';

    angular.module('fasterClient').factory('PaymentByCompanyFactory', PaymentByCompanyFactory);

	PaymentByCompanyFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

	function PaymentByCompanyFactory($http, $rootScope, SETTINGS) {
		return {
		    getByRangeCompany: getByRangeCompany,
		    getCountByCompany: getCountByCompany,
		    getByRangeCompanyComplement: getByRangeCompanyComplement
		}

		function getByRangeCompany(filter) {
		    return $http.get(SETTINGS.SERVICE_URL + 'api/payment/range/company/' + filter.skip + '/' + filter.id, $rootScope.header)
		}

		function getCountByCompany(filter) {
		    return $http.get(SETTINGS.SERVICE_URL + 'api/payment/count/company/' + filter.id, $rootScope.header)
		}

		function getByRangeCompanyComplement(filter) {
		    return $http.get(SETTINGS.SERVICE_URL + 'api/paymentcomplement/range/company/' + filter.skip +'/' + filter.id,  $rootScope.header)
		}

	}

})();