(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ListLoanCanceledCtrl', ListLoanCanceledCtrl);

    ListLoanCanceledCtrl.$inject = ['ControlLoanFactory', 'RedirectUserService'];

    function ListLoanCanceledCtrl(ControlLoanFactory, RedirectUserService) {

        var vm = this;

        vm.controlsLoan = [];
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = { skip: 1, word: null, status: 3 };

        vm.range = range;
        vm.getByRangeControlLoan = getByRangeControlLoan;
        vm.searchControlLoan = searchControlLoan;

        activate();

        function activate() {
            getByRangeControlLoan(vm.filter.skip);
            getCountControlLoan();
        }

        function searchControlLoan() {
            if (vm.filter.word == '')
                vm.filter.word = null;

            getByRangeControlLoan(vm.filter.skip);
            getCountControlLoan();
        }

        function range(n) {
            return new Array(n);
        }

        function getCountControlLoan() {
            ControlLoanFactory.getCount(vm.filter)
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

        function getByRangeControlLoan(skip) {
            vm.filter.skip = skip;
            ControlLoanFactory.getByRange(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.controlsLoan = response;
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
    };
})();