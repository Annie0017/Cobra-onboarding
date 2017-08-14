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
   
    $scope.deleteCus = function (id) {
        console.log(id);      
        var Index = hexafy.getSelectedIndex(id);
        $scope.model.people.splice(Index, 1);
                   
    }; 
    
    $scope.editCus = function (id) {
        
        hexafy.GetCustomerById(id).then(function (d) { $scope.cus = d.data;})
    };
    $scope.editCu = function () { 
        
                var req = {
                    method: 'POST',
                    url: '/c2/Edit/',
                    data: $scope.cus
                }
                $http(req).then(function (response) {
                    if (response.data.success) {
                        $scope.cus = null;
                        Console.log("Saved Successfully!!");
                    }
                });
    };
    

    $scope.hex = hexafy.myFunc(255); 
});






//onboardapp.factory('CustomerService', ['$http', function ($scope) {
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

//}); $http.post('/c2/Add/', editc).success(function (data) {
//$scope.model.people.cusid.push(data);
//Console.log("Saved Successfully!!");
//console.log(data);
//console.log(scope.model.people.cusid);
//                });var editc = {

//'Name': $scope.cus.name,
//    'Address1': $scope.cus.add1,
//        'Address2': $scope.cus.add2,
//            'City': $scope.cus.city
//        };