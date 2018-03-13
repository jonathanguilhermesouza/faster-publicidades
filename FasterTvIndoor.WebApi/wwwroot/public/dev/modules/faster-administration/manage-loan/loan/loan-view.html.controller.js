(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ViewControlLoanCtrl', ViewControlLoanCtrl);

    ViewControlLoanCtrl.$inject = ['$filter', '$routeParams', 'EquipmentFactory', 'StatusControlLoanFactory', 'ControlLoanFactory', 'RedirectUserService'];

    function ViewControlLoanCtrl($filter, $routeParams, EquipmentFactory, StatusControlLoanFactory, ControlLoanFactory, RedirectUserService) {

        var vm = this;
        var id = $routeParams.id;
        var errors = false;//variável para identificar se tenho erro no formulário

        vm.equipments = [];
        vm.controlLoan = {
            idCompany: 0,
            idEquipment: 0,
            dateLocation: new Date(),
            dateEndLocation: new Date(),
            note: '',
            statusControlLoan: 0,
            equipment: {},
            company:{}
        };
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };

        vm.save = save;
        vm.showStatus = showStatus;
        vm.setEquipment = setEquipment;
        vm.setCompany = setCompany;

        activate();

        function activate() {
            getAllStatusControlLoan();
            getByIdControlLoan();
        }

        function setEquipment(equipment) {
            if (equipment != null) {
                vm.controlLoan.idEquipment = equipment.idEquipment;
                return equipment.serialNumber;
            } else {
                return vm.controlLoan.equipment.serialNumber;
            }
        }

        function setCompany(company) {
            console.log(company);
            if (company != null) {
                vm.controlLoan.idCompany = company.idCompany;
                return company.fantasyName;
            } else {
                return vm.controlLoan.company.fantasyName;
            }
        }

        function showStatus(loan) {
            var selected = [];
            var index = loan.statusControlLoan;
            if (loan.statusControlLoan) {
                selected = $filter('filter')(vm.statusControlLoan, { value: loan.statusControlLoan.name });
            }
            return selected.length ? selected[index - 1].name : 'Vazio';
        };

        function getAllStatusControlLoan() {
            StatusControlLoanFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.statusControlLoan = response;
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

        function getByIdControlLoan() {
            ControlLoanFactory.getById(id)
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.controlLoan = response;
                vm.controlLoan.dateLocation = new Date(response.dateLocation);
                vm.controlLoan.dateEndLocation = new Date(response.dateEndLocation);
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

        function cancel() {
            clearControlLoan();
        }

        function save() {
            ControlLoanFactory.put(vm.controlLoan)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Empréstimo alterado com sucesso', 'Atualização com sucesso');
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex();
                }
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao salvar dados!</strong>');
                    });
                }
                errors = true;
            }
        }

        function clearControlLoan() {
            vm.controlLoan = {
                idCompany: 0,
                idEquipment: 0,
                dateLocation: new Date(),
                dateEndLocation: new Date(),
                note: '',
                statusControlLoan: 0,
                equipment: {},
                company: {}
            };
        }
    };
})();