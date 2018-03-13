(function () {

    'use strict';

    angular.module('fasterClient').controller('ListPlanCtrl', ListPlanCtrl);

    ListPlanCtrl.$inject = ['$location', 'PlanFactory', 'RedirectUserService'];

    function ListPlanCtrl($location, PlanFactory, RedirectUserService) {

        var vm = this;
        vm.plans = [];
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = { skip: 1, status: 1, word: null };

        vm.range = range;
        vm.getByRangePlan = getByRangePlan;

        activate();

        function range(n) {
            return new Array(n);
        }

        activate();

        function activate() {
            getByRangePlan(vm.filter.skip);
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
    };

})();