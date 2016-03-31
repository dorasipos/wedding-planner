(function (ng) {
    'use strict';

    ng.module('WeddingPlannerApp', ['ng', 'ngMaterial'])
    .config(['$mdThemingProvider', function ($mdThemingProvider) {
        $mdThemingProvider.theme('default');
    }]);

})(this.angular);