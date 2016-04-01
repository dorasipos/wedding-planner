(function (ng) {
    'use strict';

    ng.module('WeddingPlannerApp', ['ng', 'ngRoute', 'ngMaterial'])
    .config(['$mdThemingProvider', '$routeProvider', '$locationProvider', function ($mdThemingProvider, $route, $location) {
        $mdThemingProvider.theme('default');

        $location.html5Mode(false);

        $route
            .when('/new', { templateUrl: 'views/define-new-wedding.tmpl.html' });

    }]);

})(this.angular);