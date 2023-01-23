using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using AssessusMorsMod.Swords;

namespace AssessusMorsMod.Enemies
{
    public class Something : ModNPC
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Something");
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[1];
        }

        public override void SetDefaults()
        {
            NPC.width = 33;
            NPC.height = 15;
            NPC.damage = 60;
            NPC.defense = 3;
            NPC.lifeMax = 50;
            NPC.value = 850f;
            NPC.aiStyle = 0;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            AIType = NPCID.Tim;
            AnimationType = NPCID.Tim;
            NPC.knockBackResist = 1f;
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.Underground.Chance * 0.2f;
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

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            Item.newItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height);
        }

    }
}