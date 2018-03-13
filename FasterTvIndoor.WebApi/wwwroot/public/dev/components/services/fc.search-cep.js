(function () {
    'use strict'

    angular.module('faster').factory('SearchCepFactory', SearchCepFactory);

    SearchCepFactory.$inject = ['$http'];

    function SearchCepFactory($http) {
        return {
            getSearchCep: getSearchCep
        };

        function getSearchCep(cep) {
            return $http.get("https://viacep.com.br/ws/" + cep + "/json/")
        }
     
    };

})();