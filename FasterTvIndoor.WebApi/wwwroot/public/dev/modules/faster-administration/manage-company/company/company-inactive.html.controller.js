(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ListInactiveCompanyCtrl', ListInactiveCompanyCtrl);

    ListInactiveCompanyCtrl.$inject = ['$location', '$rootScope', 'SETTINGS', 'CompanyFactory', 'RedirectUserService'];

    function ListInactiveCompanyCtrl($location, $rootScope, SETTINGS, CompanyFactory, RedirectUserService) {

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
            status: 2,
            contract: false
        };

        vm.range = range;
        vm.getAllCompany = getAllCompany;
        vm.removeCompany = removeCompany;
        vm.searchCompany = searchCompany;

        activate();

        function activate() {
            getAllCompany(vm.filter.skip);
            getCountCompany();
            $rootScope.menu = true;
        }

        function searchCompany() {
            if (vm.filter.word == '')
                vm.filter.word = null;

            getAllCompany(vm.filter.skip = 1);
            getCountCompany();
        }

        function range(n) {
            return new Array(n);
        }

        function getCountCompany() {
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

        function getAllCompany(skip) {
            vm.filter.skip = skip;
            CompanyFactory.getByRange(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.companies = response;
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
                    getAllCompany(vm.filter.skip - 1);
                else
                    getAllCompany(vm.filter.skip);
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
                companyName: '',
                fantasyName: '',
                stateInscription: '',
                cnpj: '',
                email: '',
                classificationCompany: 0,
                listAddressCompany: [{
                    cep: '',
                    logradouro: '',
                    complemento: '',
                    bairro: '',
                    localidade: '',
                    uf: '',
                    ibge: '',
                    gia: '',
                    number: '',
                    reference: ''
                }],
                listPhonesCompany: []
            };
        }

    };


})();