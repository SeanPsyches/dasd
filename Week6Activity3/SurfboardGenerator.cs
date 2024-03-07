using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Activity3
{
    public static class AvailableSurfboards     //very self explanatory, allows me to generate varying surfboards with different but usuable dimensions
    {
        public static List<Surfboard> SurfboardsAvailable()
        {
            List<Surfboard> availableSurfboards = new List<Surfboard>();

            double lengthIteration = 0.2;

            for (double length = 5.4; length <= 7.6; length += lengthIteration)
            {
                if (length > 6.4)
                {
                    for (double thickness = 20.0; thickness <= 28.0; thickness++)
                    {
                        int volume = (int)(thickness * 1.65);
                        Surfboard surfboardc = new ChubbyChedda($"{length}'", $"{thickness}\"", volume);
                        Surfboard surfboardp = new PyzelGhost($"{length}'", $"{thickness}\"", volume);
                        availableSurfboards.Add(surfboardc);
                        availableSurfboards.Add(surfboardp);
                    }
                }
                else
                {
                    for (double thickness = 15.0; thickness <= 24.0; thickness++)
                    {
                        if (thickness < 20)
                        {
                            int volume = (int)(thickness * 1.8);
                            Surfboard surfboardc = new ChubbyChedda($"{length}'", $"{thickness}\"", volume);
                            Surfboard surfboardp = new PyzelGhost($"{length}'", $"{thickness}\"", volume);
                            availableSurfboards.Add(surfboardc);
                            availableSurfboards.Add(surfboardp);
                        }
                        else if (thickness >= 20)
                        {
                            int volume = (int)(thickness * 1.3);
                            Surfboard surfboardc = new ChubbyChedda($"{length}'", $"{thickness}\"", volume);
                            Surfboard surfboardp = new PyzelGhost($"{length}'", $"{thickness}\"", volume);
                            availableSurfboards.Add(surfboardc);
                            availableSurfboards.Add(surfboardp);
                        }
                    }
                }
            }

            return availableSurfboards;
        }
    }
}
