(function () {

    'use strict';

    angular.module('fasterAdministration').controller('CreateCategoryCtrl', CreateCategoryCtrl);

	CreateCategoryCtrl.$inject = ['$rootScope', '$location', 'CategoryProductFactory', 'RedirectUserService'];

	function CreateCategoryCtrl($rootScope, $location, CategoryProductFactory, RedirectUserService)
	{
	    var vm = this;

	    var errors = false;

	    vm.errors = [];
		vm.categories = [];
		vm.category = {
			category :''
		};

		vm.save = save;
		vm.cancel = cancel;
		vm.clearError = clearError;

		activate();
		
		function activate(){
		    getAllCategoryProduct();
		}

		function getAllCategoryProduct() {
			CategoryProductFactory.getAll()
				.success(success)
				.catch(fail);
			
			function success(response)
			{
			    vm.categories = response;			    
			}
			function fail (error)
			{
			    if (error.status == 401) {
			        RedirectUserService.redirectToIndex();
			    }
			    else {
			        var items = angular.fromJson(error.data.errors);
			        angular.forEach(items, function (value, key) {
			            toastr.warning(value.value, '<strong>Falha ao recuperar dados!</strong>');
			        });
			    }
			}
		}

		function save() {
			CategoryProductFactory.post(vm.category)
				.success(success)
				.catch(fail);

			function success(response) {
				toastr.success('Categoria <strong>' + vm.category.category + '</strong> cadastrada com sucesso', 'Categoria Cadastrada');
				$location.path('/category');
			}
			function fail(error) {
			    if (error.status == 401) {
			        RedirectUserService.redirectToIndex();
			    }
			    else {
			        vm.errors = angular.fromJson(error.data.errors);
			        angular.forEach(vm.errors, function (value, key) {
			            toastr.warning(value.value, '<strong>Falha ao salvar dados!</strong>');
			        });
			    }
			    errors = true;
			}

		}

		function cancel() {
		    clearCategory();
		    $location.path('/category');
		}

		function clearError(error) {
		    var index = vm.errors.indexOf(error);
		    vm.errors.splice(index, 1);
		}

		function clearCategory() {
		    vm.category = {
		        id: 0,
                category: ''
		    }
		}
	}
})();