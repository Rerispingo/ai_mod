using Terraria;
using Terraria.ModLoader;

namespace ai_mod
{
    public class HyperSpeedGlobalItem : GlobalItem
    {
        public override float UseTimeMultiplier(Item item, Player player) {
            if (player.GetModPlayer<HyperSpeedPlayer>().hasHyperSpeedClock) {
                // Reduz o tempo de uso pela metade, dobrando a frequência de ataque/tiro.
                return 0.5f;
            }
            return base.UseTimeMultiplier(item, player);
        }

        public override float UseAnimationMultiplier(Item item, Player player) {
            if (player.GetModPlayer<HyperSpeedPlayer>().hasHyperSpeedClock) {
                // Reduz o tempo da animação pela metade, dobrando a velocidade visual do movimento.
                return 0.5f;
            }
            return base.UseAnimationMultiplier(item, player);
        }

        public override void ModifyShootStats(Item item, Player player, ref Microsoft.Xna.Framework.Vector2 position, ref Microsoft.Xna.Framework.Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            if (player.GetModPlayer<HyperSpeedPlayer>().hasHyperSpeedClock) {
                // Dobra a velocidade do projetil disparado para condizer com o tema de "Hiper Velocidade".
                velocity *= 2f;
            }
        }
    }
}
