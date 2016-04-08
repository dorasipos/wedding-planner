(function (ng) {
    'use strict';

    ng.module('wedding')
    .service('wedding', ['$routeParams', '$http', '$q', function ($p, $http, $q) {

        var weddingId = $p.weddingId,
            wedding = null;

        this.id = function () { return weddingId; }

        this.current = function () {
            var deff = $q.defer();
            if (wedding) {
                deff.resolve(wedding);
            }
            else {
                $http.get('../wedding/' + $p.weddingId)
                    .success(function (weddingDto) {
                        wedding = weddingDto;
                        deff.resolve(wedding);
                    })
                    .error(function () {
                        deff.reject();
                    });
            }
            return deff.promise;
        };

    }]);

})(this.angular);