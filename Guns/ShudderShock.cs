using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
namespace AssessusMorsMod.Guns
{
    public class ShudderShock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shudder Shock");
            Tooltip.SetDefault("Shoots rapid shots");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 42;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 6;
            Item.useAnimation = 50;
            Item.useStyle = 5;
            Item.knockBack = 0.2f;
            Item.value = 5000;
            Item.rare = ItemRarityID.Yellow; ;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.shoot = 1;
            Item.useAmmo = AmmoID.Bullet;
            Item.shootSpeed = 30f;
            Item.noMelee = true;
            Item.crit = 75;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TacticalShotgun, 1);
            recipe.AddIngredient(ItemID.ChainGun, 1);
            recipe.AddIngredient(ItemID.HallowedBar, 25);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)     
        {
            Vector2 offset = velocity;
            position += offset;
           
            
            for (var i = 0; i < Main.rand.Next(3, 4); i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(25));
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
