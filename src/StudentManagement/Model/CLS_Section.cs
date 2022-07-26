using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSchool.Model
{
    public class CLS_Section : CLS_Classroom
    {
        public int SubClassId { get; set; }
        public string SubClassName { get; set; }
    }
}
