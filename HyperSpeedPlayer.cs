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
    }
}
