onboardapp.controller('CustomerCtrl',function ($scope, $http, hexafy) {
    
    $http.get('/c2/CustomerList').then(function success(response) { $scope.model = response.data; }, function error(response) { $scope.model = "Something went wrong"; });
    //$scope.new = { cus: {} };
    $scope.addCus = function () {
        var addc = {
            'Name': $scope.cus.name,
            'Address1': $scope.cus.add1,
            'Address2': $scope.cus.add2,
            'City': $scope.cus.city
        };
        $http.post('/c2/Add/', addc);/*.success(function (data) { $http.get('/c2/CustomerList').success(function (response) { $scope.model = response.data; } );*/
        $http.get('/c2/CustomerList').then(function success(response) { $scope.model = response.data; }, function error(response) { $scope.model = "Something went wrong"; });
        alert("Added!!");
    };
   
    $scope.deleteCus = function (item) {
        var req = {
            method: 'POST',
            url: '/c2/Delete/',
            data: item
        }
        alert("going to delete");
        $http(req).then(function (response) {              
            $http.get('/c2/CustomerList').then(function success(response) { $scope.model = response.data; }, function error(response) { $scope.model = "Something went wrong"; });
            alert("Deleted!!");
        });            
    }; 
    $scope.cus={}
    
    $scope.editCus = function (customer) {
        $scope.cus.Id = customer.Id;
        $scope.cus.name = customer.Name;
        $scope.cus.add1 = customer.Address1;
        $scope.cus.add2 = customer.Address2;
        $scope.cus.city = customer.City;                 
    }
         
    $scope.editCu = function () {
        debugger;

                var req = {
                    method: 'POST',
                    url: '/c2/Edit/',
                    data: $scope.cus
                }
                alert("going to save");

                $http(req).then(function (response) {
                    
                        debugger;
                        $scope.cus = null;
                        $http.get('/c2/CustomerList').then(function success(response) { $scope.model = response.data; }, function error(response) { $scope.model = "Something went wrong"; });
                        alert("Saved Successfully!!");
                    
                });
                
    };
    
    $scope.hex = hexafy.myFunc(255); 
});