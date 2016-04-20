(function (ng, session, undefined) {
    'use strict';

    ng.module('wedding')
    .service('wedding', ['$routeParams', '$http', '$q', function ($p, $http, $q) {

        var weddingId = $p.weddingId || session.weddingId,
            wedding = null;

        this.id = function () { return weddingId; }

        this.current = function () {
            var deff = $q.defer();

            if ($p.weddingId !== undefined && $p.weddingId !== weddingId) {
                session.weddingId = weddingId = $p.weddingId;
                wedding = null;
            }

            if (wedding) {
                deff.resolve(wedding);
            }
            else {
                $http.get('../wedding/' + weddingId)
                    .success(function (queryResult) {
                        wedding = queryResult.result;
                        deff.resolve(wedding);
                    })
                    .error(function () {
                        deff.reject();
                    });
            }
            return deff.promise;
        };

        this.refresh = function () {
            delete session.weddingId;
            wedding = null;
            return this;
        };

    }]);

})(this.angular, this.sessionStorage);