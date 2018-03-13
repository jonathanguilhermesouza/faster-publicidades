(function () {

    'use strict';

    angular.module('fasterAdministration').config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                controller: 'ViewHomeFasterCtrl',
                controllerAs: 'vm',
                templateUrl: 'home/faster-administration-index.html',
                authorize: true,
                menuAdm: false
            })
            .when('/logout', {
                controller: 'LogoutCtrl',
                controllerAs: 'vm',
                templateUrl: '../account/login.view.html',
                menuAdm: false
            })
            .when('/company/', {
                controller: 'GerenciarCompanyCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-company/index.html',
                authorize: true,
                menuAdm: true
            })
            .when('/company/active/', {
                controller: 'ListCompanyActiveCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-company/company/company-active.html',
                authorize: true,
                menuAdm: true
            })
            .when('/company/inactive/', {
                controller: 'ListInactiveCompanyCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-company/company/company-inactive.html',
                authorize: true,
                menuAdm: true
            })
            .when('/company/excluded/', {
                controller: 'ListExcludedCompanyCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-company/company/company-excluded.html',
                authorize: true,
                menuAdm: true
            })
            .when('/company/locked/', {
                controller: 'ListCompanyCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-company/company/company-active.html',
                authorize: true,
                menuAdm: true
            })
            .when('/company/create', {
                controller: 'CreateCompanyCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-company/company/company-create.html',
                authorize: true,
                menuAdm: true
            })
            .when('/company/edit/:id', {
                controller: 'EditCompanyCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-company/company/company-edit.html',
                authorize: true,
                menuAdm: true
            })
            .when('/company/view/:id', {
                controller: 'ViewCompanyCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-company/company/company-view.html',
                authorize: true,
                menuAdm: true
            })
            .when('/category', {
                controller: 'ListCategoryCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-category-product/category-product-index.html',
                authorize: true,
                menuAdm: true
            })
            .when('/category/create', {
                controller: 'CreateCategoryCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-category-product/category-product-create.html',
                authorize: true,
                menuAdm: true
            })
            .when('/category/edit/:id', {
                controller: 'EditCategoryCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-category-product/category-product-edit.html',
                authorize: true,
                menuAdm: true
            })
            .when('/category/view/:id', {
                controller: 'ViewCategoryProductCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-category-product/category-product-view.html',
                authorize: true,
                menuAdm: true
            })
            .when('/employee/create', {
                controller: 'CreateEmployeeCtrl',
                controllerAs: 'vm',
                templateUrl: '../back-office/manage-employee/employee/employee-create.html',
                authorize: true,
                menuAdm: true
            })
            .when('/employee/view/:id', {
                controller: 'ViewEmployeeCtrl',
                controllerAs: 'vm',
                templateUrl: '../back-office/manage-employee/employee/employee-view.html',
                authorize: true,
                menuAdm: true
            })
            .when('/employee/inactive', {
                controller: 'ListEmployeeInactiveCtrl',
                controllerAs: 'vm',
                templateUrl: '../back-office/manage-employee/employee/employee-inactive.html',
                authorize: true,
                menuAdm: true
            })
            .when('/employee/active', {
                controller: 'ListEmployeeActiveCtrl',
                controllerAs: 'vm',
                templateUrl: '../back-office/manage-employee/employee/employee-active.html',
                authorize: true,
                menuAdm: true
            })
            .when('/contract', {
                controller: 'ListContractCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-contract/contract/contract-index.html',
                authorize: true,
                menuAdm: true
            })
            .when('/contract/create', {
                controller: 'CreateContractCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-contract/contract/contract-create.html',
                authorize: true,
                menuAdm: true
            })
            .when('/sector', {
                controller: 'ListSectorCompanyCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-sector-company/sector-company-index.html',
                authorize: true,
                menuAdm: true
            })
            .when('/sector/create', {
                controller: 'CreateSectorCompanyCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-sector-company/sector-company-create.html',
                authorize: true,
                menuAdm: true
            })
            .when('/sector/view/:id', {
                controller: 'ViewSectorCompanyCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-sector-company/sector-company-view.html',
                authorize: true,
                menuAdm: true

            })
            .when('/profile', {
                controller: 'ListProfileCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-profile/profile-index.html',
                authorize: true,
                menuAdm: true
            })
            .when('/profile/create', {
                controller: 'CreateProfileCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-profile/profile-create.html',
                authorize: true,
                menuAdm: true
            })
            .when('/profile/view/:id', {
                controller: 'ViewProfileCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-profile/profile-view.html',
                authorize: true,
                menuAdm: true
            })
            .when('/equipment/create', {
                controller: 'CreateEquipmentCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-equipment/equipment/equipment-create.html',
                authorize: true,
                menuAdm: true
            })
            .when('/equipment/view/:id', {
                controller: 'ViewEquipmentCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-equipment/equipment/equipment-view.html',
                authorize: true,
                menuAdm: true
            })
            .when('/equipment/available', {
                controller: 'ListEquipmentAvailableCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-equipment/equipment/equipment-available.html',
                authorize: true,
                menuAdm: true
            })
            .when('/equipment/unavailable', {
                controller: 'ListEquipmentUnavailableCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-equipment/equipment/equipment-unavailable.html',
                authorize: true,
                menuAdm: true
            })
            .when('/equipment/inactive', {
                controller: 'ListEquipmentInactiveCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-equipment/equipment/equipment-inactive.html',
                authorize: true,
                menuAdm: true
            })
            .when('/equipment/support', {
                controller: 'ListEquipmentSupportCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-equipment/equipment/equipment-support.html',
                authorize: true,
                menuAdm: true
            })
            .when('/type-equipment', {
                controller: 'ListTypeEquipmentCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-equipment/equipment-type/equipment-type-index.html',
                authorize: true,
                menuAdm: true
            })
            .when('/type-equipment/create', {
                controller: 'CreateTypeEquipmentCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-equipment/equipment-type/equipment-type-create.html',
                authorize: true,
                menuAdm: true
            })
            .when('/type-equipment/edit/:id', {
                controller: 'EditTypeEquipmentCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-equipment/equipment-type/equipment-type-edit.html',
                authorize: true,
                menuAdm: true
            })
            .when('/type-equipment/view/:id', {
                controller: 'ViewTypeEquipmentCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-equipment/equipment-type/equipment-type-view.html',
                authorize: true,
                menuAdm: true
            })
            .when('/loan/open', {
                controller: 'ListLoanOpenCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-loan/loan/loan-open.html',
                authorize: true,
                menuAdm: true
            })
             .when('/loan/closed', {
                 controller: 'ListLoanClosedCtrl',
                 controllerAs: 'vm',
                 templateUrl: 'manage-loan/loan/loan-closed.html',
                 authorize: true,
                 menuAdm: true
             })
            .when('/loan/canceled', {
                controller: 'ListLoanCanceledCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-loan/loan/loan-canceled.html',
                authorize: true,
                menuAdm: true
            })
            .when('/loan/create', {
                controller: 'CreateLoanCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-loan/loan/loan-create.html',
                authorize: true,
                menuAdm: true
            })
            .when('/loan/view/:id', {
                controller: 'ViewControlLoanCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-loan/loan/loan-view.html',
                authorize: true,
                menuAdm: true
            })
            .when('/configuration/', {
                controller: 'ViewConfigurationCtrl',
                controllerAs: 'vm',
                templateUrl: '../client/configuration/configuration-view.html',
                authorize: true,
                menuAdm: true
            })
            .when('/card/', {
                controller: 'CreateCardCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-number-card/number-card-create.html',
                authorize: true,
                menuAdm: true
            })
            .when('/contract-current', {
                controller: 'ContractCurrentCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-contract/contract/contract-current.html',
                authorize: true,
                menuAdm: true
            })
            .when('/contract-closed', {
                controller: 'ContractClosedCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-contract/contract/contract-closed.html',
                authorize: true,
                menuAdm: true
            })
            .when('/contract-canceled', {
                controller: 'ContractCanceledCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-contract/contract/contract-canceled.html',
                authorize: true,
                menuAdm: true
            })
            .when('/contract-view/:id', {
                controller: 'ViewContractCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-contract/contract/contract-view.html',
                authorize: true,
                menuAdm: true
            })
            .when('/contract/create', {
                controller: 'CreateContractCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-contract/contract/contract-create.html',
                authorize: true,
                menuAdm: true
            })
            .when('/video', {
                controller: 'VideoCtrl',
                controllerAs: 'vm',
                templateUrl: 'video/view-video.html',
                authorize: false,
                menuAdm: false
            })
            .when('/video2', {
                controller: 'VideoCtrl',
                controllerAs: 'vm',
                templateUrl: '../../bower_components/videogular-youtube/example/youtube.html',
                authorize: false,
                menuAdm: false
            })
            .when('/type-video', {
                controller: 'ListTypeVideoCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-video/type/video-type-index.html',
                authorize: true,
                menuAdm: true
            })
            .when('/type-video/create', {
                controller: 'CreateTypeVideoCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-video/type/video-type-create.html',
                authorize: true,
                menuAdm: true
            })
            .when('/type-video/edit/:id', {
                controller: 'EditTypeVideoCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-video/type/video-type-edit.html',
                authorize: true,
                menuAdm: true
            })
            .when('/type-video/view/:id', {
                controller: 'ViewTypeVideoCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-video/type/video-type-view.html',
                authorize: true,
                menuAdm: true
            })
            .when('/category-video', {
                controller: 'ListVideoCategoryCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-video/category/video-category-index.html',
                authorize: true,
                menuAdm: true
            })
            .when('/category-video/create', {
                controller: 'CreateVideoCategoryCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-video/category/video-category-create.html',
                authorize: true,
                menuAdm: true
            })
            .when('/category-video/edit/:id', {
                controller: 'EditVideoCategoryCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-video/category/video-category-edit.html',
                authorize: true,
                menuAdm: true
            })
            .when('/category-video/view/:id', {
                controller: 'ViewVideoCategoryCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-video/category/video-category-view.html',
                authorize: true,
                menuAdm: true
            })            
            .when('/video/', {
                controller: 'ListViewCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-video/video/video-view.html',
                authorize: true,
                menuAdm: true
            })
            .when('/video/view/:id', {
                controller: 'ViewVideoCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-video/video/video-view.html',
                authorize: true,
                menuAdm: true
            })
            .when('/video/active', {
                controller: 'ListVideoActiveCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-video/video/video-active.html',
                authorize: true,
                menuAdm: true
            })
            .when('/video/inactive', {
                controller: 'ListVideoInactiveCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-video/video/video-inactive.html',
                authorize: true,
                menuAdm: true
            })
            .when('/video/create', {
                controller: 'CreateVideoCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-video/video/video-create.html',
                authorize: true,
                menuAdm: true
            })
             .when('/time-video', {
                 controller: 'ListTimeVideoCtrl',
                 controllerAs: 'vm',
                 templateUrl: 'manage-video/time/time-video-index.html',
                 authorize: true,
                 menuAdm: true
             })
            .when('/time-video/create', {
                controller: 'CreateTimeVideoCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-video/time/time-video-create.html',
                authorize: true,
                menuAdm: true
            })
            .when('/time-video/edit/:id', {
                controller: 'EditTimeVideoCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-video/time-video-edit.html',
                authorize: true,
                menuAdm: true
            })
            .when('/time-video/view/:id', {
                controller: 'ViewTimeVideoCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-video/time/time-video-view.html',
                authorize: true,
                menuAdm: true
            })
            .when('/plan', {
                controller: 'ListPlanCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-plan/plan/plan-index.html',
                authorize: true,
                menuAdm: true
            })
            .when('/plan/create', {
                controller: 'CreatePlanCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-plan/plan/plan-create.html',
                authorize: true,
                menuAdm: true
            })
            .when('/plan/edit/:id', {
                controller: 'EditPlanCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-plan/plan/plan-edit.html',
                authorize: true,
                menuAdm: true
            })
            .when('/plan/view/:id', {
                controller: 'ViewPlanCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-plan/plan/plan-view.html',
                authorize: true,
                menuAdm: true
            })

            .when('/payment', {
                controller: 'ListPaymentCompanyCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-payment-company/payment/payment-index.html',
                authorize: true,
                menuAdm: true
            })
            .when('/payment/create', {
                controller: 'CreatePaymentCompanyCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-payment-company/payment/payment-create.html',
                authorize: true,
                menuAdm: true
            })
            .when('/payment/edit/:id', {
                controller: 'EditPaymentCompanyCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-payment-company/payment/payment-edit.html',
                authorize: true,
                menuAdm: true
            })
            .when('/payment/view/:id', {
                controller: 'ViewPaymentCompanyCtrl',
                controllerAs: 'vm',
                templateUrl: 'manage-payment-company/payment/payment-view.html',
                authorize: true,
                menuAdm: true
            });
    });

})();