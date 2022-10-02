using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MutateThem
{
    class DebugController //Concept
    {
        public List<string> stats = new List<string>(); //might make a custom object: stat //In a new folder //vars : Colour, WhatCorner, Size, 
        private int spacing; // 30 //for the first one 15
        private int fontSize; //30
        private Color textColour;
        public DebugController(int spacing, int fontSize, Color textColour)
        {
            this.spacing = spacing;
            this.fontSize = fontSize;
            this.textColour = textColour;
        }
        public DebugController()
        {
            spacing = 30;
            fontSize = 30;
            textColour = Color.WHITE;
        }

        public void Draw()
        {
            //int i = 0;
            stats.ForEach(s =>
            {
                int i = stats.IndexOf(s);
                Raylib.DrawText(s, 15, spacing * i + 15, fontSize, textColour);
            });
            //Raylib.DrawText(stats.First, )
        }
        public void Add(string stat)
        {
            foreach (string t in stats.Where(t =>
                     stat == t))
            {
                stats.Remove(t);
            }
            stats.Add(stat);
        }
        public void Add(int stat)
        {
            if (stat == 0)
            stats.Add(stat.ToString());
        }
        public void Add(Vector2 stat)
        {
            stats.Add(stat.ToString());
        }
    }
}
