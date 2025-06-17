using UnityEngine;
using System.Collections.Generic;

namespace ProceduralDungeon.Infrastructure
{
    public class DungeonGenerator
    {
        public struct Room { public RectInt rect; }

        public List<Room> Generate(int width, int height, int minRoom, int maxRoom, int seed)
        {
            Random.InitState(seed);
            var rooms = new List<Room>();

            // Very small BSP demo: split once horizontally, once vertically
            var root = new RectInt(0, 0, width, height);
            int splitX = Random.Range(minRoom, width - minRoom);
            int splitY = Random.Range(minRoom, height - minRoom);

            rooms.Add(new Room { rect = new RectInt(root.xMin, root.yMin, splitX, splitY) });
            rooms.Add(new Room { rect = new RectInt(splitX, root.yMin, root.width - splitX, splitY) });
            rooms.Add(new Room { rect = new RectInt(root.xMin, splitY, splitX, root.height - splitY) });
            rooms.Add(new Room { rect = new RectInt(splitX, splitY, root.width - splitX, root.height - splitY) });

            return rooms;
        }
    }
}
