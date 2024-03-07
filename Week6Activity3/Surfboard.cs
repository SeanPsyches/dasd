using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Activity3
{
    [Serializable]
    public abstract class Surfboard : ISurf
    {
        // Properties / attributes

        private string Length { get; set; }
        private string Width { get; set; }
        private int Volume { get; set; }

        public string SurfboardName { get; set; }

        // Constructors / methods
        public Surfboard() { }
        public Surfboard(string surfboardName, string sLength, string sWidth, int sVolume)
        {
            SurfboardName = surfboardName;
            Length = sLength;
            Width = sWidth;
            Volume = sVolume;
        }

        // ToString()
        public override string ToString()
        {
            return $"Name : {SurfboardName} Length : {Length}, Volume : {Volume}, Width : {Width} ";
        }

        public int GetVolume()
        {
            return Volume;
        }
        public abstract void Surf();
        
    }
}
