(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ViewPlanCtrl', ViewPlanCtrl);

    ViewPlanCtrl.$inject = ['$filter', '$routeParams', 'PlanFactory', 'RedirectUserService'];

    function ViewPlanCtrl($filter, $routeParams, PlanFactory, RedirectUserService) {

        var vm = this;
        var id = $routeParams.id;
        var errors = false;//variável para identificar se tenho erro no formulário

        vm.plan = {
            idPlan: 0,
            value: 0,
            description: '',
            amountTv: 0,
            title:''
        };

        vm.save = save;

        activate();

        function activate() {
            getByIdPlan();
        }

        function getByIdPlan() {
            PlanFactory.getById(id)
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.plan = response;
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
            clearPlan();
        }

        function save() {
            PlanFactory.put(vm.plan)
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

        function clearPlan() {
            vm.plan = {
                idPlan: 0,
                value: 0,
                description: '',
                amountTv: 0,
                title: ''
            };
        }
    };
})();