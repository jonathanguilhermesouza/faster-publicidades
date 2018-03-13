(function () {

    'use strict';

    angular.module('fasterVideoPlayer').config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                controller: 'PlayerCtrl',
                controllerAs: 'vm',
                templateUrl: 'player/player.html',
                authorize: true,
                menuAdm: false
            })
            .when('/login', {
                controller: 'LoginCtrl',
                controllerAs: 'vm',
                templateUrl: 'modules/account/login.view.html',
                authorize: true
            })
            .when('/register', {
                controller: 'RegisterCtrl',
                controllerAs: 'vm',
                templateUrl: 'modules/account/register.view.html'
            })
            .when('/logout', {
                controller: 'LogoutCtrl',
                controllerAs: 'vm',
                templateUrl: 'modules/account/login.view.html'
            })
    });

})();