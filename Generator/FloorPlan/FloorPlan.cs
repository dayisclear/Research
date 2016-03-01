using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RTFP.Generator.FloorPlan;
using RTFP.DataStructures;
using System.Drawing;

namespace RTFP.Generator.FloorPlan
{
	public class FloorPlan : DataStructures.GenericTree<Room>
	{
		public FloorPlan(Room data) : base(data) { }

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			Traverse(this, new DataStructures.TreeVisitor<Room>(delegate(Room room)
			{
				sb.AppendLine(String.Format("node: {0}, area: {1}", room.Type.ToString(), room.Area));
			}));

			return sb.ToString();
		}

		private int[] GetAreaArray()
		{
			List<int> list = new List<int>();

			Traverse(this, new DataStructures.TreeVisitor<Room>(delegate(Room r)
			{
				list.Add(r.Area);
			}));

			return list.ToArray();
		}

		public List<Point> Generate2DPoints()
		{
			// We need to move width and height to properties of our floor plan,
			// floor plan structure needs to be reworked 
			int Width = 250, Height = 250;
			const double MinSliceRatio = 0.35;

			var elements = GetAreaArray()
				.Select(x => new SquarifiedTreeMap.Element<string> { Object = x.ToString(), Value = x })
				.OrderByDescending(x => x.Value)
				.ToList();

			var slice = SquarifiedTreeMap.GetSlice(elements, 1, MinSliceRatio);

			var rectangles = SquarifiedTreeMap.GetRectangles(slice, Width, Height).ToList();

			List<Point> points = new List<Point>();
			foreach(var r in rectangles)
			{
				points.Add(new Point(r.X, r.Y));
				points.Add(new Point(r.X + r.Width, r.Y));
				points.Add(new Point(r.X, r.Y + r.Height));
				points.Add(new Point(r.X + r.Width, r.Y + r.Height));
			}

			return points;
		}
	}
}
