﻿namespace Example
{
	using OpenTK.Graphics;
	using OpenTK.Graphics.OpenGL;
	using System;
	using Zenseless.ExampleFramework;
	using Zenseless.Geometry;
	using Zenseless.HLGL;

	class MyVisual
	{
		private MyVisual(IRenderState renderState)
		{
			//background clear color
			renderState.Set(new ClearColorState(1, 1, 1, 1));
			//setup blending equation Color = Color_new · alpha + Color_before · (1 - alpha)
			renderState.Set(new BlendState(BlendOperator.Add, BlendParameter.SourceAlpha, BlendParameter.OneMinusSourceAlpha));
			//renderState.Set(BlendStates.AlphaBlend); // does the same
		}

		private void Render()
		{
			GL.Clear(ClearBufferMask.ColorBufferBit);

			var rectA = new Box2D(0f, 0f, .5f, .5f);
			var colorA = new Color4(1f, 1f, 0f, .75f);

			var rectB = new Box2D(.1f, -.1f, .5f, .5f);
			var colorB = new Color4(0f, 1f, 1f, .75f);

			GL.LoadIdentity();
			GL.Translate(-0.8f, -.25f, 0f);
			DrawRect(rectA, colorA);
			DrawRect(rectB, colorB);

			GL.Translate(1f, 0f, 0f);
			DrawRect(rectB, colorB);
			DrawRect(rectA, colorA);
		}

		[STAThread]
		private static void Main()
		{
			var window = new ExampleWindow();
			var visual = new MyVisual(window.RenderContext.RenderState);
			window.Render += visual.Render;
			window.Run();
		}

		private void DrawRect(IReadOnlyBox2D rectangle, Color4 color)
		{
			GL.Color4(color);
			GL.Begin(PrimitiveType.Quads);
			GL.Vertex2(rectangle.MinX, rectangle.MinY);
			GL.Vertex2(rectangle.MaxX, rectangle.MinY);
			GL.Vertex2(rectangle.MaxX, rectangle.MaxY);
			GL.Vertex2(rectangle.MinX, rectangle.MaxY);
			GL.End();
		}
	}
}