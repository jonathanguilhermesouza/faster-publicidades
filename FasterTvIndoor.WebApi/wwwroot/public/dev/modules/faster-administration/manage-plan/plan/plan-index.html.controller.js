(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ListPlanCtrl', ListPlanCtrl);

    ListPlanCtrl.$inject = ['PlanFactory', 'RedirectUserService'];

    function ListPlanCtrl(PlanFactory, RedirectUserService) {

        var vm = this;

        vm.plans = [];
        vm.plan = {};
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = { skip: 1, status: 1, word: null };

        vm.range = range;
        vm.getByRangePlan = getByRangePlan;
        vm.remove = remove;

        activate();

        function range(n) {
            return new Array(n);
        }

        function activate() {
            getCountPlan();
            getByRangePlan(vm.filter.skip);
        }

        function getCountPlan() {
            PlanFactory.getCount(vm.filter)
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

        function getByRangePlan(skip) {
            vm.filter.skip = skip;
            PlanFactory.getByRange(vm.filter)
                .success(success)
                .catch(fail);

            function success(response) {
                vm.plans = response;
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

        function remove(plan) {
            loadPlan(plan);
            PlanFactory.remove(vm.plan)
               .success(success)
               .catch(fail);

            function success(response) {
                toastr.success('Plano removido com sucesso', 'Sucesso');
                var index = vm.plans.indexOf(plan);
                vm.plans.splice(index, 1);
                getCountPlan();

                if (vm.filter.skip > 1 && vm.plans.length == 0)
                    getByRangePlan(vm.filter.skip - 1);
                else
                    getByRangePlan(vm.filter.skip);
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
            clearPlan();
        }
        function loadPlan(plan) {
            vm.plan = plan;
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