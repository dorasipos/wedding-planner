(function (ng) {
    'use strict';

    ng.module('tasks')
    .service('tasks', ['$http', '$q', function ($http, $q) {

        var predefinedTasks = null,
            defaultIcon = 'today',
            iconDictionary = {
                PlanCivilCeremonyWeddingTask: 'people',
                PlanReligiousCeremonyWeddingTask: 'notifications',
                PlanWeddingReceptionPartyWeddingTask: 'cake',
            };

        this.icon = function (id) {
            return iconDictionary[id] || defaultIcon;
        };

        this.predefined = function () {
            var deff = $q.defer();

            if (predefinedTasks) {
                deff.resolve(predefinedTasks);
            }
            else {
                $http.get('../tasks/predefined')
                .success(function (queryResult) {
                    predefinedTasks = queryResult.result;
                    deff.resolve(predefinedTasks);
                })
                .error(function (queryResult) {
                    deff.reject(queryResult.details);
                });
            }

            return deff.promise;
        };

    }]);

})(this.angular);