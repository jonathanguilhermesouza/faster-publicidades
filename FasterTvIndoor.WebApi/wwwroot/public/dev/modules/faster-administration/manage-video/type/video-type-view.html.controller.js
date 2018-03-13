(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ViewTypeVideoCtrl', ViewTypeVideoCtrl);

    ViewTypeVideoCtrl.$inject = ['$routeParams', 'TypeVideoFactory', 'RedirectUserService'];

    function ViewTypeVideoCtrl($routeParams, TypeVideoFactory, RedirectUserService) {

        var vm = this;
        var id = $routeParams.id;
        var errors = false;//variável para identificar se tenho erro no formulário


        vm.typeVideo = {
            type: ''
        };
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = { skip: 1, word: null };

        vm.save = save;

        activate();

        function activate() {
            getCountTypeVideo();
            getTypeVideo();
        }

        function getCountTypeVideo() {
            TypeVideoFactory.getCount(vm.filter)
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

        function getTypeVideo() {
            TypeVideoFactory.getById(id)
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.typeVideo = response;
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
                errors = true;
            }
        }

        function cancel() {
            clearTypeVideo();
        }

        function save() {
            TypeVideoFactory.put(vm.typeVideo)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Tipo <strong>' + response.type + '</strong> alterado com sucesso', 'Atualização com sucesso');
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
                errors = true;
            }
        }

        function clearTypeVideo() {
            vm.typeVideo = {
                type: ''
            };
        }

    };
})();