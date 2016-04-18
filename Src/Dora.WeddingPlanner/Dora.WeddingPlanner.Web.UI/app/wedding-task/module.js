(function (ng) {
    'use strict';

    ng.module('wedding-task', ['ng', 'ngMaterial', 'ngRoute', 'tasks', 'wedding'])
    .config(['$routeProvider', function ($route) {

        $route
            .when('/task/new/:id', { templateUrl: 'app/wedding-task/views/new-wedding-task.tmpl.html', controller: 'newWeddingTask' })
            .when('/task/new', { templateUrl: 'app/wedding-task/views/new-wedding-task.tmpl.html', controller: 'newWeddingTask' })
            .when('/task/:index', { templateUrl: 'app/wedding-task/views/edit-wedding-task.tmpl.html', controller: 'weddingTask' });

    }]);

})(this.angular);