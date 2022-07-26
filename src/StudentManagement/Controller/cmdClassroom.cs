using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiSchool.Factory;
using MiSchool.Model;

namespace MiSchool.Controller
{
    public class cmdClassroom
    {
        Repository<CLS_Classroom> cmd = new Repository<CLS_Classroom>();

        public List<CLS_Classroom> GetAllClass()
        {
            try
            {
                return cmd.GetAll("SF_GetAllClassrooms").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
