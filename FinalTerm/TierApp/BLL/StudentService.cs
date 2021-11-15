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
    public class StudentService
    {
        public static List<StudentModel> Get() {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<Student, StudentModel>();
                c.CreateMap<Department, DepartmentModel>();
            });
            var mapper = new Mapper(config);
            var da = DataAccessFactory.StudentDataAcees();
            var data = mapper.Map<List<StudentModel>>(da.Get());
            return data;
        }
        public static List<string> GetNames() {
            //var sl = StudentRepo.Get();
            //var data = (from v in sl select v.Name).ToList();
            var data = DataAccessFactory.StudentDataAcees().Get().Select(e => e.Name).ToList();
            return data;
        }
        public static void Add(StudentModel s) {
            var config = new MapperConfiguration(c =>
            {
                c.CreateMap<StudentModel, Student>();
               
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<Student>(s);
            DataAccessFactory.StudentDataAcees().Add(data);
        }
    }
}
