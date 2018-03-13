(function () {

    'use strict';

    angular.module('fasterAdministration').controller('CreatePlanCtrl', CreatePlanCtrl);

    CreatePlanCtrl.$inject = ['$location', 'PlanFactory', 'RedirectUserService'];

    function CreatePlanCtrl($location, PlanFactory, RedirectUserService) {

        var vm = this;
        var errors = false;

        vm.errors = [];
        vm.plan = {
            value: 0,
            description: '',
        };


        activate();

        vm.save = save;
        vm.cancel = cancel;
        vm.clearError = clearError;

        function activate() {
        }

        function save() {
            PlanFactory.post(vm.plan)
                .success(success)
                .catch(fail);
            function success(response) {
                toastr.success('Plano cadastrado com sucesso', 'Plano Cadastrado');
                $location.path('/plan');
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
                value: 0,
                description : ''
            }
        }
    };

})();