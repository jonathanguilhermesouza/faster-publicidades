(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ListTypeEquipmentCtrl', ListTypeEquipmentCtrl);

    ListTypeEquipmentCtrl.$inject = ['TypeEquipmentFactory', 'RedirectUserService'];

    function ListTypeEquipmentCtrl(TypeEquipmentFactory, RedirectUserService) {

        var vm = this;         

        vm.typeEquipment = {
            type: ''
        };
        vm.typesEquipment = [];
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = { skip: 1, word: null };

        vm.range = range;
        vm.getAllTypeEquipment = getAllTypeEquipment;

        activate();       

        function activate() {                    
            getAllTypeEquipment(vm.filter.skip);
            getCountTypeEquipment();
        }

        function range(n) {
            return new Array(n);
        }

        function getCountTypeEquipment() {
            TypeEquipmentFactory.getCount()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.pagination.qtdPages = Math.ceil(response / vm.pagination.take);
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex(error);
                }
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao salvar dados!</strong>');
                    });
                }
            }
        }

        function getAllTypeEquipment(skip) {
            vm.filter.skip = skip;
            TypeEquipmentFactory.getByRange(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.typesEquipment = response;
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex(error);
                }
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao salvar dados!</strong>');
                    });
                }
            }
        }       

        function clearTypeEquipment() {
            vm.typeEquipment = {
                type: ''
            };
        }       
    };

})();