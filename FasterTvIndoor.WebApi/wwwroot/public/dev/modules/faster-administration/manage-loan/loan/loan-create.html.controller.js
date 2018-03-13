(function () {

    'use strict'

    angular.module('fasterAdministration').controller('CreateLoanCtrl', CreateLoanCtrl);

    CreateLoanCtrl.$inject = ['$rootScope', '$location', 'EquipmentFactory', 'ControlLoanFactory', 'RedirectUserService'];

    function CreateLoanCtrl($rootScope, $location, EquipmentFactory, ControlLoanFactory,RedirectUserService) {

        var vm = this;
        var errors = false;//variável para identificar se tenho erro no formulário

        var companyLoan = null;
        var equipmentLoan = null;
        vm.errors = [];
        vm.modelEquipment = '';
        vm.equipments = [];
        vm.loan = {
            idCompany: 0,
            idEquipment: 0,
            dateLocation: new Date(),
            dateEndLocation: new Date(),
            note: '',
            statusControlLoan: 0,
            equipment: {},
            company: {}
        };
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = { skip: 0, word: null, status: 1 };

        vm.clearError = clearError;
        vm.range = range;
        vm.save = save;
        vm.cancel = cancel;
        vm.setEquipment = setEquipment;
        vm.setCompany = setCompany;

        activate();

        function activate() {
            $rootScope.haveContract = false;
        }

        function range(n) {
            return new Array(n);
        }

        function setEquipment(equipment) {
            equipmentLoan = equipment;
            if (equipment != null) {
                vm.loan.idEquipment = equipment.idEquipment;
                vm.loan.equipment.serialNumber = equipment.serialNumber;
                return vm.loan.equipment.serialNumber;
            } else {
                return vm.loan.equipment.serialNumber;
            }
        }

        function setCompany(company) {
            companyLoan = company;
            if (company != null) {
                vm.loan.idCompany = company.idCompany;
                vm.loan.company.fantasyName = company.fantasyName;
                return vm.loan.company.fantasyName;
            } else {
                return vm.loan.company.fantasyName;
            }
        }


        function save() {
            ControlLoanFactory.post(vm.loan)
                .success(success)
                .catch(fail);

            function success(response) {
                clearLoan();
                toastr.success('Empréstimo cadastrado com sucesso', 'Equipamento Cadastrado');
                $location.path('/loan/view/' + response.idControlLoan);
            }

            function fail(error) {
                clearLoan();
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
            clearLoan();
            $location.path('/loan/open');
        }

        function clearError(error) {
            var index = vm.errors.indexOf(error);
            vm.errors.splice(index, 1);
        }

        function clearLoan() {
            if (companyLoan = ! null && equipmentLoan != null) {
                $rootScope.clearEquipment();
                $rootScope.clearCompany();
                
            }
            vm.loan = {
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