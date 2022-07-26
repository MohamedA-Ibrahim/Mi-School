using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSchool.Model
{
    public class CLS_HealthConditions : CLS_Student
    {
        public int HealthId { get; set; }
        public string Condition { get; set; }
        public string Date { get; set; }
    }
}
