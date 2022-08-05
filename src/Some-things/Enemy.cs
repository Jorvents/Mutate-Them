using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace MutateThem.Some_things
{

    public class Enemy : Something
    {
        public int count { get; set; }
        //public Vector2[] vector2s { get; set; }
        public Enemy(Player player)
        {
            count = 5;
            loc = new Vector2[count];

            var rndm = new Random();

            for (int i = 0; i < count; i++)
            {
                loc[i] = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
            }

            //loc = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));

            radius = 30;
            colour = Raylib_cs.Color.RED;
        }
        public void Work()
        {

        }
        private void ScatterThem
    }
}
