(function (ng) {
    'use strict';

    ng.module('wedding-task')
    .controller('newWeddingTask', ['$scope', '$mdDialog', function ($s, $mdDialog) {

        $s.title = null;
        $s.description = null;
        $s.isMandatory = false;

        //$s.submit = function () {
        //    $s.submit.ing = true;
        //    $http.post('../wedding', {
        //        bride: $s.bride,
        //        groom: $s.groom
        //    })
        //    .success(function (response) {
        //        $toast
        //            .show(
        //                $toast.simple()
        //                    .textContent('Successfully created a new wedding, taking U there in a bit...')
        //                    .position('bottom right')
        //                    .hideDelay(2000)
        //            )
        //            .then(function () {
        //                $l.path('/' + response.result);
        //            });
        //    })
        //    .error(function () {
        //        $toast
        //            .show(
        //                $toast.simple()
        //                    .textContent('Error creating a new wedding')
        //                    .position('bottom right')
        //                    .hideDelay(5000)
        //            );
        //    })
        //    .finally(function () {
        //        delete $s.submit.ing;
        //    });
        //};

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