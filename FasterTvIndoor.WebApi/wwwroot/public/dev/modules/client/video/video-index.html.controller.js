(function () {

    'use strict';

    angular.module('fasterClient').controller('ListVideoCompanyCtrl', ListVideoCompanyCtrl);

    ListVideoCompanyCtrl.$inject = ['$location', '$filter', '$rootScope', 'VideoFactory', 'EmployeeFactory'];

    function ListVideoCompanyCtrl($location, $filter, $rootScope, VideoFactory, EmployeeFactory) {

        var vm = this;

        vm.videos = [];

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
        vm.getRangeVideoByCompany = getRangeVideoByCompany;
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

        function getCountVideoByCompany() {
            vm.filter.id = vm.employee.idCompany;
            VideoFactory.getCountCompany(vm.filter)
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
                getCountVideoByCompany();
                getRangeVideoByCompany(vm.filter.skip);
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

        function getRangeVideoByCompany(skip) {
            vm.filter.skip = skip;
            vm.filter.id = vm.employee.idCompany;
            VideoFactory.getByRangeCompany(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                console.log(response);
                vm.videos = response;
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