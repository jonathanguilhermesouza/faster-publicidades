(function () {
    'use strict'

    angular.module('faster').directive('acMenuAdm', function () {


        return {
            templateUrl: 'components/ac.menu-left/ac.menu-left.html',
            //templateUrl: 'modules/faster-administration/components/ac.menu-left/ac.menu-left.html',
            controller: 'AcMenuAdmCtrl',
            scope: {},
            restrict: 'E'
        };

    });
})();