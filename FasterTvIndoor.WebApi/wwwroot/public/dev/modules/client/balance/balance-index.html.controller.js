(function () {

    'use strict';

    angular.module('fasterClient').controller('ListBalanceCtrl', ListBalanceCtrl)

    ListBalanceCtrl.$inject = ['$rootScope', '$scope', 'BalanceFactory', 'PaymentByCompanyFactory', 'VideoFactory', 'EmployeeFactory'];

    function ListBalanceCtrl($rootScope, $scope, BalanceFactory, PaymentByCompanyFactory, VideoFactory, EmployeeFactory) {

        var vm = this;

        vm.balances = [];
        vm.payments = [];
        vm.employee = {};
        vm.amountVideo = 0;
        $rootScope.company = {};
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = {
            skip: 1,
            take: 12,
            word: null,
            status: 1,
            id: 0
        };

        $rootScope.data = [
            { y: "01", a: 100, b: 90 },
            { y: "02", a: 75, b: 65 },
            { y: "03", a: 50, b: 40 },
            { y: "04", a: 75, b: 65 },
            { y: "05", a: 50, b: 40 },
            { y: "06", a: 75, b: 65 },
            { y: "07", a: 100, b: 90 }
        ];


        var ano = [];
        vm.yearsCompanyPayment = [];
        vm.months = ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"];
        vm.years = [];
        vm.values = [];
        //vm.colours = [{
        //    fillColor: '#c7254e',
        //    strokeColor: '#c7254e',
        //    highlightFill: '#c7254e',
        //    highlightStroke: '#c7254e'
        //},
        //{
        //    fillColor: '#c72500',
        //    strokeColor: '#c72500',
        //    highlightFill: '#c72500',
        //    highlightStroke: '#c72500'
        //}];
        $scope.onClick = function (points, evt) {
            console.log(points, evt);
        };


        //$scope.xkey = 'range';

        //$scope.ykeys = ['total_faturament'];

        //$scope.labels = ['Faturamento'];

        //$scope.myModel = [
        //  { range: 'Janeiro', total_faturament: 20 },
        //  { range: 'Fevereiro', total_faturament: 35 },
        //  { range: 'Março', total_faturament: 20 },
        //  { range: 'Abril', total_faturament: 20 }
        //];

        activate();

        function activate() {
            getEmployeeLogado();
        }

        function calcTotal() {
            console.log(vm.balances);
            vm.total = {
                value: 0
            };
            angular.forEach(vm.balances, function (value, key) {
                vm.total.value = vm.total.value + value.value;
            });

            vm.total.value = parseFloat((vm.total.value).toFixed(2));
        }

        function payment() {

            //angular.forEach(vm.payments, function (value, key) {

            //});

            angular.forEach(vm.payments, function (value, key) {
                ano.push(value.value);

                if (!contains(value.year))
                    vm.years.push(value.year);

            });

        }

        function groupByYear() {


            for (var i = 0; i < vm.years.length; i++) {
                group(vm.years[i]);//agrupa os dados por ano
            }

            //groupByMonth();

        }

        //function groupByMonth() {

        //    for (var i = 0; i < vm.values.length; i++) {
        //        groupMonth(vm.values[i])
        //    }



        //    //for (var i = 0; i < vm.months.length; i++) {
        //    //    groupMonth(vm.months[i]);
        //    //}

        //}

        //function groupMonth(values) {
        //    var dataByMonth = [];

        //    for (var i = 0; i < vm.payments.length; i++) {
        //        if (vm.payments[i].month == month)
        //            dataByMonth.push(vm.payments[i].value);
        //        else
        //            dataByMonth.push(0);
        //    }

        //    vm.values.push(dataByMonth);
        //}

        function group(year) {

            var dataByYear = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];



            for (var i = 0; i < vm.months.length; i++) {
                for (var j = 0; j < vm.payments.length; j++) {
                    if (vm.months[i] == vm.payments[j].month && vm.payments[j].year == year) {
                        dataByYear[i] = vm.payments[j].value;
                    }
                    //else if (vm.payments[j].year == year) {
                    //    dataByYear.push(0);
                    //}
                }
            }





            //for (var i = 0; i < vm.payments.length; i++) {
            //    if (vm.payments[i].year == year)
            //        dataByYear.push(vm.payments[i].value);
            //}

            vm.values.push(dataByYear);
            console.log('dados');
            console.log(vm.values);
        }

        function contains(obj) {
            var i = vm.payments.length;
            while (i--) {
                if (vm.years[i] === obj) {
                    return true;
                }
            }
            return false;
        }

        function getAmountVideo() {
            vm.filter.id = vm.employee.idCompany;
            VideoFactory.getCountCompany(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                console.log(response);
                vm.amountVideo = response;
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

        function getByRangePayment(skip) {
            vm.filter.skip = skip;
            vm.filter.id = vm.employee.idCompany;
            console.log(vm.filter);
            PaymentByCompanyFactory.getByRangeCompanyComplement(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.payments = response;
                payment();
                groupByYear();
                getAmountVideo();
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

        function getByRangeBalance(skip) {
            vm.filter.skip = skip;
            vm.filter.id = vm.employee.idCompany;
            BalanceFactory.getByRange(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.balances = response;
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

        function getEmployeeLogado() {
            EmployeeFactory.getByEmail($rootScope.user.email)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.employee = response;
                getByRangeBalance(vm.filter.skip);
                getByRangePayment(vm.filter.skip);
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
    };

})();