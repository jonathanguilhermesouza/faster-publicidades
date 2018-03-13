(function () {

    'use strict';

    angular.module('fasterBackOffice').controller('ViewHomeFasterCtrl', ViewHomeFasterCtrl)

    ViewHomeFasterCtrl.$inject = ['$rootScope', 'RedirectUserService'];

    function ViewHomeFasterCtrl($rootScope, RedirectUserService) {

        var vm = this;
        vm.title = "Meu Home Controller";

        activate();

        function activate() {
            if ($rootScope.user.profile != 'Administrador')
                RedirectUserService.redirectToIndex();

        }
    };

})();