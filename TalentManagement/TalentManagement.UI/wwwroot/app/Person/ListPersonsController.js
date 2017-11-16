var app = angular.module('appListPersons', ['angularUtils.directives.dirPagination'])
    .controller('listPersons', ["$scope", "$http", function ($scope, $http) {

        var hostSite = window.location.host;
        var urlApi = "http://localhost:49697/api/";

        var url = window.location.href.split('/');

        $scope.IdPerson = url[url.length - 1];
        $scope.IdProfile = 0;

        $scope.divLoad = true;

        $http({
            url: urlApi + "Person/GetPersonById/" + $scope.IdPerson,
            method: "Get"
        }).
            then(function (success) {

                $scope.IdProfile = success.data.profileId;
                $scope.LoadAllPerson();
            },
            function (error) {
                $scope.divLoad = false;
                console.log(error);
            }
        );

        $scope.ListPersons = [];

        $scope.LoadAllPerson = function () {
            $http({
                url: urlApi + "Person/GetAllPerson",
                method: "Get"
            }).
                then(function (success) {

                    $scope.ListPersons = success.data;
                    $scope.divLoad = false;
                },
                function (error) {
                    $scope.divLoad = false;
                    console.log(error);
                }
            );
        };

        $scope.ReloadPersons = function () {
            $http({
                url: urlApi + "Person/GetAllPerson",
                method: "Get"
            }).
                then(function (success) {

                    $scope.ListPersons = success.data;
                    $scope.divLoad = false;
                },
                function (error) {
                    $scope.divLoad = false;
                    console.log(error);
                }
                );
        };

        $scope.NewPerson = function () {
            window.location.href = "http://" + hostSite + "/Person/CreatePerson/" + $scope.IdPerson;
        };

        $scope.EditPerson = function (item) {
            window.location.href = "http://" + hostSite + "/Person/EditPerson/" + item.id + "/" + $scope.IdPerson;
        };

        $scope.EditProfile = function (item) {

            if ($scope.IdPerson != item.id)
            {
                window.location.href = "http://" + hostSite + "/Person/UpdateProfile/" + item.id + "/" + $scope.IdPerson;
            }
            else
            {
                alert('Choose another user for this action!\nEscolha outro usuário para esta ação!');
            }
        };

        $scope.DeletePerson = function (item) {

            if (confirm('Do you really want to delete ' + item.name + '?\nDeseja realmente excluir ' + item.name + '?'))
            {
                if ($scope.IdPerson != item.id)
                {
                    $scope.divLoad = true;

                    $http({
                        url: urlApi + "Person/DeletePerson/" + item.id,
                        method: "Delete"
                    }).
                        then(function (success) {

                            $scope.ReloadPersons();
                        },
                        function (error) {
                            $scope.divLoad = false;
                            console.log(error);
                        }
                    );
                }
                else
                {
                    alert('Choose another user for this action!\nEscolha outro usuário para esta ação!');
                }
            }
        };
}])