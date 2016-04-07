(function (ng) {
    'use strict';

    ng.module('wedding')
    .controller('weddingDashboard', ['$scope', '$routeParams', '$http', '$location', '$mdToast', function ($s, $p, $http, $l, $toast) {

        $http.get('../wedding/' + $p.weddingId)
        .success(function (weddingDto) {
            $s.wedding = weddingDto;
        })
        .error(function () {
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