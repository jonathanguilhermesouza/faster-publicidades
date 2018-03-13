(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ListTimeVideoCtrl', ListTimeVideoCtrl);

    ListTimeVideoCtrl.$inject = ['TimeVideoFactory', 'RedirectUserService'];

    function ListTimeVideoCtrl(TimeVideoFactory, RedirectUserService) {

        var vm = this;

        vm.timesVideo = [];
        vm.timeVideo = {};
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = { skip: 1, status: 1, word: null };

        vm.range = range;
        vm.getByRangeTimeVideo = getByRangeTimeVideo;
        vm.remove = remove;

        activate();

        function range(n) {
            return new Array(n);
        }

        function activate() {
            getCountTimeVideo();
            getByRangeTimeVideo(vm.filter.skip);
        }

        function getCountTimeVideo() {
            TimeVideoFactory.getCount(vm.filter)
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

        function getByRangeTimeVideo(skip) {
            vm.filter.skip = skip;
            TimeVideoFactory.getByRange(vm.filter)
                .success(success)
                .catch(fail);

            function success(response) {
                vm.timesVideo = response;
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

        function remove(time) {
            loadTimeVideo(time);
            TimeVideoFactory.remove(vm.timeVideo)
               .success(success)
               .catch(fail);

            function success(response) {
                toastr.success('Tempo <strong>' + response.time + '</strong> removido com sucesso', 'Sucesso');
                var index = vm.timesVideo.indexOf(time);
                vm.timesVideo.splice(index, 1);
                getCountTimeVideo();

                if (vm.filter.skip > 1 && vm.timesVideo.length == 0)
                    getByRangeTimeVideo(vm.filter.skip - 1);
                else
                    getByRangeTimeVideo(vm.filter.skip);
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
            clearTimeVideo();
        }
        function loadTimeVideo(time) {
            vm.timeVideo = time;
        }

        function clearTimeVideo() {
            vm.timesVideo = {
                idTimeVideo: 0,
                time: ''
            }
        }
    };

})();