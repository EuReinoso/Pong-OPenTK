using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace PongOpenTK
{
    class Program : GameWindow
    {

        public Ball ball = new Ball(20,0,0);
        public Bar BRight = new Bar(310,0,20,60);
        public Bar BLeft = new Bar(-310,0,20,60);

        static void Main(string[] args)
        {

            new Program().Run();

        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            ball.velocity();
            ball.hitBar(BRight,BLeft);
            BRight.move("right");
            BLeft.move("left");
            ball.makePoint(BRight,BLeft,ClientSize.Width);
            ball.hitWall(ClientSize.Height);

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {

            GL.Viewport(0, 0, ClientSize.Width, ClientSize.Height);

            Matrix4 projection = Matrix4.CreateOrthographic(ClientSize.Width, ClientSize.Height, 0.0f, 1.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            printRectangle(ball.pos[0], ball.pos[1], ball.size,ball.size);
            printRectangle(BRight.pos[0], BRight.pos[1],BRight.sizeX, BRight.sizeY);
            printRectangle(BLeft.pos[0],BLeft.pos[1], BLeft.sizeX, BLeft.sizeY);

            SwapBuffers();
        }

        void printRectangle(float x, float y, float width, float height)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(-0.5f * width + x, -0.5 * height + y);
            GL.Vertex2(0.5f * width + x, -0.5 * height + y);
            GL.Vertex2(0.5f * width + x, 0.5 * height + y);
            GL.Vertex2(-0.5f * width + x, 0.5 * height + y);
            GL.End();
        }

        


    }
}
