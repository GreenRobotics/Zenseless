﻿using Zenseless.ExampleFramework;
using Zenseless.Base;
using System;
using System.IO;
using Zenseless.OpenGL;

namespace Example
{
	class Controller
	{
		[STAThread]
		private static void Main()
		{
			var window = new ExampleWindow();
			window.SetContentSearchDirectory(Path.GetDirectoryName(PathTools.GetSourceFilePath())); //would be faster if you only specify a subdirectory
			var visual = new MainVisual(window.RenderContext.RenderState, window.ContentLoader);

			window.GameWindow.AddMayaCameraEvents(visual.OrbitCamera);
			window.Render += visual.Render;
			window.Run();
		}
	}
}