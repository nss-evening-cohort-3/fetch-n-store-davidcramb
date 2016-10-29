var hi = "hi";
var b = "";
console.log(hi);
app.controller('FetchCtrl', function ($scope, $http) {
    $scope.userURL = "";
    $scope.status = "";
    $scope.method = "";
    $scope.responseTime = "";
    $scope.placeholder = "http://httpstat.us/";
    
    $scope.selectables =
        [{
            value: 'get',
            name: 'get'
        }, {
            value: 'head',
            name: 'head'
        }];
    $scope.selected = $scope.selectables[0];

    $scope.fetchURL = (selectedMethod) => {
        var pingFirst = new Date();
        var pingLast = "";
        console.log(pingFirst);
        if (selectedMethod == 'get')
        {
            $http.get($scope.userURL)
            .then(function (data, status, headers, config) {
                console.log(data)
                $scope.status = data.status;
                $scope.method = data.config.method;
                pingLast = new Date();
                b = data;
            }, function errorCallback(response)
            {
                console.log(response);
            });
        } else if (selectedMethod == 'head')
        {
            $http.head($scope.userURL)
            .then(function (data) {
                console.log(data);
                $scope.status = data.status;
                $scope.method = data.config.method;
                pingLast = new Date.now();
                b = data;
            });
        }
        $scope.responseTime = pingFirst - pingLast;
    };

    $scope.storeData = () => {
        console.log('store');
        var data = $.param({
            URL: $scope.userURL,
            Status_Code: $scope.status,
            Method: $scope.method,
            Response_Time: $scope.responseTime,
            Time : null
        })
        $http.post('/api/Response', data)
        console.log(data)
        .then(function (response) {
            console.log(response);
        }, function errorCallback(response) {
            console.log(response);
        });
    };


});