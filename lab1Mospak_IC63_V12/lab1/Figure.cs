using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Figure
    {
        public Type Type { get; set; }
        public Storona Storona { get; set; }
        public Perimetr Perimetr { get; set; }
        public Plosha Plosha { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Type != null)
                sb.Append(Type.type + "\n");
            if (Storona != null)
                sb.Append(Storona.storona + "\n");
            if (Perimetr != null)
                sb.Append(Perimetr.perimetr + "\n");
            if (Plosha != null)
                sb.Append(Plosha.plosha + "\n");
            return sb.ToString();
        }
    }
    class Type
    {
        public string type { get; set; }
    }
    class Storona
    {
        public string storona { get; set; }
    }
    class Perimetr
    {
        public string perimetr { get; set; }
    }
    class Plosha
    {
        public string plosha { get; set; }
    }

}
