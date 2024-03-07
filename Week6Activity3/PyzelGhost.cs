using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week6Activity3
{
    [Serializable]
    public class PyzelGhost : Surfboard, ISurf
    {
        public PyzelGhost(string sLength, string sWidth, int sVolume)
           : base("PyzelGhost", sLength, sWidth, sVolume) //Put PyzelGhost so I wouldn't have to 'name' it later
        {
        }
        public override void Surf()
        {
        }
    }
}
