using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSchool.Model
{
    public class CLS_Parent : CLS_Student
    {
        public int ParentId { get; set; }
        public string date { get; set; }
        public string Reason { get; set; }
        public string Done { get; set; }
    }
}
