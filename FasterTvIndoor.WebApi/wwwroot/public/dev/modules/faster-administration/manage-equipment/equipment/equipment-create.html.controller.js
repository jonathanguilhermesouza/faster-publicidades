(function () {

    'use strict';

    angular.module('fasterAdministration').controller('CreateEquipmentCtrl', CreateEquipmentCtrl);

    CreateEquipmentCtrl.$inject = ['$location', 'EquipmentFactory', 'TypeEquipmentFactory', 'RedirectUserService'];

    function CreateEquipmentCtrl($location, EquipmentFactory, TypeEquipmentFactory, RedirectUserService) {

        var vm = this;
        var errors = false;//variável para identificar se tenho erro no formulário

        vm.errors = [];
        vm.typesEquipment = [];
        vm.equipment = {
            idTypeEquipment:0,
            description: '',
            model: '',
            serialNumber: '',
            dateBuy: new Date(),
            patrimony: ''
        };

        vm.save = save;
        vm.cancel = cancel;
        vm.clearError = clearError;

        activate();

        function activate() {
            getAllTypesEquipment();
        }

        function getAllTypesEquipment() {
            TypeEquipmentFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.typesEquipment = response;
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

        function save() {
            EquipmentFactory.post(vm.equipment)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('Equipamento <strong>' + response.model + '</strong> cadastrado com sucesso', 'Equipamento Cadastrado');
                $location.path('/equipment/view/' + response.idEquipment);                
            }

            function fail(error) {
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
            clearEquipment();
            $location.path('/equipment/available');
        }

        function clearError(error) {
            var index = vm.errors.indexOf(error);
            vm.errors.splice(index, 1);
        }

        function clearEquipment() {
            vm.equipment = {
                idTypeEquipment: 0,
                description: '',
                model: '',
                serialNumber: '',
                dateBuy: new Date(),
                patrimony: ''
            };
        }
    };
})();