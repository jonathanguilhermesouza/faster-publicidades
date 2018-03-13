(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ViewVideoCtrl', ViewVideoCtrl);

    ViewVideoCtrl.$inject = ['$window', '$rootScope', '$filter', '$location', '$routeParams', 'TypeVideoFactory', 'TimeVideoFactory', 'VideoCategoryFactory', 'VideoFactory', 'StatusVideoFactory', 'ControlLoanFactory', 'VideoEquipmentFactory', 'PlanFactory', 'RedirectUserService'];

    function ViewVideoCtrl($window, $rootScope, $filter, $location, $routeParams, TypeVideoFactory, TimeVideoFactory, VideoCategoryFactory, VideoFactory, StatusVideoFactory, ControlLoanFactory, VideoEquipmentFactory, PlanFactory, RedirectUserService) {

        var vm = this;
        var id = $routeParams.id;
        var errors = false;//variável para identificar se tenho erro no formulário
        var idVideoEquipment = 0;

        vm.statusVideo = [{
            id: 0,
            name: ''
        }];

        vm.pagination = {
            take: 12,
            qtdPages: 0
        };

        vm.videoEquipment = {
            idVideo: 0,
            idEquipment: 0,
            idControlLoan: 0
        }
        vm.plans = [];
        vm.video = {
            idVideo: 0,
            idCompany: 0,
            idTypeVideo: 0,
            idCategoryVideo: 0,
            idPlan: 0,
            url: '',
            tvAdditional: 0,
            time: '',
            status: '',
            dateRegister: null,
            dateEnd: new Date(),
            dateStart: new Date(),
            typeVideo: null,
            company: null,
            categoryVideo: null,
            listVideoEquipment: null
        };

        vm.filter = {
            word: '',
            skip: '',
            take: '',
            status: '',
            video: 0,
            equipment: 0,
            controlLoan: 0
        };

        vm.categoryVideo = [];
        vm.typesVideo = [];
        vm.controlsLoanEquipment = [];
        vm.controlsLoanEquipmentTemp = [];

        vm.saveVideo = saveVideo;
        vm.showStatus = showStatus;
        vm.showTimeVideo = showTimeVideo;
        vm.showCategoryVideo = showCategoryVideo;
        vm.showTypeVideo = showTypeVideo;
        vm.showPlan = showPlan;
        vm.checkEquipment = checkEquipment;
        vm.removeVideoEquipment = removeVideoEquipment;
        vm.addVideoEquipment = addVideoEquipment;

        activate();

        function activate() {
            getAllStatusVideo();
            getAllTypesVideo();
            getAllCategoryVideo();
            getAllTimesVideo();
            getAllPlans();
            getByIdVideo();
            getAllControlsLoanEquipments();
        }

        function getAllPlans() {
            PlanFactory.getAll()
                .success(success)
                .catch(fail);

            function success(response) {
                vm.plans = response;
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

        function addVideoEquipment(loan) {
            vm.videoEquipment.idEquipment = loan.idEquipment;
            vm.videoEquipment.idVideo = id;
            vm.videoEquipment.idControlLoan = loan.idControlLoan;
            console.log(loan);
            VideoEquipmentFactory.post(vm.videoEquipment)
            .success(success)
            .catch(fail);

            function success(response) {
                toastr.success('Video ativado na tv selecionada com sucesso', 'Sucesso');
                $window.location.reload();
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
                errors = true;
            }
        }

        function removeVideoEquipment(loan) {
            vm.filter.equipment = loan.idEquipment;
            vm.filter.video = id;
            vm.filter.controlLoan = loan.idControlLoan;
            VideoEquipmentFactory.remove(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                toastr.success('Video desativado na tv selecionada com sucesso', 'Sucesso');
                getAllControlsLoanEquipments();
                $window.location.reload();
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
                errors = true;
            }
        }

        function showStatus(video) {
            var selected = [];
            var index = video.status;
            if (video.status) {
                selected = $filter('filter')(vm.statusVideo, { value: video.status.name });
            }
            return selected.length ? selected[index - 1].name : 'Vazio';
        };

        function showPlan(video) {
            var selected = [];
            var index = video.idPlan;
            if (video.idPlan) {
                selected = $filter('filter')(vm.plans, { value: video.idPlan.idPlan });
            }
            return selected.length ? selected[index - 1].description : 'Vazio';
        };

        function checkEquipment(idEquipment) {
            if (vm.video.listVideoEquipment != null)
                for (var i = 0; i < vm.video.listVideoEquipment.length; i++) {
                    if (idEquipment == vm.video.listVideoEquipment[i].idEquipment && vm.video.listVideoEquipment[i].status == 1) {
                        return true;
                    }
                }
        }

        function getIdVideoEquipment(idEquipment) {
            vm.filter.equipment = idEquipment;
            vm.filter.video = id;
            VideoEquipmentFactory.getIdVideoEquipment(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                idVideoEquipment = response.idVideoEquipment;
                alert('getIdVideoEquipment');
                alert(idVideoEquipment);
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
                errors = true;
            }
        }

        function getAllControlsLoanEquipments() {
            vm.filter.status = 1;
            vm.filter.word = 1;
            ControlLoanFactory.getAllControlLoanEquipmentByVideo(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.controlsLoanEquipment = response;
                console.log(vm.controlsLoanEquipment);
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
                errors = true;
            }
        }

        function showTimeVideo(video) {
            var selected = [];
            var index = video.idTimeVideo;
            if (video.idTimeVideo) {
                selected = $filter('filter')(vm.timesVideo, { value: video.timeVideo.timeVideo });
            }
            return selected.length ? selected[index - 1].time : 'Vazio';
        };

        function showCategoryVideo(video) {
            var selected = [];
            var index = video.idCategoryVideo;
            if (video.idCategoryVideo) {
                selected = $filter('filter')(vm.categoryVideo, { value: video.categoryVideo.categoryVideo });
            }
            return selected.length ? selected[index - 1].category : 'Vazio';
        };

        function showTypeVideo(video) {
            var selected = [];
            var index = video.idTypeVideo;
            if (video.idTypeVideo) {
                selected = $filter('filter')(vm.typesVideo, { value: video.typeVideo.typeVideo });
            }
            return selected.length ? selected[index - 1].type : 'Vazio';
        };


        function getAllTypesVideo() {
            TypeVideoFactory.getAll()
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
                        toastr.warning(value.value, '<strong>Falha ao recuperar dados!</strong>');
                    });
                }
                errors = true;
            }
        }

        function getAllTimesVideo() {
            TimeVideoFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.timesVideo = response;
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
                errors = true;
            }
        }

        function getAllStatusVideo() {
            StatusVideoFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.statusVideo = response;
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
                errors = true;
            }
        }

        function getAllCategoryVideo() {
            VideoCategoryFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                console.log(response);
                vm.categoryVideo = response;
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
                errors = true;
            }
        }

        function getByIdVideo() {
            VideoFactory.getById(id)
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.video = response;
                vm.video.dateEnd = new Date(response.dateEnd);
                vm.video.dateStart = new Date(response.dateStart);
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
                errors = true;
            }
        }

        function cancel() {
            clearVideo();
        }

        function saveVideo() {
            VideoFactory.put(vm.video)
                 .success(success)
                 .catch(fail);

            function success(response) {
                toastr.success('Video <strong>' + response.url + '</strong> alterado com sucesso', 'Atualização com sucesso');
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

        function clearVideo() {
            vm.video = {
                idVideo: 0,
                idCompany: 0,
                idTypeVideo: 0,
                idCategoryVideo: 0,
                url: '',
                tvAdditional: 0,
                time: '',
                status: '',
                dateRegister: null,
                dateEnd: new Date(),
                dateStart: new Date(),
                typeVideo: null,
                company: null,
                categoryVideo: null,
                listVideoEquipment: null
            };
        }

    };
})();