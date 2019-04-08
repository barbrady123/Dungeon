using System.Collections.Generic;
using System.Linq;
using Whitehouse.Dungeon.Generator.Enums;

namespace Whitehouse.Dungeon.Generator.Models
{
	public class Room
	{
		public int InnerTopX { get; }

		public int InnerTopY { get; }

		public int InnerBottomX { get; }

		public int InnerBottomY { get; }

		public int OuterTopX => this.InnerTopX - 1;

		public int OuterTopY => this.InnerTopY - 1;

		public int OuterBottomX => this.InnerBottomX + 1;

		public int OuterBottomY => this.InnerBottomY + 1;

		public List<Cell> OuterCells { get; set; }

		public List<Cell> InnerCells { get; set; }

		public Room(int innerCorner1X, int innerCorner1Y, int innerCorner2X, int innerCorner2Y)
		{
			this.InnerTopX = (innerCorner1X < innerCorner2X) ? innerCorner1X : innerCorner2X;
			this.InnerBottomX = (innerCorner1X < innerCorner2X) ? innerCorner2X : innerCorner1X;

			this.InnerTopY = (innerCorner1Y < innerCorner2Y) ? innerCorner1Y : innerCorner2Y;
			this.InnerBottomY = (innerCorner1Y < innerCorner2Y) ? innerCorner2Y : innerCorner1Y;

			this.OuterCells = new List<Cell>();
			this.InnerCells = new List<Cell>();
		}

		public bool Intersects(Room room)
		{
			// This allows equal, as outer walls are allowed to intersect with each other...
			if ((this.OuterBottomX <= room.OuterTopX) || (room.OuterBottomX <= this.OuterTopX))
				return false;

			if ((this.OuterBottomY <= room.OuterTopY) || (room.OuterBottomY <= this.OuterTopY))
				return false;

			return true;
		}

		public void ClearInnerCells()
		{
			this.InnerCells.ForEach(c => c.Type = CellType.Open);
		}
	}
}
