using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using RTFP.DataStructures;
using RTFP.DataStructures.Geometry;
using RTFP.Generator.FloorPlan;
using System.Reflection;

namespace RTFP
{
	static class Program
	{
		static void Main()
		{
			Graph ga = new Graph();

			Object a = "a";
			Object b = "b";
			Object c = "c";
			Object d = "d";
			Object e = "e";
			Object f = "f";
			Object g = "g";

			ga.AddEdge(ref a, ref b, 2);
			ga.AddEdge(ref a, ref c, 3);
			ga.AddEdge(ref a, ref d, 3);

			ga.AddEdge(ref b, ref a, 2);
			ga.AddEdge(ref b, ref c, 4);
			ga.AddEdge(ref b, ref e, 3);

			ga.AddEdge(ref c, ref a, 3);
			ga.AddEdge(ref c, ref b, 4);
			ga.AddEdge(ref c, ref e, 1);
			ga.AddEdge(ref c, ref d, 5);
			ga.AddEdge(ref c, ref f, 6);

			ga.AddEdge(ref d, ref a, 3);
			ga.AddEdge(ref d, ref c, 5);
			ga.AddEdge(ref d, ref f, 7);

			ga.AddEdge(ref f, ref d, 7);
			ga.AddEdge(ref f, ref c, 6);
			ga.AddEdge(ref f, ref e, 8);

			ga.AddEdge(ref f, ref g, 9);

			Algorithms.MST.Prims.FindMST(ref a, ga);
			Console.Read();


		/*	SuburbanGenerator generator = new SuburbanGenerator();

			while (true)
			{
				FloorPlan fp = generator.GenerateFloorPlan();
				DrawFloorPlan(fp);
			}*/
		}

		private static void DrawFloorPlan(FloorPlan fp)
		{
			int width = 252, height = 252;
			Brush[] brushes = new Brush[] { Brushes.Gray, Brushes.DarkGray, Brushes.LightGray, Brushes.LightSlateGray, Brushes.BurlyWood };

			// Create our canvas to work with
			var font = new Font("Arial", 8);
			var bmp = new Bitmap(width, height);
			var gfx = Graphics.FromImage(bmp);

			gfx.FillRectangle(Brushes.White, new RectangleF(0, 0, width, height));

			// Draw rooms and their types
			for(int i = 0; i < fp.Rooms.Count; i++)
			{
				var r = fp.Rooms[i];

				gfx.FillRectangle(brushes[i % brushes.Length], r.X, r.Y, r.Width, r.Height);
				gfx.DrawRectangle(Pens.Black, new Rectangle(new Point(r.X, r.Y), new Size(r.Width, r.Height)));

				gfx.DrawString(r.Type.ToString(), font, Brushes.Black, r.X, r.Y);
			}

			// Display form
			var form = new Form() { AutoSize = true };
			form.Controls.Add(new PictureBox() { Width = width, Height = height, Image = bmp, Location = new Point(5, 5) });
			form.ShowDialog();
		}
	}
}
