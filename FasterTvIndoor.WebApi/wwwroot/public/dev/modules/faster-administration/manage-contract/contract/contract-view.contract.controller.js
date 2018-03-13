(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ViewContractCtrl', ViewContractCtrl);

    ViewContractCtrl.$inject = ['$filter', '$rootScope', '$routeParams', 'StatusContractFactory', 'ContractFactory', 'DayFactory', 'RedirectUserService'];

    function ViewContractCtrl($filter, $rootScope, $routeParams, StatusContractFactory, ContractFactory, DayFactory, RedirectUserService) {

        var vm = this;
        var id = $routeParams.id;
        var errors = false;//variável para identificar se tenho erro no formulário

        vm.statusContract = {};
        vm.contracts = [];
        vm.contract = {
            idContract: 0,
            idCompany: 0,
            dateStart: new Date(),
            dateEnd: new Date(),
            note: '',
            company: {}

        };
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.days = [];
        vm.filter = { skip: 0, word: null, status: 0 };

        activate();

        vm.save = save;
        vm.showStatusContract = showStatusContract;
        vm.showDayOfMonth = showDayOfMonth;

        function activate() {
            $rootScope.haveContract = true;
            getStatusContract();
            getContract();
            getAllDays();
        }

        function showStatusContract(contract) {
            var selected = [];
            var index = contract.statusContract;
            if (contract.statusContract) {
                selected = $filter('filter')(vm.statusContract, { value: contract.statusContract.name });
            }
            return selected.length ? selected[index - 1].name : 'Vazio';
        };

        function showDayOfMonth(contract) {
            var selected = [];
            var index = contract.idDayOfMonth;
            if (contract.idDayOfMonth) {
                selected = $filter('filter')(vm.days, { value: contract.dayOfMonth.dayOfMonth });
            }
            return selected.length ? selected[index - 1].day : 'Vazio';
        };

        function getStatusContract() {
            StatusContractFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.statusContract = response;
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex(error);
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

        function getContract() {
            ContractFactory.getById(id)
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.contract = response;
                vm.contract.dateStart = new Date(vm.contract.dateStart);
                vm.contract.dateEnd = new Date(vm.contract.dateEnd);
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex(error);
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

        function cancel() {
            clearContract();
        }

        function save() {
            ContractFactory.put(vm.contract)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Contrato alterado com sucesso', 'Atualização com sucesso');
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex(error);
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

        function clearContract() {
            vm.contract = {
                idContract: 0,
                idCompany: 0,
                dateStart: new Date(),
                dateEnd: new Date(),
                note: '',
                company: {}
            };
        }
    };
})();