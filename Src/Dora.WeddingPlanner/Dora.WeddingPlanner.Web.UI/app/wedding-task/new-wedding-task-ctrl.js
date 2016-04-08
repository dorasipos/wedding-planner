(function (ng) {
    'use strict';

    ng.module('wedding-task')
    .controller('newWeddingTask', ['$scope', '$mdDialog', function ($s, $mdDialog) {

        $s.cancel = function (ev) {
            var confirm = $mdDialog.confirm()
                .title('Are you sure?')
                .textContent('Are you sure you want to cancel the current task? All your manual entries will be lost.')
                .ariaLabel('Are you sure you want to cancel task?')
                .targetEvent(ev)
                .ok('Yup, sure!')
                .cancel('Nope, sorry!');

            $mdDialog.show(confirm).then(function () {
                console.log('Yup, cancel task');
            }, function () {
                console.log('No, no, get back to task editing');
            });
        };

    }]);

})(this.angular);