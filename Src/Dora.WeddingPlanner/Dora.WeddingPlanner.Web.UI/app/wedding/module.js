﻿(function (ng) {
    'use strict';

    ng.module('wedding', ['ng', 'ngMaterial', 'ngRoute', 'tasks', 'wedding-task'])
    .config(['$routeProvider', function ($route) {

        $route
            .when('/:weddingId', { templateUrl: 'app/wedding/views/wedding-dashboard.tmpl.html', controller: 'weddingDashboard' });

    }]);

})(this.angular);