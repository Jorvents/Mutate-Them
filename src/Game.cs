using MutateThem.Some_things;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MutateThem
{
    internal class Game
    {
        Player player;
        //Enemy enemy;
        Enemy[] enemies = new Enemy[4];
        public Game(Player player/*, Enemy enemy*/)
        {
            this.player = player;
            //this.enemy = enemy;
            ScatterThem(5);
        }
        public void justRun()
        {
            Play();
            Work();
            Draw();
        }
        void Play()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_K))
            {
                ScatterThem(5);
            }

        }
        void Work()
        {
            player.Work();
            foreach (Enemy enemyz in enemies)
            {
                //enemyz.MyEnemy = player;

                enemyz.Work();
            }
        }
        void Draw()
        {
            player.Draw();
            foreach (Enemy enemyz in enemies)
            {
                enemyz.Draw();
            }
        }
        public void ScatterThem(int count)
        {
            enemies = new Enemy[count];
            //this.count = count;
            //enemy.count = count;
            //this.count = count;
            //enemies = new Enemy[this.count];
            //enemies.loc = new Vector2[this.count];

            var rndm = new Random();

            for (int i = 0; i < count; i++)
            {
                //enemies[i].loc = new Vector();
                enemies[i] = new Enemy();
                enemies[i].MyEnemy = player;
                enemies[i].loc = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
                /*
                enemy.loc = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));

                /*
                enemies[i] = new Enemy(MyEnemy);
                enemies[i].loc = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
                //loc[i] = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
                //enemies = new Enemy[i];
                /*
                enemies[i] ??= new Enemy(MyEnemy);
                enemies[i].loc = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
                */
            }
        }
    }
}
