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
            if (response.data.success == true) {
                $scope.order = null;
                $http.get('/c2/OrderByList/').then(function success(response) { $scope.model2 = response.data; }, function error(response) { $scope.model = "Something went wrong"; });
                $("#myModal").modal("hide");
                alert("Saved Successfully!!");
            } else {
                alert("Error in saving data");
            }
        });
    };
    $scope.addPrice = function (order) {
        $http({
            method: 'Post',
            url: '/c2/Prod/',
            data: { PId: JSON.stringify(order) }

        }).then(function successCallback(response) {
            if (response.data.success == false) {
                alert("Error in getting price");
            } else {
                $scope.order.Price = response.data.pc;
            }
        });
        debugger;
    };
     
    $scope.addOrd = function () {         
        var addc = {
            method: 'Post',
            url: '/c2/AddOrder/',
            data: $scope.order
        }
        debugger;
        alert("going to save");       
        $http(addc).then(function (respon) {
            debugger;
            if (response.data.success == true) {
            $http.get('/c2/OrderByList/').then(function success(response) { $scope.model2 = response.data; }, function error(response) { $scope.model2 = "Something went wrong"; });
             alert("Added!!");
            } else {
                alert("Error no return");
            }
            $("#myAddModal").modal("hide");
            debugger;                    
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
            if (response.data.success == true) {
            $http.get('/c2/OrderByList').then(function success(response) { $scope.model2 = response.data; }, function error(response) { $scope.model = "Something went wrong"; });
            alert("Deleted!!");
            } else {
                alert("Error no return");
            }
        });
    };
});