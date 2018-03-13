(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ViewTimeVideoCtrl', ViewTimeVideoCtrl);

    ViewTimeVideoCtrl.$inject = ['$routeParams', 'TimeVideoFactory', 'RedirectUserService'];

    function ViewTimeVideoCtrl($routeParams, TimeVideoFactory, RedirectUserService) {

        var vm = this;

        vm.timeVideo = {
            idTimeVideo: 0,
            time: ''
        };
        var erros = false;
        var id = $routeParams.id;

        activate();

        vm.save = save;

        function activate() {
            getByIdTimeVideo();
        }

        function getByIdTimeVideo() {
            TimeVideoFactory.getById(id)
                .success(success)
                .catch(fail);

            function success(response) {
                vm.timeVideo = response;
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

        function save() {
            TimeVideoFactory.put(vm.timeVideo)
               .success(success)
               .catch(fail);
            function success(response) {
                toastr.success('Tempo <strong>' + vm.timeVideo.time + '</strong> atualizado com sucesso', 'Tempo atualizado');
            }
            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex();
                }
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao salvar dados!</strong>');
                    });
                }
                //errors = true;
                clear();
            }
        }

        function clear() {
            vm.timeVideo = {
                idTimeVideo: 0,
                time: ''
            }
        }

    }

})();