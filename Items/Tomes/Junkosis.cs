using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace AssessusMorsMod.Items.Tomes
{
	public class Junkosis : ModItem
	{

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Another Man's trash...");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 11;
			Item.DamageType = DamageClass.Magic; // Makes the damage register as magic. If your item does not have any damage type, it becomes true damage (which means that damage scalars will not affect it). Be sure to have a damage type.
			Item.width = 34;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot; // Makes the player use a 'Shoot' use style for the Item.
			Item.noMelee = true; // Makes the item not do damage with it's melee hitbox.
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item9;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.PewMaticHornShot; // Shoot a black bolt, also known as the projectile shot from the onyx blaster.
			Item.shootSpeed = 18; // How fast the item shoots the projectile.
			Item.crit = 33; // The percent chance at hitting an enemy with a crit, plus the default amount of 4.
			Item.mana = 9; // This is how much mana the item uses.
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Wood, 30);
			recipe.AddIngredient(ItemID.StoneBlock, 30);
			recipe.AddIngredient(ItemID.CanOfWorms, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}


