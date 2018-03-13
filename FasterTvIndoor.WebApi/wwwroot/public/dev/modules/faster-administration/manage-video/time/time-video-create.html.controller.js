(function () {

    'use strict';

    angular.module('fasterAdministration').controller('CreateTimeVideoCtrl', CreateTimeVideoCtrl);

    CreateTimeVideoCtrl.$inject = ['$location', 'TimeVideoFactory', 'RedirectUserService'];

    function CreateTimeVideoCtrl($location, TimeVideoFactory, RedirectUserService) {

        var vm = this;
        var errors = false;

        vm.errors = [];
        vm.timeVideo = {
            time:null
        };

        activate();

        vm.save = save;
        vm.cancel = cancel;
        vm.clearError = clearError;

        function activate() {
        }

        function save() {
            TimeVideoFactory.post(vm.timeVideo)
                .success(success)
                .catch(fail);
            function success(response) {
                toastr.success('Tmepo <strong>' + vm.timeVideo.time + '</strong> cadastrado com sucesso', 'Tempo Cadastrado');
                $location.path('/time-video');
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
            clearTimeVideo();
            $location.path('/time-video');
        }

        function clearError(error) {
            var index = vm.errors.indexOf(error);
            vm.errors.splice(index, 1);
        }

        function clearTimeVideo() {
            vm.timeVideo = {
                idTimeVideo: 0,
                time : ''
            }
        }
    };

})();