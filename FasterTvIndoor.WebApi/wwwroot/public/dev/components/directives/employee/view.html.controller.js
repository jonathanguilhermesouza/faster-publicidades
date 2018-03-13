(function () {
    'use strict';
    angular.module('faster').controller('ViewEmployeeCtrl', ViewEmployeeCtrl);

    ViewEmployeeCtrl.$inject = ['$rootScope', '$location', '$routeParams', 'EmployeeFactory'];

    function ViewEmployeeCtrl($rootScope, $location, $routeParams, EmployeeFactory) {
        var vm = this;
        var id = $routeParams.id;
        var errors = false;//variável para identificar se tenho erro no formulário

        //Declararações de objetos do tipo json
        vm.employe = {
            name: '',
            cpf: ''
        };

        activate();

        function activate() {  
            getCount(id);            
        }

        function getCount(id) {
            console.log(id);
            EmployeeFactory.getCountEmployee(id)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.amountEmployee = response;
            }

            function fail(error) {
                toastr.error(error.data.error_description, 'Falha ao listar as empresas Matriz');
            }
        }

    };
})();