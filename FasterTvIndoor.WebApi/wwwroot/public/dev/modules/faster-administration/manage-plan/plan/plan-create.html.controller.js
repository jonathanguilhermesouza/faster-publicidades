(function () {

    'use strict';

    angular.module('fasterAdministration').controller('CreatePlanCtrl', CreatePlanCtrl);

    CreatePlanCtrl.$inject = ['$location', 'PlanFactory', 'RedirectUserService'];

    function CreatePlanCtrl($location, PlanFactory, RedirectUserService) {

        var vm = this;
        var errors = false;

        vm.errors = [];
        vm.plan = {
            valueEquipmentMain: null,
            valueEquipmentAdditional: null,
            valueUpdate: null,
            description: '',
            title: ''
        };

        activate();

        vm.save = save;
        vm.cancel = cancel;
        vm.clearError = clearError;

        function activate() {
        }

        function save() {
            if (vm.plan.valueEquipmentMain == null )
            vm.plan.valueEquipmentMain = 0;

            if (vm.plan.valueEquipmentAdditional == null)
                vm.plan.valueEquipmentAdditional = 0;

            if (vm.plan.valueEquipmentAdditional == null)
                vm.plan.valueUpdate = 0;

            PlanFactory.post(vm.plan)
                .success(success)
                .catch(fail);
            function success(response) {
                clearPlan();
                toastr.success('Plano cadastrado com sucesso', 'Plano Cadastrado');
                $location.path('/plan');
            }
            function fail(error) {
                clearPlan();
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

        function cancel() {
            clearPlan();
            $location.path('/plan');
        }

        function clearError(error) {
            var index = vm.errors.indexOf(error);
            vm.errors.splice(index, 1);
        }

        function clearPlan() {
            vm.plan = {
                idPlan: 0,
                valueEquipmentMain: null,
                valueEquipmentAdditional: null,
                valueUpdate: null,
                description: '',
                title: ''
            }
        }
    };

})();