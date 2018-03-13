(function () {
    'use strict';

    angular.module('faster').controller('ModalNoteContractCtrl', ModalNoteContractCtrl);

    ModalNoteContractCtrl.$inject = ['$location', '$scope', '$rootScope', '$modalInstance', 'ContractFactory'];

    function ModalNoteContractCtrl($location, $scope, $rootScope, $modalInstance, ContractFactory) {

        //Declaração de Funções
        $scope.confirmContract = confirmContract;
        $rootScope.clearContract = clearContract;

        //Confirma determinado equipamento que foi selecionado
        function confirmContract(contract) {
            $rootScope.contract.note = contract.note;
            cancelContract($rootScope.contract);
            $modalInstance.close();
        }

        //Cancela e fecha o modal
        $scope.cancel = function () {
            clearContract();
            $modalInstance.dismiss('cancel');
        }

        function clearContract() {
            $rootScope.contract = {
                idContract: 0,
                idCompany: 0,
                dateStart: null,
                dateEnd: null,
                statusContract: 0,
                note: ''
            };
        }

        function cancelContract(contract) {
            ContractFactory.cancel(contract)
                .success(success)
                .catch(fail);

            function success(response) {
                $rootScope.getContract(1);
                toastr.success('Contrato cancelado com sucesso', 'Atualização com sucesso');
            }

            function fail(error) {
                if (error.status == 401)
                    toastr.error('Você não tem permissão para ver esta página', 'Requisição não autorizada');
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Atualização sem sucesso!</strong>');
                    });
                }
                errors = true;
            }
        }
    };
})();