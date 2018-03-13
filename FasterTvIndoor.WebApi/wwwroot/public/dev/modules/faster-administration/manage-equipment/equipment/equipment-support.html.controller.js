(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ListEquipmentSupportCtrl', ListEquipmentSupportCtrl);

    ListEquipmentSupportCtrl.$inject = ['EquipmentFactory', 'RedirectUserService'];

    function ListEquipmentSupportCtrl(EquipmentFactory, RedirectUserService) {

        var vm = this;

        vm.equipment = {
            description: '',
            model: '',
            serialNumber: '',
            dateBuy: null,
            patrimony: '',
            idStatusEquipment: 0
        };
        vm.equipments = [];
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = { skip: 1, word: null, status: 3 };

        vm.range = range;
        vm.getEquipment = getEquipment;
        vm.removeEquipment = removeEquipment;
        vm.searchEquipment = searchEquipment;

        activate();

        function activate() {
            getEquipment(vm.filter.skip);
            getCountEquipment();
        }

        function searchEquipment() {
            if (vm.filter.word == '')
                vm.filter.word = null;

            getEquipment(vm.filter.skip);
            getCountEquipment();
        }

        function range(n) {
            return new Array(n);
        }

        function getCountEquipment() {
            EquipmentFactory.getCount(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.pagination.qtdPages = Math.ceil(response / vm.pagination.take);
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
            }
        }

        function getEquipment(skip) {
            vm.filter.skip = skip;
            EquipmentFactory.getByRange(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.equipments = response;
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
            }
        }

        function removeEquipment(equipment) {
            loadEquipment(equipment);
            EquipmentFactory.remove(vm.equipment)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Equipamento <strong>' + response.model + '</strong> removido com sucesso', 'Remoção com Sucesso');

                var index = vm.equipments.indexOf(equipment);
                vm.equipments.splice(index, 1);
                getCountEquipment();

                if (vm.filter.skip > 1 && vm.equipments.length == 0)
                    getEquipment(vm.filter.skip - 1);
                else
                    getEquipment(vm.filter.skip);
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex(error);
                }
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao remover dados!</strong>');
                    });
                }
            }

            //clearEquipment();
        }

        function loadEquipment(equipment) {
            vm.equipment = equipment;
        }

        function clearEquipment() {
            vm.equipment = {
                description: '',
                model: '',
                serialNumber: '',
                dateBuy: null,
                patrimony: '',
                idStatusEquipment: 0
            };
        }
        
    };

})();