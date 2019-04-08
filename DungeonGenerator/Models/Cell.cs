using Whitehouse.Dungeon.Generator.Enums;

namespace Whitehouse.Dungeon.Generator.Models
{
    public class Cell
    {
		public int X { get; set; }

		public int Y { get; set; }

		public CellType Type { get; set; }

		public CellFlag Flags { get; set; }

		public Cell(int x, int y, CellType type = CellType.Solid, CellFlag flags = CellFlag.None)
		{
			this.X = x;
			this.Y = y;
			this.Type = type;
			this.Flags = flags;
		}
    }
}
