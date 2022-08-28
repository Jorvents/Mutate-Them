using MutateThem.Some_things;
using MutateThem.Info;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.IO;
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
        Enemy[] enemies;
        public Game(Player player/*, Enemy enemy*/)
        {
            this.player = player;
            //Console.WriteLine(Directory.GetCurrentDirectory());
            //this.enemy = enemy;
            ScatterThem(25);
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
                ScatterThem(500);
            }

        }
        void Work()
        {
            player.Work();
            //player.HandRotation = Angle(player.loc, Raylib.GetMouseX(), Raylib.GetMouseY()) + 135;
            foreach (Enemy enemy in enemies)
            {
                //enemyz.MyEnemy = player;
                enemy.Work();
            }
        }
        void Draw()
        {
            player.Draw();
            //Raylib.DrawLine((int)player.loc.X, (int)player.loc.Y, Raylib.GetMouseX(), Raylib.GetMouseY(), Color.YELLOW);
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw();
            }

            //Angle(player.loc, Raylib.GetMouseX(), Raylib.GetMouseY());
        }
        public void ScatterThem(int count)
        {
            enemies = new Enemy[count];

            var rndm = new Random();

            for (int i = 0; i < count; i++)
            {
                //enemies[i].loc = new Vector();
                enemies[i] = new Enemy();
                enemies[i].MyEnemy = player;
                enemies[i].loc = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
            }
        }
        public float Angle(Vector2 first, int secondX, int secondY)
        {
            double angleD;
            angleD = Math.Atan2(first.Y - secondY , first.X - secondX);
            angleD = (180 / Math.PI) * angleD;

            //Math.Atan2;
           //Math.Tau;
            //angleD = -angleD;
            return (float)angleD;
        }
        public float Hypotenus()
        {
            return 0.0f;
        }
    }
}
