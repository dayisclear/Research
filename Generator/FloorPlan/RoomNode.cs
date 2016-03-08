using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RTFP.DataStructures;
using RTFP.DataStructures.Geometry;

using RTFP.Generator.Constraints;

namespace RTFP.Generator.FloorPlan
{
	public class RoomNode
	{
		public RoomType Type { get; set; }
		public int Area { get; set; }
		public LinkedList<RoomNode> Children { get; set; }

		public RoomNode(RoomType type)
		{
			this.Type = type;
			this.Children = new LinkedList<RoomNode>();
		}

		public FloorPlan ToFloorPlan()
		{
			// Default house size is 250x250
			return ToFloorPlan(250, 250);
		}

		public FloorPlan ToFloorPlan(int Width, int Height)
		{
			double MinSliceRatio = Constraint.GetRandomNumber(25, 45) / 100;

			// Generate our Squarified Tree Map
			var nodes = Children
				.Select(x => new SquarifiedTreeMap.Element<RoomNode> { Object = x, Value = x.Area })
				.OrderBy(x => Constraint.GetRandomNumber(-100, 100))
				.ToList();

			// We want to include our own area inside our tree map
			nodes.Insert(0, new SquarifiedTreeMap.Element<RoomNode> { Object = this, Value = this.Area });

			var slice = SquarifiedTreeMap.GetSlice(nodes, 1, MinSliceRatio);
			var rectangles = SquarifiedTreeMap.GetRectangles(slice, Width, Height).ToList();

			FloorPlan fp = new FloorPlan();

			// Build our floorplan off our our tree map
			foreach (var r in rectangles)
			{
				fp.AddRoom(r.X, r.Y, r.Width, r.Height, r.Slice.Elements.First().Object.Type);

				// Build our rooms internal tree map
				foreach (var child in r.Slice.Elements)
				{
					// We ignore ourself and nodes without children
					if (child.Object != this && child.Object.Children.Count > 0)
					{
						// Child tree map uses local coordinates of parent room,
						// we must offset these and then merge our floorplans
						fp.MergeFloorPlan(child.Object.ToFloorPlan(r.Width, r.Height), r.X, r.Y);
					}
				}
			}
			
			// Return our produced floor plan
			return fp;
		}

		public override string ToString()
		{
			return Type.ToString();
		}
	}
}