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

                // Aplica bônus de velocidade de mineração e posicionamento (via atributos do jogador)
                // Nota: pickSpeed é um multiplicador de tempo (menor é mais rápido)
                if (config.MiningSpeedBonus > 0) {
                    float bonus = config.MiningSpeedBonus / 100f;
                    Player.pickSpeed *= 1f / (1f + bonus);
                    // O bônus de mineração deve afetar paredes (martelos) e árvores (machados)
                    // No Terraria, wallSpeed e tileSpeed afetam a velocidade de ação dessas ferramentas.
                    Player.wallSpeed += bonus;
                    Player.tileSpeed += bonus;
                }

                if (config.PlacementSpeedBonus > 0) {
                    float bonus = config.PlacementSpeedBonus / 100f;
                    Player.tileSpeed += bonus;
                    Player.wallSpeed += bonus;
                }
            }
        }
    }
}
