using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week6Activity3
{
    [Serializable]
    public class ChubbyChedda : Surfboard, ISurf
    {
        public ChubbyChedda(string sLength, string sWidth, int sVolume)
            : base("ChubbyChedda", sLength, sWidth, sVolume)    //Put ChubbyChedda so I wouldn't have to 'name' it later
        {
        }
        public override void Surf()
        {
        }
    }
}
