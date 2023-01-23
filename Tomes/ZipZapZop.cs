using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace AssessusMorsMod.Tomes


{
	public class ZipZapZop : ModItem
	{

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Zippy. Didn't you say you got this out of a floating magnet? No? That's awkward.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 42;
			Item.DamageType = DamageClass.Magic; // Makes the damage register as magic. If your item does not have any damage type, it becomes true damage (which means that damage scalars will not affect it). Be sure to have a damage type.
			Item.width = 34;
			Item.height = 40;
			Item.useTime = 9;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot; // Makes the player use a 'Shoot' use style for the Item.
			Item.noMelee = true; // Makes the item not do damage with it's melee hitbox.
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = ItemRarityID.LightPurple;
			Item.UseSound = SoundID.Item9;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.ThunderStaffShot; // Shoot a black bolt, also known as the projectile shot from the onyx blaster.
			Item.shootSpeed = 23; // How fast the item shoots the projectile.
			Item.crit = 44; // The percent chance at hitting an enemy with a crit, plus the default amount of 4.
			Item.mana = 19; // This is how much mana the item uses.
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SpellTome, 1);
			recipe.AddIngredient(ItemID.Cloud, 30);
			recipe.AddIngredient(ItemID.NimbusRod, 1);
			recipe.AddTile(TileID.Bookcases);
			recipe.Register();
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 offset = velocity;
			position += offset;


			for (var i = 0; i < Main.rand.Next(2, 3); i++)
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