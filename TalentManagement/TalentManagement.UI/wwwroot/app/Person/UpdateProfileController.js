var app = angular.module('appUpdateProfile', [])
    .controller('updateProfile', ["$scope", "$http", function ($scope, $http) {

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

        $scope.ProfileSelected = null;
        $scope.ListProfile = [];

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
                    $scope.LoadProfile();
                },
                function (error) {
                    $scope.divLoad = false;
                    console.log(error);
                }
            );
        };

        $scope.LoadProfile = function () {
            $http({
                url: urlApi + "Profile/GetAllProfile",
                method: "Get"
            }).
                then(function (success) {

                    $scope.ListProfile = success.data;
                    $scope.LoadScreen();
                    $scope.divLoad = false;
                },
                function (error) {
                    $scope.divLoad = false;
                    console.log(error);
                }
            );
        };

        $scope.LoadScreen = function () {

            for (var i = 0; i < $scope.ListProfile.length; i++)
            {
                if ($scope.ListProfile[i].id == $scope.PersonSelected.profileId)
                {
                    $scope.ProfileSelected = $scope.ListProfile[i];
                    break;
                }
            }
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
                "Password": $scope.PersonSelected.password,
                "Phone": $scope.PersonSelected.phone,
                "Portfolio": $scope.PersonSelected.portfolio == "" ? null : $scope.PersonSelected.portfolio,
                "ProfileId": $scope.ProfileSelected.id,
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
                url: urlApi + "Person/UpdateProfilePerson/" + $scope.PersonSelected.id,
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

            if ($scope.ProfileSelected == null)
                message = message + "\nSelect one option\nSelecione uma opção";

            if (message != "") {
                alert(message);
                return false;
            }

            return true;
        };
    }])