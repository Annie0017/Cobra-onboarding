onboardapp.controller('OrderCtrl', function ($scope, $http) {
    $http.get('/c2/OrderByList/').then(function success(response) {
        console.log(response.data);
        console.log("hi");
        $scope.model2 = response.data;
        console.log($scope.model2);
    }, function error(response) { $scope.model2 = "Something went wrong"; });
    $http.get('/c2/ProductList/').then(function success(response) {
        console.log(response.data);
        $scope.model3 = response.data;
    }, function error(response) { $scope.model3 = "Something went wrong"; });
    $http.get('/c2/CustomerList').then(function success(response) {
        $scope.model = response.data;
    }, function error(response) { $scope.model = "Something went wrong"; });
    $scope.order = {}
    $scope.OrderList = function (customer) {
        debugger;
        $scope.order = {}
        $scope.order.OrderId = customer.OrderId;
        //$scope.order.OrderDate = customer.OrderDate;
        $scope.order.Name = customer.pp.Id;       
        $scope.order.Id = customer.p.Id;
        $scope.order.Price = customer.p.Price;
    }

    $scope.EditOrder = function () {
        debugger;

        var req = {
            method: 'POST',
            url: '/c2/EditOrder/',
            data: $scope.order
        }
        alert("going to save");

        $http(req).then(function (response) {

            debugger;
            $scope.order = null;
            $http.get('/c2/OderByList').then(function success(response) { $scope.model2 = response.data; }, function error(response) { $scope.model = "Something went wrong"; });
            alert("Saved Successfully!!");

        });

    };

    $scope.addPrice = function (order) {
              $http({
                method: 'Post',
                url: '/c2/Prod/',
                data: { PId: JSON.stringify(order) }
                
            }).then(function successCallback(response) {

            $scope.order.Price = response.data;
        });
        debugger;
    };
   
    $scope.addOrd = function () {
        debugger;
        var addc = {            
            //'OrderDate': $scope.order.OrderDate,
            'Name': $scope.order.Name,            
            'Id': $scope.order.Id         
        };
        $http.post('/c2/AddOrder/', addc).then(function (response) {
            debugger;
            $http.get('/c2/OderByList').then(function success(response) { $scope.model2 = response.data; }, function error(response) { $scope.model2 = "Something went wrong"; });
            alert("Added!!");
        });
    };

    $scope.OrderDelete = function (item) {
        var req = {
            method: 'POST',
            url: '/c2/OrderDelete/',
            data: item
        }
        alert("going to delete");
        $http(req).then(function (response) {
            $http.get('/c2/OrderByList').then(function success(response) { $scope.model2 = response.data; }, function error(response) { $scope.model = "Something went wrong"; });
            alert("Deleted!!");
        });
    }; 
});