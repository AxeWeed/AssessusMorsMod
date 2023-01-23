using AssessusMorsMod.Items.Tomes;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AssessusMorsMod
{
    internal class AssessusMorsModSystem : ModSystem
    {

        public override void PostWorldGen()
        {
            base.PostWorldGen();
            int[] itemsToPlaceInWoodenChests = { ModContent.ItemType<Junkosis>() };
            int itemsToPlaceInWoodenChestsChoice = 0;
            for (int chestIndex = 0; chestIndex < 1000; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest != null && Main.tile[chest.x, chest.y].TileType == TileID.Containers && Main.tile[chest.x, chest.y].TileFrameX == 0 * 36)
                {
                    for (int inventoryIndex = 0; inventoryIndex < 40; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            chest.item[inventoryIndex].SetDefaults(itemsToPlaceInWoodenChests[itemsToPlaceInWoodenChestsChoice]);
                            itemsToPlaceInWoodenChestsChoice = (itemsToPlaceInWoodenChestsChoice + 1) % itemsToPlaceInWoodenChests.Length;
                            break;
                        }
                    }
                }
            }
        }
    }
}
