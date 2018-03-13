(function () {

    'use strict';

    angular.module('fasterBackOffice').config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                controller: 'ViewHomeFasterCtrl',
                controllerAs: 'vm',
                templateUrl: 'home/index.html',
                authorize: true,
                menuAdm:false
            })
            .when('/login', {
                controller: 'LoginCtrl',
                controllerAs: 'vm',
                templateUrl: '../account/login.view.html',
                authorize: true,
                menuAdm: false
            })
            .when('/logout', {
                controller: 'LogoutCtrl',
                controllerAs: 'vm',
                templateUrl: '../account/login.view.html',
                menuAdm: false
            })
    });

})();