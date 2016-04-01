(function (ng) {
    'use strict';

    function Person() {
        this.firstName = null;
        this.lastName = null;
    }

    ng.module('wedding-definition')
    .controller('newWedding', ['$scope', '$http', '$mdToast', function ($s, $http, $toast) {

        $s.bride = new Person();
        $s.groom = new Person();

        $s.submit = function () {
            $s.submit.ing = true;
            $http.post('../wedding', {
                bride: $s.bride,
                groom: $s.groom
            })
            .success(function () {
                $toast.show(
                    $toast.simple()
                        .textContent('Successfully created a new wedding!')
                        .position('top right')
                        .hideDelay(5000)
                    );
            })
            .error(function () {
                $toast.show(
                    $toast.simple()
                        .textContent('Error creating a new wedding')
                        .position('top right')
                        .hideDelay(5000)
                    );
            })
            .finally(function () {
                delete $s.submit.ing;
            });
        };

    }]);

})(this.angular);