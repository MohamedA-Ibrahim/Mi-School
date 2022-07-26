using MiSchool.Factory;
using MiSchool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSchool.Controller
{
    public class cmdSection
    {
        Repository<CLS_Section> cmd = new Repository<CLS_Section>();

        public List<CLS_Section> GetSectionByClassId(int classId)
        {
            try
            {
                return cmd.GetById("SF_GetSectionByClassId", classId).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
