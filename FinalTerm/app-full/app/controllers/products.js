app.controller("products",function($scope,$http,ajax,$route){
    var data = $route.current.$$route.user;
    console.log(JSON.parse(data));
    ajax.get("api/Product",success,error);
    function success(response){
      $scope.products=response.data;
    }
    function error(error){

    }

});
