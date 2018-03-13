(function () {

    'use strict';

    angular.module('fasterAdministration').controller('CreateTypeEquipmentCtrl', CreateTypeEquipmentCtrl);

    CreateTypeEquipmentCtrl.$inject = ['$rootScope', '$location', 'TypeEquipmentFactory', 'RedirectUserService'];

    function CreateTypeEquipmentCtrl($rootScope, $location, TypeEquipmentFactory, RedirectUserService) {

        var vm = this;
        var errors = false;//variável para identificar se tenho erro no formulário

        vm.errors = [];
        vm.typeEquipment = {
            idTypeEquipment: 0,
            type: ''
        };

        vm.save = save;
        vm.cancel = cancel;
        vm.clearError = clearError;

        activate();

        function activate() {
        }        

        function save() {
            TypeEquipmentFactory.post(vm.typeEquipment)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('Tipo de Equipamento <strong>' + response.type + '</strong> cadastrado com sucesso', 'Tipo Cadastrado');
                $location.path('/type-equipment/view/' + response.idTypeEquipment);                
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex(error);
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
            clearTypeEquipment();
            $location.path('/type-equipment/');
        }

        function clearError(error) {
            var index = vm.errors.indexOf(error);
            vm.errors.splice(index, 1);
        }

        function clearTypeEquipment() {
            vm.typeEquipment = {
                idTypeEquipment: 0,
                type: ''
            };
        }
    };

})();