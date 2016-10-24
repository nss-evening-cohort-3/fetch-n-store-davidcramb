var hi = "hi";
console.log(hi);
app.controller('FetchCtrl', function ($scope, $http) {
    $scope.userURL = "";
    $scope.status = "";
    $scope.method = "";
    $scope.responseTime = "";
    $scope.placeholder = "http://www.reddit.com";

    $scope.fetchURL = () => {
        console.log("test");
        console.log($scope.userURL);
        $http.get($scope.userURL)
        .then(function (response) {
            console.log(response)
            $scope.status = response.status;
            $scope.method = response.config.method; 
        });
    };


});