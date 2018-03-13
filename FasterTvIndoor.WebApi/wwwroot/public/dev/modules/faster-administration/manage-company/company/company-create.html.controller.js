(function () {

    'use strict';

    angular.module('fasterAdministration').controller('CreateCompanyCtrl', CreateCompanyCtrl);

    CreateCompanyCtrl.$inject = ['$location', 'CompanyFactory', 'ClassificationFactory', 'StatusFactory', 'SearchCepFactory', 'SizeCompanyFactory', 'RedirectUserService'];

    function CreateCompanyCtrl($location, CompanyFactory, ClassificationFactory, StatusFactory, SearchCepFactory, SizeCompanyFactory, RedirectUserService) {

        var vm = this;
        var errors = false;//variável para identificar se tenho erro no formulário

        vm.errors = [];
        vm.statusCompany = [{
            id: 0,
            name: ''
        }];
        vm.classificationsCompany = [{
            id: 0,
            name: ''
        }];
        vm.sizesCompany = [{
            id: 0,
            name: ''
        }];
        vm.phonesCompany = [{
            number: ''
        }];
        vm.company = {
            companyName: '',
            fantasyName: '',
            stateInscription: '',
            cnpj: '',
            email: '',
            classificationCompany: 0,
            listAddressCompany: [],
            listPhonesCompany: []
        };

        vm.clearError = clearError;
        vm.searchCep = searchCep;
        vm.save = save;
        vm.cancel = cancel;

        activate();

        function activate() {
            getAllStatusCompany();
            getAllClassificationCompany();
            getAllSizesCompany();
        }

        function searchCep(cep) {
            SearchCepFactory.getSearchCep(cep)
            .success(success)
            .catch(fail);

            function success(response) {

                if (response.erro == true)
                    toastr.error(vm.company.listAddressCompany[0].cep, 'CEP não encontrado');

                vm.company.listAddressCompany[0].cep = response.cep;
                vm.company.listAddressCompany[0].logradouro = response.logradouro;
                vm.company.listAddressCompany[0].complemento = response.complemento;
                vm.company.listAddressCompany[0].bairro = response.bairro;
                vm.company.listAddressCompany[0].localidade = response.localidade;
                vm.company.listAddressCompany[0].uf = response.uf;
                vm.company.listAddressCompany[0].ibge = response.ibge;
                vm.company.listAddressCompany[0].gia = response.gia;

            }

            function fail(error) {
                toastr.warning(error, 'Favor, informe o CEP!');
                errors = true;
            }
        }

        function getAllSizesCompany() {
            SizeCompanyFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.sizesCompany = response;
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
                errors = true;
            }
        }

        function getAllClassificationCompany() {
            ClassificationFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.classificationsCompany = response;
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
                errors = true;
            }
        }

        function getAllStatusCompany() {
            StatusFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.statusCompany = response;
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
                errors = true;
            }
        }

        function save() {
            getPhones();
            CompanyFactory.post(vm.company)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('Empresa <strong>' + response.fantasyName + '</strong> cadastrada com sucesso', 'Empresa Cadastrada');
                $location.path('/company/view/' + response.idCompany);
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex();
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

        function getPhones() {
            if (errors = false)
                angular.forEach(vm.phonesCompany, function (value, key) {
                    vm.company.listPhonesCompany.push(value);
                });
        }

        function cancel() {
            clearCompany();
            $location.path('/company/active/');
        }

        function clearError(error) {
            var index = vm.errors.indexOf(error);
            vm.errors.splice(index, 1);
        }

        function clearCompany() {
            vm.company = {
                companyName: '',
                fantasyName: '',
                stateInscription: '',
                cnpj: '',
                email: '',
                classificationCompany: 0,
                listAddressCompany: [],
                listPhonesCompany: []
            };
        }
    };

})();