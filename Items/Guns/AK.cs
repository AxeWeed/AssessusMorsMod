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
	public class AK: ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ak");
			Tooltip.SetDefault("Ricka Pow Pow");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{

			Item.damage = 35;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 20;
			Item.height = 20;
			Item.useTime = 6;
			Item.useAnimation = 50;
			Item.useStyle = 5;
			Item.knockBack = 0.2f;
			Item.value = 5000;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.BulletHighVelocity;
			Item.rare = ItemRarityID.Pink;
			Item.noMelee = true;
			Item.shootSpeed = 45;
			Item.useAmmo = AmmoID.Bullet;

			Item.UseSound = SoundID.Item31;
			Item.crit = 30;
		}


		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ClockworkAssaultRifle);
			recipe.AddIngredient(ItemID.HallowedBar);
			recipe.AddIngredient(ItemID.SoulofFright);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
			 
			 

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