(function () {

    'use strict';

	angular.module('fasterAdministration').controller('CreateSectorCompanyCtrl', CreateSectorCompanyCtrl);

	CreateSectorCompanyCtrl.$inject = ['$location', 'SectorCompanyFactory', 'RedirectUserService'];

	function CreateSectorCompanyCtrl($location, SectorCompanyFactory, RedirectUserService) {

	    var vm = this;
	    var errors = false;

	    vm.errors = [];
		vm.sectorCompany = {
			sector: ''
		};

		vm.save = save;
		vm.cancel = cancel;
		vm.clearError = clearError;

		activate();
		
		function activate(){
		}
        		
		function save() {
			SectorCompanyFactory.post(vm.sectorCompany)
				.success(success)
				.catch(fail);

			function success(response) {
				toastr.success('Setor <strong>' + vm.sectorCompany.sector + '</strong> cadastrada com sucesso', 'Categoria Cadastrada');
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
		    clearSectorCompany();
		    $location.path('/sector');
		}


		function clearError(error) {
		    var index = vm.errors.indexOf(error);
		    vm.errors.splice(index, 1);
		}

		function clearCategory() {
		    vm.sectorCompany = {
		        idSectorCompany: 0,
                sector: ''
		    }
		}
	}
})();