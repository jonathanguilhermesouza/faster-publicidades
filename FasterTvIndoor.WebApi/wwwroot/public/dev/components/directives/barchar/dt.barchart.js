(function () {
    'use strict';

    angular.module('faster').directive('barchart', barchart);

    //barchart.$inject = ['$scope'];

    function barchart() {
        return {

            // required to make it work as an element
            restrict: 'E',
            template: '<div></div>',
            replace: true,
            // observe and manipulate the DOM
            link: function ($scope, element, attrs) {

                var data = $scope[attrs.data],
                    xkey = $scope[attrs.xkey],
                    ykeys = $scope[attrs.ykeys],
                    labels = $scope[attrs.labels];

                Morris.Bar({
                    element: element,
                    data: data,
                    xkey: xkey,
                    ykeys: ykeys,
                    labels: labels,
                    barColors: function (row, series, type) {
                        if (series.key == 'b') {
                            if (row.y < 70)
                                return "#31C0BE";
                            else
                                return "#c7254e";
                        }
                        else {
                            return "#31C0BE";
                        }
                    }
                });


            }
        }
    };
})();