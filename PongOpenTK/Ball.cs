using System;


namespace PongOpenTK
{
    class Ball
    {
        public int size = new int();
        public int[] pos = new int[2];
        public int velX = new int();
        public int velY = new int();
        public int velStart = new int();

        public Ball(int size, int posX, int posY){

            
            this.size = size;
            this.pos[0] = posX;
            this.pos[1] = posY;
            this.velStart = 4;
            this.velX = dirX();
            this.velY = dirY();
        }

        public void hitWall(int wallPos)
        {
            if (pos[1] + size/2 >= wallPos/2)
            {
                velY = -velY;
            }
            if (pos[1] - size/2 <= -wallPos/2)
            {
                velY = -velY;
            }
        }

        public void velocity()
        {

            pos[0] += velX;
            pos[1] += velY;
        }

        public void hitBar(Bar barR,Bar barL)
        {
            if (pos[0] + size / 2 >= barR.pos[0] - barR.sizeX / 2)
            {
                if (pos[1] + size / 2 >= barR.pos[1] - barR.sizeY / 2 && pos[1] - size / 2 <= barR.pos[1] + barR.sizeY)
                {

                    velX = -velX;
                    velX -= 1;
                }
            }
            else if (pos[0] - size / 2 <= barL.pos[0] + barL.sizeX / 2)
            {
                if (pos[1] + size / 2 >= barL.pos[1] - barL.sizeY / 2 && pos[1] - size / 2 <= barL.pos[1] + barL.sizeY)
                {
                    velX = -velX;
                    velX += 1;
                }
            }
        }

        public void makePoint(Bar barR,Bar barL,int wallPos)
        {
            if(pos[0] + size/2 >= wallPos/2)
            {
                barL.point();
                getRestart();
                printScore(barR,barL);   

            }
            if (pos[0] - size/2 <= -wallPos/2)
            {
                barR.point();
                getRestart();
                printScore(barR, barL);
            }
        }

        public void getRestart()
        {
            pos[0] = 0;
            pos[1] = 0;
            velX = dirX();
            velY = dirY();
        }

        public void printScore(Bar r,Bar l)
        {
            Console.Clear();
            Console.WriteLine("Score: " + r.pts + " x " + l.pts);
        }

        public int dirX()
        {
            Random num = new Random();
            if (num.Next(100) >= 50)
            {
                return velStart;
            }
            else
            {
                return -velStart;
            }
        }
        public int dirY()
        {
            Random num1 = new Random();
            if (num1.Next(100) >= 50)
            {
                return velStart;
            }
            else
            {
                return -velStart;
            }
        }


    }
}
