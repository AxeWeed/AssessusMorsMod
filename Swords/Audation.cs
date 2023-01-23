using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using AssessusMorsMod.Items;
namespace AssessusMorsMod.Swords
{
    public class Audation : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Audation");
            Tooltip.SetDefault("Like death in a cup... Minus the cup.");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 110;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item15;
            Item.autoReuse = true;
			Item.shoot = ProjectileID.HoundiusShootiusFireball;
            Item.crit = 54;
            ;
            Item.shootSpeed = 30;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
           
            target.AddBuff(BuffID.Bleeding, 380);

        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.RedTorch, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
           
            CreateRecipe()
             .AddIngredient(ModContent.ItemType<AmberBlade>(), 1)
             .AddIngredient(ModContent.ItemType<AmethystBlade>(), 1)
             .AddIngredient(ModContent.ItemType<DiamondBlade>(), 1)
             .AddIngredient(ModContent.ItemType<RubyBlade>(), 1)
             .AddIngredient(ModContent.ItemType<SapphireBlade>(), 1)
             .AddIngredient(ModContent.ItemType<TopazBlade>(), 1)
             .AddIngredient(ModContent.ItemType<EmeraldBlade>(), 1)
             .AddIngredient(ModContent.ItemType<AudiChrome>(), 1)
             .AddIngredient(ItemID.Chain, 13)
             
             .AddTile(134)
             .Register();
            recipe.AddTile(TileID.MythrilAnvil);

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 offset = velocity;
        position += offset;
           
            
            for (var i = 0; i<Main.rand.Next(5, 5); i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(45));
        Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }
            return false;
        }    
    }
}