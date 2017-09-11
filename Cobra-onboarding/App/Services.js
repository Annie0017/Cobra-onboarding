onboardapp.service('hexafy', function () {
    this.myFunc = function (x) {
        return x.toString(16);
    }
    
    

    //onboardapp.filter('formatDateTime', function ($filter) {
    //        return function (date, format) {
    //            if (date) {
    //                return moment(Number(date)).format(format || "DD/MM/YYYY h:mm A");
    //            }
    //            else
    //                return "";
    //        };
    //    });
});
onboardapp.filter("mydate", function () {
    var re = /\/Date\(([0-9]*)\)\//;
    return function (x) {
        var m = x.match(re);
        if (m) { return new Date(parseInt(m[1])); }
        else return null;
    }
});
