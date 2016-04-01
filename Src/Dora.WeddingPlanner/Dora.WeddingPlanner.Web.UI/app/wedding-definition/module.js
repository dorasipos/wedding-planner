(function (ng) {
    'use strict';

    ng.module('wedding-definition', ['ng', 'ngMaterial'])
    .config(['$routeProvider', function ($route) {

        $route
            .when('/new', { templateUrl: 'app/wedding-definition/views/define-new-wedding.tmpl.html', controller: 'newWedding' });

    }]);

})(this.angular);