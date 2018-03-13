(function () {
    'use strict'

    angular.module('faster').controller('CreateEmployeeCtrl', CreateEmployeeCtrl);

    CreateEmployeeCtrl.$inject = ['$rootScope', '$location', 'EmployeeFactory'];

    function CreateCompanyCtrl($rootScope, $location, EmployeeFactory) {
        var vm = this;
        var errors = false;//variável para identificar se tenho erro no formulário

        //Declararações de objetos do tipo json       
        vm.employee = {
            name:'',
            cpf: ''
        };

        //Declarações de Funções
        vm.save = save;
        vm.cancel = cancel;        
      
        
        activate();

        function activate()
        {            
        }   

        function save() {
            console.log(vm.employee);
            EmployeeFactory.post(vm.employee)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('Empresa <strong>' + response.name + '</strong> cadastrada com sucesso', 'Empresa Cadastrada');
                $location.path('/company/active/');
            }

            function fail(error) {
                console.log(error.data.errors);
                if (error.status == 401)
                    toastr.error('Você não tem permissão para ver esta página', 'Requisição não autorizada');
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Cadastro sem sucesso!</strong>');
                    });
                }
                errors = true;
            }
        }

        function cancel() {
            clearCompany();
            $location.path('/company/active/');
        }

        
    };

})();