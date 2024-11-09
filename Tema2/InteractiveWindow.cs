using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;


namespace TemeOpenGL
{
    class InteractiveWindow : GameWindow
    {
        private float posX = 0.0f;
        private float posY = 0.0f;
        private float rotationAngle = 0.0f;

        public InteractiveWindow() : base(800, 600)
        {
            KeyDown += Keyboard_KeyDown;
            MouseMove += Mouse_Move;
        }

        void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Exit();

            if (e.Key == Key.F11)
                this.WindowState = (this.WindowState == WindowState.Fullscreen) ? WindowState.Normal : WindowState.Fullscreen;

            if (e.Key == Key.Left) posX -= 0.1f;
            if (e.Key == Key.Right) posX += 0.1f;
            if (e.Key == Key.Up) posY += 0.1f;
            if (e.Key == Key.Down) posY -= 0.1f;
        }

        void Mouse_Move(object sender, MouseMoveEventArgs e)
        {
            rotationAngle = e.XDelta * 0.1f;
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.MidnightBlue);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-2.0, 2.0, -2.0, 2.0, 0.0, 4.0); 
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Translate(posX, posY, 0.0f); // Apply translation
            GL.Rotate(rotationAngle, 0.0f, 0.0f, 1.0f); // Apply rotation

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.MidnightBlue);
            GL.Vertex2(-0.5f, 0.5f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex2(0.5f, 0.5f);
            GL.Color3(Color.Ivory);
            GL.Vertex2(0.0f, -0.5f);

            GL.End();

            SwapBuffers();
        }

        [STAThread]
        static void Main(string[] args)
        {
            using (InteractiveWindow example = new InteractiveWindow())
            {
                example.Run(30.0, 0.0);
            }
        }
    }
}
