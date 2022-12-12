using MutateThem.Scenes;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MutateThem.Some_things.notPlayer
{
    public class MutablesController
    {
        public List<Mutable> info = new();
        Vector2 enemiescentre;
        public enum Mutables
        {
            Blank = -1, //Empty
            Throw,      //Enemy
            Ally,
            Bomb,
            Teleport,
            Shield,
            Heal
        }

        public MutablesController()
        {
            info.Add(new Enemy(Game.player, new Vector2()));
            info.Add(new Ally(new Vector2()));
            info.Add(new Bomb(new Vector2()));
            info.Add(new Teleport(new Vector2()));
            info.Add(new Shield(new Vector2()));
            info.Add(new Heal(new Vector2()));
        }
        public void Work()
        {
            if (Game.enemies.Count == 1) return;
            if (!Game.player.isActive) return;
            if (!Game.enemies.Any()) return;

            Vector2[] locs = new Vector2[Game.enemies.Count];

            for (int i = 0; i < Game.enemies.Count; i++)
            {
                locs[i] = Game.enemies[i].loc;
            }
            enemiescentre = Vector2.Zero;

            enemiescentre = Centre(locs);

            for (int i = 0; i < Game.enemies.Count; i++)
            {
                if (Game.enemies[i].inControl) return;
                Vector2 farness = Game.enemies[i].loc - enemiescentre;
                Vector2 direction = Vector2.Normalize(farness);
                Game.enemies[i].loc += direction * 10 * Raylib.GetFrameTime();
            }
        }
        public void Draw()
        {

        }
        public Vector2 Centre(Vector2[] locs)
        {
            Vector2 sum = locs.Aggregate((a, b) => new Vector2(a.X + b.X, a.Y + b.Y));
            int size = locs.Length;
            sum /= size;
            return sum;
        }
    }
}
