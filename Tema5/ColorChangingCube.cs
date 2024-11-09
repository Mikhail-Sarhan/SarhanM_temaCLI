using System;
using System.Drawing;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

class ColorChangingCube : GameWindow
{
    private float[,,] cubeVertices;
    private float[,] faceColors = new float[6, 4]; 
    private Random random = new Random();

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;
    private float rotationZ = 0.0f;

    public ColorChangingCube() : base(800, 600)
    {
        LoadCubeVertices("cube_coords.txt");
        KeyDown += OnKeyDown;
        RandomizeColors();
    }

    private void LoadCubeVertices(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        cubeVertices = new float[6, 4, 3];
        int faceIndex = 0;

        foreach (var line in lines)
        {
            var coords = line.Split(',');
            for (int i = 0; i < 4; i++)
            {
                cubeVertices[faceIndex, i, 0] = float.Parse(coords[i * 3]);
                cubeVertices[faceIndex, i, 1] = float.Parse(coords[i * 3 + 1]);
                cubeVertices[faceIndex, i, 2] = float.Parse(coords[i * 3 + 2]);
            }
            faceIndex++;
        }
    }

    private void OnKeyDown(object sender, KeyboardKeyEventArgs e)
    {
        if (e.Key == Key.R) faceColors[0, 0] = (faceColors[0, 0] + 0.1f) % 1.0f;
        if (e.Key == Key.G) faceColors[0, 1] = (faceColors[0, 1] + 0.1f) % 1.0f;
        if (e.Key == Key.B) faceColors[0, 2] = (faceColors[0, 2] + 0.1f) % 1.0f;
        if (e.Key == Key.A) faceColors[0, 3] = (faceColors[0, 3] + 0.1f) % 1.0f;
        if (e.Key == Key.Space) RandomizeColors();
    }

    private void RandomizeColors()
    {
        for (int face = 0; face < 6; face++)
        {
            faceColors[face, 0] = (float)random.NextDouble();
            faceColors[face, 1] = (float)random.NextDouble();
            faceColors[face, 2] = (float)random.NextDouble();
            faceColors[face, 3] = 1.0f; 
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        GL.ClearColor(Color.Black);
        GL.Enable(EnableCap.DepthTest);
    }

    protected override void OnResize(EventArgs e)
    {
        GL.Viewport(0, 0, Width, Height);
        Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(
            MathHelper.DegreesToRadians(45.0f),
            Width / (float)Height,
            0.1f,
            100.0f
        );
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadMatrix(ref perspective);
    }

    private void DrawCube()
    {
        for (int face = 0; face < 6; face++)
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color4(faceColors[face, 0], faceColors[face, 1], faceColors[face, 2], faceColors[face, 3]);

            for (int vertex = 0; vertex < 4; vertex++)
            {
                GL.Vertex3(cubeVertices[face, vertex, 0], cubeVertices[face, vertex, 1], cubeVertices[face, vertex, 2]);
            }

            GL.End();
        }
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadIdentity();

        GL.Translate(0.0f, 0.0f, -5.0f);

        rotationX += 30.0f * (float)e.Time; 
        rotationY += 45.0f * (float)e.Time; 
        rotationZ += 60.0f * (float)e.Time; 

        GL.Rotate(rotationX, 1.0f, 0.0f, 0.0f);
        GL.Rotate(rotationY, 0.0f, 1.0f, 0.0f);
        GL.Rotate(rotationZ, 0.0f, 0.0f, 1.0f);

        DrawCube();

        SwapBuffers();
    }

    public static void Main()
    {
        using (var window = new ColorChangingCube())
        {
            window.Run(60);
        }
    }
}
