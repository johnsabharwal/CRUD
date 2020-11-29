var app = angular.module('myApp', []);
app.controller('myCtrl',
    function ($scope) {

        $scope.userVm = {
            Id: "",
            Name: "",
            Email: "",
            RoleType: "Admin",
            Status: "",
            Mobile: ""
        }


        $scope.init = function () {
            $scope.LoadUsers();
        }


        $scope.LoadUsers = function () {
            $.ajax({
                type: "POST",
                url: "Home/List",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    $scope.Users = result;
                    $scope.$apply();
                }
            });
        }



        $scope.AddUser = function (obj) {
            console.log(1);
            var data = JSON.parse(JSON.stringify(obj));
            $.ajax({
                type: "POST",
                url: "Home/Create",
                data: { userVm: data },
                dataType: 'json',
                success: function (result) {
                    $('#addUser').modal('toggle');
                    $scope.LoadUsers();
                    $scope.$apply();
                }
            });
        }



        $scope.Update = function (obj) {
            $scope.userVm = {
                Id: obj.id,
                Name: obj.name,
                Email: obj.email,
                RoleType: obj.roleType,
                Status: obj.Status,
                Mobile: obj.mobile
            }
            $('#addUser').modal('toggle');

        }



        $scope.Delete = function (id) {
            $.ajax({
                type: "POST",
                url: "Home/Delete?userId=" + id,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    $scope.LoadUsers();
                    $scope.$apply();
                }
            });
        }

    });