(function () {

    'use strict';

    angular.module('fasterClient').constant('SETTINGS', {
        'VERSION':'0.0.1',
        'CURR_ENV':'dev',
        'AUTH_TOKEN':'faster-token',
        'AUTH_USER':'faster-user',
        'SERVICE_URL':'/',
        //'SERVICE_URL': 'http://www.fastertecnologia.com.br/',
    });

    angular.module('fasterClient').run(function ($rootScope, $location,$window, editableOptions, SETTINGS) {

        var token = sessionStorage.getItem(SETTINGS.AUTH_TOKEN);
        var user = sessionStorage.getItem(SETTINGS.AUTH_USER);

        editableOptions.theme = 'bs3'; // bootstrap3 theme. Can be also 'bs2', 'default'

        //Configuração do Toastr
        toastr.options.closeButton = true;
        toastr.options.progressBar = true;
        toastr.options.timeOut = 10000;

        $rootScope.user = null;
        $rootScope.token = null;        
        $rootScope.header = null;
        $rootScope.showMenuAdm = false;
        

        if (token && user) {
            $rootScope.token = token;
            $rootScope.user = JSON.parse(user);            
            $rootScope.header = {
                headers: {
                    'Authorization': 'Bearer ' + $rootScope.token
                }
            }
        }

        $rootScope.$on("$routeChangeStart", function (event, next, current) {
            if (next.menuAdm) {
                $rootScope.showMenuAdm = true;
            } else
            {
                $rootScope.showMenuAdm = false;
            }

            if ($rootScope.user == null && next.authorize) {
                //$window.location.href = 'http://localhost:4002/';
                $window.location.href = 'http://www.fastertecnologia.com.br/';
            }
        });
    });

})();