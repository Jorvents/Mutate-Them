using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutateThem.Some_things.notPlayer
{
    public class Empty : Mutable
    {
        public Empty() : base(new System.Numerics.Vector2(), 0, Color.BLANK, 0) => what = Mutables.Blank;


        //very useless
        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void Work()
        {
            throw new NotImplementedException();
        }
    }
}
