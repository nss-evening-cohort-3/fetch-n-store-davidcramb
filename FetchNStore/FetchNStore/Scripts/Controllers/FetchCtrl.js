a = "";
b = "";
c = "";
app.controller('FetchCtrl', function ($scope, $http, FetchFactory) {
    $scope.userURL = "";
    $scope.status = "";
    $scope.method = "";
    $scope.responseTime = ""
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

    $scope.responseData = [];

    $scope.fetchURL = (selectedMethod) => {
        var pingFirst, pingLast;
        pingFirst = Date.now();
        if (selectedMethod == 'get')
        {
            $http.get($scope.userURL)
            .then(function (data, status, headers, config) {
                console.log("response data", data)
                $scope.status = data.status;
                $scope.method = data.config.method;
                pingLast = Date.now();
                $scope.responseTime = pingLast - pingFirst;
            }, function errorCallback(response)
            {
                console.log(response);
            });
        } else if (selectedMethod == 'head')
        {
            $http.head($scope.userURL)
            .then(function (data) {
                console.log(data);
                pingLast = Date.now();
                $scope.status = data.status;
                $scope.method = data.config.method;
                $scope.responseTime = pingLast - pingFirst;
            });
        }
    };

    $scope.storeData = () => {
        console.log('store');
        var data = {
            URL_Address: $scope.userURL,
            Status_Code: $scope.status,
            Method: $scope.method,
            Response_Time: $scope.responseTime,
        }   
        console.log(data);
            $http.post('/api/Response', data)
        .then(function (response) {
            console.log(response);
        }, function errorCallback(response) {
            console.log(response);
        });
    };

    $scope.displayData = () => {
        $scope.responseData = [];
        console.log('display!')
        FetchFactory.getData()
        .then(function (dataList) {
            Object.keys(dataList).forEach(function (key) {
                $scope.responseData.push(dataList[key]);
            });
            console.log($scope.responseData);
        });
    };
    $scope.displayData();
});



app.factory('FetchFactory', function ($q, $http) {

    var getData = () => {
        var data = [];
        return $q(function (resolve, reject) {
            $http.get('http://localhost:50386/api/Response')
            .success(function (responseObject) {
                data.push(responseObject);
                resolve(data[0]);
            })
            .error(function (error) {
                reject(error);
            });
        });
    };
    return {
        getData: getData
    }
})