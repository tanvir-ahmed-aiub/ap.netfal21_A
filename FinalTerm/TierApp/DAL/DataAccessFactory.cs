using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static UMS_AEntities db;
        static DataAccessFactory() {
            db = new UMS_AEntities();
        }
        public static IRepository<Student,int> StudentDataAcees() {
            return new StudentRepo(db);    
        }
        public static IRepository<Department,int> DepartmentDataAccess() {
            return new DepartmentRepo(db);
        }
        
    }
}
