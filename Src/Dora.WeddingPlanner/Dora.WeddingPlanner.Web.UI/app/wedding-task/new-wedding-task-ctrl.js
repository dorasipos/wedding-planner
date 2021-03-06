﻿(function (ng, _) {
    'use strict';

    ng.module('wedding-task')
    .controller('newWeddingTask', ['$scope', '$routeParams', '$http', '$location', '$mdDialog', '$mdToast', 'tasks', 'wedding', function ($s, $p, $http, $l, $mdDialog, $toast, tasks, w) {

        $s.title = null;
        $s.description = null;
        $s.isMandatory = false;

        if ($p.id) {
            tasks.predefined().then(function (tasks) {
                var pTask = _.find(tasks, { id: $p.id });
                if (pTask) {
                    $s.title = pTask.task.title;
                }
            });
        }

        $s.submit = function () {
            $s.submit.ing = true;
            $http.post('../task', {
                weddingId: w.id(),
                title: $s.title,
                description: $s.description,
                isMandatory: $s.isMandatory
            })
            .success(function (response) {
                $toast
                    .show(
                        $toast.simple()
                            .textContent('Successfully created a new wedding task, taking U back to the wedding dash...')
                            .position('bottom right')
                            .hideDelay(2000)
                    )
                    .then(function () {
                        w.refresh();
                        $l.path('/' + w.id());
                    });
            })
            .error(function () {
                $toast
                    .show(
                        $toast.simple()
                            .textContent('Error creating a new wedding task')
                            .position('bottom right')
                            .hideDelay(5000)
                    );
            })
            .finally(function () {
                delete $s.submit.ing;
            });
        };

        $s.cancel = function (ev) {
            var confirm = $mdDialog.confirm()
                .title('Are you sure?')
                .textContent('Are you sure you want to cancel the current task? All your manual entries will be lost.')
                .ariaLabel('Are you sure you want to cancel task?')
                .targetEvent(ev)
                .ok('Yup, sure!')
                .cancel('Nope, sorry!');

            $mdDialog.show(confirm).then(function () {
                $l.path('/' + w.id());
            });
        };

    }]);

})(this.angular, this._);