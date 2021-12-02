app.controller("products",function($scope,$http,ajax){
    ajax.get("https://localhost:44350/api/Product",success,error);
    function success(response){
      $scope.products=response.data;
    }
    function error(error){

    }

});
