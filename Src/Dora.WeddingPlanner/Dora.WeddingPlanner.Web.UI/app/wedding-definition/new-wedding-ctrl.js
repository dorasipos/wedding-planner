(function (ng) {
    'use strict';

    function Person() {
        this.firstName = null;
        this.lastName = null;
    }

    ng.module('wedding-definition')
    .controller('newWedding', ['$scope', '$http', '$location', '$mdToast', function ($s, $http, $l, $toast) {

        $s.bride = new Person();
        $s.groom = new Person();

        $s.submit = function () {
            $s.submit.ing = true;
            $http.post('../wedding', {
                bride: $s.bride,
                groom: $s.groom
            })
            .success(function (response) {
                $toast
                    .show(
                        $toast.simple()
                            .textContent('Successfully created a new wedding, taking U there in a bit...')
                            .position('bottom right')
                            .hideDelay(2000)
                    )
                    .then(function () {
                        $l.path('/' + response.result);
                    });
            })
            .error(function () {
                $toast
                    .show(
                        $toast.simple()
                            .textContent('Error creating a new wedding')
                            .position('bottom right')
                            .hideDelay(5000)
                    );
            })
            .finally(function () {
                delete $s.submit.ing;
            });
        };

    }]);

})(this.angular);