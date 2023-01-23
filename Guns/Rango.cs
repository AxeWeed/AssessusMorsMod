using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
namespace AssessusMorsMod.Guns
{
	public class Rango : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rango");
			Tooltip.SetDefault("It only takes one bullet.");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 3400;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 20;
			Item.height = 20;
			Item.useTime = 60;
			Item.useAnimation = 50;
			Item.useStyle = 5;
			Item.knockBack = 5f;
			Item.value = 5000;
			Item.rare = ItemRarityID.Cyan; ;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = true;
			
            Item.shoot = ProjectileID.BulletHighVelocity;
            Item.shootSpeed = 8f;
			Item.noMelee = true;
			Item.crit = 80;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Revolver, 1);
			recipe.AddIngredient(ItemID.LunarBar, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 offset = velocity;
			position += offset;


			for (var i = 0; i < Main.rand.Next(1, 1); i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(2));
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
