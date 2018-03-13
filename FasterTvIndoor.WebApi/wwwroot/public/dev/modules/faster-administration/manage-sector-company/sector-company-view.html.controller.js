(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ViewSectorCompanyCtrl', ViewSectorCompanyCtrl);

    ViewSectorCompanyCtrl.$inject = ['$location', '$routeParams', 'SectorCompanyFactory'];

    function ViewSectorCompanyCtrl($location, $routeParams, SectorCompanyFactory) {

        var vm = this;
        var errors = false;

        vm.sectorCompany = {
            idSectorCompany: 0,
            sector: ''
        }
        var id = $routeParams.id;

        vm.save = save;

        activate();

        function activate() {
            getSectorCompanyById();
        }

        function getSectorCompanyById() {
            SectorCompanyFactory.getById(id)
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.sectorCompany = response;
            }

            function fail(error) {
                toastr.error('Sua requisição não pode ser processada', 'Falha na Requisição');
            }
            clearSectorCompany();
        }

        function clearSectorCompany() {
            vm.sectorCompany = {
                idSectorCompany: 0,
                sector: ''
            };
        }

        function save() {
            SectorCompanyFactory.put(vm.sectorCompany)
               .success(success)
               .catch(fail);

            function success(response) {
                toastr.success('Setor <strong>' + vm.sectorCompany.sector + '</strong> alterado com sucesso', 'Categoria Cadastrada');
                $location.path('/sector');
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
    };
})();