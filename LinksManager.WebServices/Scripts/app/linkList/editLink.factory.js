(function() {
    'use strict';

    angular
        .module('LinkListModule')
        .factory('editLinkFactory', Factory);

    Factory.$inject = ['$http'];

    function Factory($http) {
        return {
            confirmEdit: confirmEdit
        }

        function confirmEdit(link) {
            return $http({
                method: 'PUT',
                url: '/api/link/' + link.Id,
                data: link
            });
        }
    }
})();