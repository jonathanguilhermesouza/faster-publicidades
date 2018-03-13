(function () {
    'use strict'

    angular.module('faster').directive('acMenuClient', function () {


        return {
            templateUrl: 'components/ac.menu-left/ac.menu-left.html',
            //templateUrl: 'modules/faster-administration/components/ac.menu-left/ac.menu-left.html',
            controller: 'AcMenuClientCtrl',
            scope: {},
            restrict: 'E'
        };

    });
})();