using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

class ColorChangingTriangle : GameWindow
{
    private float red = 1.0f, green = 1.0f, blue = 1.0f;
    private float angle = 0.0f;

    public ColorChangingTriangle() : base(800, 600)
    {
        KeyDown += OnKeyDown;
        MouseMove += OnMouseMove;
    }

    private void OnKeyDown(object sender, KeyboardKeyEventArgs e)
    {
        if (e.Key == Key.R) red = (red + 0.1f) % 1.0f;
        if (e.Key == Key.G) green = (green + 0.1f) % 1.0f;
        if (e.Key == Key.B) blue = (blue + 0.1f) % 1.0f;
    }

    private void OnMouseMove(object sender, MouseMoveEventArgs e)
    {
        angle = e.XDelta * 0.1f;
    }

    protected override void OnLoad(EventArgs e)
    {
        GL.ClearColor(0.1f, 0.1f, 0.1f, 1.0f);
    }

    protected override void OnResize(EventArgs e)
    {
        GL.Viewport(0, 0, Width, Height);
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadIdentity();
        GL.Ortho(-1, 1, -1, 1, -1, 1);
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadIdentity();
        GL.Rotate(angle, 0.0f, 0.0f, 1.0f);

        GL.Begin(PrimitiveType.Triangles);
        GL.Color3(red, green, blue);
        GL.Vertex2(-0.5f, -0.5f);
        GL.Color3(red, green, blue);
        GL.Vertex2(0.5f, -0.5f);
        GL.Color3(red, green, blue);
        GL.Vertex2(0.0f, 0.5f);
        GL.End();

        SwapBuffers();
    }

    public static void Main()
    {
        using (var window = new ColorChangingTriangle())
        {
            window.Run(30);
        }
    }
}
