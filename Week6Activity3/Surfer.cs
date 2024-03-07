using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Activity3
{
    [Serializable]      //so the data can be kept even if application is closed
    public abstract class Surfer : ISurf, IComparable<Surfer>   
    {
        //Properties
        public string Name { get; set; }        //i HAVE USED both types of getters and setters throughout my portfolio, I prefer declaring it in my properties section
        public string Country { get; set; }
        public string Stance { get; set; }
       

        //Methods
        public Surfer() { }

        public Surfboard AssignedSurfboard { get; set; }

        public Surfer(string sName, string sCountry, string sStance)
        {
            Name = sName;
            Country = sCountry;
            Stance = sStance;
        }

        // ToString()
        public override string ToString()
        {
            return $"Name : {Name}, Country : {Country}, Stance : {Stance}";
        }

       public int CompareTo(Surfer other)
        {
            if (other == null)  //comparing to another surfer lexicographically, comparing Name to other.Name and returning 1, 0 or -1
                return 1;

            return string.Compare(Name, other.Name);     
        }
       //overriding interface method
        public abstract void Surf();
    }
}
