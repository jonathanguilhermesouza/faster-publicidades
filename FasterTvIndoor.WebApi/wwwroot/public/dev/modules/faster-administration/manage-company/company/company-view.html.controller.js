(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ViewCompanyCtrl', ViewCompanyCtrl);

    ViewCompanyCtrl.$inject = ['$rootScope', '$filter', '$location', '$routeParams', 'CompanyFactory', 'ClassificationFactory', 'StatusFactory', 'PhoneCompanyFactory', 'AddressCompanyFactory', 'SearchCepFactory', 'ControlLoanFactory', 'SizeCompanyFactory', 'RedirectUserService'];

    function ViewCompanyCtrl($rootScope, $filter, $location, $routeParams, CompanyFactory, ClassificationFactory, StatusFactory, PhoneCompanyFactory, AddressCompanyFactory, SearchCepFactory, ControlLoanFactory,SizeCompanyFactory, RedirectUserService) {

        var vm = this;
        var id = $routeParams.id;
        var errors = false;//variável para identificar se tenho erro no formulário


        vm.phoneCompany = {
            idPhoneCompany: 0,
            number: '',
            idCompany: 0
        };
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
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
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

        vm.searchCep = searchCep;
        vm.saveCompany = saveCompany;
        vm.savePhoneCompany = savePhoneCompany;
        vm.updateAddressCompany = updateAddressCompany;
        vm.removePhoneCompany = removePhoneCompany;
        vm.removeAddressCompany = removeAddressCompany;
        vm.addPhoneCompany = addPhoneCompany;
        vm.showSize = showSize;
        vm.showStatus = showStatus;
        vm.showClassification = showClassification;

        activate();

        function activate() {
            getAllStatusCompany();
            getAllClassificationCompany();
            getAllSizesCompany();
            getByIdCompany();
        }

        function showSize(company) {
            var selected = [];
            var index = company.sizeCompany;
            if (company.sizeCompany) {
                selected = $filter('filter')(vm.sizesCompany, { value: company.sizeCompany.size });
            }
            return selected.length ? selected[index - 1].size : 'Vazio';
        };

        function showStatus(company) {
            var selected = [];
            var index = company.statusCompany;
            if (company.statusCompany) {
                selected = $filter('filter')(vm.statusCompany, { value: company.statusCompany.name });
            }
            return selected.length ? selected[index - 1].name : 'Vazio';
        };

        function showClassification(company) {
            var selected = [];
            var index = company.classificationCompany;
            if (company.classificationCompany) {
                selected = $filter('filter')(vm.classificationsCompany, { value: company.classificationCompany.name });
            }
            return selected.length ? selected[index - 1].name : 'Vazio';
        };

        function addPhoneCompany() {
            vm.phoneCompany.idCompany = id;
            vm.company.listPhonesCompany.push(vm.phoneCompany);
        }

        function removePhoneCompany(phone) {
            PhoneCompanyFactory.remove(phone)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Telefone <strong>' + response.number + '</strong> removido com sucesso', 'Remoção com sucesso');
                var index = vm.company.listPhonesCompany.indexOf(phone);
                vm.company.listPhonesCompany.splice(index, 1);
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex(error);
                }
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao remover dados!</strong>');
                    });
                }
            }
        }

        function savePhoneCompany(phone) {
            if (phone.idPhoneCompany == 0) {
                PhoneCompanyFactory.post(phone)
                .success(success)
                .catch(fail);

                function success(response) {
                    toastr.success('Telefone <strong>' + response.number + '</strong> Adicionado com sucesso', 'Atualização com sucesso');
                    clearPhone();
                }

                function fail(error) {
                    if (error.status == 401) {
                        RedirectUserService.redirectToIndex(error);
                    }
                    else {
                        var items = angular.fromJson(error.data.errors);
                        angular.forEach(items, function (value, key) {
                            toastr.warning(value.value, '<strong>Falha ao salvar dados!</strong>');
                        });
                    }
                    errors = true;
                }
            }
            else {
                PhoneCompanyFactory.put(phone)
                .success(success)
                .catch(fail);

                function success(response) {
                    toastr.success('Telefone <strong>' + response.number + '</strong> alterado com sucesso', 'Atualização com sucesso');
                }

                function fail(error) {
                    if (error.status == 401) {
                        RedirectUserService.redirectToIndex(error);
                    }
                    else {
                        var items = angular.fromJson(error.data.errors);
                        angular.forEach(items, function (value, key) {
                            toastr.warning(value.value, '<strong>Falha ao atualizar dados!</strong>');
                        });
                    }
                    errors = true;
                }
            }
        }

        function removeAddressCompany(address) {
            AddressCompanyFactory.remove(address)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Endereço <strong>' + response.cep + '</strong> removido com sucesso', 'Remoção com sucesso');
                var index = vm.company.listAddressCompany.indexOf(address);
                vm.company.listAddressCompany.splice(index, 1);
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex(error);
                }
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao remover dados!</strong>');
                    });
                }
            }
        }

        function updateAddressCompany(address) {
            AddressCompanyFactory.put(address)
            .success(success)
            .catch(fail);

            function success(response) {
                toastr.success('Endereço <strong>' + response.cep + '</strong> alterado com sucesso', 'Atualização com sucesso');
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

        function searchCep(address) {
            SearchCepFactory.getSearchCep(address.cep)
            .success(success)
            .catch(fail);

            function success(response) {

                if (response.erro == true)
                    toastr.error(address.cep, 'CEP não encontrado');

                address.cep = response.cep;
                address.logradouro = response.logradouro;
                address.complemento = response.complemento;
                address.bairro = response.bairro;
                address.localidade = response.localidade;
                address.uf = response.uf;
                address.ibge = response.ibge;
                address.gia = response.gia;

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
                    RedirectUserService.redirectToIndex(error);
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
                    RedirectUserService.redirectToIndex(error);
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
                    RedirectUserService.redirectToIndex(error);
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

        function getByIdCompany() {
            CompanyFactory.getById(id)
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.company = response;
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
                errors = true;
            }
        }

        function cancel() {
            clearCompany();
        }

        function saveCompany() {
            CompanyFactory.put(vm.company)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Empresa <strong>' + response.fantasyName + '</strong> alterada com sucesso', 'Atualização com sucesso');
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex(error);
                }
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao salvar dados!</strong>');
                    });
                }
                errors = true;
            }
        }

        function clearCompany() {
            vm.company = {
                companyName: '',
                fantasyName: '',
                stateInscription: '',
                cnpj: '',
                email: '',
                statusCompany: 0,
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

        function clearPhone() {
            vm.phoneCompany = { idPhoneCompany: 0, number: '', idCompany: 0 };
        }
    };
})();