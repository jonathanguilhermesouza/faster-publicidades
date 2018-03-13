(function () {

    'use strict';

    angular.module('fasterClient').controller('ListHistoryMonthCurrentCtrl', ListHistoryMonthCurrentCtrl);

    ListHistoryMonthCurrentCtrl.$inject = ['$location', '$filter', '$rootScope', 'BalanceFactory', 'EmployeeFactory'];

    function ListHistoryMonthCurrentCtrl($location, $filter, $rootScope, BalanceFactory, EmployeeFactory) {

        var vm = this;

        vm.balances = [];
        vm.employee = {};
        vm.filter = {
            skip: 1,
            take: 12,
            word: null,
            status: 1,
            id: 0
        };
        vm.total = {
            value: 0
        };
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };

        vm.getByRangeBalance = getByRangeBalance;
        vm.range = range;

        function range(n) {
            return new Array(n);
        }

        activate();

        function activate() {
            getEmployeeLogado();            
        }

        function getEmployeeLogado() {
            EmployeeFactory.getByEmail($rootScope.user.email)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.employee = response;
                getCountBalance();
                getByRangeBalance(vm.filter.skip);
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

        function getCountBalance() {
            vm.filter.id = vm.employee.idCompany;
            BalanceFactory.getCount(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                console.log(response);
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

        function getByRangeBalance(skip) {
            vm.filter.skip = skip;
            vm.filter.id = vm.employee.idCompany;
            BalanceFactory.getByRange(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.balances = response;
                vm.total.value = 0;
                calcTotal();
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

        function calcTotal() {            
            angular.forEach(vm.balances, function (value, key) {
                vm.total.value = vm.total.value + value.value;
            });

            vm.total.value = parseFloat((vm.total.value).toFixed(2));//calcula 10 % que o parceiro tem direito
        }
    };

})();