using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RainbowMod
{
    public class RainbowWorld : ModWorld
    {
        public override void PostWorldGen()
        {
            if (RainbowConfig.Instance.rainbowGen)
            {
                for (int i = 0; i < Main.maxTilesX; i++)
                {
                    // Every Y coord with that X coord
                    for (int j = 0; j < Main.maxTilesY; j++)
                    {
                        // Get the Tile
                        Tile tile = Framing.GetTileSafely(i, j);

                    // Dedede, that's the name you should know
                    // Dedede, he's the star of the show
                    if (tile.type == TileID.LihzahrdBrick ||
                        tile.type == TileID.BlueDungeonBrick || tile.type == TileID.GreenDungeonBrick || tile.type == TileID.PinkDungeonBrick ||
                        tile.type == TileID.Copper || tile.type == TileID.Iron || tile.type == TileID.Silver || tile.type == TileID.Gold ||
                        tile.type == TileID.Tin || tile.type == TileID.Lead || tile.type == TileID.Tungsten || tile.type == TileID.Platinum ||
                        tile.type == TileID.Containers || tile.type == TileID.Containers2 || Main.tileContainer[tile.type] == true ||
                        tile.type == TileID.Trees || tile.type == TileID.Chairs || tile.type == TileID.Tables || tile.type == TileID.Tables2 ||
                        tile.wall == WallID.LihzahrdBrickUnsafe || tile.wall == WallID.SpiderUnsafe ||
                        tile.wall == WallID.BlueDungeonUnsafe || tile.wall == WallID.BlueDungeonSlabUnsafe || tile.wall == WallID.BlueDungeonTileUnsafe ||
                        tile.wall == WallID.GreenDungeonUnsafe || tile.wall == WallID.GreenDungeonSlabUnsafe || tile.wall == WallID.GreenDungeonTileUnsafe ||
                        tile.wall == WallID.PinkDungeonUnsafe || tile.wall == WallID.PinkDungeonSlabUnsafe || tile.wall == WallID.PinkDungeonTileUnsafe ||
                        tile.type == TileID.LihzahrdAltar || tile.type == TileID.ShadowOrbs || tile.type == TileID.DemonAltar || tile.type == TileID.Larva || tile.type == TileID.Hive ||
                        tile.type == TileID.Spikes || tile.type == TileID.Platforms || tile.type == TileID.Books || tile.type == TileID.Bookcases ||
                        tile.type == TileID.Ebonstone || tile.type == TileID.CorruptIce || tile.type == TileID.CorruptHardenedSand || tile.type == TileID.CorruptThorns ||
                        tile.type == TileID.Crimstone || tile.type == TileID.FleshIce || tile.type == TileID.CrimsonHardenedSand || tile.type == TileID.CrimsonVines ||
                        !Main.tileSolid[tile.type]) // argh hopefully this covers all furniture
                            continue;




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