(function () {
    'use strict'

    angular.module('fasterAdministration').directive('mdListCompany', function () {


        return {
            templateUrl: 'faster-administration/components/md.list-company/md.list-company.html',
            controller: 'mdListCompanyCtrl',
            scope: { openCompany: '&' },
            restrict: 'E'
        };

    });
})();