(function () {

    'use strict';

    angular.module('fasterClient').controller('ListHistoryPaymentCompanyCtrl', ListHistoryPaymentCompanyCtrl);

    ListHistoryPaymentCompanyCtrl.$inject = ['$location', '$filter', '$rootScope', 'PaymentByCompanyFactory', 'EmployeeFactory'];

    function ListHistoryPaymentCompanyCtrl($location, $filter, $rootScope, PaymentByCompanyFactory, EmployeeFactory) {

        var vm = this;

        vm.histories = [];

        vm.employee = {};
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = {
            skip: 1,
            word: null,
            status: 1,
            take: 12,
            id: 0
        };
        vm.range = range;
        vm.getByRangeCompany = getByRangeCompany;
        vm.redirect = redirect;

        activate();

        function range(n) {
            return new Array(n);
        }

        function activate() {
            getEmployeeLogado();
        }

        function redirect(url) {
            $location.path(url);
        }

        function getCountByCompany() {
            vm.filter.id = vm.employee.idCompany;
            PaymentByCompanyFactory.getCountByCompany(vm.filter)
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

        function getEmployeeLogado() {
            EmployeeFactory.getByEmail($rootScope.user.email)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.employee = response;
                getCountByCompany();
                getByRangeCompany(vm.filter.skip);
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

        function getByRangeCompany(skip) {
            vm.filter.skip = skip;
            vm.filter.id = vm.employee.idCompany;
            PaymentByCompanyFactory.getByRangeCompany(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                console.log(response);
                vm.histories = response;
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

        function getAllAction() {
            ActionFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.actions = response;
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