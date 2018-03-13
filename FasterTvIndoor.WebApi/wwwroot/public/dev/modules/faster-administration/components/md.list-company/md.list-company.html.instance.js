(function () {
    'use strict'
    angular.module('fasterAdministration').controller('ModalCompanyInstanceCtrl', ModalCompanyInstanceCtrl);

    ModalCompanyInstanceCtrl.$inject = ['$location', '$scope', '$rootScope', '$uibModalInstance', 'CompanyFactory'];

    function ModalCompanyInstanceCtrl($location, $scope, $rootScope, $uibModalInstance, CompanyFactory) {

        //Variáveis
        $rootScope.company = {
            idCompany: 0,
            fantasyName: ''
        };

        //Declaração de Funções
        $scope.confirmCompany = confirmCompany;
        $rootScope.clearCompany = clearCompany;

        //Confirma determinado equipamento que foi selecionado
        function confirmCompany(company) {
            $rootScope.company = company;
            $uibModalInstance.close();
        }

        //Cancela e fecha o modal
        $scope.cancel = function () {
            $uibModalInstance.dismiss('cancel');
        }

        function clearCompany() {
            $rootScope.company = {
                idCompany: 0,
                fantasyName: ''
            };
        }
    };

})();