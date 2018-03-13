(function () {

    'use strict';

    angular.module('fasterClient').controller('ViewConfigurationCtrl', ViewConfigurationCtrl);

    ViewConfigurationCtrl.$inject = ['$filter', '$rootScope', 'UserFactory', 'StatusUserFactory', 'ProfileUserFactory', 'PhoneUserFactory', 'AddressUserFactory', 'SearchCepFactory', 'RedirectUserService'];

    function ViewConfigurationCtrl($filter, $rootScope, UserFactory, StatusUserFactory, ProfileUserFactory, PhoneUserFactory, AddressUserFactory, SearchCepFactory, RedirectUserService) {

        var vm = this;
        var errors = false;

        vm.user = {
            idUser: 0,
            idProfileUser: 0,
            email: '',
            password: '',
            name: '',
            lastName: '',
            nickName: '',
            dateRegister: '',
            profileUser: null,
            statusUser: '',
            listAddressUser: [],
            listPhoneUser: [],
            listEmployedCompany: null,
            listAccountCurrent: null
        };

        vm.statusUser = [{
            id: 0,
            name: ''
        }];
        vm.profilesUser = [{
            id: 0,
            name: ''
        }];
        vm.phoneUser = {
            idPhoneUser: 0,
            number: '',
            idUser: 0
        };
        vm.addressUser = {
            idAddressUser: 0,            
            idUser: 0
        };

        vm.showStatus = showStatus;
        vm.showProfile = showProfile;
        vm.saveUser = saveUser;
        vm.addPhoneUser = addPhoneUser;
        vm.addAddressUser = addAddressUser;
        vm.removePhoneUser = removePhoneUser;
        vm.removeAddressUser = removeAddressUser;
        vm.savePhoneUser = savePhoneUser;
        vm.saveAddressUser = saveAddressUser;
        vm.searchCep = searchCep;

        activate();

        function activate() {
            getByEmailUser();
            getAllStatusUser();
            getAllProfileUser();
        }

        function addPhoneUser() {
            vm.phoneUser.idUser = vm.user.idUser;
            vm.user.listPhoneUser.push(vm.phoneUser);
        }

        function addAddressUser() {
            vm.addressUser.idUser = vm.user.idUser;
            vm.user.listAddressUser.push(vm.addressUser);
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

        function removePhoneUser(phone) {
            PhoneUserFactory.remove(phone)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Telefone <strong>' + response.number + '</strong> removido com sucesso', 'Remoção com sucesso');
                var index = vm.user.listPhoneUser.indexOf(phone);
                vm.user.listPhoneUser.splice(index, 1);
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

        function removeAddressUser(address) {
            loadAddressUser(address);
            AddressUserFactory.remove(address)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Endereço <strong>' + response.cep + '</strong> removido com sucesso', 'Remoção com sucesso');
                var index = vm.user.listAddressUser.indexOf(address);
                vm.user.listAddressUser.splice(index, 1);
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

        function loadAddressUser(address) {
            vm.addressUser = address;
        }

        function savePhoneUser(phone) {
            if (phone.idPhoneUser == 0) {
                PhoneUserFactory.post(phone)
                .success(success)
                .catch(fail);

                function success(response) {
                    toastr.success('Telefone <strong>' + response.number + '</strong> Adicionado com sucesso', 'Atualização com sucesso');
                    clearPhone();
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

        function saveAddressUser(address) {
            if (address.idAddressUser == 0) {
                AddressUserFactory.post(address)
                .success(success)
                .catch(fail);

                function success(response) {
                    toastr.success('Endereço <strong>' + response.cep + '</strong> Adicionado com sucesso', 'Atualização com sucesso');
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
        }

        function showStatus(user) {
            var selected = [];
            var index = user.statusUser;
            if (user.statusUser) {
                selected = $filter('filter')(vm.statusUser, { value: user.statusUser.name });
            }
            return selected.length ? selected[index - 1].name : 'Vazio';
        };

        function showProfile(user) {
            console.log(user);
            var selected = [];
            var index = user.idProfileUser;
            if (user.idProfileUser) {
                selected = $filter('filter')(vm.profilesUser, { value: user.profileUser.name });
            }
            return selected.length ? selected[index - 1].profile : 'Vazio';
        };

        function saveUser() {
            UserFactory.put(vm.user)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Usuário <strong>' + response.name + '</strong> alterado com sucesso', 'Atualização com sucesso');
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

        function getAllStatusUser() {
            StatusUserFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.statusUser = response;
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

        function getByEmailUser() {
            UserFactory.getByEmail($rootScope.user.email)
                .success(success)
                .catch(fail);
            function success(response) {
                vm.user = response;
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


    }

})();