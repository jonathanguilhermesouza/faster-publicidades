(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ListPaymentCompanyCtrl', ListPaymentCompanyCtrl);

    ListPaymentCompanyCtrl.$inject = ['$location', 'PaymentFactory', 'RedirectUserService'];

    function ListPaymentCompanyCtrl($location, PaymentFactory, RedirectUserService) {

        var vm = this;

        vm.payments = [];
        vm.payment = {
            idCompany: 0,
            description: '',
            datePayment: new Date(),
            value: null,
            company: {}
        }
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = {
            skip: 1,
            word: null,
            status: 1
        };
        vm.range = range;
        vm.getByRangePayment = getByRangePayment;
        vm.removePayment = removePayment;
        vm.searchPayment = searchPayment;

        activate();

        function range(n) {
            return new Array(n);
        }

        function activate() {
            getCountPayment();
            getByRangePayment(vm.filter.skip);
        }

        function getCountPayment() {
            PaymentFactory.getCount(vm.filter)
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

        function getByRangePayment(skip) {
            vm.filter.skip = skip;
            PaymentFactory.getByRange(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                console.log(response);
                vm.payments = response;
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

        function searchPayment() {
            if (vm.filter.word == '')
                vm.filter.word = null;

            getByRangePayment(vm.filter.skip);
            getCountPayment();
        }

        function removePayment(payment) {
            loadPayment(payment);
            PaymentFactory.remove(vm.payment)
               .success(success)
               .catch(fail);

            function success(response) {
                toastr.success('Pagamento <strong>' + response.datePayment + '</strong> removido com sucesso', 'Sucesso');
                var index = vm.payments.indexOf(payment);
                vm.payments.splice(index, 1);

                getCountPayment();

                if (vm.filter.skip > 1 && vm.payments.length == 0)
                    getByRangePayment(vm.filter.skip - 1);
                else
                    getByRangePayment(vm.filter.skip);
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
            clearPayment();

        }
        function loadPayment(payment) {
            vm.payment = payment;
        }

        function clearPayment() {
            vm.payment = {
                idCompany: 0,
                description: '',
                datePayment: '',
                value: null,
                company: {}
            }
        }

    };

})();