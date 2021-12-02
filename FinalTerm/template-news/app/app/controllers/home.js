app.controller("home",function($scope,$http){
    $scope.fname = "Tanvir";
    $http.get("https://jsonplaceholder.typicode.com/posts").
    then(function(resp){
        $scope.posts = resp.data.slice(0,5);

    });
});
