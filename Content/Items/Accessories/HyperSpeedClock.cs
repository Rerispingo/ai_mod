using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ai_mod.Content.Items.Accessories
{
    /// <summary>
    /// Acessório que aumenta a velocidade de ataque de todas as classes em 100%.
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
            // Define a flag no ModPlayer para que o GlobalItem possa aplicar os bônus de velocidade.
            // O uso de GlobalItem garante que a frequência de projéteis também seja aumentada,
            // o que nem sempre acontece apenas aumentando o atributo de AttackSpeed.
            player.GetModPlayer<HyperSpeedPlayer>().hasHyperSpeedClock = true;
        }
    }
}
