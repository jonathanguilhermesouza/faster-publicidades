(function () {

    'use strict';

    angular.module('fasterAdministration').controller('CreateTypeVideoCtrl', CreateTypeVideoCtrl);

    CreateTypeVideoCtrl.$inject = ['$rootScope', '$location', 'TypeVideoFactory', 'RedirectUserService'];

    function CreateTypeVideoCtrl($rootScope, $location, TypeVideoFactory, RedirectUserService) {

        var vm = this;
        var errors = false;//variável para identificar se tenho erro no formulário

        vm.errors = [];
        vm.typeVideo = {
            idTypeVideo: 0,
            type: ''
        };

        vm.filter = { skip: 1, word: null };
        vm.save = save;
        vm.cancel = cancel;
        vm.clearError = clearError;

        activate();

        function activate() {
        }        

        function save() {
            TypeVideoFactory.post(vm.typeVideo)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('Tipo de Video <strong>' + response.type + '</strong> cadastrado com sucesso', 'Tipo Cadastrado');
                $location.path('/type-video/view/' + response.idTypeVideo);                
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex(error);
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
            clearTypeVideo();
            $location.path('/type-video/');
        }

        function clearError(error) {
            var index = vm.errors.indexOf(error);
            vm.errors.splice(index, 1);
        }

        function clearTypeVideo() {
            vm.typeVideo = {
                idTypeVideo: 0,
                type: ''
            };
        }
    };

})();