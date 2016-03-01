using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RTFP.DataStructures;
using RTFP.DataStructures.Geometry;
using RTFP.Generator.FloorPlan;

namespace RTFP.Generator.FloorPlan
{
	public class FloorPlan
	{
		class Room
		{
			public int X, Y, Width, Height;
			public RoomType Type;
		}

		private List<Room> Rooms { get; set; }
		public List<Edge> Edges { get; set; }
		public List<Vertex> Vertices { get; set; }

		public void AddRoom(int x, int y, int width, int height, RoomType type)
		{
			Rooms.Add(new Room() { X = x, Y = y, Width = width, Height = height, Type = type });
		}

		public void MergeFloorPlan(FloorPlan fp)
		{
			foreach (Room r in fp.Rooms)
				this.Rooms.Add(r);
		}
	}
}
