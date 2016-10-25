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
        console.log("test");
        console.log($scope.userURL);
        console.log($scope.selected.value);
        console.log(selectedMethod == 'get');
        if (selectedMethod == 'get')
        {
            $http.get($scope.userURL)
            .then(function (response) {
                console.log(response)
                $scope.status = response.status;
                $scope.method = response.config.method;
                b = response;
            });
        } else if (selectedMethod == 'head')
        {
            $http.head($scope.userURL)
            .then(function (response) {
                console.log(response)
                $scope.status = response.status;
                $scope.method = response.config.method;
                b = response;
            });
        }
    };

    $scope.storeData = () => {
        //
    };


});