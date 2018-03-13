(function () {

    'use strict';

    angular.module('fasterAdministration').controller('CreatePaymentCompanyCtrl', CreatePaymentCompanyCtrl);

    CreatePaymentCompanyCtrl.$inject = ['$rootScope', '$location', 'PaymentFactory', 'RedirectUserService'];

    function CreatePaymentCompanyCtrl($rootScope, $location, PaymentFactory, RedirectUserService) {
        var vm = this;

        var errors = false;
        var companyPayment = null;

        vm.errors = [];
        vm.payment = {
            idCompany: 0,
            description: '',
            datePayment: new Date(),
            value: null,
            company: {}
        };

        vm.save = save;
        vm.cancel = cancel;
        vm.clearError = clearError;
        vm.setCompany = setCompany;

        activate();

        function activate() {
        }

        function save() {
            PaymentFactory.post(vm.payment)
				.success(success)
				.catch(fail);

            function success(response) {
                clearPayment();
                toastr.success('Pagamento cadastrado com sucesso', 'Pagamento Cadastrado');
                $location.path('/payment');
            }
            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex();
                }
                else {
                    vm.errors = angular.fromJson(error.data.errors);
                    angular.forEach(vm.errors, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao salvar dados!</strong>');
                    });
                }
                errors = true;
            }

        }

        function setCompany(company) {
            companyPayment = company;
            if (company != null) {
                vm.payment.idCompany = company.idCompany;
                vm.payment.company.fantasyName = company.fantasyName;
                return vm.payment.company.fantasyName;
            } else {
                return vm.payment.company.fantasyName;
            }
        }

        function cancel() {
            clearPayment();
            $location.path('/category');
        }

        function clearError(error) {
            var index = vm.errors.indexOf(error);
            vm.errors.splice(index, 1);
        }

        function clearPayment() {
            if (companyPayment = ! null) {
                $rootScope.clearCompany();
            }
            vm.category = {
                idCompany: 0,
                description: '',
                datePayment: null,
                value: 0,
                company: {}
            }
        }
    }
})();