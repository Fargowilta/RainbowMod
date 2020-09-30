using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace RainbowMod
{
    public class RainbowGlobalItem : GlobalItem
    {
        public override Color? GetAlpha(Item item, Color lightColor)
        {
            return new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
        }
        
        public override bool PreDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
		{
			spriteBatch.Draw(Main.itemTexture[item.type], position, null, Main.DiscoColor, 0f, origin, scale, SpriteEffects.None, 0f);
			return false;
		}

		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			for (int i = 0; i < tooltips.Count; i++)
			{
				tooltips[i].overrideColor = Main.DiscoColor;
			}
		}
    }

    public class RainbowGlobalNPC : GlobalNPC
    {
        public override Color? GetAlpha(NPC npc, Color drawColor)
        {
            return new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
        }
    }

    public class RainbowGlobalProj : GlobalProjectile
    {
        public override Color? GetAlpha(Projectile projectile, Color lightColor)
        {
            return new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
        }
    }

    /*public class RainbowGlobalTile : GlobalTile
    {
        public override void DrawEffects(int i, int j, int type, SpriteBatch spriteBatch, ref Color drawColor, ref int nextSpecialDrawIndex)
        {
            drawColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
            //Main.tile[i, j].wall = WallID.RainbowBrick;
        }
    }*/

    public class RainbowPlayer : ModPlayer
    {
        public override void PostUpdate()
        {

            byte rainbow = (byte)GameShaders.Armor.GetShaderIdFromItemId(2870);

            for (int i = 0; i < player.dye.Length; i++)
            {
                player.dye[i].dye = rainbow;
            }

            for (int j = 0; j < player.miscDyes.Length; j++)
            {
                player.miscDyes[j].dye = rainbow;
            }

            player.UpdateDyes(player.whoAmI);
        }
    }
}


