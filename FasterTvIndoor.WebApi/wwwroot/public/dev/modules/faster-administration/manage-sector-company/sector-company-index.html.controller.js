(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ListSectorCompanyCtrl', ListSectorCompanyCtrl);

    ListSectorCompanyCtrl.$inject = ['SectorCompanyFactory', 'RedirectUserService'];

    function ListSectorCompanyCtrl(SectorCompanyFactory, RedirectUserService) {

        var vm = this;

        vm.sectorsCompany = [];
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = { skip: 1, status: 1, word: null };

        vm.range = range;
        vm.getByRangeSectorCompany = getByRangeSectorCompany;
        vm.remove = remove;

        activate();

        function range(n) {
            return new Array(n);
        }

        function activate() {
            getCountSectorCompany();
            getByRangeSectorCompany(vm.filter.skip);
        }

        function getCountSectorCompany() {
            SectorCompanyFactory.getCount()
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

        function getByRangeSectorCompany(skip) {
            vm.filter.skip = skip;
            SectorCompanyFactory.getByRange(skip)
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
            }
        }

        function remove(sector) {
            loadSectorCompany(sector);
            SectorCompanyFactory.remove(vm.sectorCompany)
               .success(success)
               .catch(fail);

            function success(response) {
                toastr.success('Setor <strong>' + response.sector + '</strong> removido com sucesso', 'Sucesso');
                var index = vm.sectorsCompany.indexOf(sector);
                vm.sectorsCompany.splice(index, 1);
                getCountSectorCompany();

                if (vm.filter.skip > 1 && vm.sectorsCompany.length == 0)
                    getByRangeSectorCompany(vm.filter.skip - 1);
                else
                    getByRangeSectorCompany(vm.filter.skip);
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
            clearSectorCompany();

        }
        function loadSectorCompany(sector) {
            vm.sectorCompany = sector;
        }

        function clearSectorCompany() {
            vm.sectorCompany = {
                idSectorCompany: 0,
                sector: ''
            }
        }
    };
})();