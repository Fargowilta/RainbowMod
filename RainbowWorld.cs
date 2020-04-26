using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RainbowMod
{
    public class RainbowWorld : ModWorld
    {
        public override void PostWorldGen()
        {
            for (int i = 0; i < Main.maxTilesX; i++)
            {
                // Every Y coord with that X coord
                for (int j = 0; j < Main.maxTilesY; j++)
                {
                    // Get the Tile
                    Tile tile = Framing.GetTileSafely(i, j);

                    ReplaceTile(tile, TileID.RainbowBrick, i, j);

                    if (tile.wall != 0)
                    {
                        ReplaceWall(tile, WallID.RainbowBrick, i, j);
                    }
                    else
                    {
                        ReplaceWall(tile, WallID.RainbowStainedGlass, i, j);
                    }
                }
            }
        }

        /// <summary>
        /// Multiplayer friendly way to easily replace a tile with another
        /// </summary>
        /// <param name="tile">The Tile you want replaced</param>
        /// <param name="DesiredType">Desired type of the tile</param>
        /// <param name="i">Location in tile coords</param>
        /// <param name="j">Location in tile coords</param>
        public static void ReplaceTile(Tile tile, ushort DesiredType, int i, int j)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                tile.type = DesiredType;
                WorldGen.SquareTileFrame(i, j);
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendTileSquare(-1, i, j, 1);
                }
            }
        }

        /// <summary>
        /// Multiplayer friendly way to easily replace a wall with another
        /// </summary>
        /// <param name="tile">The Tile with the wall you want to replace</param>
        /// <param name="DesiredType">Desired type of the wall</param>
        /// <param name="i">X location in tile coords</param>
        /// <param name="j">Y location in tile coords</param>
        public static void ReplaceWall(Tile tile, ushort DesiredType, int i, int j)
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                tile.wall = DesiredType;
                WorldGen.SquareWallFrame(i, j);
                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendTileSquare(-1, i, j, 1);
                }
            }
        }
    }
}