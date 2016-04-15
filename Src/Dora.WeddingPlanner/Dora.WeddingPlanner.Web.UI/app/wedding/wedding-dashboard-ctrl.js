(function (ng) {
    'use strict';

    ng.module('wedding')
    .controller('weddingDashboard', ['$scope', '$location', '$mdToast', 'tasks', 'wedding', function ($s, $l, $toast, tasks, wedding) {

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

        tasks.predefined().then(
            function (t) {
                $s.predefinedTasks = t;
            },
            function (reason) {
                $toast.show(
                    $toast.simple()
                        .textContent('Error loading predefined wedding tasks.\r\n' + reason)
                        .position('bottom right')
                        .hideDelay(5000)
                    );
            });

        $s.taskIcon = tasks.icon;

        $s.goTo = function (path) {
            $l.path(path);
        };

    }]);

})(this.angular);