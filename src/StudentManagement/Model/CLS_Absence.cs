using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSchool.Model
{
    public class CLS_Absence : CLS_Student
    {
        public int AbsenceId { get; set; }
        public string date { get; set; }
    }
}
