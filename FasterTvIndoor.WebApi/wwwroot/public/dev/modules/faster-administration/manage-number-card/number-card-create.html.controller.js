(function () {

    'use strict';

    angular.module('fasterAdministration').controller('CreateCardCtrl', CreateCardCtrl);

    CreateCardCtrl.$inject = ['$rootScope', '$location', 'CardFactory'];

    function CreateCardCtrl($rootScope, $location, CardFactory) {

        var vm = this;

        vm.card = {
            start:0,
            end:0
        };
        var errors = false;

        activate();

        vm.save = save;
        vm.cancel = cancel;

        function activate() {

        }

        function save() {
            CardFactory.post(vm.card)
                .success(success)
                .catch(fail);
            function success(response) {
                toastr.success('Cadastro de comandas com sucesso', 'Cadastrado de comandas');
                redirect();
            }
            function fail(error) {
                if (error.status == 401)
                    toastr.error('Você não tem permissão para ver esta página', 'Requisição não autorizada');
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Não foi possível Completar o cadastro!</strong>');
                    });
                }
                errors = true;
            }
        }
        function cancel() {
        }

    };

})();