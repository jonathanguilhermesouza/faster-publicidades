(function () {
    'use strict'

    //Ac = Accordion

    angular.module('faster').controller('AcMenuAdmCtrl', AcMenuAdmCtrl);

    AcMenuAdmCtrl.$inject = ['$rootScope', '$scope', '$location'];

    function AcMenuAdmCtrl($rootScope, $scope, $location) {

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