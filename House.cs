using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBuild
{
    public class House
    {
        public List<IPart> Parts { get; set; }

        public House(IEnumerable<IPart> parts)
        {
            Parts = (List<IPart>)parts;
        }
    }
}
