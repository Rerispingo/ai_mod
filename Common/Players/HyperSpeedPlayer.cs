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
            }
        }
    }
}
