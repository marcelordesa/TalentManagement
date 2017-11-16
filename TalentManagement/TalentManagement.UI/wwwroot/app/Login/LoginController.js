var app = angular.module('appLoginTalentManagement', [])
    .controller('login', ["$scope", "$http", function ($scope, $http) {

        var hostSite = window.location.host;
        var urlApi = "http://localhost:49697/api/";
        $scope.divLoad = false;

        $scope.email = "";
        $scope.password = "";

        $scope.Login = function () {

            if ($scope.ValidateLogin())
            {
                $scope.CallLogin();
            }
        };

        $scope.CallLogin = function () {

            $scope.divLoad = true;

            var person = {
                "Id": 0,
                "AccountNumber": "",
                "AccountTypeId": 0,
                "Agency": "",
                "BankId": 0,
                "CityId": 0,
                "Cpf": "",
                "Email": $scope.email,
                "LinkTest": "",
                "LinkedIn": "",
                "Name": "",
                "OtherKnowledge": "",
                "Password": $scope.password,
                "Phone": "",
                "Portfolio": "",
                "ProfileId": 0,
                "Salary": 10000,
                "Skype": "",
                "StateId": 0
            }

            $http({
                url: urlApi + "Person/LoginPerson",
                data: person,
                method: "Post"
            }).
                then(function (success) {

                    $scope.divLoad = false;

                    var resultPerson = success.data;

                    if (resultPerson == null || resultPerson == "")
                        alert('Usuário e/ou senha inválidos!\n(Invalid user and/or password!)')
                    else
                    {
                        window.location.href = "http://" + hostSite + "/Person/Index/" + resultPerson.profileId + "/" + resultPerson.id
                    }
                },
                function (error) {
                    $scope.divLoad = false;
                    console.log(error);
                }
            );
        };

        $scope.ValidateLogin = function () {
            var message = "";

            if ($scope.email == "")
                message = message + "Enter e-mail / Informe o e-mail";

            if ($scope.password == "")
                message = message + "\nEnter password / Informe a senha";

            if (message != "")
            {
                alert(message);
                return false;
            }

            return true;
        };
}])