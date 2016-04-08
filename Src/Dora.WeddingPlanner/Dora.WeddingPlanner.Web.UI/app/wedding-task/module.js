(function (ng) {
    'use strict';

    ng.module('wedding-task', ['ng', 'ngMaterial', 'ngRoute', 'wedding'])
    .config(['$routeProvider', function ($route) {

        $route
            .when('/task/new', { templateUrl: 'app/wedding-task/views/new-wedding-task.tmpl.html', controller: 'newWeddingTask' });

    }]);

})(this.angular);