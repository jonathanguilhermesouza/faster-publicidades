(function () {

    'use strict'

    angular.module('fasterBackOffice').controller('CreateEmployeeCtrl', CreateEmployeeCtrl);

    CreateEmployeeCtrl.$inject = ['$rootScope', '$location', 'EmployeeFactory', 'SectorCompanyFactory', 'ProfileUserFactory', 'CompanyFactory', 'SearchCepFactory', 'RedirectUserService'];

    function CreateEmployeeCtrl($rootScope, $location, EmployeeFactory, SectorCompanyFactory, ProfileUserFactory, CompanyFactory, SearchCepFactory, RedirectUserService) {

        var vm = this;
        var errors = false;//variável para identificar se tenho erro no formulário

        vm.errors = [];
        vm.profilesUser = [];
        vm.sectorsCompany = [];
        vm.employee = {
            cpf: '',
            user: {
                email: '',
                name: '',
                lastName: '',
                password: '',
                idProfileUser: '',
                idStatusUser: 1,
                listPhoneUser: [],
                listAddressUser: []
            },
            company: {},
            idSectorCompany: 0,
            idCompany: 0
        };

        vm.save = save;
        vm.searchCep = searchCep;
        vm.setCompany = setCompany;
        vm.cancel = cancel;
        vm.clearError = clearError;

        activate();

        function activate() {
            getAllSectorCompany();
            getAllProfileUser();
        }

        function setCompany(company) {
            if (company != null) {
                vm.employee.idCompany = company.idCompany;
                return company.fantasyName;
            } else {
                return vm.employee.company.fantasyName;
            }
        }

        function searchCep(cep) {
            SearchCepFactory.getSearchCep(cep)
            .success(success)
            .catch(fail);

            function success(response) {

                if (response.erro == true)
                    toastr.error(vm.employee.user.listAddressUser[0].cep, 'CEP não encontrado');

                vm.employee.user.listAddressUser[0].cep = response.cep;
                vm.employee.user.listAddressUser[0].logradouro = response.logradouro;
                vm.employee.user.listAddressUser[0].complemento = response.complemento;
                vm.employee.user.listAddressUser[0].bairro = response.bairro;
                vm.employee.user.listAddressUser[0].localidade = response.localidade;
                vm.employee.user.listAddressUser[0].uf = response.uf;
                vm.employee.user.listAddressUser[0].ibge = response.ibge;
                vm.employee.user.listAddressUser[0].gia = response.gia;

            }

            function fail(error) {
                toastr.warning(error, 'Favor, informe o CEP!');
                errors = true;
            }
        }

        function getAllProfileUser() {
            ProfileUserFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.profilesUser = response;
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

        function getAllSectorCompany() {
            SectorCompanyFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.sectorsCompany = response;
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
            EmployeeFactory.post(vm.employee)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('Funcionário <strong>' + response.user.name + '</strong> cadastrado com sucesso', 'Funcionário Cadastrada');
                $location.path('/employee/view/' + response.idEmployeeCompany);
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

        function cancel() {
            clearEmployee();
            $location.path('/company/active/');
        }

        function clearError(error) {
            var index = vm.errors.indexOf(error);
            vm.errors.splice(index, 1);
        }

        function clearEmployee() {
            vm.employee = {
                cpf: '',
                user: {
                    email: '',
                    name: '',
                    lastName: '',
                    password: '',
                    idProfileUser: '',
                    idStatusUser: 1,
                    listPhoneUser: [],
                    listAddressUser: []
                },
                company: {},
                idSectorCompany: 0,
                idCompany: 0
            };
        }
    };

})();