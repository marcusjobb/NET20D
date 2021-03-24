using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTajm.Interfaces
{
    public interface IPizzaTopping
    {
        List<IStuff> Ingredients { get; set; }
        void Generate(int max);
    }
}
