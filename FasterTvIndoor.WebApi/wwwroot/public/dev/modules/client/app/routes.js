(function () {
    'use strict';
    angular.module('fasterClient').config(function ($routeProvider) {
        $routeProvider
            //.when('/', {
            //    controller: 'ViewHomeFasterCtrl',
            //    controllerAs: 'vm',
            //    templateUrl: 'home/client-index.html',
            //    authorize: true,
            //    menuAdm:false
            //})
            .when('/', {
                controller: 'ListBalanceCtrl',
                controllerAs: 'vm',
                templateUrl: 'balance/balance-index.html',
                menuAdm: false
            })
            .when('/login', {
                controller: 'LoginCtrl',
                controllerAs: 'vm',
                templateUrl: '../account/login.view.html',
                authorize: true,
                menuAdm: false
            })
            .when('/register', {
                controller: 'RegisterCtrl',
                controllerAs: 'vm',
                templateUrl: 'modules/account/register.view.html',
                menuAdm: false
            })
            .when('/logout', {
                controller: 'LogoutCtrl',
                controllerAs: 'vm',
                templateUrl: '../account/login.view.html',
                menuAdm: false
            })
            .when('/balance', {
                controller: 'ListBalanceCtrl',
                controllerAs: 'vm',
                templateUrl: 'balance/balance-index.html',
                menuAdm: true
            })
            .when('/history', {
                controller: 'ListHistoryEquipmentCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-history-equipment/history/history-index.html',
                menuAdm: true
            })
            .when('/history-payment', {
                controller: 'ListHistoryPaymentCompanyCtrl',
                controllerAs: 'vm',
                templateUrl: 'history-payment-company/payment/payment-index.html',
                menuAdm: true
            })
            .when('/video-equipment-company', {
                controller: 'ListVideoCompanyCtrl',
                controllerAs: 'vm',
                templateUrl: 'video/video-index.html',
                menuAdm: true
            })
            .when('/feature', {
                controller: 'ListFeaturesCtrl',
                controllerAs: 'vm',
                templateUrl: 'navbar/feature.html',
                menuAdm: false
            })
            .when('/contact', {
                controller: 'ListContactCtrl',
                controllerAs: 'vm',
                templateUrl: 'navbar/contact.html',
                menuAdm: false
            })
            .when('/plan', {
                controller: 'ListPlanCtrl',
                controllerAs: 'vm',
                templateUrl: 'navbar/plan.html',
                menuAdm: false
            })
             .when('/configuration', {
                 controller: 'ViewConfigurationCtrl',
                 controllerAs: 'vm',
                 templateUrl: 'configuration/configuration-view.html',
                 authorize: true,
                 menuAdm: true
             })
            .when('/history-month-current', {
                controller: 'ListHistoryMonthCurrentCtrl',
                controllerAs: 'vm',
                templateUrl: 'history-month-current/history-index.html',
                authorize: true,
                menuAdm: true
            });
    });

})();