using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSchool.Model
{
    class CLS_Violation : CLS_Student
    {
        public int ViolationId { get; set; }
        public string date { get; set; }
        public string Uniform { get; set; }
        public string Trouble { get; set; }
    }
}
