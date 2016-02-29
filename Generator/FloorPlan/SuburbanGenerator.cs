/*
	Based off of Real-time Procedural Generation of Building Floor Plans paper
	by Maysam Mirahmadi and Abdallah Shami of The University of Western Ontario
	http://arxiv.org/pdf/1211.5842.pdf
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RTFP.DataStructures;

using RTFP.Generator;
using RTFP.Generator.Constraints;
using RTFP.Generator.FloorPlan;

namespace RTFP.Generator.FloorPlan
{
	public class SuburbanGenerator : FloorPlanGenerator
	{
		public ConstraintSet Constraints { get; set; }

		public SuburbanGenerator()
		{
			// using sample constraint set until constraint stuff is finished
			Constraints = new ConstraintSet();

			// suburban room should have following constraints:
			// # rooms, # bed rooms, # bathrooms, # kitchens
			// % liklihood of bathroom/closet in bedrooms
			Constraints.Add("Rooms", new MinMax(1, 4));
			Constraints.Add("AreaRooms", new MinMax(1200, 2400));

			Constraints.Add("LivingRooms", new MinMax(1, 1));
			Constraints.Add("AreaLivingRooms", new MinMax(400, 800));

			Constraints.Add("BedRooms", new MinMax(1, 2));
			Constraints.Add("AreaBedRooms", new MinMax(200, 400));

			Constraints.Add("Kitchens", new MinMax(0, 1));
			Constraints.Add("AreaKitchens", new MinMax(50, 200));

			Constraints.Add("ExtraChildRooms", new MinMax(0, 1));
			Constraints.Add("AreaExtraChildRooms", new MinMax(50, 100));
		}

		public FloorPlan GenerateFloorPlan()
		{
			Room main = GenerateValidRoom(RoomType.LivingRoom);
			FloorPlan floorplan = new FloorPlan(main);

			// rooms = main + roll
			int rooms = (int) Constraints.GenerateValue("Rooms");
			for(int i = 0; i < rooms; i++)
			{
				floorplan.AddChildToParent(main, GenerateValidRoom(RoomType.BedRoom));
			}

			return floorplan;
		}

		private Room GenerateValidRoom(RoomType type)
		{
			Room room = new Room(type);
			switch(type)
			{
				case RoomType.LivingRoom:
					{
						room.Area = (int) Constraints.GenerateValue("AreaLivingRooms");
					}
					break;
				case RoomType.BedRoom:
					{
						room.Area = (int) Constraints.GenerateValue("AreaBedRooms");
					}
					break;
				case RoomType.Kitchen:
					{
						room.Area = (int) Constraints.GenerateValue("AreaKitchens");
					}
					break;
				case RoomType.Bathroom:
					{
						room.Area = (int) Constraints.GenerateValue("AreaExtraChildRooms");
					}
					break;
			}
			return room;
		}
	}
}