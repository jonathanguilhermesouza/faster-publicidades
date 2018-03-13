(function () {

    'use strict'

    angular.module('fasterAdministration').controller('ListCompanyActiveCtrl', ListCompanyActiveCtrl);

    ListCompanyActiveCtrl.$inject = ['$location', '$rootScope', 'SETTINGS', 'CompanyFactory', 'RedirectUserService'];

    function ListCompanyActiveCtrl($location, $rootScope, SETTINGS, CompanyFactory, RedirectUserService) {

        var vm = this;         

        vm.company = {};
        vm.companies = [];
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = {
            skip: 1,
            word: null,
            status: 1,
            contract: false
        };

        vm.range = range;
        vm.getByRangeCompany = getByRangeCompany;
        vm.removeCompany = removeCompany;
        vm.searchCompany = searchCompany;        

        activate();       

        function activate() {
            getByRangeCompany(vm.filter.skip);
            getCountCompany();
        }

        function searchCompany() {
            if (vm.filter.word == '')
                vm.filter.word = null;

            getByRangeCompany(vm.filter.skip = 1);
            getCountCompany();
        }
      
        function range(n) {
            return new Array(n);
        }

        function getCountCompany() {
            console.log(vm.filter);
            CompanyFactory.getCount(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.pagination.qtdPages = Math.ceil(response / vm.pagination.take);
                console.log(response);
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex();
                }
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao recuperar dados!</strong>');
                    });
                }
            }
        }

        function getByRangeCompany(skip) {
            $rootScope.progressbar.setColor('#29abe0');
            $rootScope.progressbar.start();
            vm.filter.skip = skip;
            CompanyFactory.getByRange(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                $rootScope.progressbar.complete();
                console.log(response);
                  vm.companies = response;
            }

            function fail(error) {
                $rootScope.progressbar.complete();
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

        function removeCompany(company) {
            loadCompany(company);
            CompanyFactory.remove(vm.company)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Empresa <strong>' + company.companyName + '</strong> removida com sucesso', 'Remoção com Sucesso');

                var index = vm.companies.indexOf(company);
                vm.companies.splice(index, 1);

                getCountCompany();

                if (vm.filter.skip > 1 && vm.companies.length == 0)
                    getByRangeCompany(vm.filter.skip - 1);
                else
                    getByRangeCompany(vm.filter.skip);
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex();
                }
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao recuperar dados!</strong>');
                    });
                }
            }

            clearCompany();
        }

        function loadCompany(company) {
            vm.company = company;
        }

        function clearCompany() {
            vm.company = {
                idCompany:0,
                companyName: '',
                fantasyName: '',
                stateInscription: 0,
                cnpj: '',
                classificationCompany: 0,
                listAddressCompany: [{
                    cep: '',
                    logradouro: '',
                    bairro: '',
                    localidade: '',
                    uf: '',
                    ibge: ''
                }]
            };
        }       
    };

})();