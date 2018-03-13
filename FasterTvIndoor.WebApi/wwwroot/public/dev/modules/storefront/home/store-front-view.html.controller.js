(function () {

    'use strict';

    angular.module('faster').controller('ViewStoreFrontCtrl', ViewStoreFrontCtrl);

    ViewStoreFrontCtrl.$inject = [];

    function ViewStoreFrontCtrl() {

        var vm = this;
       
        vm.storeFront = 'Store Front';
    }

})();