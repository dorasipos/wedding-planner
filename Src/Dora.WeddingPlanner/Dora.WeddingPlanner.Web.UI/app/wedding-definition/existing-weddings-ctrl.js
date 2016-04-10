(function (ng, _) {
    'use strict';

    function Person(dto) {
        this.firstName = dto.firstName;
        this.lastName = dto.lastName;
        this.displayName = ((dto.firstName || '') + ' ' + (dto.lastName || '')).trim();
    }

    function Wedding(id, dto) {
        this.id = id;
        this.bride = new Person(dto.bride);
        this.groom = new Person(dto.groom);
    }

    ng.module('wedding-definition')
    .controller('existingWeddings', ['$scope', '$http', '$location', '$mdToast', function ($s, $http, $l, $toast) {

        $s.weddings = null;

        $http.get('../wedding')
        .success(function (query) {
            $s.weddings = _.map(query.result, function (w) {
                return new Wedding(w.key, w.value);
            });
        })
        .error(function () {
            $l.path('/');
        });

        $s.goTo = function (path) {
            $l.path(path);
        };

    }]);

})(this.angular, this._);