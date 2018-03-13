(function () {
    'use strict'

    angular.module('fasterAdministration').directive('mdListEquipment', function () {


        return {
            templateUrl: 'faster-administration/components/md.list-equipment/md.list-equipment.html',
            controller: 'MdListEquipmentCtrl',
            scope: { openEquipment: '&' },
            restrict: 'E'
        };

    });
})();