(function () {
    'use strict'

    //Ac = Accordion

    angular.module('fasterClient').controller('AcMenuClientCtrl', AcMenuClientCtrl);

    AcMenuClientCtrl.$inject = ['$rootScope', '$scope', '$location'];

    function AcMenuClientCtrl($rootScope, $scope, $location) {

        $scope.oneAtATime = true;
        $scope.changeRoute = changeRoute;

        console.log("Teste");
        console.log($rootScope.menuAdm);

        $scope.status = {
            isFirstOpen: true,
            isFirstDisabled: false
        };

        function changeRoute(route) {
            $location.path(route);            
        }

    };

})();