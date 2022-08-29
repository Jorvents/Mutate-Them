using MutateThem.Some_things;
using MutateThem.Some_things.Me;
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
        public Game(Player player)
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
                player.IsActive = false;
                ScatterThem(1);
            }
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_L))
            {
                player.IsActive = false;
                ScatterThem(5000);
            }
        }
        void Work()
        {
            float AngLe = Angle(player.loc, Raylib.GetMouseX(), Raylib.GetMouseY());
            player.HandRotation = AngLe + 134;
            HandPowers thisPower = player.handpowers;
            thisPower.rotateIn = toVector(AngLe - 180) * thisPower.disctance;
            thisPower.grabbing = enemies;
            player.Work();
            foreach (Enemy enemy in enemies)
            {
                //enemyz.MyEnemy = player;
                enemy.Work();
            }
        }
        void Draw()
        {
            Raylib.DrawText(Raylib.GetFPS().ToString(), 15, 15, 30, Color.WHITE);
            //Raylib.DrawLine((int)player.loc.X, (int)player.loc.Y, Raylib.GetMouseX(), Raylib.GetMouseY(), Color.YELLOW);
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw();
            }
            player.Draw();

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
        public Vector2 toVector(float angle)
        {
            double angleD = angle / (180 / Math.PI);
            return new Vector2((float)Math.Cos(angleD),(float)Math.Sin(angleD));
        }
        public float Hypotenus()
        {
            return 0.0f;
        }
    }
}
