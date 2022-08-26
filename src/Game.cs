using MutateThem.Some_things;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutateThem
{
    internal class Game
    {
        Player player;
        Enemy enemy;
        public Game(Player player, Enemy enemy)
        {
            this.player = player;
            this.enemy = enemy;
            this.enemy.MyEnemy = player;
            /*
            Player player = new Player();
            Enemy enemy = new Enemy(player);
            */
        }
        public void Init()
        {

        }
        public void justRun()
        {
            Work();
            Play();
            Draw();

        }
        void Play()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_K))
            {
                enemy.ScatterThem(5);
            }
        }
        void Work()
        {
            player.Work();
            enemy.Work();
        }
        void Draw()
        {
            player.Draw();
            enemy.Draw();
        }
    }
}
