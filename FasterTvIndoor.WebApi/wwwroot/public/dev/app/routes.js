(function () {
    'use strict';
    angular.module('faster').config(function ($routeProvider) {
        $routeProvider
            //Comentado inicialmente
            //.when('/', {
            //    controller: 'ViewStoreFrontCtrl',
            //    controllerAs: 'vm',
            //    templateUrl: 'modules/storefront/home/store-front-view.html',
            //    authorize: true
            //})
            .when('/', {
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
            .when('/plan', {
                controller: 'ListPlanCtrl',
                controllerAs: 'vm',
                templateUrl: 'modules/client/navbar/plan.html'
            });
    });

})();