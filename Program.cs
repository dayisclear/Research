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
			Console.Read();
		}

		public static void GenerateFloorPlan()
		{
			const int Width = 400;
			const int Height = 300;
			const double MinSliceRatio = 0.35;

			var elements = new[] { 24, 45, 32, 87, 34, 58, 10, 4, 5, 9, 52, 34 }
				.Select(x => new SquarifiedTreeMap.Element<string> { Object = x.ToString(), Value = x })
				.OrderByDescending(x => x.Value)
				.ToList();

			var slice = SquarifiedTreeMap.GetSlice(elements, 1, MinSliceRatio);

			var rectangles = SquarifiedTreeMap.GetRectangles(slice, Width, Height).ToList();

			DrawTreemap(rectangles, Width, Height);
		}

		public static void DrawTreemap<T>(IEnumerable<SquarifiedTreeMap.SliceRectangle<T>> rectangles, int width, int height)
		{
			var font = new Font("Arial", 8);

			var bmp = new Bitmap(width, height);
			var gfx = Graphics.FromImage(bmp);

			gfx.FillRectangle(Brushes.Blue, new RectangleF(0, 0, width, height));

			foreach (var r in rectangles)
			{
				gfx.DrawRectangle(Pens.Black,
				 new Rectangle(r.X, r.Y, r.Width - 1, r.Height - 1));

				gfx.DrawString(r.Slice.Elements.First().Object.ToString(), font,
				 Brushes.White, r.X, r.Y);
			}

			var form = new Form() { AutoSize = true };
			form.Controls.Add(new PictureBox() { Width = width, Height = height, Image = bmp });
			form.ShowDialog();
		}
	}
}
