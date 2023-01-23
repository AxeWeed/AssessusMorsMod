using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using AssessusMorsMod.Items;

namespace AssessusMorsMod.Pickaxes

{
    public class VoidPickaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void Pickaxe");
            Tooltip.SetDefault("Delete.");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 10;
        }

        public override void SetDefaults()
        {
            Item.damage = 50000;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 1;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 500;
            Item.value = Item.buyPrice(gold: 99); // Buy this item for one gold - change gold to any coin and change the value to any number <= 100
            Item.rare = ItemRarityID.Gray;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;

            Item.pick = 999;
        }



        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();

            CreateRecipe()
             .AddIngredient(ModContent.ItemType<AudiChrome>(), 50)
             

             .AddTile(134)
             .Register();
            recipe.AddTile(TileID.MythrilAnvil);

        }
    }
}