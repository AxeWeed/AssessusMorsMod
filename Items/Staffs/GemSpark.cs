using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
namespace AssessusMorsMod.Items.Staffs
{
    public class GemSpark : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("GemSpark");
            Tooltip.SetDefault("Casts a bolt");
            Item.staff[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.mana = 22;
            Item.DamageType = DamageClass.Magic;
            Item.width = 18;
            Item.height = 18;
            Item.useTime = 16;
            Item.useAnimation = 29;
            Item.useStyle = 5;
            Item.knockBack = 4;
            Item.value = 12000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item28;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.CrystalLeafShot; 
            Item.shootSpeed = 15f;
            Item.noMelee = true;
            Item.crit = 22;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(ItemID.Diamond, 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}