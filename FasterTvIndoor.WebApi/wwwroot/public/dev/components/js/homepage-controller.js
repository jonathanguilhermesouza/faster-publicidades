(function () {

    'use strict';

    angular.module('faster').controller('HomepageCtrl', HomepageCtrl);

    HomepageCtrl.$inject = ['$location', '$rootScope', '$scope', '$anchorScroll', 'anchorSmoothScroll', 'HomepageFactory'];

    function HomepageCtrl($location, $rootScope, $scope, $anchorScroll, anchorSmoothScroll, HomepageFactory) {

        var vm = this;

        $scope.bodyEmail = {
            phone: '',
            subject: 'Envio de email - Site Faster Technology', 
            description: '',
            name:''
        };

        $scope.gotoElement = gotoElement;
        $scope.sendEmail = sendEmail;

        function scrollTo(id) {
            $location.hash(id);
            $anchorScroll();
        }

        function gotoElement(eID) {
            // set the location.hash to the id of
            // the element you wish to scroll to.
            $location.hash('bottom');

            // call $anchorScroll()
            anchorSmoothScroll.scrollTo(eID);

        };

        function sendEmail() {
            HomepageFactory.post($scope.bodyEmail)
                .success(success)
                .catch(fail);

            function success(response) {
                clearFormEmail();
                toastr.success('E-mail enviado com sucesso', 'Enviado com sucesso');
            }

            function fail(error) {
                clearFormEmail();
                toastr.error('E-mail enviado sem sucesso', 'Enviado sem sucesso');
            }
        }

        function clearFormEmail() {

            $scope.bodyEmail = {
                phone: '',
                subject: 'Envio de email - Site Faster Technology',
                description: '',
                name: ''
            };

        }

    }
})();