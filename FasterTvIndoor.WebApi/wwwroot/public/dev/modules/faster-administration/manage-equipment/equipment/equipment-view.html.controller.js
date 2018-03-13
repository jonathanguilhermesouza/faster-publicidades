(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ViewEquipmentCtrl', ViewEquipmentCtrl);

    ViewEquipmentCtrl.$inject = ['$filter', '$routeParams', 'TypeEquipmentFactory', 'EquipmentFactory', 'StatusEquipmentFactory', 'RedirectUserService'];

    function ViewEquipmentCtrl($filter, $routeParams, TypeEquipmentFactory, EquipmentFactory, StatusEquipmentFactory, RedirectUserService) {

        var vm = this;
        var id = $routeParams.id;
        var errors = false;//variável para identificar se tenho erro no formulário

        vm.equipment = {
            idTypeEquipment: 0,
            description: '',
            model: '',
            serialNumber: '',
            dateBuy: new Date(),
            patrimony: '',
            statusEquipment: 0
        };
        vm.statusEquipment = [{
            id: 0,
            name: ''
        }];
        vm.typesEquipment = [];


        vm.save = save;
        vm.showStatus = showStatus;
        vm.showTypes = showTypes;

        activate();

        function activate() {
            getStatusEquipment();
            getTypesEquipment();
            getByIdEquipment();
        }

        function showStatus(equipment) {
            var selected = [];
            var index = equipment.statusEquipment;
            if (equipment.statusEquipment) {
                selected = $filter('filter')(vm.statusEquipment, { value: equipment.statusEquipment.name });
            }
            return selected.length ? selected[index - 1].name : 'Vazio';
        };

        function showTypes(equipment) {
            var selected = [];
            var index = equipment.idTypeEquipment;
            if (equipment.idTypeEquipment) {
                selected = $filter('filter')(vm.typesEquipment, { value: equipment.type });
            }
            return selected.length ? selected[index - 1].type : 'Vazio';
        };

        function getTypesEquipment() {
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

        function getStatusEquipment() {
            StatusEquipmentFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.statusEquipment = response;
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

        function getByIdEquipment() {
            EquipmentFactory.getById(id)
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.equipment = response;
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
            clearEquipment();
        }

        function save() {
            EquipmentFactory.put(vm.equipment)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Equipamento <strong>' + response.model + '</strong> alterado com sucesso', 'Atualização com sucesso');
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex(error);
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

        function clearEquipment() {
            vm.equipment = {
                idTypeEquipment: 0,
                description: '',
                model: '',
                serialNumber: 0,
                dateBuy: new Date(),
                patrimony: '',
                statusEquipment: 0
            };
        }
    };
})();