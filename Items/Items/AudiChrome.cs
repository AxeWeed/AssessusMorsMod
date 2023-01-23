using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using AssessusMorsMod.Items;

namespace AssessusMorsMod.Items.Items
{
	public class AudiChrome : ModItem
	{
		public override void SetStaticDefaults()
		{
            DisplayName.SetDefault("AudiChrome");
            Tooltip.SetDefault("Hell resonates in this box."); // The (English) text shown below your item's name
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1; // How many items are needed in order to research duplication of this item in Journey mode. See https://terraria.gamepedia.com/Journey_Mode/Research_list for a list of commonly used research amounts depending on item type.
		}

		public override void SetDefaults()
		{
			Item.width = 20; // The item texture's width
			Item.height = 20; // The item texture's height
			Item.rare = ItemRarityID.Purple;
			Item.maxStack = 999; // The item's max stack value
			Item.value = Item.buyPrice(platinum: 99);
			
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			CreateRecipe(1)
				.AddIngredient(ItemID.DirtBlock, 10)
				.AddIngredient(ItemID.Bone, 10)
				.AddIngredient(ItemID.HellstoneBar, 10)
				.AddIngredient(ItemID.HallowedBar, 10)
				.AddIngredient(ItemID.ChlorophyteBar, 10)
				.AddIngredient(ItemID.LunarBar, 10)
				.AddIngredient(ItemID.JungleSpores, 10)
				.AddIngredient(ItemID.Cloud, 10)
				.AddIngredient(ItemID.SolarTablet, 1)
				.AddIngredient(ItemID.ChumBucket, 10)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}



	}
}