using Terraria;
using Terraria.ModLoader;
using ai_mod.Common.Configs;
using ai_mod.Common.Players;

namespace ai_mod.Common.GlobalItems
{
    public class HyperSpeedGlobalItem : GlobalItem
    {
        public override float UseSpeedMultiplier(Item item, Player player) {
            if (player.GetModPlayer<HyperSpeedPlayer>().hasHyperSpeedClock) {
                var config = ModContent.GetInstance<HyperSpeedConfig>();
                float bonus = 0f;

                // Determina qual bônus aplicar com base no tipo de item
                if (item.pick > 0 || item.axe > 0 || item.hammer > 0) {
                    // Ferramentas de mineração (picaretas, machados e martelos)
                    bonus = config.MiningSpeedBonus / 100f;
                }
                else if (item.createTile != -1 || item.createWall != -1 || item.tileWand != -1 || item.paint > 0 || item.FitsAmmoSlot() || item.type == Terraria.ID.ItemID.EmptyBucket || item.type == Terraria.ID.ItemID.WaterBucket || item.type == Terraria.ID.ItemID.LavaBucket || item.type == Terraria.ID.ItemID.HoneyBucket || item.type == Terraria.ID.ItemID.BottomlessBucket || item.type == Terraria.ID.ItemID.BottomlessLavaBucket || item.type == Terraria.ID.ItemID.BottomlessHoneyBucket || item.type == Terraria.ID.ItemID.BottomlessShimmerBucket) {
                    // Itens de posicionamento (blocos, paredes, varinhas, tinta, baldes de líquidos)
                    bonus = config.PlacementSpeedBonus / 100f;
                }
                else if (item.damage > 0) {
                    // Armas e outros itens de combate
                    bonus = config.AttackSpeedBonus / 100f;
                }

                if (bonus <= 0f) return 1f;
                
                // Retorna o multiplicador de velocidade (1.0 + bonus). 
                // Ex: 100% bônus -> 2.0 (dobra a velocidade).
                return 1f + bonus;
            }
            return base.UseSpeedMultiplier(item, player);
        }

        public override void ModifyShootStats(Item item, Player player, ref Microsoft.Xna.Framework.Vector2 position, ref Microsoft.Xna.Framework.Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            if (player.GetModPlayer<HyperSpeedPlayer>().hasHyperSpeedClock) {
                // Mantém a velocidade do projétil dobrada como característica do item.
                velocity *= 2f;
            }
        }

        public override bool CanConsumeAmmo(Item weapon, Item ammo, Player player) {
            // Se o jogador tiver o relógio e a munição infinita estiver ativada na config, não consome.
            if (player.GetModPlayer<HyperSpeedPlayer>().hasHyperSpeedClock && ModContent.GetInstance<HyperSpeedConfig>().InfiniteAmmo) {
                return false;
            }
            return base.CanConsumeAmmo(weapon, ammo, player);
        }

        public override void HoldItem(Item item, Player player) {
            if (player.GetModPlayer<HyperSpeedPlayer>().hasHyperSpeedClock) {
                var config = ModContent.GetInstance<HyperSpeedConfig>();
                
                // Aplica o bônus de alcance diretamente ao item segurado.
                // tileBoost aumenta o alcance de interação do item (mineração e posicionamento).
                if (config.TileRangeBonus > 0) {
                    item.tileBoost = config.TileRangeBonus;
                }

                // Melhora a fluidez da mineração de paredes (martelos)
                if (item.hammer > 0 && config.MiningSpeedBonus > 0) {
                    item.reuseDelay = 0; // Remove atraso entre batidas
                }
            }
        }
    }
}
