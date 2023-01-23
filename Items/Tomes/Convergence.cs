using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;
namespace AssessusMorsMod.Items.Tomes


{
    public class Convergence : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Convergence");
            Tooltip.SetDefault("Yes");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 85;
            Item.DamageType = DamageClass.Magic; // Makes the damage register as magic. If your item does not have any damage type, it becomes true damage (which means that damage scalars will not affect it). Be sure to have a damage type.
            Item.width = 34;
            Item.height = 40;
            Item.useTime = 8;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot; // Makes the player use a 'Shoot' use style for the Item.
            Item.noMelee = true; // Makes the item not do damage with it's melee hitbox.
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item9;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.FairyQueenMagicItemShot;
            Item.shootSpeed = 22; // How fast the item shoots the projectile.
            Item.crit = 32; // The percent chance at hitting an enemy with a crit, plus the default amount of 4.
            Item.mana = 42; // This is how much mana the item uses.
        }

        

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 offset = velocity;
            position += offset;


            for (var i = 0; i < Main.rand.Next(3, 4); i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(8));
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(1, 0);
            return offset;
        }



       
    
        public class MyGlobalNPC : GlobalNPC
        {
            public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
            {
                // First, we need to check the npc.type to see if the code is running for the vanilla NPCwe want to change
                if (npc.type == NPCID.CultistBoss)
                {
                    // This is where we add item drop rules for VampireBat, here is a simple example:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Convergence>(), 500));
                }
                // We can use other if statements here to adjust the drop rules of other vanilla NPC
            }
        
    

        }
    }


}

