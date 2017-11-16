var app = angular.module('appPersonPanel', [])
    .controller('personPanel', ["$scope", "$http", function ($scope, $http) {

        var url = window.location.href.split('/');

        $scope.IdPerson = url[url.length - 1];
        $scope.IdPersonSelected = url[url.length - 2];
        $scope.IdProfile = 0;
        $scope.PersonSelected = null;

        var hostSite = window.location.host;
        var urlApi = "http://localhost:49697/api/";
        $scope.divLoad = true;

        $http({
            url: urlApi + "Person/GetPersonById/" + $scope.IdPerson,
            method: "Get"
        }).
            then(function (success) {

                if (success.data != null) {
                    $scope.IdProfile = success.data.profileId;
                    $scope.PersonSelected = success.data;
                }

                $scope.divLoad = false;
            },
            function (error) {
                $scope.divLoad = false;
                console.log(error);
            }
        );
    }])