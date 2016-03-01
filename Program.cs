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

			#region temporary drawing code
			var gfx = Graphics.FromImage(bmp);
			gfx.FillRectangle(Brushes.Blue, new RectangleF(0, 0, width, height));
			int Width = 250, Height = 250;
			const double MinSliceRatio = 0.35;
			var elements = fp.GetAreaArray()
				.Select(x => new SquarifiedTreeMap.Element<string> { Object = x.ToString(), Value = x })
				.OrderByDescending(x => x.Value)
				.ToList();

			var slice = SquarifiedTreeMap.GetSlice(elements, 1, MinSliceRatio);

			var rectangles = SquarifiedTreeMap.GetRectangles(slice, Width, Height).ToList();
			foreach (var r in rectangles)
			{
				gfx.DrawRectangle(Pens.Black,
				 new Rectangle(r.X + 5, r.Y + 5, r.Width, r.Height));

				gfx.DrawString("Area: " + r.Slice.Elements.First().Object.ToString(), font,
				 Brushes.White, r.X + 10, r.Y + 10);
			}
			#endregion

			List<Point> points = fp.Generate2DPoints();
			foreach (var p in points)
			{
				gfx.DrawRectangle(Pens.Red, new Rectangle(p.X + 2, p.Y + 2, 7, 7));
			}

			var form = new Form() { AutoSize = true };
			form.Controls.Add(new PictureBox() { Width = width, Height = height, Image = bmp });
			form.ShowDialog();
		}
	}
}
