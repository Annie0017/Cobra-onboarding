onboardapp.controller('OrderCtrl', function ($scope, $http, hexafy) {
    $http.get('/c2/OrderByList/').then(function success(response) { $scope.model2 = response.data; }, function error(response) { $scope.model2 = "Something went wrong"; });
    $http.get('/c2/ProductList/').then(function success(response) { $scope.model3 = response.data; }, function error(response) { $scope.model3 = "Something went wrong"; });
    //$scope.OrderList = function (customer) {
    //    $scope.order.OrderId = customer.OrderId;
    //    $scope.order.Name = customer.Name;
    //    $scope.order.OrderDate = customer.OrderDate;
    //    $scope.order.ProductName = customer.ProductName;
    //    $scope.order.Price = customer.Price;
    //}

    //$scope.EditOrder = function () {
    //    debugger;

    //    var req = {
    //        method: 'POST',
    //        url: '/c2/EditOrder/',
    //        data: $scope.order
    //    }
    //    alert("going to save");

    //    $http(req).then(function (response) {

    //        debugger;
    //        $scope.order = null;
    //        $http.get('/c2/OderByList').then(function success(response) { $scope.model2 = response.data; }, function error(response) { $scope.model = "Something went wrong"; });
    //        alert("Saved Successfully!!");

    //    });

    //};

    $scope.addOrder = function () {
        debugger;
        var addc = {    
            
            'ProductName':$scope.order.ProductName
            
        };
        $http.post('/c2/Prod/', addc).then(function (response) {
             $scope.order.Price=response.data;
        });
    };

    $scope.addOrd = function () {
        var addc = {
            'Name': $scope.order.Name,
            'OrderDate': $scope.order.OrderDate,
            'ProductName': $scope.order.ProductName,
            'Price': $scope.order.Price
        };
        $http.post('/c2/AddOrder/', addc).then(function (response) {
            $http.get('/c2/OderByList').then(function success(response) { $scope.model2 = response.data; }, function error(response) { $scope.model = "Something went wrong"; });
            alert("Added!!");
        });
    };

    //$scope.OrderDelete = function (item) {
    //    var req = {
    //        method: 'POST',
    //        url: '/c2/OrderDelete/',
    //        data: item
    //    }
    //    alert("going to delete");
    //    $http(req).then(function (response) {
    //        $http.get('/c2/OrderByList').then(function success(response) { $scope.model2 = response.data; }, function error(response) { $scope.model = "Something went wrong"; });
    //        alert("Deleted!!");
    //    });
    //}; 
});