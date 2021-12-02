using BEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;

namespace BLL
{
    public class BlogsService
    {
        //auto mapper 6.1.1 used
        public static List<BlogModel> Get() {
            //AutoMapper.Mapper
            Mapper.Initialize(cfg => cfg.CreateMap<Blog, BlogModel>());
            var data = AutoMapper.Mapper.Map<List<BlogModel>>(DataAccessFactory.BlogsDataAccess().Get()); // for automapper 6.1.1
            return data;
        }
        public static BlogModel Get(int id) {
            Mapper.Initialize(cfg => cfg.CreateMap<Blog, BlogModel>());
            var data = Mapper.Map<BlogModel>(DataAccessFactory.BlogsDataAccess().Get(id)); // for automapper 6.1.1
            return data;
        }
        public static void Create(BlogModel blog)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BlogModel, Blog>());
            var data = Mapper.Map<Blog>(blog); // for automapper 6.1.1
            DataAccessFactory.BlogsDataAccess().Add(data);
            
        }
        public static void Edit(BlogModel blog)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<BlogModel, Blog>());
            var data = Mapper.Map<Blog>(blog); // for automapper 6.1.1
            DataAccessFactory.BlogsDataAccess().Edit(data);

        }
        public static void Delete(int id)
        {
            DataAccessFactory.BlogsDataAccess().Delete(id);
        }




    }
}
