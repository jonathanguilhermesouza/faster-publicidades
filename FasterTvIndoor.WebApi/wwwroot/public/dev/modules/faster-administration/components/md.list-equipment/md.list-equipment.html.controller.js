(function () {
    'use strict'

    angular.module('fasterAdministration').controller('MdListEquipmentCtrl', MdListEquipmentCtrl);

    MdListEquipmentCtrl.$inject = ['$rootScope', '$scope', '$uibModal', '$log', 'EquipmentFactory'];

    function MdListEquipmentCtrl($rootScope, $scope, $uibModal, $log, EquipmentFactory) {

        //Varáveis
        var vm = this;
        $scope.animationsEnabled = true;
        $rootScope.equipments = [];
        $rootScope.pagination = {
            take: 12,
            qtdPagesEquipment: 0
        };
        $scope.search = { skip: 1, word: null, status: 1 };

        //Declaração de Funções
        $rootScope.rangeEquipment = rangeEquipment;
        $rootScope.openEquipment = openEquipment;
        $rootScope.getEquipments = getEquipments;
        $rootScope.searchEquipment = searchEquipment;

        activate();

        /*Incialização-----------------------------------------------------*/
        function activate() {
            getCountEquipments();
            getEquipments(1);
        }

        /*Instancia um novo array-----------------------------------------------------*/
        function rangeEquipment(n) {
            return new Array(n);
        }

        /*Pesquisa por determinado equipamento-----------------------------------------------------*/
        function searchEquipment() {
            if ($scope.search.word == '')
                $scope.search.word = null;

            getEquipments(1);
            getCountEquipments();
        }

        /*Traz a quantidade de equipamentos disponivel-----------------------------------------------------*/
        function getCountEquipments() {
            EquipmentFactory.getCount($scope.search)
            .success(success)
            .catch(fail);

            function success(response) {
                $scope.pagination.qtdPagesEquipment = Math.ceil(response / $scope.pagination.take);
                console.log($scope.pagination.qtdPagesEquipment);
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha ao listar a quantidade de equipamentos');
                errors = true;
            }
        }

        /*Traz os equipamentos disponíveis-----------------------------------------------------*/
        function getEquipments(page) {
            $scope.search.skip = page;
            console.log($scope.search);
            EquipmentFactory.getByRange($scope.search)
            .success(success)
            .catch(fail);

            function success(response) {
                $rootScope.equipments = response;
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha ao listar as os equipamentos');
            }
        }

        /*Exibe o modal de equipamentos-----------------------------------------------------*/
        function openEquipment() {
            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'modalEquipmentContent.html',
                controller: 'ModalEquipmentInstanceCtrl',
                size: 'lg',
                resolve: {
                }
            });
        };
    };

})();