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
			Graph tree = new Graph();

			Object a = "a";
			Object b = "b";
			Object c = "c";
			Object d = "d";
			Object e = "e";
			Object f = "f";
			Object g = "g";

			tree.AddEdge( a,  b, 2);
			tree.AddEdge( a,  c, 3);
			tree.AddEdge( a,  d, 3);

			tree.AddEdge( b,  a, 2);
			tree.AddEdge( b,  c, 4);
			tree.AddEdge( b,  e, 3);

			tree.AddEdge( c,  a, 3);
			tree.AddEdge( c,  b, 4);
			tree.AddEdge( c,  e, 1);
			tree.AddEdge( c,  d, 5);
			tree.AddEdge( c,  f, 6);

			tree.AddEdge( d,  a, 3);
			tree.AddEdge( d,  c, 5);
			tree.AddEdge( d,  f, 7);

			tree.AddEdge( f,  d, 7);
			tree.AddEdge( f,  c, 6);
			tree.AddEdge( f,  e, 8);

			tree.AddEdge( f,  g, 9);

			var mst = Algorithms.MST.Prims.FindMST( a, tree);
			foreach (var n in mst) Console.WriteLine(n);
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
