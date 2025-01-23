using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLover.Core
{
    public class Member:BaseEntity
    {
        public string Name { get; set; }
        public string Profession { get; set; }
        public string ImgUrl { get; set; }
    }
}
