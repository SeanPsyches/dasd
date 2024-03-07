using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week6Activity3
{
    [Serializable]
    public class SunderlandShredder : Surfer, ISurf
    {
        public SunderlandShredder(string sName, string sCountry, string sStance)
            : base(sName, sCountry, sStance)    //base just included for readibility for programmer
        {
        }

        public override void Surf() //overrides Interface method
        {
        }
    }
}
