using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebbShop.Controller;

namespace WebbShop.LeeUtils
{
    public static class TxtMessClass
    {
        /// <summary>
        /// Transforme Console WriteLine into an elegent form
        /// </summary>
        /// <param name="mess"></param>
        /// <returns></returns>
        public static bool Mess(string mess)
        {
            if (LeeCheckClass.IfStringContainsNullOrEmpty(mess))
            {
                Console.WriteLine(mess);
            }
            return false;
        }
    }
}
