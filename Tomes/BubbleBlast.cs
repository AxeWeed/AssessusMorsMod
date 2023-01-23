using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace AssessusMorsMod.Tomes


{
    public class BubbleBlast : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bubbble Blast");
            Tooltip.SetDefault("");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 6;
            Item.DamageType = DamageClass.Magic; // Makes the damage register as magic. If your item does not have any damage type, it becomes true damage (which means that damage scalars will not affect it). Be sure to have a damage type.
            Item.width = 34;
            Item.height = 40;
            Item.useTime = 12;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot; // Makes the player use a 'Shoot' use style for the Item.
            Item.noMelee = true; // Makes the item not do damage with it's melee hitbox.
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = ItemRarityID.Blue;
            
            Item.autoReuse = true;
            Item.shoot = ProjectileID.Bubble;
           
           
            Item.shootSpeed = 14; // How fast the item shoots the projectile.
            Item.crit = 33; // The percent chance at hitting an enemy with a crit, plus the default amount of 4.
            Item.mana = 9; // This is how much mana the item uses.
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.WaterBucket, 15);
            recipe.AddIngredient(ItemID.Book, 6);
            recipe.AddIngredient(ItemID.Starfish, 5);
            recipe.AddTile(TileID.Bookcases);
            recipe.Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 offset = velocity;
            position += offset;


            for (var i = 0; i < Main.rand.Next(4, 9); i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(18));
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