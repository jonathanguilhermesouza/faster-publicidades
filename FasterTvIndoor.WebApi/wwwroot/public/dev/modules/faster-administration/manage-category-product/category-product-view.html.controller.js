(function () {

    'use strict';

    angular.module('fasterAdministration').controller('ViewCategoryProductCtrl', ViewCategoryProductCtrl);

    ViewCategoryProductCtrl.$inject = ['$rootScope', '$location', '$routeParams', 'CategoryProductFactory', 'EmployeeFactory'];

    function ViewCategoryProductCtrl($rootScope, $location, $routeParams, CategoryProductFactory, EmployeeFactory) {
        var vm = this;
        var erros = false;
        vm.categories = [];
        vm.category = {
            id: 0,
            category: ''
        }
        var id = $routeParams.id;

        vm.save = save;

        activate();

        function activate() {
            $rootScope.authenticate = true;
            getCategoryById();
        }

        function getCategoryById() {
            CategoryProductFactory.getById(id)
                 .success(success)
                 .catch(fail);

            function success(response) {
                vm.category = response;
            }

            function fail(error) {
                toastr.error('Sua requisição não pode ser processada', 'Falha na Requisição');
            }
            clearCategoryProducts();
        }
        function clearCategoryProducts() {
            vm.category = {
                id: 0,
                category: ''
            };
        }

        function save() {
            CategoryProductFactory.put(vm.category)
               .success(success)
               .catch(fail);

            function success(response) {
                toastr.success('Categoria <strong>' + vm.category.category + '</strong> cadastrada com sucesso', 'Categoria Cadastrada');
                $location.path('/category');
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