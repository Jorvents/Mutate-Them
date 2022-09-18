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
using MutateThem.Some_things.notPlayer;

namespace MutateThem
{
    class Game
    {
        Player player;
        //Enemy enemy;
        static public List<Enemy> enemies { get; set; }
        //static public Enemy[] enemiess { get; set; }
        static public List<Ally> allies { get; set; }
        //static public Ally[] alliess { get; set; }

        //public Ally[] allies;
        //public Ally alli;
        public static int lastPressed3;
        public Game(Player player)
        {
            this.player = player;
            //Console.WriteLine(Directory.GetCurrentDirectory());
            //this.enemy = enemy;
            //alli = new Ally();
            allies = new List<Ally>();
            //allies[0] = new Ally();
            //allies.Add(new Ally(new Vector2(100, 100)));
            ScatterThem(50);
            lastPressed3 = 0;
        }
        public void justRun()// VERY IMPORTANT
        {
            Play();
            Work();
            Draw();
        }
        void Play()
        {
            player.handpowers.leftclicked = Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT);
            player.handpowers.rightclicked = Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_RIGHT);

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ONE))
            {
                lastPressed3 = 1;
            }
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_TWO))
            {
                lastPressed3 = 2;
            }
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_THREE))
            {
                lastPressed3 = 3;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_K))
            {
                Reset();
                ScatterThem(1);
            }
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_O))
            {
                Reset();
                ScatterThem(50);
            }
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_L))
            {
                Reset();
                ScatterThem(5000);
            }
        }
        void Work()
        {
            float AngLe = Angle(player.loc, Raylib.GetMouseX(), Raylib.GetMouseY());
            player.HandRotation = AngLe + 135;
            HandPowers thisPower = player.handpowers;
            thisPower.rotateIn = toVector(AngLe - 180) * thisPower.disctance;

            player.Work();
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Work();
                if (enemies[i].isDead)
                {
                    //enemies[i] = null;
                    enemies.RemoveAt(i);
                }
            }
            for (int i = 0; i < allies.Count; i++)
            {
                allies[i].Work();
                if (allies[i].IsActive == false)
                {
                    allies.RemoveAt(i);
                }
            }
        }
        void Draw()
        {

            Raylib.DrawText(Raylib.GetFPS().ToString(), 15, 15, 30, Color.WHITE);
            Raylib.DrawText(lastPressed3.ToString(), 15, 45, 30, Color.WHITE);

            //Raylib.DrawLine((int)player.loc.X, (int)player.loc.Y, Raylib.GetMouseX(), Raylib.GetMouseY(), Color.YELLOW);
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw();
            }
            for (int i = 0; i < allies.Count; i++)
            {
                allies[i].Draw();
            }
            player.Draw();
        }
        public void ScatterThem(int count)
        {
            //count++;
            //enemies = new Enemy[count];
            enemies = new List<Enemy>();
            var rndm = new Random();

            for (int i = 0; i < count; i++)
            {
                //if (i == 0) return;
                //enemies[i].loc = new Vector();
                enemies.Add(new Enemy());
                enemies[i].MyEnemy = player;
                enemies[i].loc = new(rndm.Next(0, Raylib.GetScreenWidth()), rndm.Next(0, Raylib.GetScreenHeight()));
                enemies[i].whichOne = i;
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
        public void Reset() //Temporary for testing
        {
            player.IsActive = false;
            player.handpowers.IsActive = true;
            /*
            if (allies.Count == 0)
            {
                allies.Add(new Ally(new Vector2(100, 100)));
            }
            for (int i = 0; i < allies.Count; i++)
            {
                allies[i] = new Ally(new Vector2(100, 100));
                //ALL ON TOP
            }
            */
        }
        //NOT USED METHODS
        public static bool Timer(int time) // NOT DONE
        {
            int currentTime = Environment.TickCount;
            bool yesno = false;
            for (int i = 0; time > currentTime; i++)
            {
                return yesno;

            }
            return yesno;
        }
        public static void AddAlly(/*Vector2 location*/)
        {
            /*
            int amountAllies = allies.Length;
            allies = new Ally[amountAllies++];
            allies[amountAllies] = new Ally();
            */
        }
        public bool Touches(Vector2 loc1, int radius1, Vector2 loc2, int radius2)
        {
            return Raylib.CheckCollisionCircles(loc1, radius1, loc2, radius2);
        }
        public float Hypotenus()
        {
            return 0.0f;
        }
    }
}
