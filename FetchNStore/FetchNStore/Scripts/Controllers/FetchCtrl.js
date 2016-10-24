var hi = "hi";
console.log(hi);
app.controller('FetchCtrl', function ($scope, $http) {
    $scope.placeholder = "http://www.reddit.com";
    $scope.fetchURL = () => {
        console.log("test");
    };
});