var hi = "hi";
var b = "";
console.log(hi);
app.controller('FetchCtrl', function ($scope, $http) {
    $scope.userURL = "";
    $scope.status = "";
    $scope.method = "";
    $scope.responseTime = "";
    $scope.placeholder = "http://www.reddit.com";
    
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
            .then(function (response) {
                console.log(response)
                $scope.status = response.status;
                $scope.method = response.config.method;
                pingLast = new Date();
                b = response;
            });
        } else if (selectedMethod == 'head')
        {
            $http.head($scope.userURL)
            .then(function (response) {
                console.log(response)
                $scope.status = response.status;
                $scope.method = response.config.method;
                pingLast = new Date.now();
                b = response;
            });
        }
        $scope.responseTime = pingFirst - pingLast;
    };

    $scope.storeData = () => {
        var data = $.param({
            Status_Code: $scope.status,
            URL: $scope.userURL,
            Response_Time: $scope.responseTime,
            Method: $scope.method,
            Time : null
        })

        
        $http.post('http://localhost/api/Response/', data)
        .then(function (response) {
            console.log(response);
        })

    };


});