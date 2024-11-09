using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

class FallingCubes : GameWindow
{
    private List<Cube> cubes = new List<Cube>();
    private Random random = new Random();
    private float spawnInterval = 1.0f;
    private float timeSinceLastSpawn = 0.0f;
    private const float gravity = -9.8f;

    public FallingCubes() : base(800, 600)
    {
        KeyDown += OnKeyDown;
    }

    private class Cube
    {
        public Vector3 Position;
        public Vector3 Velocity;
        public float Size;
        public float[] Color;

        public Cube(Vector3 position, float size, float[] color)
        {
            Position = position;
            Size = size;
            Velocity = Vector3.Zero;
            Color = color;
        }

        public void ApplyGravity(float deltaTime)
        {
            Velocity.Y += gravity * deltaTime;
        }

        public void Update(float deltaTime)
        {
            Position += Velocity * deltaTime;
        }

        public void Draw()
        {
            GL.Color3(Color[0], Color[1], Color[2]);

            GL.Begin(PrimitiveType.Quads);

            // Front face
            GL.Vertex3(Position.X - Size, Position.Y - Size, Position.Z + Size);
            GL.Vertex3(Position.X + Size, Position.Y - Size, Position.Z + Size);
            GL.Vertex3(Position.X + Size, Position.Y + Size, Position.Z + Size);
            GL.Vertex3(Position.X - Size, Position.Y + Size, Position.Z + Size);

            // Back face
            GL.Vertex3(Position.X - Size, Position.Y - Size, Position.Z - Size);
            GL.Vertex3(Position.X + Size, Position.Y - Size, Position.Z - Size);
            GL.Vertex3(Position.X + Size, Position.Y + Size, Position.Z - Size);
            GL.Vertex3(Position.X - Size, Position.Y + Size, Position.Z - Size);

            // Left face
            GL.Vertex3(Position.X - Size, Position.Y - Size, Position.Z - Size);
            GL.Vertex3(Position.X - Size, Position.Y - Size, Position.Z + Size);
            GL.Vertex3(Position.X - Size, Position.Y + Size, Position.Z + Size);
            GL.Vertex3(Position.X - Size, Position.Y + Size, Position.Z - Size);

            // Right face
            GL.Vertex3(Position.X + Size, Position.Y - Size, Position.Z - Size);
            GL.Vertex3(Position.X + Size, Position.Y - Size, Position.Z + Size);
            GL.Vertex3(Position.X + Size, Position.Y + Size, Position.Z + Size);
            GL.Vertex3(Position.X + Size, Position.Y + Size, Position.Z - Size);

            // Top face
            GL.Vertex3(Position.X - Size, Position.Y + Size, Position.Z - Size);
            GL.Vertex3(Position.X + Size, Position.Y + Size, Position.Z - Size);
            GL.Vertex3(Position.X + Size, Position.Y + Size, Position.Z + Size);
            GL.Vertex3(Position.X - Size, Position.Y + Size, Position.Z + Size);

            // Bottom face
            GL.Vertex3(Position.X - Size, Position.Y - Size, Position.Z - Size);
            GL.Vertex3(Position.X + Size, Position.Y - Size, Position.Z - Size);
            GL.Vertex3(Position.X + Size, Position.Y - Size, Position.Z + Size);
            GL.Vertex3(Position.X - Size, Position.Y - Size, Position.Z + Size);

            GL.End();
        }
    }

    private void OnKeyDown(object sender, KeyboardKeyEventArgs e)
    {
        if (e.Key == Key.Space)
        {
            SpawnCube();
        }
    }

    private void SpawnCube()
    {
        float size = 0.5f;
        float xPosition = (float)(random.NextDouble() * 4.0f - 2.0f);
        float[] color = { (float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble() };
        cubes.Add(new Cube(new Vector3(xPosition, 6.0f, 0.0f), size, color));
    }

    protected override void OnLoad(EventArgs e)
    {
        GL.ClearColor(0.1f, 0.1f, 0.1f, 1.0f);
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

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        float deltaTime = (float)e.Time;
        timeSinceLastSpawn += deltaTime;

        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnCube();
            timeSinceLastSpawn = 0.0f;
        }

        foreach (var cube in cubes)
        {
            cube.ApplyGravity(deltaTime);
            cube.Update(deltaTime);
        }

        HandleCollisions();
    }

    private void HandleCollisions()
    {
        float groundLevel = -3.0f;

        foreach (var cube in cubes)
        {
            if (cube.Position.Y - cube.Size <= groundLevel)
            {
                cube.Position.Y = groundLevel + cube.Size;
                cube.Velocity.Y = 0;
            }

            foreach (var other in cubes)
            {
                if (cube == other) continue;

                if (Math.Abs(cube.Position.X - other.Position.X) < cube.Size &&
                    Math.Abs(cube.Position.Y - other.Position.Y) < cube.Size * 2)
                {
                    if (cube.Position.Y > other.Position.Y)
                    {
                        cube.Position.Y = other.Position.Y + cube.Size * 2;
                        cube.Velocity.Y = 0;
                    }
                }
            }
        }
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadIdentity();

        GL.Translate(0.0f, -1.0f, -10.0f);
        GL.Rotate(30.0f, 1.0f, 0.0f, 0.0f);

        DrawGround();
        foreach (var cube in cubes)
        {
            cube.Draw();
        }

        SwapBuffers();
    }

    private void DrawGround()
    {
        GL.Color3(0.5f, 0.5f, 0.5f);
        GL.Begin(PrimitiveType.Lines);

        for (float i = -4; i <= 4; i++)
        {
            GL.Vertex3(i, -3.0f, -4.0f);
            GL.Vertex3(i, -3.0f, 4.0f);
        }

        GL.End();
    }

    public static void Main()
    {
        using (var window = new FallingCubes())
        {
            window.Run(60);
        }
    }
}
