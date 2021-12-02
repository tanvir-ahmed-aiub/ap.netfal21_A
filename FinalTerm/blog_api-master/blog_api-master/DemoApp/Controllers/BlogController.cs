using BEL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoApp.Controllers
{
    public class BlogController : ApiController
    {
        [Route("api/blogs")]
        [HttpGet]
        public HttpResponseMessage Get() { 
            return Request.CreateResponse(HttpStatusCode.OK, BlogsService.Get());
        }
        [Route("api/blogs/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id) {
            return Request.CreateResponse(HttpStatusCode.OK, BlogsService.Get(id));
        }
        [Route("api/blogs/create")]
        [HttpPost]
        public HttpResponseMessage Create(BlogModel blog)
        {
            BlogsService.Create(blog);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [Route("api/blogs/edit")]
        [HttpPost]
        public HttpResponseMessage Edit(BlogModel blog)
        {
            BlogsService.Edit(blog);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [Route("api/blogs/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            BlogsService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
