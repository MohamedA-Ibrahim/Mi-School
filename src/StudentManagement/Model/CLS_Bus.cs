using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSchool.Model
{
    public class CLS_Bus : CLS_Student
    {
        public int BusId { get; set; }
        public string date { get; set; }
        public string Problem { get; set; }
        public string Solution { get; set; }

    }
}
