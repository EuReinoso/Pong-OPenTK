using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Input;

namespace PongOpenTK
{ 
    class Bar
    {
        public int sizeX = new int();
        public int sizeY = new int();
        public int[] pos = new int[2];
        public int vel = new int();
        public int pts = new int();

        public Bar(int posX, int posY, int sizeX, int sizeY)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.pos[0] = posX;
            this.pos[1] = posY;
            this.vel = 7;

            this.pts = 0;
        }

        public void move(string bar)
        {
            if(bar == "left")
            {
                if (Keyboard.GetState().IsKeyDown(Key.W))
                {
                    pos[1] += vel;
                }
                if (Keyboard.GetState().IsKeyDown(Key.S))
                {
                    pos[1] -= vel;
                }
            }

            if (bar == "right")
            {
                if (Keyboard.GetState().IsKeyDown(Key.Up))
                {
                    pos[1] += vel;
                }
                if (Keyboard.GetState().IsKeyDown(Key.Down))
                {
                    pos[1] -= vel;
                }
            }
        }
    
        public void point()
        {
            pts++;
            
        }
    }
        
}
