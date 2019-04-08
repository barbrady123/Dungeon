using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Whitehouse.Dungeon.Generator;
using Whitehouse.Dungeon.Generator.Enums;

namespace Whitehouse.Dungeon.Visualizer
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var gen = new MapGenerator(new MapGeneratorConfiguration {
				MapWidth = Convert.ToInt32(textMapWidth.Text),
				MapHeight = Convert.ToInt32(textMapHeight.Text),
				MapBorderX = Convert.ToInt32(textMapBorderWidth.Text),
				MapBorderY = Convert.ToInt32(textMapBorderHeight.Text),
				RoomsNumberMin = Convert.ToInt32(textMinNumRooms.Text),
				RoomsNumberMax = Convert.ToInt32(textMaxNumRooms.Text),
				RoomsWidthMin = Convert.ToInt32(textRoomMinWidth.Text),
				RoomsWidthMax = Convert.ToInt32(textRoomMaxWidth.Text),
				RoomsHeightMin = Convert.ToInt32(textRoomMinHeight.Text),
				RoomsHeightMax = Convert.ToInt32(textRoomMaxHeight.Text)
			});

			var map = gen.GenerateMap();

			var mapText = new StringBuilder();

			for (int y = 0; y < map.Height; y++)
			{				
				var mapRow = new StringBuilder();

				for (int x = 0; x < map.Width; x++)
				{
					mapRow.Append(map.Cells[x, y].Type == CellType.Solid ? "X" : " ");
				}

				mapText.AppendLine(mapRow.ToString());
			}

			mapText.AppendLine($"Seed: {map.Seed}");

			textMap.Text = mapText.ToString();
		}
	}
}
