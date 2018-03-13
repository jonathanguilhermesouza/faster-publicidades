(function () {
    'use strict'

    angular.module('faster').controller('mdCancelContractCtrl', mdCancelContractCtrl);

    mdCancelContractCtrl.$inject = ['$rootScope', '$scope', '$uibModal', '$log', 'ContractFactory'];

    function mdCancelContractCtrl($rootScope, $scope, $uibModal, $log, ContractFactory) {

        //Varáveis
        var vm = this;
        $scope.animationsEnabled = true;
        $rootScope.contract = {
            idContract: 0,
            idCompany: 0,
            dateStart: null,
            dateEnd: null,
            statusContract: 0,
            note: ''
        };
        //var id = $routeParams.id;
        var errors = false;//variável para identificar se tenho erro no formulário

        //Declaração de Funções
        $rootScope.openNoteContract = openNoteContract;
        $rootScope.getNoteContract = getNoteContract;

        activate();

        /*Incialização-----------------------------------------------------*/
        function activate() {
        }


        /*Traz a quantidade de equipamentos disponivel-----------------------------------------------------*/
        function getNoteContract(contract) {
            $rootScope.contract = contract;
            openNoteContract();
        }

        /*Exibe o modal de observações do contrato-----------------------------------------------------*/
        function openNoteContract() {
            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'modalNoteContract.html',
                controller: 'ModalNoteContractCtrl',
                size: 'lg',
                resolve: {
                }
            });
        };
    };

})();
