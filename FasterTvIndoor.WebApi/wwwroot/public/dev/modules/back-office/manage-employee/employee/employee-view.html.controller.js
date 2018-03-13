(function () {

    'use strict';

    angular.module('fasterBackOffice').controller('ViewEmployeeCtrl', ViewEmployeeCtrl);

    ViewEmployeeCtrl.$inject = ['$rootScope', '$filter', '$routeParams', 'EmployeeFactory', 'SectorCompanyFactory', 'ProfileUserFactory', 'AccountFactory', 'PhoneUserFactory', 'AddressUserFactory', 'SearchCepFactory', 'RedirectUserService'];

    function ViewEmployeeCtrl($rootScope, $filter, $routeParams, EmployeeFactory, SectorCompanyFactory, ProfileUserFactory, AccountFactory, PhoneUserFactory, AddressUserFactory, SearchCepFactory, RedirectUserService) {

        var vm = this;
        var id = $routeParams.id;
        var errors = false;//variável para identificar se tenho erro no formulário

        vm.sectorsCompany = [];
        vm.profilesUser = [];
        vm.phoneUser = {
            idPhoneUser: 0,
            number: ''
        };
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.employee = {
            idEmployeeCompany: 0,
            idUser: 0,
            idSectorCompany: 0,
            idCompany: 0,
            cpf: '',
            user: {
                idUser: 0,
                idProfileUser: 0,
                idStatusUser: 0,
                email: '',
                name: '',
                lastName: '',
                dateRegister: null,
                profileUser: { idProfileUser: 0, profile: '' },
                statusUser: 0,
                listCompanyFavorite: null,
                listProductFavorite: null,
                listAddressUser: null,
                listPhoneUser: null,
                listCard: null,
                listEmployedCompany: [],
                listAccountCurrent: null,
                listVehicle: null
            },
            sectorCompany: 0,
            company: null
        };

        vm.searchCep = searchCep;
        vm.showSector = showSector;
        vm.showProfile = showProfile;
        vm.saveUser = saveUser;
        vm.saveEmployee = saveEmployee;
        vm.addPhoneUser = addPhoneUser;
        vm.savePhoneUser = savePhoneUser;
        vm.updateAddressUser = updateAddressUser;
        vm.removePhoneUser = removePhoneUser;

        activate();

        function activate() {
            $rootScope.idEmployeeCompany = id;
            getAllSectorCompany();
            getAllProfileUser();
            getEmployee();
        }

        function showSector(employee) {
            var selected = [];
            var index = employee.idSectorCompany;
            if (employee.idSectorCompany) {
                selected = $filter('filter')(vm.sectorsCompany, { value: employee.sectorCompany.sectorCompany });
            }
            return selected.length ? selected[index - 1].sector : 'Vazio';
        };

        function showProfile(user) {
            var selected = [];
            var index = user.idProfileUser;
            if (user.idProfileUser) {
                selected = $filter('filter')(vm.profilesUser, { value: user.profileUser.profileUser });
            }
            return selected.length ? selected[index - 1].profile : 'Vazio';
        };

        function getCountEmployee(id) {
            EmployeeFactory.getCountEmployee(id)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.amountEmployees = response;
                vm.pagination.qtdPages = Math.ceil(response / vm.pagination.take);
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

        function getEmployee() {
            EmployeeFactory.getById(id)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.employee = response;
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

        function getAllProfileUser() {
            ProfileUserFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                console.log(response);
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

        function addPhoneUser() {
            vm.phoneUser.idUser = vm.employee.user.idUser;
            vm.employee.user.listPhoneUser.push(vm.phoneUser);
        }

        function removePhoneUser(phone) {
            PhoneUserFactory.remove(phone)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Telefone <strong>' + response.number + '</strong> removido com sucesso', 'Remoção com sucesso');
                var index = vm.employee.user.listPhoneUser.indexOf(phone);
                vm.employee.user.listPhoneUser.splice(index, 1);
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex();
                }
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao remover dados!</strong>');
                    });
                }
            }
        }

        function savePhoneUser(phone) {
            if (phone.idPhoneUser == 0) {
                PhoneUserFactory.post(phone)
                .success(success)
                .catch(fail);

                function success(response) {
                    toastr.success('Telefone <strong>' + response.number + '</strong> Adicionado com sucesso', 'Atualização com sucesso');
                }

                function fail(error) {
                    if (error.status == 401) {
                        RedirectUserService.redirectToIndex();
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
                PhoneUserFactory.put(phone)
                .success(success)
                .catch(fail);

                function success(response) {
                    toastr.success('Telefone <strong>' + response.number + '</strong> alterado com sucesso', 'Atualização com sucesso');
                }

                function fail(error) {
                    if (error.status == 401) {
                        RedirectUserService.redirectToIndex();
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

        /*Remove um enredeço do usuário-----------------------------------------------------*/
        /*function removeAddressUser(address) {
            AddressUserFactory.remove(address)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Endereço <strong>' + response.cep + '</strong> removido com sucesso', 'Remoção com sucesso');
                var index = vm.company.listAddressUser.indexOf(address);
                vm.company.listAddressUser.splice(index, 1);
            }

            function fail(error) {
                toastr.error('Sua requisição não pode ser processada', 'Falha na Requisição');
            }
        }        
        */

        function updateAddressUser(address) {
            AddressUserFactory.put(address)
            .success(success)
            .catch(fail);

            function success(response) {
                toastr.success('Endereço <strong>' + response.cep + '</strong> alterado com sucesso', 'Atualização com sucesso');
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex();
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

        function searchCep(address) {
            console.log(address);
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

        function saveUser() {
            AccountFactory.put(vm.employee.user)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Usuário <strong>' + response.name + '</strong> alterado com sucesso', 'Atualização com sucesso');
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex();
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

        function saveEmployee() {
            EmployeeFactory.put(vm.employee)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Funcionário <strong>' + response.cpf + '</strong> alterado com sucesso', 'Atualização com sucesso');
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex();
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
    };
})();