using MiSchool.Factory;
using MiSchool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSchool.Controller
{
    public class cmdStudent
    {
        Repository<CLS_Student> cmd = new Repository<CLS_Student>();

        public List<CLS_Student> GetAllStudent()
        {
            try
            {
                return cmd.GetAll("SF_GetAllStudent").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool AddStudent(string studentName, int classId, int sectionId, string busName, int num1, int num2, string notes)
        {
            try
            {
                List<CLS_Student> cls = new List<CLS_Student>();
                cls.Add(new CLS_Student { StudentName = studentName, ClassId = classId, SectionId = sectionId, BusName = busName, Num1 = num1, Num2 = num2, Notes = notes });
                cmd.ExecuteParam("SF_InsertStudent", cls);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditStudent(int studentId, string studentName, int classId, int sectionId, string busName, int num1, int num2, string notes)
        {
            try
            {
                List<CLS_Student> cls = new List<CLS_Student>();
                cls.Add(new CLS_Student { StudentName = studentName, ClassId = classId, SectionId = sectionId, BusName = busName, Num1 = num1, Num2 = num2, Notes = notes });
                cmd.ExecuteParam("SF_UpdateStudent", cls);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveStudent(int studnetId)
        {
            try
            {
                List<CLS_Student> cls = new List<CLS_Student>();
                cls.Add(new CLS_Student { StudentId = studnetId });
                cmd.ExecuteParam("SF_DeleteStudent", cls);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
