(function (ng) {
    'use strict';

    ng.module('WeddingPlannerApp', ['ng', 'ngRoute', 'ngMaterial', 'wedding-definition'])
    .config(['$mdThemingProvider', '$routeProvider', '$locationProvider', function ($mdThemingProvider, $route, $location) {
        $mdThemingProvider.theme('default');

        $location.html5Mode(false);

        $route
            .otherwise({ redirectTo: '/new' });

    }]);

})(this.angular);