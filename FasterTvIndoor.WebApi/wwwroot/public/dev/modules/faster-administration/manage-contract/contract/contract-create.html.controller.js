(function () {

    'use strict';

    angular.module('fasterAdministration').controller('CreateContractCtrl', CreateContractCtrl);

    CreateContractCtrl.$inject = ['$location', '$rootScope', 'ContractFactory', 'DayFactory', 'RedirectUserService'];

    function CreateContractCtrl($location, $rootScope, ContractFactory, DayFactory, RedirectUserService) {

        var vm = this;
        var erros = false;

        vm.errors = [];
        vm.contracts = [];
        vm.contract = {
            idContract: 0,
            idCompany: 0,
            idDayOfMonth: 0,
            dateStart: new Date(),
            dateEnd: new Date(),
            note: '',
            company: {}
        };
        vm.company = [];
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.days = [];

        activate();

        vm.clearError = clearError;
        vm.save = save;
        vm.setCompany = setCompany;
        vm.cancel = cancel;

        function activate() {
            $rootScope.haveContract = true;
            getAllDays();
        }

        function range(n) {
            return new Array(n);
        }

        function setCompany(company) {
            if (company != null) {
                vm.contract.idCompany = company.idCompany;
                vm.contract.company.companyName = company.companyName;
                return vm.contract.company.companyName;
            } else {
                return vm.contract.company.companyName;
            }
        }

        function save() {
            ContractFactory.post(vm.contract)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('Contrato cadastrado com sucesso', 'Contrato Cadastrado');
                $location.path('/contract-current');
                $rootScope.clearCompany();
            }

            function fail(error) {
                $rootScope.clearCompany();
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex(error);
                }
                else {
                    vm.errors = angular.fromJson(error.data.errors);
                    angular.forEach(vm.errors, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao recuperar dados!</strong>');
                    });
                }
                errors = true;
            }
        }

        function cancel() {
            $rootScope.filterCompany.status = 0;
            clearContract();
            $location.path('/contract-current/');
        }

        function clearError(error) {
            var index = vm.errors.indexOf(error);
            vm.errors.splice(index, 1);
        }

        function clearContract() {
            vm.contract = {
                idContract: 0,
                idCompany: 0,
                idDayOfMonth: 0,
                dateStart: new Date(),
                dateEnd: new Date(),
                note: '',
                company: {}
            };
        }

        function getAllDays() {
            DayFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.days = response;
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex();
                }
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao recuperar dados!</strong>');
                    });
                }
                errors = true;
            }
        }
    }
})();