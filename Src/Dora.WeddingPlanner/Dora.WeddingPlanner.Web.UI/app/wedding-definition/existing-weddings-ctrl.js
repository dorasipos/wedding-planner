(function (ng) {
    'use strict';

    ng.module('wedding-definition')
    .controller('existingWeddings', ['$scope', '$http', '$location', '$mdToast', function ($s, $http, $l, $toast) {

        $http.get('../')
        .success(function (weddings) {

        })

    }]);

})(this.angular);