using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RTFP.DataStructures;
using RTFP.DataStructures.Geometry;

namespace RTFP.Generator.FloorPlan
{
	public enum RoomType
	{
		LivingRoom,
		BedRoom,
		Kitchen,
		Bathroom,
		ExtraRoom
	}

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
			// Default house size is 500x500
			return ToFloorPlan(500, 500);
		}

		public FloorPlan ToFloorPlan(int Width, int Height)
		{
			double MinSliceRatio = 0.35;

			// Generate our Squarified Tree Map
			var nodes = Children
					.Select(x => new SquarifiedTreeMap.Element<RoomNode> { Object = x, Value = Area })
					.OrderByDescending(x => x.Value)
					.ToList();

			var slice = SquarifiedTreeMap.GetSlice(nodes, 1, MinSliceRatio);
			var rectangles = SquarifiedTreeMap.GetRectangles(slice, Width, Height).ToList();

			// Lists for building our floor plan
			List<Vertex> vertices = new List<Vertex>();
			List<Edge> edges = new List<Edge>();

			// Build our floorplan off our our tree map
			foreach (var r in rectangles)
			{
				// Add our vertices and edges to our list
				Vertex v1 = new Vertex(r.X, r.Y);						// Top-left corner
				Vertex v2 = new Vertex(r.X, r.Y + r.Height);			// Top-right corner
				Vertex v3 = new Vertex(r.X + r.Width, r.Y);				// Bottom-right corner
				Vertex v4 = new Vertex(r.X + r.Width, r.Y + r.Height);	// Bottom-left corner

				edges.Add(new Edge(v1, v2));
				edges.Add(new Edge(v2, v4));
				edges.Add(new Edge(v4, v3));
				edges.Add(new Edge(v3, v1));

				// Build our rooms internal tree map
				foreach (var child in r.Slice.Elements)
				{
					FloorPlan fp = child.Object.ToFloorPlan();

					vertices.AddRange(fp.Vertices);
					edges.AddRange(fp.Edges);
				}
			}
			
			// Return our produced floor plan
			return new FloorPlan() { Vertices = vertices, Edges = edges };
		}

		public override string ToString()
		{
			return Type.ToString();
		}
	}
}
