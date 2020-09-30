using Microsoft.Xna.Framework.Graphics;
using System.ComponentModel;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace RainbowMod
{
	public class RainbowMod : Mod
	{
		public override void Load()
		{
			if (Main.netMode != NetmodeID.Server)
			{
				Ref<Effect> gay = new Ref<Effect>(GetEffect("Effects/GayFilter"));
				Filters.Scene["Rainbow"] = new Filter(new ScreenShaderData(gay, "Gayify"), EffectPriority.VeryHigh);
				Filters.Scene["Rainbow"].Load();
			}
		}

		float progress;
		public override void PreUpdateEntities()
		{
			if (Main.netMode != NetmodeID.Server)
			{
				if (!Filters.Scene["Rainbow"].IsActive())
				{
					Filters.Scene.Activate("Rainbow").GetShader().UseColor(Main.DiscoR / 255f, Main.DiscoG / 255f, Main.DiscoB / 255f).UseOpacity(0.4f);
				}
				else if (Filters.Scene["Rainbow"].IsActive())
				{
					progress++;
					Filters.Scene["Rainbow"].GetShader().UseProgress(progress).UseColor(Main.DiscoR / 255f, Main.DiscoG / 255f, Main.DiscoB / 255f).UseOpacity(0.4f);
				}
			}
		}
	}

    public class RainbowConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        public static RainbowConfig Instance;

        [Label("Rainbow Worldgen")]
        [DefaultValue(true)]
        public bool rainbowGen;
    }
}
