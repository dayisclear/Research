using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTFP.Generator.FloorPlan
{
	public enum RoomType
	{
		LivingRoom,
		BedRoom,
		Kitchen,
		Bathroom
	}

	public class Room
	{
		public RoomType Type { get; set; }
		public int Area { get; set; }

		public Room(RoomType type)
		{
			this.Type = type;
		}
	}
}
