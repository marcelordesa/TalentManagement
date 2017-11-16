var app = angular.module('appCreatePerson', ['ui.mask'])
    .controller('createPerson', ["$scope", "$http", function ($scope, $http) {

        var url = window.location.href.split('/');

        $scope.IdPerson = url[url.length - 1];
        $scope.IdProfile = 0;

        var hostSite = window.location.host;
        var urlApi = "http://localhost:49697/api/";
        $scope.divLoad = true;

        $http({
            url: urlApi + "Person/GetPersonById/" + $scope.IdPerson,
            method: "Get"
        }).
            then(function (success) {

                $scope.IdProfile = success.data.profileId;
                $scope.LoadAllState();
            },
            function (error) {
                $scope.divLoad = false;
                console.log(error);
            }
        );

        $scope.ListStates = [];
        $scope.ListCity = [];
        $scope.ListWillingness = [];
        $scope.ListTimeWork = [];
        $scope.ListBank = [];
        $scope.ListAccountType = [];
        $scope.ListKnowledge = [];
        $scope.ListKnowledgeLevel = [];
        $scope.ListWillingnessSelected = [];
        $scope.ListTimeWorkSelected = [];
        $scope.ListKnowledgeSelected = [];

        $scope.email = "";
        $scope.password = "";
        $scope.repassword = "";
        $scope.name = "";
        $scope.skype = "";
        $scope.phone = "";
        $scope.linkedIn = "";
        $scope.stateSelected = null;
        $scope.citySelected = null;
        $scope.portfolio = "";
        $scope.salary = "";
        $scope.cpf = "";
        $scope.bankSelected = null;
        $scope.agency = "";
        $scope.accountTypeSelected = null;
        $scope.accountNumber = "";
        $scope.otherKnowledge = "";
        $scope.linkCrud = "";

        $scope.isStepOne = true;
        $scope.isStepTwo = false;
        $scope.isStepThree = false;
        $scope.isStepFour = false;

        $scope.LoadAllState = function () {
            $http({
                url: urlApi + "State/GetAllState",
                method: "Get"
            }).
                then(function (success) {

                    $scope.ListStates = success.data;
                    $scope.GetWillingnesss();
                },
                function (error) {
                    $scope.divLoad = false;
                    console.log(error);
                }
            );
        };

        $scope.NextStepOne = function () {
            $scope.isStepOne = true;
            $scope.isStepTwo = false;
            $scope.isStepThree = false;
            $scope.isStepFour = false;
        };

        $scope.NextStepTwo = function () {
            if ($scope.isStepOne == true) {
                if ($scope.ValidateStepOne()) {
                    $scope.isStepOne = false;
                    $scope.isStepTwo = true;
                    $scope.isStepThree = false;
                    $scope.isStepFour = false;
                }
            }
            else {
                $scope.isStepOne = false;
                $scope.isStepTwo = true;
                $scope.isStepThree = false;
                $scope.isStepFour = false;
            }
        };

        $scope.NextStepThree = function () {
            if ($scope.isStepTwo == true) {
                if ($scope.ValidateStepTwo()) {
                    $scope.isStepOne = false;
                    $scope.isStepTwo = false;
                    $scope.isStepThree = true;
                    $scope.isStepFour = false;
                }
            }
            else {
                $scope.isStepOne = false;
                $scope.isStepTwo = false;
                $scope.isStepThree = true;
                $scope.isStepFour = false;
            }
        };

        $scope.NextStepFour = function () {
            $scope.isStepOne = false;
            $scope.isStepTwo = false;
            $scope.isStepThree = false;
            $scope.isStepFour = true;
        };

        $scope.KnowledgeSelect = function (item, level) {

            for (var i = 0; i < $scope.ListKnowledgeSelected.length; i++) {
                if (item.id == $scope.ListKnowledgeSelected[i].KnowledgeId) {
                    $scope.ListKnowledgeSelected[i].Level = level;
                    break;
                }
            }
        };

        $scope.CheckedWillingness = function (willingness) {

            var personWillingness = {
                "PersonId": 0,
                "WillingnessId": willingness.id
            }

            var isExist = false;

            for (var i = 0; i < $scope.ListWillingnessSelected.length; i++) {
                if ($scope.ListWillingnessSelected[i].WillingnessId == willingness.id) {
                    $scope.ListWillingnessSelected.splice(i, 1);
                    isExist = true;
                    break;
                }
            }

            if (!isExist)
                $scope.ListWillingnessSelected.push(personWillingness);
        };

        $scope.CheckedTimeWork = function (timeWork) {
            var personTimeWork = {
                "PersonId": 0,
                "TimeWorkId": timeWork.id
            }

            var isExist = false;

            for (var i = 0; i < $scope.ListTimeWorkSelected.length; i++) {
                if ($scope.ListTimeWorkSelected[i].TimeWorkId == timeWork.id) {
                    $scope.ListTimeWorkSelected.splice(i, 1);
                    isExist = true;
                    break;
                }
            }

            if (!isExist)
                $scope.ListTimeWorkSelected.push(personTimeWork);
        };

        $scope.Save = function () {

            var person = {
                "AccountNumber": $scope.accountNumber == "" ? null : $scope.accountNumber,
                "AccountTypeId": $scope.accountTypeSelected != null ? $scope.accountTypeSelected.id : null,
                "Agency": $scope.agency == "" ? null : $scope.agency,
                "BankId": $scope.bankSelected != null ? $scope.bankSelected.id : null,
                "CityId": $scope.citySelected.id,
                "Cpf": $scope.cpf == "" ? null : $scope.cpf,
                "Email": $scope.email,
                "Id": 0,
                "LinkTest": $scope.linkCrud == "" ? null : $scope.linkCrud,
                "LinkedIn": $scope.linkedIn == "" ? null : $scope.linkedIn,
                "Name": $scope.name,
                "OtherKnowledge": $scope.otherKnowledge == "" ? null : $scope.otherKnowledge,
                "Password": $scope.password,
                "Phone": $scope.phone,
                "Portfolio": $scope.portfolio == "" ? null : $scope.portfolio,
                "ProfileId": 0,
                "Salary": $scope.salary,
                "Skype": $scope.skype,
                "StateId": $scope.stateSelected.id,
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
                url: urlApi + "Person/InsertPerson",
                data: person,
                method: "Post"
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

        $scope.GetCitys = function (state) {
            $scope.divLoad = true;
            $http({
                url: urlApi + "City/GetAllCityByStateId/" + state.id,
                method: "Get"
            }).
                then(function (success) {

                    $scope.ListCity = success.data;
                    $scope.divLoad = false;
                },
                function (error) {
                    $scope.divLoad = false;
                    console.log(error);
                }
                );
        };

        $scope.GetWillingnesss = function () {
            $http({
                url: urlApi + "Willingness/GetAllWillingness",
                method: "Get"
            }).
                then(function (success) {

                    $scope.ListWillingness = success.data;
                    $scope.GetTimeWorks();
                },
                function (error) {
                    $scope.divLoad = false;
                    console.log(error);
                }
                );
        };

        $scope.GetTimeWorks = function () {
            $http({
                url: urlApi + "TimeWork/GetAllTimeWork",
                method: "Get"
            }).
                then(function (success) {

                    $scope.ListTimeWork = success.data;
                    $scope.GetBanks();
                },
                function (error) {
                    $scope.divLoad = false;
                    console.log(error);
                }
                );
        };

        $scope.GetBanks = function () {
            $http({
                url: urlApi + "Bank/GetAllBank",
                method: "Get"
            }).
                then(function (success) {

                    $scope.ListBank = success.data;
                    $scope.GetAccountTypes();
                },
                function (error) {
                    $scope.divLoad = false;
                    console.log(error);
                }
                );
        };

        $scope.GetAccountTypes = function () {
            $http({
                url: urlApi + "AccountType/GetAllAccountType",
                method: "Get"
            }).
                then(function (success) {

                    $scope.ListAccountType = success.data;
                    $scope.GetKnowledges();
                },
                function (error) {
                    $scope.divLoad = false;
                    console.log(error);
                }
                );
        };

        $scope.GetKnowledges = function () {
            $http({
                url: urlApi + "Knowledge/GetAllKnowledge",
                method: "Get"
            }).
                then(function (success) {

                    $scope.ListKnowledge = success.data;

                    for (var i = 0; i < $scope.ListKnowledge.length; i++) {
                        var knowledgeLevel = {
                            "id": $scope.ListKnowledge[i].id,
                            "description": $scope.ListKnowledge[i].description,
                            "level": 0
                        }
                        $scope.ListKnowledgeLevel.push(knowledgeLevel);

                        var personKnowledge = {
                            "PersonId": 0,
                            "KnowledgeId": $scope.ListKnowledge[i].id,
                            "Level": 0
                        }

                        $scope.ListKnowledgeSelected.push(personKnowledge);
                    }

                    $scope.divLoad = false;
                },
                function (error) {
                    $scope.divLoad = false;
                    console.log(error);
                }
                );
        };

        $scope.ValidateStepOne = function () {
            var message = "";

            if ($scope.email == "")
                message = message + "Enter e-mail\nInforme o e-mail";
            else
                if (!ValidateEmail($scope.email))
                    message = message + "\n\nInvalid e-mail\nE-mail inválido";

            if ($scope.password == "")
                message = message + "\n\nEnter password\nInforme a senha";

            if ($scope.repassword == "")
                message = message + "\n\nEnter the password again\nInforme a senha novamente";

            if ($scope.password != "" && $scope.repassword != "")
                if ($scope.password != $scope.repassword)
                    message = message + "\n\nInvalid password\nSenha inválida";

            if ($scope.name == "")
                message = message + "\n\nEnter name\nInforme o nome";

            if ($scope.skype == "")
                message = message + "\n\nEnter skype\nInforme o skype";

            if ($scope.phone == "")
                message = message + "\n\nEnter phone\nInforme o telefone";

            if ($scope.stateSelected == null)
                message = message + "\n\nSelect state\nSelecione o estado";

            if ($scope.citySelected == null)
                message = message + "\n\nSelect city\nSelecione a cidade";

            if (message != "") {
                alert(message);
                return false;
            }

            return true;
        };

        $scope.ValidateStepTwo = function () {

            var message = "";

            if ($scope.ListWillingnessSelected.length == 0)
                message = message + "\n\nSelect at least one item willingness\nSelecione pelo menos um item da disponibilidade";

            if ($scope.ListTimeWorkSelected.length == 0)
                message = message + "\n\nSelect at least one item of best time to work\nSelecione pelo menos um item do melhor horário para trabalhar";

            if ($scope.salary == "")
                message = message + "\n\nEnter salary\nInforme o valor/hora";

            if (message != "") {
                alert(message);
                return false;
            }

            return true;
        };
    }])

function ValidateEmail(email) {
    user = email.substring(0, email.indexOf("@"));
    domain = email.substring(email.indexOf("@") + 1, email.length);

    if ((user.length >= 1) &&
        (domain.length >= 3) &&
        (user.search("@") == -1) &&
        (domain.search("@") == -1) &&
        (user.search(" ") == -1) &&
        (domain.search(" ") == -1) &&
        (domain.search(".") != -1) &&
        (domain.indexOf(".") >= 1) &&
        (domain.lastIndexOf(".") < domain.length - 1)) {
        return true;
    }
    else {
        return false;
    }
}