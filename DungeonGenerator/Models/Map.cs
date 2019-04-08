using System.Collections.Generic;

namespace Whitehouse.Dungeon.Generator.Models
{
	public class Map
	{
		public int Seed { get; }

		public int Width { get; }

		public int Height { get; }

		public int BorderX { get; }

		public int BorderY { get; set; }

		public Cell[,] Cells { get; }

		public List<Path> Paths { get; }

		public List<Room> Rooms { get; }

		public Map(int seed, int width, int height, int borderX, int borderY)
		{
			this.Seed = seed;
			this.Width = width;
			this.Height = height;
			this.BorderX = borderX;
			this.BorderY = borderY;
			this.Cells = new Cell[width, height];
			this.Paths = new List<Path>();
			this.Rooms = new List<Room>();

			InitCells();
		}

		public Cell GetCell(int x, int y) => this.Cells[x, y];

		public bool RoomValid(Room testRoom)
		{
			foreach (var room in this.Rooms)
			{
				if (room.Intersects(testRoom))
					return false;
			}

			if ((testRoom.OuterTopX < this.BorderX) || (testRoom.OuterBottomX > this.Width - this.BorderX - 1))
				return false;

			if ((testRoom.OuterTopY < this.BorderY) || (testRoom.OuterBottomY > this.Height - this.BorderY - 1))
				return false;

			return true;
		}

		public void AddRoom(Room room)
		{
			for (int x = room.OuterTopX; x <= room.OuterBottomX; x++)
			for (int y = room.OuterTopY; y <= room.OuterBottomY; y++)
			{
				if ((x == room.OuterTopX) || (x == room.OuterBottomX) || (y == room.OuterTopY) || (y == room.OuterBottomY))
					room.OuterCells.Add(this.Cells[x, y]);
				else
					room.InnerCells.Add(this.Cells[x ,y]);
			}

			room.ClearInnerCells();

			this.Rooms.Add(room);
		}

		private void InitCells()
		{
			for (int x = 0; x < this.Width; x++)
			for (int y = 0; y < this.Height; y++)
			{
				this.Cells[x, y] = new Cell(x, y);
			}
		}
	}
}
