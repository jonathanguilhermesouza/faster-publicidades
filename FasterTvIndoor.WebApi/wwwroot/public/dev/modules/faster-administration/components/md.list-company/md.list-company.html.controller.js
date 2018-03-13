(function () {
    'use strict'

    angular.module('fasterAdministration').controller('MdListCompanyCtrl', MdListCompanyCtrl);

    MdListCompanyCtrl.$inject = ['$rootScope', '$scope', '$uibModal', '$log', 'CompanyFactory'];

    function MdListCompanyCtrl($rootScope, $scope, $uibModal, $log, CompanyFactory) {

        //Variáveis
        var vm = this;

        $scope.animationsEnabled = true;
        $rootScope.companies = [];
        $rootScope.pagination = {
            take: 12,
            qtdPagesCompany: 0
        };
        $rootScope.filterCompany = { skip: 1, status: 1, word: null, contract: false };

        //Declaração de Funções
        $rootScope.rangeCompany = rangeCompany;
        $rootScope.openCompany = openCompany;
        $rootScope.getCompanies = getCompanies;
        $rootScope.searchCompany = searchCompany;

        activate();

        /*Incialização-----------------------------------------------------*/
        function activate() {
            if ($rootScope.haveContract)
                $rootScope.filterCompany.contract = $rootScope.haveContract;

            getCountCompanies();
            getCompanies($rootScope.filterCompany.skip);
        }

        /*Instancia um novo array-----------------------------------------------------*/
        function rangeCompany(n) {
            return new Array(n);
        }

        /*Pesquisa por determinado equipamento-----------------------------------------------------*/
        function searchCompany() {
            if ($rootScope.filterCompany.word == '')
                $rootScope.filterCompany.word = null;

            getCompanies($rootScope.filterCompany.skip);
            getCountCompanies();
        }

        /*Traz a quantidade de equipamentos disponivel-----------------------------------------------------*/
        function getCountCompanies() {
            CompanyFactory.getCount($rootScope.filterCompany)
            .success(success)
            .catch(fail);

            function success(response) {
                $rootScope.pagination.qtdPagesCompany = Math.ceil(response / $rootScope.pagination.take);
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha ao listar a quantidade de empresas');
            }
        }

        /*Traz os equipamentos disponíveis-----------------------------------------------------*/
        function getCompanies(page) {
            $rootScope.filterCompany.skip = page;
            CompanyFactory.getByRange($rootScope.filterCompany)
            .success(success)
            .catch(fail);

            function success(response) {
                $rootScope.companies = response;
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha ao listar as empresas');
            }
        }

        /*Exibe o modal de equipamentos-----------------------------------------------------*/
        function openCompany() {
            var modalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'modalCompany.html',
                controller: 'ModalCompanyInstanceCtrl',
                size: 'lg',
                resolve: {
                    '$modalInstance': function () { return function () { return modalInstance; } }
                }
            });
        };
    };

})();