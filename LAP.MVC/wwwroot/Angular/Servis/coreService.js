angular.module("CoreService", [])
    .factory("coreSrv", function ($http, $q, helperSrv, LapEnum) {
        return {
            getAll: function (url) {
                var deferred = $q.defer();
                $http.get(url)
                    .then(function successCallback(response) {
                        var result = response.data;
                        if (result.success) {
                            deferred.resolve(result.data);
                        } else {
                            helperSrv.notification(result.message, "Uyarı", LapEnum.NotificaitonType[4]);
                        }
                    }).catch(function (response) {
                        console.log("Hata ==>" + response);
                        deferred.resolve([]);

                    }).finally(function () { });
                return deferred.promise;
            },
            create: function (model, url) {
                var deferred = $q.defer();
                $http.post(url, model)
                    .then(function successCallback(response) {
                        var result = response.data;
                        deferred.resolve(result);
                        if (result.success) {
                            helperSrv.notification(result.message, "Uyarı", LapEnum.NotificaitonType[1]);
                        } else {
                            helperSrv.notification(result.message, "Uyarı", LapEnum.NotificaitonType[4]);
                        }
                    }).catch(function (response) {
                        deferred.resolve(0);
                        console.log("Hata ==>" + response);
                    }).finally(function () { });
                return deferred.promise;
            },
            get: function (url) {
                var deferred = $q.defer();
                $http.get(url)
                    .then(function successCallback(response) {
                        var result = response.data;
                        deferred.resolve(result);
                        if (!result.success) {
                            helperSrv.notification(result.message, "Uyarı", LapEnum.NotificaitonType[4]);
                        }
                    }).catch(function (response) {
                        deferred.resolve(0);
                        console.log("Hata ==>" + response);
                    }).finally(function () { });
                return deferred.promise;
            },
            delete: function (id, url) {
                var deferred = $q.defer();
                $http.post(url + "/" + id)
                    .then(function successCallback(response) {
                        var result = response.data;
                        deferred.resolve(result);
                        if (result.success) {
                            helperSrv.notification(result.message, "Uyarı", LapEnum.NotificaitonType[1]);
                        } else {
                            helperSrv.notification(result.message, "Uyarı", LapEnum.NotificaitonType[4]);
                        }
                    }).catch(function (response) {
                        deferred.resolve(0);
                        console.log("Hata ==>" + response);
                    }).finally(function () { });
                return deferred.promise;
            }
        };
    })
    .constant('LapEnum', {
        NotificaitonType:
        {
            1: "success",
            2: "info",
            3: "warning",
            4: "error"
        }
    });