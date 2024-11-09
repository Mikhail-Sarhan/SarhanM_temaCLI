using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

class TriangleColorControl : GameWindow
{
    private float[,] vertexColors = { { 1.0f, 0.0f, 0.0f }, { 0.0f, 1.0f, 0.0f }, { 0.0f, 0.0f, 1.0f } };

    protected override void OnLoad(EventArgs e)
    {
        GL.ClearColor(0.1f, 0.1f, 0.1f, 1.0f);
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);

        GL.Begin(PrimitiveType.Triangles);
        for (int i = 0; i < 3; i++)
        {
            GL.Color3(vertexColors[i, 0], vertexColors[i, 1], vertexColors[i, 2]);
            GL.Vertex2(i == 0 ? -0.5f : 0.5f, i == 2 ? -0.5f : 0.5f);
        }
        GL.End();

        Console.WriteLine($"Vertex Colors: R={vertexColors[0, 0]}, G={vertexColors[1, 1]}, B={vertexColors[2, 2]}");

        SwapBuffers();
    }

   /* public static void Main()
    {
        using (var window = new TriangleColorControl())
        {
            window.Run(30);
        }
    }*/
}
