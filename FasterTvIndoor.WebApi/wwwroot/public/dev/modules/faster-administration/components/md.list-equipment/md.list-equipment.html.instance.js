(function () {
    'use strict'
    angular.module('fasterAdministration').controller('ModalEquipmentInstanceCtrl', ModalEquipmentInstanceCtrl);

    ModalEquipmentInstanceCtrl.$inject = ['$location', '$scope', '$rootScope', '$modalInstance', 'CompanyFactory'];

    function ModalEquipmentInstanceCtrl($location, $scope, $rootScope, $modalInstance, items, CompanyFactory) {

        //Variáveis
        $rootScope.equipment = {
            idEquipment: 0,
            serialNumber: ''
        };

        //Declaração de Funções
        $rootScope.confirmEquipment = confirmEquipment;
        $rootScope.clearEquipment = clearEquipment;

        //Confirma determinado equipamento que foi selecionado
        function confirmEquipment(equipment) {
            $rootScope.equipment = equipment;
            $modalInstance.close();
        }

        //Cancela e fecha o modal
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        }

        function clearEquipment() {
            $rootScope.equipment = {
                idEquipment: 0,
                serialNumber: ''
            };
        }
    };

})();