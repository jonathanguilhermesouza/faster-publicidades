(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ListProfileCtrl', ListProfileCtrl);

    ListProfileCtrl.$inject = ['ProfileUserFactory', 'RedirectUserService'];

    function ListProfileCtrl(ProfileUserFactory, RedirectUserService) {

        var vm = this;

        vm.profiles = [];
        vm.profile = {};
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = { skip: 1, status: 1, word: null };

        vm.range = range;
        vm.getByRangeProfileUser = getByRangeProfileUser;
        vm.remove = remove;

        activate();

        function range(n) {
            return new Array(n);
        }

        function activate() {
            getCountProfileUser();
            getByRangeProfileUser(vm.filter.skip);
        }

        function getCountProfileUser() {
            ProfileUserFactory.getCount()
            .success(success)
            .catch(fail);

            function success(response) {
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

        function getByRangeProfileUser(skip) {
            vm.filter.skip = skip;
            console.log(vm.filter);
            ProfileUserFactory.getByRange(vm.filter)
                .success(success)
                .catch(fail);

            function success(response) {
                vm.profiles = response;
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

        function remove(profile) {
            loadProfile(profile);
            ProfileUserFactory.remove(vm.profile)
               .success(success)
               .catch(fail);

            function success(response) {
                toastr.success('Perfil <strong>' + response.profile + '</strong> removido com sucesso', 'Sucesso');
                var index = vm.profiles.indexOf(profile);
                vm.profiles.splice(index, 1);
                getCountProfileUser();

                if (vm.filter.skip > 1 && vm.profiles.length == 0)
                    getByRangeProfileUser(vm.filter.skip - 1);
                else
                    getByRangeProfileUser(vm.filter.skip);
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
            clearProfile();
        }
        function loadProfile(profile) {
            vm.profile = profile;
        }

        function clearProfile() {
            vm.profile = {
                idProfileUser: 0,
                profile: ''
            }
        }
    };

})();