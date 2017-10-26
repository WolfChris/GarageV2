using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageV2.Controllers
{
    public class TypeCount : IEnumerable
    {
        public string Type { get; set; }
        public int Count { get; set; }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Type).GetEnumerator();
        }
    }
}