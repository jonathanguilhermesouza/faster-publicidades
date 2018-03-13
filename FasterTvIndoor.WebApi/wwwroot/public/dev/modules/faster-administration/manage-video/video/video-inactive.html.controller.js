(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ListVideoInactiveCtrl', ListVideoInactiveCtrl);

    ListVideoInactiveCtrl.$inject = ['$location', '$rootScope', 'SETTINGS', 'CompanyFactory', 'VideoFactory', 'RedirectUserService'];

    function ListVideoInactiveCtrl($location, $rootScope, SETTINGS, CompanyFactory,VideoFactory, RedirectUserService) {

        var vm = this;

        vm.video = {
            idVideo: 0,
            idCompany: 0,
            idTypeVideo: 0,
            idCategoryVideo: 0,
            url: '',
            tvAdditional:null,
            time: '',
            status: '',
            dateRegister: null,
            dateEnd: null,
            typeVideo: null,
            company: null,
            categoryVideo: null,
            listVideoEquipment: null
        };
        vm.videos = [];
        vm.pagination = {
            take: 12,
            qtdPages: 0
        };
        vm.filter = {
            skip: 1,
            word: null,
            status: 2
        };

        vm.range = range;
        vm.getByRangeVideo = getByRangeVideo;
        vm.removeVideo = removeVideo;
        vm.searchVideo = searchVideo;

        activate();

        function activate() {
            getByRangeVideo(vm.filter.skip);
            getCountVideo();
        }

        function searchVideo() {
            if (vm.filter.word == '')
                vm.filter.word = null;

            getByRangeVideo(vm.filter.skip);
            getCountVideo();
        }

        function range(n) {
            return new Array(n);
        }

        function getCountVideo() {
            console.log(vm.filter);
            VideoFactory.getCount(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.pagination.qtdPages = Math.ceil(response / vm.pagination.take);
                console.log(response);
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

        function getByRangeVideo(skip) {
            vm.filter.skip = skip;
            VideoFactory.getByRange(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.videos = response;
            }

            function fail(error) {
                if (error.status == 401) {
                    RedirectUserService.redirectToIndex(error);
                }
                else {
                    var items = angular.fromJson(error.data.errors);
                    angular.forEach(items, function (value, key) {
                        toastr.warning(value.value, '<strong>Falha ao recuperar dados!</strong>');
                    });
                }
            }
        }

        function removeVideo(video) {
            loadVideo(video);
            VideoFactory.remove(vm.video)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Video <strong>' + video.url + '</strong> removido com sucesso', 'Remoção com Sucesso');

                var index = vm.videos.indexOf(video);
                vm.videos.splice(index, 1);

                getCountVideo();

                if (vm.filter.skip > 1 && vm.videos.length == 0)
                    getByRangeVideo(vm.filter.skip - 1);
                else
                    getByRangeVideo(vm.filter.skip);
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

            clearVideo();
        }

        function loadVideo(video) {
            vm.video = video;
        }

        function clearVideo() {
            vm.video = {
                idVideo: 0,
                idCompany: 0,
                idTypeVideo: 0,
                idCategoryVideo: 0,
                url: '',
                tvAdditional: null,
                time: '',
                status: '',
                dateRegister: null,
                dateEnd: null,
                typeVideo: null,
                company: null,
                categoryVideo: null,
                listVideoEquipment: null
            };
        }

    };


})();