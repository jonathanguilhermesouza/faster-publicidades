(function () {
    'use strict'

    angular.module('faster').directive('mdCancelContract', function () {


        return {
            templateUrl: 'faster-administration/components/md.note-cancel-contract/md.note-cancel-contract.html',
            controller: 'mdCancelContractCtrl',
            scope: { openCompany: '&' },
            restrict: 'E'
        };

    });
})();