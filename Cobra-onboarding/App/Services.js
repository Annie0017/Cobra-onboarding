onboardapp.service('hexafy', function () {
    this.myFunc = function (x) {
        return x.toString(16);
    }
    this.GetCustomerById = function (id) {
        $http.get('/c2/GetCustomerById/', { params: { id: id } })
    }
    this.getSelectedIndex=function (id) {
        for (var i = 0; i < $scope.model.length; i++)
            if ($scope.model[i].Id == id)
                return i;
        return -1;
    }
});