(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ContractCurrentCtrl', ContractCurrentCtrl);

    ContractCurrentCtrl.$inject = ['ContractFactory', 'RedirectUserService'];

    function ContractCurrentCtrl(ContractFactory, RedirectUserService) {
        
        var vm = this;

        vm.contracts = [];
        vm.contract = {};

        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = { skip: 1, status: 1, word: null };

        vm.range = range;
        vm.getByRangeContract = getByRangeContract;
        vm.searchContract = searchContract;

        activate();

        function activate() {
            getByRangeContract(vm.filter.skip);
            getCountContract();
        }

        function searchContract() {
            if (vm.filter.word == '')
                vm.filter.word = null;

            getByRangeContract(vm.filter.skip);
            getCountContract();
        }

        function range(n) {
            return new Array(n);
        }

        function getCountContract() {
            ContractFactory.getCount(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.pagination.qtdPages = Math.ceil(response / vm.pagination.take);
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

        function getByRangeContract(skip) {
            vm.filter.skip = skip;
            ContractFactory.getByRange(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.contracts = response;
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
    }
})();