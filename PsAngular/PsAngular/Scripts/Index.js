
var app = angular.module('myApp', []);
app.controller('userCtrl', function ($scope, $http,$filter) {
        $scope.flag = false;
        $scope.ErrorMsg = "";
        $scope.HasError = false;
        $scope.users = [{}];
        $scope.load = function (AllUsers, getUserTypes) {
        /*    $http.get(AllUsers)
                .then(function (response) {
                    console.log(response.data); $scope.users = response.data;

                    *//*   $scope.types = [];
                        $http.get(getUserTypes)
                            .then(function (response) {
                                angular.forEach(response.data, function (value, key) {
                                    if (key + 1 == $scope.users.UserType) {
                                        $scope.users.UserType = value
                                        console.log($scope.users.UserType);
                                    }
                                });});*//*

                });
*/
            $http.get(AllUsers).success(function (result, status) {
                console.log(result);
                $scope.users = result;
                if (!result.HasError) {
                    $scope.HasError = false;
                    $scope.users = result;
                } else {
                    $scope.HasError = true;
                    $scope.ErrorMsg = "Unable to get User! ";
                    alertError($scope.ErrorMsg);
                }

            }).error(function (result, status) {
                $scope.HasError = true;
                $scope.ErrorMsg = "Unable to get User! ";
                alertError($scope.ErrorMsg);
            });
          
        }
    
      
      

        $scope.showMe = false;
        $scope.myFunc = function () {
           
            $scope.flag = false;
            $scope.showMe = !$scope.showMe;
            $scope.depts = [{ }];
/*            $http.get($scope.getAllDepartments)
                .then(function (response) { $scope.depts = response.data; console.log($scope.depts); });*/

            $http.get($scope.getAllDepartments).success(function (result, status) {
                if (!result.HasError) {
                    $scope.HasError = false;
                    $scope.depts = result;
                } else {
                    $scope.HasError = true;
                    $scope.ErrorMsg = "Unable to get Departments! ";
                    alertError($scope.ErrorMsg);
                }

            }).error(function (result, status) {
                $scope.HasError = true;
                $scope.ErrorMsg = "Unable to get Departments! ";
                alertError($scope.ErrorMsg);
            });


            $scope.desg = [{ }];
          /*    $http.get($scope.getAllDesignations)
                .then(function (response) { $scope.desg = response.data; });*/

            $http.get($scope.getAllDesignations).success(function (result, status) {
                if (!result.HasError) {
                    $scope.HasError = false;
                    $scope.desg = result;
                } else {
                    $scope.HasError = true;
                    $scope.ErrorMsg = "Unable to get Designations! ";
                    alertError($scope.ErrorMsg);
                }

            }).error(function (result, status) {
                $scope.HasError = true;
                $scope.ErrorMsg = "Unable to get Designations! ";
                alertError($scope.ErrorMsg);
            });


            $scope.types = [];
            /*   $http.get($scope.getUserTypes)
                .then(function (response) { $scope.types = response.data; });*/

            $http.get($scope.getUserTypes).success(function (result, status) {
                if (!result.HasError) {
                    $scope.HasError = false;
                    $scope.types = result;
                } else {
                    $scope.HasError = true;
                    $scope.ErrorMsg = "Unable to get User Types! ";
                    alertError($scope.ErrorMsg);
                }

            }).error(function (result, status) {
                $scope.HasError = true;
                $scope.ErrorMsg = "Unable to get User Types! ";
                alertError($scope.ErrorMsg);
            });

            
            //console.log($scope.types);
        }
        $scope.fromData = {
        FirstName: "",
            LastName: "",
            Email: "",
            DepartmentId: "",
            DesignationId: "",
            UserType: ""
        };

        $scope.saveUser = function () {

            var data = $scope.fromData;
            var data2 = JSON.stringify(data)
            console.log(data);
     /*       $http.post($scope.createUser, data2).then(function (response) {
                if (response.data == "success") {
        alert("Create Successsful");
                    $http.get($scope.getAllUsers)
                        .then(function (response) {$scope.users = response.data; });
                } else {alert(response.data)}


            }, function (response) {

        console.log(response);

            });*/

            $http.post($scope.createUser, data2).success(function (result, status) {
                console.log(result);
                if (result == "success") {
                    $scope.HasError = false;
                    console.log($scope.fromData);
                    alert("Create Successsful");
                    $scope.fromData2 = {
                        FirstName: $scope.fromData.FirstName,
                        LastName: $scope.fromData.LastName,
                        Email: $scope.fromData.Email,
                        Department: { DepartmentId: $scope.fromData.DepartmentId, DepartmentName: $scope.fromData.DepartmentId==1?"CSE":"BBA" },
                        Designation: { DesignationId: $scope.fromData.DesignationId, DesignationName: $scope.fromData.DesignationId == 1 ? "Admin" : "Super Admin" },
                        UserType: $scope.fromData.UserType
                    };
                    $scope.users.push($scope.fromData2);
                } else {
                    $scope.HasError = true;
                    $scope.ErrorMsg = "Unable to Save user! ";
                    alert($scope.ErrorMsg + result);
                }

            }).error(function (result, status) {
                $scope.HasError = true;
                $scope.ErrorMsg = "Unable to Save user! ";
                alertError($scope.ErrorMsg);
            });

        }

        $scope.deleteUser = function (id) {
         /*   $http.delete($scope.deleteUserById + id ).then(function (response) {
            if (response.data == "success") {
                alert("Delete Successsful");
                $http.get($scope.getAllUsers)
                    .then(function (response) { $scope.users = response.data; });
            } else { alert(response.data) }

            }, function (response) { console.log(response); });*/

            $http.delete($scope.deleteUserById + id ).success(function (result, status) {
                if (!result.HasError) {
                    $scope.HasError = false;
                    alert("Delete Successsful");
                    var obj = $filter('filter')($scope.users, { UserId: id }, true);
                    console.log(obj);
                    var index = $scope.users.indexOf(obj);
                    $scope.users.splice(index, 1);
                } else {
                    $scope.HasError = true;
                    $scope.ErrorMsg = "Unable to Delete User ! ";
                    alert($scope.ErrorMsg);
                }

            }).error(function (result, status) {
                $scope.HasError = true;
                $scope.ErrorMsg = "Unable to Delete User ! ";
                alert($scope.ErrorMsg);
            });

        }


        $scope.myFunc2= function () {
        $scope.showMe = true;
            $scope.depts = [{}];
            /*            $http.get($scope.getAllDepartments)
                            .then(function (response) { $scope.depts = response.data; console.log($scope.depts); });*/

            $http.get($scope.getAllDepartments).success(function (result, status) {
                if (!result.HasError) {
                    $scope.HasError = false;
                    $scope.depts = result;
                } else {
                    $scope.HasError = true;
                    $scope.ErrorMsg = "Unable to get Departments! ";
                    alertError($scope.ErrorMsg);
                }

            }).error(function (result, status) {
                $scope.HasError = true;
                $scope.ErrorMsg = "Unable to get Departments! ";
                alertError($scope.ErrorMsg);
            });


            $scope.desg = [{}];
            /*    $http.get($scope.getAllDesignations)
                  .then(function (response) { $scope.desg = response.data; });*/

            $http.get($scope.getAllDesignations).success(function (result, status) {
                if (!result.HasError) {
                    $scope.HasError = false;
                    $scope.desg = result;
                } else {
                    $scope.HasError = true;
                    $scope.ErrorMsg = "Unable to get Designations! ";
                    alertError($scope.ErrorMsg);
                }

            }).error(function (result, status) {
                $scope.HasError = true;
                $scope.ErrorMsg = "Unable to get Designations! ";
                alertError($scope.ErrorMsg);
            });


            $scope.types = [];
            /*   $http.get($scope.getUserTypes)
                .then(function (response) { $scope.types = response.data; });*/

            $http.get($scope.getUserTypes).success(function (result, status) {
                if (!result.HasError) {
                    $scope.HasError = false;
                    $scope.types = result;
                } else {
                    $scope.HasError = true;
                    $scope.ErrorMsg = "Unable to get User Types! ";
                    alertError($scope.ErrorMsg);
                }

            }).error(function (result, status) {
                $scope.HasError = true;
                $scope.ErrorMsg = "Unable to get User Types! ";
                alertError($scope.ErrorMsg);
            });
        }

        $scope.editId = 0;
        $scope.editUser = function (id) {
        $scope.flag = true;
            $scope.myFunc2();

        /*    $http.get( $scope.getUsersById + id )
                .then(function (response) {
       
                    console.log(response.data);
                    $scope.editId = response.data.UserId;
                    $scope.fromData = response.data;
                   *//* $scope.fromData.UserType = response.data.UserType;*/
                 /*   $scope.fromData.firstName = response.data.FirstName;
                    $scope.fromData.lastName = response.data.LastName;
                    $scope.fromData.email = response.data.Email;
                    $scope.fromData.departmentId = response.data.DepartmentId;
                    $scope.fromData.designationId = response.data.DesignationId;
                    $scope.fromData.userType = response.data.UserType;*//*
                });*/

            $http.get($scope.getUsersById + id).success(function (result, status) {
                if (!result.HasError) {
                    $scope.HasError = false;
                    $scope.editId = result.UserId;
                    $scope.fromData = result;
                } else {
                    $scope.HasError = true;
                    $scope.ErrorMsg = "Unable to get User! ";
                    alertError($scope.ErrorMsg);
                }

            }).error(function (result, status) {
                $scope.HasError = true;
                $scope.ErrorMsg = "Unable to get User ";
                alertError($scope.ErrorMsg);
            });



        }

    $scope.edited = function () {
       /*     $http.put($scope.updateUserById  + $scope.editId , $scope.fromData)
            .then(function (response) {
                if (response.data == "success") {
                    alert("Update Successsful");
                    $http.get($scope.getAllUsers)
                        .then(function (response) { $scope.flag = false; $scope.users = response.data; $scope.fromData = {} });
                } else { alert(response.data) }
            });*/
        $http.put($scope.updateUserById + $scope.editId, $scope.fromData).success(function (result, status) {
            if (result == "success") {
                $scope.HasError = false;
                alert("Edit Successsful");
                $scope.load($scope.getAllUsers, $scope.getUserTypes);
            } else {
                $scope.HasError = true;
                $scope.ErrorMsg = "Unable to Update User ! ";
                alert($scope.ErrorMsg + result);
            }

        }).error(function (result, status) {
            $scope.HasError = true;
            $scope.ErrorMsg = "Unable to Update User ! ";
            alert($scope.ErrorMsg);
        });

        }

        $scope.Init = function (getAllUsers, getUsersById, createUser, updateUserById, deleteUserById, getAllDepartments, getAllDesignations, getUserTypes) {
            $scope.getAllUsers = getAllUsers;
            $scope.getUsersById = getUsersById;
            $scope.createUser = createUser;
            $scope.updateUserById = updateUserById;
            $scope.deleteUserById = deleteUserById;
            $scope.getAllDepartments = getAllDepartments;
            $scope.getAllDesignations = getAllDesignations;
            $scope.getUserTypes = getUserTypes;
            console.log($scope.getAllUsers)
            $scope.load($scope.getAllUsers, $scope.getUserTypes);
        };

    });

//======Custom Variabales goes hare=====


// app.controller('formCtrl', function ($scope, $http) { });

