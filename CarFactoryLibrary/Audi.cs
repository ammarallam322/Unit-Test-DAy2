using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactoryLibrary
{
    public class Audi : Car
    {
        public override void Accelerate()
        {
            this.velocity+=20;
        }
    }
}
