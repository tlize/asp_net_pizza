using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BO
{
    public class Pate : IEnumerable
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}