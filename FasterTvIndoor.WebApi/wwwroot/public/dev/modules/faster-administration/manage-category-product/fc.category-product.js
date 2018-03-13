(function () {

    'use strict';

    angular.module('fasterAdministration').factory('CategoryProductFactory', CategoryProductFactory);

	CategoryProductFactory.$inject = ['$http', '$rootScope', 'SETTINGS'];

	function CategoryProductFactory($http, $rootScope, SETTINGS) {
		return {
			getAll: getAll,
			post: post,
			put: put,
			remove: remove,
			getByRange: getByRange,
			getById: getById,
			getCount: getCount
		}

		function getAll(data) {
			return $http.get(SETTINGS.SERVICE_URL + 'api/category-product/', $rootScope.header);
		}

		function post(category) {
			return $http.post(SETTINGS.SERVICE_URL + 'api/category-product/', category, $rootScope.header);
		}

		function put(category) {
			return $http.put(SETTINGS.SERVICE_URL + 'api/category-product/' + category.idCategoryProduct, category, $rootScope.header);
		}

		function remove(category) {
			return $http.delete(SETTINGS.SERVICE_URL + 'api/category-product/' + category.idCategoryProduct, $rootScope.header);
		}

		function getByRange(filter) {
			return $http.get(SETTINGS.SERVICE_URL + 'api/category-product/range/' + filter.skip + '', $rootScope.header)
		}

		function getCount() {
			return $http.get(SETTINGS.SERVICE_URL + 'api/category-product/count', $rootScope.header)
		}

		function getById(id) {
			return $http.get(SETTINGS.SERVICE_URL + 'api/category-product/' + id, $rootScope.header);
		}
	}

})();