(function (ng, _) {
    'use strict';

    ng.module('wedding-task')
    .controller('weddingTask', ['$scope', '$routeParams', '$http', '$location', '$mdDialog', '$mdToast', 'tasks', 'wedding', function ($s, $p, $http, $l, $mdDialog, $toast, tasks, w) {

        w.current().then(function (wedding) {
            $s.task = wedding.tasks[$p.index];
        });

    }]);

})(this.angular, this._);