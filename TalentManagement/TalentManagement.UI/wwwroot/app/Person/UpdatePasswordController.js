var app = angular.module('appUpdatePassword', [])
    .controller('updatePassword', ["$scope", "$http", function ($scope, $http) {

        var url = window.location.href.split('/');

        $scope.IdPerson = url[url.length - 1];
        $scope.IdPersonSelected = url[url.length - 2];
        $scope.IdProfile = 0;
        $scope.PersonSelected = null;

        var hostSite = window.location.host;
        var urlApi = "http://localhost:49697/api/";
        $scope.divLoad = true;

        $scope.ListWillingnessSelected = [];
        $scope.ListTimeWorkSelected = [];
        $scope.ListKnowledgeSelected = [];

        $scope.password = "";
        $scope.repassword = "";

        $http({
            url: urlApi + "Person/GetPersonById/" + $scope.IdPerson,
            method: "Get"
        }).
            then(function (success) {

                if (success.data != null) {
                    $scope.IdProfile = success.data.profileId;
                    $scope.LoadPersonSelected();
                }
            },
            function (error) {
                $scope.divLoad = false;
                console.log(error);
            }
        );

        $scope.LoadPersonSelected = function () {

            $http({
                url: urlApi + "Person/GetPersonById/" + $scope.IdPersonSelected,
                method: "Get"
            }).
                then(function (success) {

                    $scope.PersonSelected = success.data;
                    $scope.divLoad = false;
                },
                function (error) {
                    $scope.divLoad = false;
                    console.log(error);
                }
            );
        };

        $scope.Save = function () {

            if (!$scope.Validate())
                return;

            if ($scope.PersonSelected.personTimeWorks.length > 0) {
                for (var i = 0; i < $scope.PersonSelected.personTimeWorks.length; i++) {
                    var personTimeWork = {
                        "PersonId": $scope.PersonSelected.personTimeWorks[i].personId,
                        "TimeWorkId": $scope.PersonSelected.personTimeWorks[i].timeWorkId
                    }

                    $scope.ListTimeWorkSelected.push(personTimeWork);
                }
            }

            if ($scope.PersonSelected.personWillingnesss.length > 0) {
                for (var i = 0; i < $scope.PersonSelected.personWillingnesss.length; i++) {
                    var personWillingness = {
                        "PersonId": $scope.PersonSelected.personWillingnesss[i].personId,
                        "WillingnessId": $scope.PersonSelected.personWillingnesss[i].willingnessId
                    }

                    $scope.ListWillingnessSelected.push(personWillingness);
                }
            }

            if ($scope.PersonSelected.personKnowledges.length > 0) {
                for (var i = 0; i < $scope.PersonSelected.personKnowledges.length; i++) {
                    var personKnowledge = {
                        "PersonId": $scope.PersonSelected.personKnowledges[i].personId,
                        "KnowledgeId": $scope.PersonSelected.personKnowledges[i].knowledgeId,
                        "Level": $scope.PersonSelected.personKnowledges[i].level
                    }

                    $scope.ListKnowledgeSelected.push(personKnowledge);
                }
            }

            var person = {
                "AccountNumber": $scope.PersonSelected.accountNumber == "" ? null : $scope.PersonSelected.accountNumber,
                "AccountTypeId": $scope.PersonSelected.accountTypeId != null ? $scope.PersonSelected.accountTypeId : null,
                "Agency": $scope.PersonSelected.agency == "" ? null : $scope.PersonSelected.agency,
                "BankId": $scope.PersonSelected.bankId != null ? $scope.PersonSelected.bankId : null,
                "CityId": $scope.PersonSelected.cityId,
                "Cpf": $scope.PersonSelected.cpf == "" ? null : $scope.PersonSelected.cpf,
                "Email": $scope.PersonSelected.email,
                "Id": $scope.PersonSelected.id,
                "LinkTest": $scope.PersonSelected.linkTest == "" ? null : $scope.PersonSelected.linkTest,
                "LinkedIn": $scope.PersonSelected.linkedIn == "" ? null : $scope.PersonSelected.linkedIn,
                "Name": $scope.PersonSelected.name,
                "OtherKnowledge": $scope.PersonSelected.otherKnowledge == "" ? null : $scope.PersonSelected.otherKnowledge,
                "Password": $scope.password,
                "Phone": $scope.PersonSelected.phone,
                "Portfolio": $scope.PersonSelected.portfolio == "" ? null : $scope.PersonSelected.portfolio,
                "ProfileId": $scope.PersonSelected.profileId,
                "Salary": $scope.PersonSelected.salary,
                "Skype": $scope.PersonSelected.skype,
                "StateId": $scope.PersonSelected.stateId,
                "City": null,
                "State": null,
                "Bank": null,
                "AccountType": null,
                "Profile": null,
                "PersonKnowledges": $scope.ListKnowledgeSelected,
                "PersonTimeWorks": $scope.ListTimeWorkSelected,
                "PersonWillingnesss": $scope.ListWillingnessSelected
            }

            $http({
                url: urlApi + "Person/UpdatePasswordPerson/" + $scope.PersonSelected.id,
                data: person,
                method: "Put"
            }).
                then(function (success) {

                    window.location.href = "http://" + hostSite + "/Person/Index/" + $scope.IdProfile + "/" + $scope.IdPerson;
                },
                function (error) {
                    $scope.divLoad = false;
                    console.log(error);
                }
            );
        };

        $scope.Cancel = function () {
            window.location.href = "http://" + hostSite + "/Person/Index/" + $scope.IdProfile + "/" + $scope.IdPerson;
        };

        $scope.Validate = function () {
            var message = "";

            if ($scope.passwordCurrent == "")
                message = message + "\n\nEnter current password\nInforme a senha atual";
            else
            {
                if ($scope.passwordCurrent != $scope.PersonSelected.password)
                    message = message + "\n\nInvalid current password\nSenha atual inválida";
            }

            if ($scope.password == "")
                message = message + "\n\nEnter new password\nInforme a nova senha";

            if ($scope.repassword == "")
                message = message + "\n\nEnter the password again\nInforme a nova senha novamente";

            if ($scope.password != "" && $scope.repassword != "")
            {
                if ($scope.password != $scope.repassword)
                    message = message + "\n\nInvalid new password\nNova senha inválida";
            }

            if (message != "") {
                alert(message);
                return false;
            }

            return true;
        };
}])