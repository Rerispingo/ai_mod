using Terraria;
using Terraria.ModLoader;

namespace ai_mod
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
