app.factory("ajax",function($http,$q){
  var resp=undefined;
  var api_root = "https://localhost:44350";
  return{
    say:function(){
      return "Hello ajax";
    },
    get:function(url,success,error){
        $http.get(api_root+url).then(success,error);
    },
    post:function(url,data,success,error){
        $http.post(api_root+url,data).then(success,error);
    },
  }
});
