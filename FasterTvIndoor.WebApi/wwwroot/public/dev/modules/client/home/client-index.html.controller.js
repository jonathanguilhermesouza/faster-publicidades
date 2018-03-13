(function () {

    'use strict';

    angular.module('fasterClient').controller('ViewHomeFasterCtrl', ViewHomeFasterCtrl)

    ViewHomeFasterCtrl.$inject = ['$rootScope', 'BalanceFactory'];

    function ViewHomeFasterCtrl($rootScope, BalanceFactory) {

        var vm = this;

        vm.title = "Meu Home Controller";

        activate();

        function activate() {
        }
    };

})();