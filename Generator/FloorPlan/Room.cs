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
		Bathroom,
		ExtraRoom
	}

	public class Room
	{
		public int X, Y, Width, Height;
		public RoomType Type;
	}
}
