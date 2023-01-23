using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using AssessusMorsMod.Items.Guns;

namespace AssessusMorsMod.Items.Guns
{
    public class Vacancy : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vacancy");
            Tooltip.SetDefault("The final product,  " +
                "Still kills moderately everything");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            
            Item.width = 62; 
            Item.height = 33;
            Item.scale = 1f;
            Item.rare = ItemRarityID.Red; 
            Item.useTime = 2;
            Item.useAnimation = 8; 
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;
            Item.DamageType = DamageClass.Ranged; 
            Item.damage = 100; 
            Item.knockBack = 5f; 
            Item.noMelee = true; 
            Item.shootSpeed = 85f; 
            Item.useAmmo = AmmoID.Bullet;
            Item.shoot = ProjectileID.BulletHighVelocity;
            Item.UseSound = SoundID.Item40;
            Item.crit = 23;
        }

       
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            CreateRecipe()
             .AddIngredient(ItemID.FlareGun, 1)
             .AddIngredient(ItemID.FlintlockPistol, 1)
             .AddIngredient(ItemID.ClockworkAssaultRifle, 1)
             .AddIngredient(ItemID.PhoenixBlaster, 1)
             .AddIngredient(ItemID.Revolver, 1)
             .AddIngredient(ItemID.OnyxBlaster, 1)
             .AddIngredient(ItemID.VenusMagnum, 1)
             .AddIngredient(ItemID.Xenopopper, 1)
             .AddIngredient(ItemID.VortexBeater, 1)
             .AddIngredient(ItemID.SniperRifle, 1)
             .AddIngredient(ModContent.ItemType<ShudderShock>(), 1)
             .AddIngredient(ItemID.SDMG, 1)
             .AddTile(134)
             .Register();
            recipe.AddTile(TileID.MythrilAnvil );
            
        }


        
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 offset = velocity;
            position += offset;


            for (var i = 0; i < Main.rand.Next(1, 2); i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(5));
                Projectile.NewProjectile(Projectile.GetSource_NaturalSpawn(), position, perturbedSpeed, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
        public override Vector2? HoldoutOffset()
        {
            Vector2 offset = new Vector2(1, 0);
            return offset;
        }
    }

}