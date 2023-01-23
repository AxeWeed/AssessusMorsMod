using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.Utilities;

namespace AssessusMorsMod.Enemies
{
	public class WoodSlime : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wooden Slime");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[2];
		}

		public override void SetDefaults()
		{
			NPC.width = 32;
			NPC.height = 15;
			NPC.damage = 5;
			NPC.defense = 3;
			NPC.lifeMax = 24;
			NPC.value = 500f;
			NPC.aiStyle = 1;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			AIType = NPCID.GreenSlime;
			AnimationType = NPCID.GreenSlime;
			
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.OverworldDaySlime.Chance * 0.2f;
		}
		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter++;
			if (NPC.frameCounter >= 20)
			{
				NPC.frameCounter = 0;
			}
			NPC.frame.Y = (int)NPC.frameCounter / 10 * frameHeight;
		}
		public override void OnKill()
		{
			Terraria.Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.Gel, Main.rand.Next(0, 2));
			Terraria.Item.NewItem(NPC.GetSource_Death(), NPC.getRect(), ItemID.Wood, Main.rand.Next(5, 10));

        }
	}

}