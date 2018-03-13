(function () {

    'use strict';

    angular.module('fasterClient').controller('ListHistoryEquipmentCtrl', ListHistoryEquipmentCtrl);

    ListHistoryEquipmentCtrl.$inject = ['$location', '$filter', '$rootScope', 'ActionFactory', 'EmployeeFactory', 'HistoryEquipmentFactory'];

    function ListHistoryEquipmentCtrl($location, $filter, $rootScope, ActionFactory, EmployeeFactory, HistoryEquipmentFactory) {

        var vm = this;

        vm.histories = [];
        vm.actions = [];
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
        vm.showAction = showAction;
        vm.getPaymentByRangeCompany = getPaymentByRangeCompany;
        vm.redirect = redirect;

        activate();

        function range(n) {
            return new Array(n);
        }

        function activate() {
            getEmployeeLogado();
            getAllAction();            
        }

        function redirect(url) {
            $location.path(url);
        }

        function showAction(history) {
            var selected = [];
            var index = history.action;
            if (history.action) {
                selected = $filter('filter')(vm.actions, { value: history.action.name });
            }
            return selected.length ? selected[index - 1].name : 'Vazio';
        };

        function getCountByCompany() {
            vm.filter.id = vm.employee.idCompany;
            HistoryEquipmentFactory.getCountByCompany(vm.filter)
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

        function getEmployeeLogado() {
            EmployeeFactory.getByEmail($rootScope.user.email)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.employee = response;
                getCountByCompany();
                getPaymentByRangeCompany(vm.filter.skip);
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

        function getPaymentByRangeCompany(skip) {
            vm.filter.skip = skip;
            vm.filter.id = vm.employee.idCompany;
            HistoryEquipmentFactory.getByRangeCompany(vm.filter)
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