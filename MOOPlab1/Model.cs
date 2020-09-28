using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MOOPlab1
{
    class Model
    {
        public int LBound { get; set; }
        public int RBound { get; set; }

        [Range(0, 100)]
        public int Answer { get; set; }
        [Range(0, 100)]
        public int YourNum { get; set; }
        public List<Model> History { get; set; }
    }
}
