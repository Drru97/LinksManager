(function () {
    'use strict';

    angular
        .module('LinkListModule')
        .factory('deleteLinkFactory', Factory);

    Factory.$inject = ['$http'];

    function Factory($http) {
        return {
            deleteLink: deleteLink
        }

        function deleteLink(id) {
            return $http({
                method: 'DELETE',
                url: '/api/link/' + id
            });
        }
    }
})();