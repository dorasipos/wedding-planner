(function (ng) {
    'use strict';

    ng.module('wedding')
    .controller('weddingDashboard', ['$scope', '$location', '$mdToast', 'wedding', function ($s, $l, $toast, wedding) {

        wedding
            .current()
            .then(function (wedding) {
                $s.wedding = wedding;
            }, function () {
                $toast
                    .show(
                        $toast.simple()
                            .textContent('Error loading wedding, taking you home in a bit...')
                            .position('bottom right')
                            .hideDelay(3000)
                        )
                    .then(function () {
                        $l.path('/');
                    });
            });

    }]);

})(this.angular);