using Terraria;
using Terraria.ModLoader;
using ai_mod.Common.Configs;

namespace ai_mod.Common.Players
{
    public class HyperSpeedPlayer : ModPlayer
    {
        // Flag para indicar se o acessório HyperSpeedClock está equipado
        public bool hasHyperSpeedClock = false;

        public override void ResetEffects() {
            hasHyperSpeedClock = false;
        }

        public override void PostUpdateEquips() {
            if (hasHyperSpeedClock) {
                var config = ModContent.GetInstance<HyperSpeedConfig>();

                // Aplica bônus de dano e crítico
                if (config.DamageBonus > 0) {
                    Player.GetDamage(DamageClass.Generic) += config.DamageBonus / 100f;
                }

                if (config.CritBonus > 0) {
                    Player.GetCritChance(DamageClass.Generic) += config.CritBonus;
                }

                // Se a configuração de mana infinita estiver ativa, mantém a mana no máximo.
                if (config.InfiniteMana) {
                    Player.statMana = Player.statManaMax2;
                }

                // Se a configuração de voo infinito estiver ativa, reseta o tempo de voo das asas/botas.
                if (config.InfiniteFlight) {
                    Player.wingTime = Player.wingTimeMax;
                }

                // Aplica bônus de alcance
                if (config.TileRangeBonus > 0) {
                    Player.blockRange += config.TileRangeBonus;
                }

                // Aplica bônus de minions e sentinelas
                if (config.InfiniteMinions) {
                    Player.maxMinions += 200;
                    Player.maxTurrets += 200;
                }

                // Aplica bônus de velocidade de movimento máximo e aceleração
                if (config.MoveSpeedBonus > 0) {
                    float moveSpeedMult = 1f + (config.MoveSpeedBonus / 100f);
                    // accRunSpeed afeta a velocidade máxima com botas, maxRunSpeed afeta a velocidade base
                    Player.accRunSpeed *= moveSpeedMult;
                    Player.maxRunSpeed *= moveSpeedMult;
                }

                if (config.AccelerationBonus > 0) {
                    // runAcceleration controla a rapidez com que o jogador atinge a velocidade máxima
                    Player.runAcceleration *= 1f + (config.AccelerationBonus / 100f);
                }
            }
        }
    }
}
