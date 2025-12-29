using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ai_mod.Common.Players;

namespace ai_mod.Content.Items.Accessories
{
    /// <summary>
    /// Acessório que aumenta atributos de combate conforme configurado.
    /// </summary>
    public class HyperSpeedClock : ModItem
    {
        public override void SetDefaults() {
            Item.width = 30;
            Item.height = 30;
            Item.accessory = true;
            Item.rare = ItemRarityID.Orange;
            Item.value = Item.sellPrice(gold: 5);
        }

        public override void UpdateAccessory(Player player, bool hideVisual) {
            // Define a flag no ModPlayer para que o GlobalItem possa aplicar os bônus.
            player.GetModPlayer<HyperSpeedPlayer>().hasHyperSpeedClock = true;
        }

        public override void AddRecipes() {
            // Cria uma receita simples: sem itens e sem necessidade de bancada.
            CreateRecipe()
                .Register();
        }
    }
}
