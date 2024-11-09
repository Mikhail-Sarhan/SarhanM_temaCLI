using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

class CoordinateAxes : GameWindow
{
    protected override void OnLoad(EventArgs e)
    {
        GL.ClearColor(0f, 0f, 0f, 1f);
    }

    protected override void OnResize(EventArgs e)
    {
        GL.Viewport(0, 0, Width, Height);
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadIdentity();
        GL.Ortho(-10, 10, -10, 10, -1, 1);
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);

        // Draw X and Y axes
        GL.Begin(PrimitiveType.Lines);
        GL.Color3(1.0f, 0.0f, 0.0f); // Red for X-axis
        GL.Vertex2(-10.0f, 0.0f);
        GL.Vertex2(10.0f, 0.0f);

        GL.Color3(0.0f, 1.0f, 0.0f); // Green for Y-axis
        GL.Vertex2(0.0f, -10.0f);
        GL.Vertex2(0.0f, 10.0f);
        GL.End();

        SwapBuffers();
    }

}
