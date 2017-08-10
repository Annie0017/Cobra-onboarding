onboardapp.controller('CustomerCtrl',function ($scope, $http, hexafy) {
    
    $http.get('/c2/CustomerList').then(function success(response) { $scope.model = response.data; }, function error(response) { $scope.model = "Something went wrong"; });
    //$scope.new = { cus: {} };
    $scope.addCus = function () {
        var addc = {
            'Name': $scope.new.cus.name,
            'Address1': $scope.new.cus.add1,
            'Address2': $scope.new.cus.add2,
            'City': $scope.new.cus.city
        };
        $http.post('/c2/Add/', addc).success(function (data) { $scope.model.people.push(data); });
    };
   
    $scope.deletecus = function (item){
                    
                    var  cusid  =  this.item.Id;
                    $http.delete('/c2/CustomerList' + cusid).success(function (data)
                    {
                            alert("Deleted Successfully!!");
                            $.each($scope.items, function (i)
                            {
                                if ($scope.items[i].Id === cusid)
                                {
                                    $scope.items.splice(i, 1);
                                            return  false;
                                }
                            });
                                                
                    }).error(function  (data)  {
                        $scope.error = "An Error has occured while Saving Customer! " + data;

                    });
    }; 

    $scope.editCus = function () {
        $http.put('/c2/Edit/emp', editc).success(function (data) { $scope.model.people.emp.Id.push(data); });
         var editc = {
            'Name': $scope.new.cus.name,
            'Address1': $scope.new.cus.add1,
            'Address2': $scope.new.cus.add2,
            'City': $scope.new.cus.city
         };
        $http.put('/c2/CustomerList',  editc).success(function  (data)  {
                        alert("Saved Successfully!!");
                                               
        }).error(function  (data)  {
                        $scope.error  =  "An Error has occured while Saving Friend! "  +  data;
        });   
    };

    $scope.hex = hexafy.myFunc(255); 
});

//onboardapp.controller('AddController', function ($scope) {
//    $scope.model = "in add view"; 
//});

//onboardapp.controller('EditController', function ($scope) {
//    $scope.message = "in edit view";
//});

//onboardapp.controller('DeleteController', function ($scope) {
//    $scope.message = "in delete view";
//}); 
//onboardapp.controller('CustomerCtrl', function ($scope, $http) {
//    $http.get('/c2/CustomerList').success(function (data) { $scope.model = data; });

//});