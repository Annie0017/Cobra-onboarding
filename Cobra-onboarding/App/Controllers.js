onboardapp.controller('CustomerCtrl', function ($scope, $http, hexafy) {
    $scope.cus = {}
    $scope.deleteMessage = "Are you sure you want to delete this record?"
    $http.get('/c2/CustomerList').then(function success(response) { $scope.model = response.data; }, function error(response) { $scope.model = "Something went wrong"; });
        
   
    $scope.Delete = function (index) {
        
        // display the popup asking the user to comfirm they want to delete a record
        $scope.actionEdit = false;
        $scope.actionDelete = true;
        $("#myModal").modal("show");
        $scope.currentEditId = index;
        debugger;
    };
    $scope.deleteCus = function () {       
        var req = {
            method: 'POST',
            url: '/c2/Delete/',
            data: { id: $scope.model[$scope.currentEditId].Id }             
        }           
        $http(req).then(function (response) {  
            alert("going to delete");
            if (response.data.success == true) {
                $scope.model.splice($scope.currentEditId, 1);
                $("#myModal").modal("hide");
            }
             else {
                    alert("Error Deleting record!!");
            }            
        });            
    }; 
    
    
    $scope.editCus = function (index) {    
        if (index != -1) {
            $scope.currentEditId = index;
            $scope.cus.Id = $scope.model[index].Id;
            $scope.cus.name = $scope.model[index].Name;
            $scope.cus.add1 = $scope.model[index].Address1;
            $scope.cus.add2 = $scope.model[index].Address2;
            $scope.cus.city = $scope.model[index].City;
        } 
        else {
            $scope.cus.currentEditId = $scope.model.length + 1;
            $scope.cus.Id = index;
        }
            $scope.actionEdit = true;
            $scope.actionDelete = false;
            $("#myModal").modal("show");
    }
         
    $scope.editCu = function () {
                var req = {
                    method: 'POST',
                    url: '/c2/Edit/',
                    data: $scope.cus
                }
                alert("going to save");

                $http(req).then(function (response) {
                    if (response.data.success == true) {
                        if (response.data.edit == true) {
                            $scope.model[$scope.currentEditId].Name = $scope.cus.name;
                            $scope.model[$scope.currentEditId].Address1 = $scope.cus.add1;
                            $scope.model[$scope.currentEditId].Address2 = $scope.cus.add2;
                            $scope.model[$scope.currentEditId].City = $scope.cus.city;
                        } else {
                            $scope.model.push({
                                'Id': response.data.id,
                                'Name': $scope.cus.name,
                                'Address1': $scope.cus.add1,
                                'Address2': $scope.cus.add2,
                                'City': $scope.cus.city
                             });
                        }
                        $("#myModal").modal("hide");
                    } else {
                        alert("Error Save To Database Failed");
                    }
                    
                });
                
    };
    
    $scope.hex = hexafy.myFunc(255); 

    
});