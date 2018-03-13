(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ViewPaymentCompanyCtrl', ViewPaymentCompanyCtrl);

    ViewPaymentCompanyCtrl.$inject = ['$filter', '$routeParams', 'PaymentFactory', 'RedirectUserService'];

    function ViewPaymentCompanyCtrl($filter, $routeParams, PaymentFactory, RedirectUserService) {

        var vm = this;
        var id = $routeParams.id;
        var errors = false;//variável para identificar se tenho erro no formulário

        vm.payment = {
            idCompany: 0,
            description: '',
            datePayment: new Date(),
            value: null,
            company: {}
        };

        vm.save = save;

        activate();

        function activate() {
            getByIdPayment();
        }

        function getByIdPayment() {
            PaymentFactory.getById(id)
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.payment = response;
                vm.payment.datePayment = new Date(response.datePayment);
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
                errors = true;
            }
        }

        function cancel() {
            clearPayment();
        }

        function save() {
            console.log(vm.payment);
            PaymentFactory.put(vm.payment)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Plano alterado com sucesso', 'Atualização com sucesso');
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex();
                }
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao salvar dados!</strong>');
                    });
                }
                errors = true;
            }
        }

        function clearPayment() {
            vm.payment = {
                idPaymentToCompany:0,
                idCompany: 0,
                description: '',
                datePayment: new Date(),
                value: null,
                company: {}
            };
        }
    };
})();