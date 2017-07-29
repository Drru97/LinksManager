(function () {
    'use strict';

    angular
        .module('LinkListModule')
        .factory('LinkListFactory', Factory);

    Factory.$inject = ['$http'];
    function Factory($http) {
        return {
            getLinks: getLinks
        }

        function getLinks() {
            return $http({
                method: 'GET',
                url: '/api/link/'
            });
        }
    }
}());