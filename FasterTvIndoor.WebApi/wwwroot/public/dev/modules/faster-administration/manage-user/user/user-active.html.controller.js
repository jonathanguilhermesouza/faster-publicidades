(function () {

    'use strict';

    angular.module('fasterBackOffice').controller('ListEmployeeActiveCtrl', ListEmployeeActiveCtrl);

    ListEmployeeActiveCtrl.$inject = ['EmployeeFactory', 'RedirectUserService'];

    function ListEmployeeActiveCtrl(EmployeeFactory, RedirectUserService) {

        var vm = this;         

        vm.employees = [];
        vm.employee = {};
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
        vm.getByRangeEmployee = getByRangeEmployee;
        vm.removeEmployee = removeEmployee;
        vm.searchEmployee = searchEmployee;        

        activate();

        function activate() {                    
            getCountEmployee();
            getByRangeEmployee(vm.filter.skip);
        }

        function searchEmployee() {
            if (vm.filter.word == '')
                vm.filter.word = null;

            getCountEmployee();
            getByRangeEmployee(vm.filter.skip);
        }
      
        function range(n) {
            return new Array(n);
        }

        function getCountEmployee() {
            EmployeeFactory.getCount(vm.filter)
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
        
        function getByRangeEmployee(skip) {
            vm.filter.skip = skip;
            EmployeeFactory.getByRange(vm.filter)
                .success(success)
                .catch(fail);

            function success(response) {
                vm.employees = response;
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

        function removeEmployee(employee) {
            EmployeeFactory.remove(employee)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Funcionário <strong>' + employee.user.name + '</strong> removido com sucesso', 'Remoção com sucesso');
                var index = vm.employees.indexOf(employee);
                vm.employees.splice(index, 1);

                getCountEmployee();

                if (vm.filter.skip > 1 && vm.employees.length == 0)
                    getByRangeEmployee(vm.filter.skip - 1);
                else
                    getByRangeEmployee(vm.filter.skip);
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
        }

        function loadEquipment(equipment) {
            vm.equipment = equipment;
        }

        function clearEmployee() {
            vm.employee = {
                cpf: '',
                user: {
                    email: '',
                    password: '',
                    nickName: '',
                    idProfileUser: 0,
                    idStatusUser: 0
                },
                idSectorCompany: 0,
                idCompany: 0
            };
        }       
    };

})();