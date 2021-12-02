app.controller("post",function($scope,$http,$routeParams){
    $scope.fname = "Tanvir";

    $http.get("https://jsonplaceholder.typicode.com/posts/"+$routeParams.id).
    then(function(resp){
        $scope.post = resp.data;

    });
});
