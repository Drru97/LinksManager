(function () {
    'use strict';

    angular
        .module('LinkListModule')
        .directive('linkList', directive);

    directive.$inject = ['LinkListFactory', 'editLinkFactory', 'deleteLinkFactory'];
    function directive(LinkListFactory, editLinkFactory, deleteLinkFactory) {
        function directiveController(LinkListFactory, editLinkFactory, deleteLinkFactory) {
            var vm = this;
            vm.links = [];

            vm.showEditForm = { value: false };
            vm.editedLink = {};

            init();

            function init() {
                LinkListFactory.getLinks()
                    .then(function successCallBack(response) {
                        vm.links = response.data;
                    });
            }

            vm.editLinkClick = function (id) {
                vm.editedLink = vm.links[id - 1];
                vm.showEditForm.value = true;
            }

            vm.editLinkConfirm = function () {
                editLinkFactory.confirmEdit(vm.editedLink);
                vm.showEditForm.value = false;
            }

            vm.deleteLink = function (id) {
                deleteLinkFactory.deleteLink(id);
                init();
            }
        }

        return {
            bindController: true,
            controller: directiveController,
            controllerAs: 'Ctrl',
            restrict: 'E',
            templateUrl: 'Scripts/app/linkList/linkList.template.html',
            scope: {}
        }
    }
}());