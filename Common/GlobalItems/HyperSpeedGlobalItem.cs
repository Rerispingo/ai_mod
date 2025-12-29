using Terraria;
using Terraria.ModLoader;
using ai_mod.Common.Configs;
using ai_mod.Common.Players;

namespace ai_mod.Common.GlobalItems
{
    public class HyperSpeedGlobalItem : GlobalItem
    {
        public override float UseTimeMultiplier(Item item, Player player) {
            if (player.GetModPlayer<HyperSpeedPlayer>().hasHyperSpeedClock) {
                // Obtém o bônus das configurações e calcula o multiplicador.
                // Multiplicador = 1 / (1 + bônus%). Ex: 100% bônus -> 1 / (1 + 1) = 0.5 (dobra a velocidade).
                float bonus = ModContent.GetInstance<HyperSpeedConfig>().AttackSpeedBonus / 100f;
                return 1f / (1f + bonus);
            }
            return base.UseTimeMultiplier(item, player);
        }

        public override float UseAnimationMultiplier(Item item, Player player) {
            if (player.GetModPlayer<HyperSpeedPlayer>().hasHyperSpeedClock) {
                // Aplica o mesmo multiplicador para a animação.
                float bonus = ModContent.GetInstance<HyperSpeedConfig>().AttackSpeedBonus / 100f;
                return 1f / (1f + bonus);
            }
            return base.UseAnimationMultiplier(item, player);
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
    }
}
