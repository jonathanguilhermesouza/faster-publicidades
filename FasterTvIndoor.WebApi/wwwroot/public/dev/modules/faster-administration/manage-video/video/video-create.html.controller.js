(function () {

    'use strict';

    angular.module('fasterAdministration').controller('CreateVideoCtrl', CreateVideoCtrl);

    CreateVideoCtrl.$inject = ['$location', '$rootScope', 'TypeVideoFactory', 'VideoCategoryFactory', 'TimeVideoFactory', 'VideoFactory', 'StatusVideoFactory', 'VideoEquipmentFactory', 'ControlLoanFactory', 'EquipmentFactory', 'PlanFactory', 'RedirectUserService'];

    function CreateVideoCtrl($location, $rootScope, TypeVideoFactory, VideoCategoryFactory, TimeVideoFactory, VideoFactory, StatusVideoFactory, VideoEquipmentFactory, ControlLoanFactory, EquipmentFactory,PlanFactory, RedirectUserService) {

        var vm = this;
        var errors = false;//variável para identificar se tenho erro no formulário

        vm.errors = [];
        vm.categoriesVideo = [];
        vm.controlsLoanEquipment = [];
        vm.statusVideo = [];
        vm.typesVideo = [];
        vm.equipments = [];
        vm.idEquipment = [];
        vm.plans = [];


        vm.equipment = {
            idVideo: 0,
            idEquipment: 0
        };
        vm.videoEquipment = [];

        //vm.videoEquipment = [];

        vm.clearError = clearError;
        vm.save = save;
        vm.cancel = cancel;
        vm.setCompany = setCompany;
        vm.checkEquipment = checkEquipment;
        //vm.saveListEquipment = saveListEquipment;

        vm.video = {
            idVideo: 0,
            idCompany: 0,
            idTypeVideo: 0,
            idCategoryVideo: 0,
            idPlan:0,
            url: '',
            time: '',
            tvAdditional: null,
            dateRegister: null,
            dateEnd: null,
            dateStart: null,
            typeVideo: null,
            company: {},
            categoryVideo: null,
            listVideoEquipment: []
        };
        vm.filter = {
            word: '',
            skip: '',
            take: '',
            status: ''
        };

        activate();

        function activate() {
            getAllStatusVideo();
            getAllTypesVideo();
            getAllTimesVideo();
            getAllCategoriesVideo();
            getAllEquipments();
            getAllControlsLoanEquipments();
            getAllPlans();
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

        function checkEquipment(loan) {
            for (var i = 0; vm.controlsLoanEquipment.length; i++) {
                if (vm.video.listVideoEquipment[i].idEquipment == loan.idEquipment)
                    return true;

            }

            return true;
        }

        function addVideoEquipmentList() {

            var idControlLoan = 0;


            //console.log(vm.idEquipment);
            for (var i = 0 ; i < vm.idEquipment.length; i++) {

                for (var j = 0; j < vm.controlsLoanEquipment.length; j++) {
                    if (vm.idEquipment[i] == vm.controlsLoanEquipment[j].idEquipment) {
                        idControlLoan = vm.controlsLoanEquipment[j].idControlLoan;
                        vm.equipment.idEquipment = vm.idEquipment[i];
                        vm.video.listVideoEquipment.push({ idVideo: 0, idEquipment: vm.equipment.idEquipment, idControlLoan: idControlLoan });

                        console.log(vm.video.listVideoEquipment);
                    }
                }
            }
            console.log(vm.video.listVideoEquipment);
            //alert('werwer');
            //VideoEquipmentFactory.post(vm.videoEquipment);
            //console.log(vm.videoEquipment);
        }

        function setCompany(company) {
            if (company != null) {
                vm.video.idCompany = company.idCompany;
                vm.video.company.companyName = company.companyName;
                //console.log(vm.video);
                return vm.video.company.companyName;
            } else {
                return vm.video.company.companyName;
            }
        }

        function getAllControlsLoanEquipments() {
            vm.filter.status = 1;
            vm.filter.word = 1;
            ControlLoanFactory.getAllControlLoanEquipment(vm.filter)
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

        function getAllTimesVideo() {
            TimeVideoFactory.getAll()
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
                errors = true;
            }
        }

        function getAllEquipments() {
            vm.filter.word = 'Tv';
            vm.filter.status = 1;
            vm.filter.skip = 1;
            vm.filter.take = 100;
            EquipmentFactory.getByRange(vm.filter)
            .success(success)
            .catch(fail);

            function success(response) {
                vm.equipments = response;
                console.log(vm.equipments);
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

        function getAllCategoriesVideo() {
            VideoCategoryFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.categoriesVideo = response;
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

        function getAllStatusVideo() {
            StatusVideoFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.statusVideo = response;
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

        function getAllTypesVideo() {
            TypeVideoFactory.getAll()
            .success(success)
            .catch(fail);

            function success(response) {
                vm.typesVideo = response;
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

        function save() {
            if (vm.video.tvAdditional == null)
                vm.video.tvAdditional = 0;

            addVideoEquipmentList();
            VideoFactory.post(vm.video)
                .success(success)
                .catch(fail);

            function success(response) {
                toastr.success('Video <strong>' + response.url + '</strong> cadastrado com sucesso', 'Video Cadastrado');
                $rootScope.clearCompany();
                $location.path('/video/view/' + response.idVideo);
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
            clearVideo();
            $location.path('/company/active/');
        }

        function clearError(error) {
            var index = vm.errors.indexOf(error);
            vm.errors.splice(index, 1);
        }

        function clearVideo() {
            vm.video = {
                idVideo: 0,
                idCompany: 0,
                idTypeVideo: 0,
                idCategoryVideo: 0,
                url: '',
                time: '',
                status: '',
                tvAdditional: null,
                dateRegister: null,
                dateEnd: null,
                dateStart: null,
                typeVideo: null,
                company: null,
                categoryVideo: null,
                listVideoEquipment: null
            };
        }
    };

})();