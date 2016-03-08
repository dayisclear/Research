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
		public class Room
		{
			public int X, Y, Width, Height;
			public RoomType Type;
		}

		public List<Room> Rooms { get; set; }

		public FloorPlan()
		{
			this.Rooms = new List<Room>();
		}

		public void AddRoom(int x, int y, int width, int height, RoomType type)
		{
			Rooms.Add(new Room() { X = x, Y = y, Width = width, Height = height, Type = type });
		}

		public void MergeFloorPlan(FloorPlan fp)
		{
			MergeFloorPlan(fp, 0, 0);
		}

		public void MergeFloorPlan(FloorPlan fp, int offsetX, int offsetY)
		{
			foreach(Room r in fp.Rooms)
			{
				r.X += offsetX;
				r.Y += offsetY;
				this.Rooms.Add(r);
			}
		}
	}
}
