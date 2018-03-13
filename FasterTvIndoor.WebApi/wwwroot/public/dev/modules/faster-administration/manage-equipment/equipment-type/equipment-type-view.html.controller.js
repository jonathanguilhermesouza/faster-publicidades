(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ViewTypeEquipmentCtrl', ViewTypeEquipmentCtrl);

    ViewTypeEquipmentCtrl.$inject = ['$routeParams', 'TypeEquipmentFactory', 'RedirectUserService'];

    function ViewTypeEquipmentCtrl($routeParams, TypeEquipmentFactory, RedirectUserService) {

        var vm = this;
        var id = $routeParams.id;
        var errors = false;//variável para identificar se tenho erro no formulário

        vm.typeEquipment = {
            type: ''
        };
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };

        vm.save = save;

        activate();

        function activate() {
            getCountTypeEquipment();
            getTypeEquipment();
        }

        function getCountTypeEquipment() {
            TypeEquipmentFactory.getCount()
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
                        toastr.warning(value.value, '<strong>Falha ao salvar dados!</strong>');
                    });
                }
            }
        }

        function getTypeEquipment() {
            TypeEquipmentFactory.getById(id)
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.typeEquipment = response;
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

        function cancel() {
            clearTypeEquipment();
        }

        function save() {
            TypeEquipmentFactory.put(vm.typeEquipment)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Tipo <strong>' + response.type + '</strong> alterado com sucesso', 'Atualização com sucesso');
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

        function clearTypeEquipment() {
            vm.typeEquipment = {
                type: ''
            };
        }

    };
})();