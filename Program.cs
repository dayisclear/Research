using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using RTFP.DataStructures;
using RTFP.Generator.FloorPlan;


namespace RTFP
{
	static class Program
	{
		static void Main()
		{
			SuburbanGenerator generator = new SuburbanGenerator();
			FloorPlan fp = generator.GenerateFloorPlan();

			Console.WriteLine(fp);
			DrawFloorPlan(fp);
		}

		public static void DrawFloorPlan(FloorPlan fp)
		{
			int width = 500, height = 500;
			var font = new Font("Arial", 8);

			var bmp = new Bitmap(width, height);
			var gfx = Graphics.FromImage(bmp);

			List<Point> points = fp.GenerateVertices();
			foreach (var p in points)
			{
				gfx.DrawRectangle(Pens.Black, new Rectangle(p.X + 5, p.Y + 5, 3, 3));
			}

			var form = new Form() { AutoSize = true };
			form.Controls.Add(new PictureBox() { Width = width, Height = height, Image = bmp });
			form.ShowDialog();
		}
	}
}
