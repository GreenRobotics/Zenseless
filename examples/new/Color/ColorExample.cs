﻿namespace Example
{
	using OpenTK.Graphics.OpenGL;
	using System;
	using System.Numerics;
	using Zenseless.Base;
	using Zenseless.ExampleFramework;
	using Zenseless.Geometry;
	using Zenseless.OpenGL;

	class MyVisual
	{
		private GameTime time = new GameTime();

		private void Render()
		{
			GL.Clear(ClearBufferMask.ColorBufferBit);
			var hue = (float)(Math.Sin(time.AbsoluteTime * 0.3) * 0.5 + 0.5);
			const int count = 16;
			var boxSize = 1.9f / count;
			for (int xI = 0; xI < count; ++xI)
			{
				float x = xI * 2f / count - 1f;
				float brightness = xI / (float)count;
				for (int yI = 0; yI < count; ++yI)
				{
					float y = yI * 2f / count - 1f;
					float saturation = yI / (float)count;
					var color = ColorSystems.Hsb2rgb(hue, saturation, brightness);
					DrawRect(new Box2D(x, y, boxSize, boxSize), color);
				}
			}
		}

		private void DrawRect(IReadOnlyBox2D rectangle, Vector3 color)
		{
			GL.Color3(color.X, color.Y, color.Z);
			GL.Begin(PrimitiveType.Quads);
			GL.Vertex2(rectangle.MinX, rectangle.MinY);
			GL.Vertex2(rectangle.MaxX, rectangle.MinY);
			GL.Vertex2(rectangle.MaxX, rectangle.MaxY);
			GL.Vertex2(rectangle.MinX, rectangle.MaxY);
			GL.End();
		}

		[STAThread]
		private static void Main()
		{
			var window = new ExampleWindow();
			var visual = new MyVisual();
			window.Render += visual.Render;
			window.Run();
		}
	}
}