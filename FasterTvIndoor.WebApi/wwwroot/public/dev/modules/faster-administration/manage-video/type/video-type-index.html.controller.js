(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ListTypeVideoCtrl', ListTypeVideoCtrl);

    ListTypeVideoCtrl.$inject = ['TypeVideoFactory', 'RedirectUserService'];

    function ListTypeVideoCtrl(TypeVideoFactory, RedirectUserService) {

        var vm = this;         

        vm.typeVideo = {
            type: ''
        };
        vm.typesVideo = [];
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = { skip: 1, word: null };

        vm.range = range;
        vm.getAllTypeVideo = getAllTypeVideo;

        activate();       

        function activate() {                    
            getAllTypeVideo(vm.filter.skip);
            getCountTypeVideo();
        }

        function range(n) {
            return new Array(n);
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

        function getAllTypeVideo(skip) {
            vm.filter.skip = skip;
            TypeVideoFactory.getByRange(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.typesVideo = response;
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

        function clearTypeVideo() {
            vm.typeVideo = {
                type: ''
            };
        }       
    };

})();