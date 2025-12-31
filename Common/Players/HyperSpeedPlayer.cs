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

                // Aplica efeitos da bota de terraisca se configurado
                if (config.TerrasparkEffects) {
                    ApplyTerrasparkEffects();
                }
            }
        }

        public override void PostUpdateRunSpeeds() {
            if (hasHyperSpeedClock) {
                var config = ModContent.GetInstance<HyperSpeedConfig>();

                // Aplica bônus de velocidade de movimento máximo e aceleração
                // Conforme documentação do tModLoader, modificações em accRunSpeed, maxRunSpeed e runAcceleration
                // devem ser feitas no PostUpdateRunSpeeds para evitar conflitos com outros mods e o jogo base.
                if (config.MoveSpeedBonus > 0) {
                    float moveSpeedMult = 1f + (config.MoveSpeedBonus / 100f);
                    Player.accRunSpeed *= moveSpeedMult;
                    Player.maxRunSpeed *= moveSpeedMult;
                }

                if (config.AccelerationBonus > 0) {
                    Player.runAcceleration *= 1f + (config.AccelerationBonus / 100f);
                }
            }
        }

        /// <summary>
        /// Aplica os efeitos da bota de terraisca (Terraspark Boots).
        /// Inclui corrida veloz, mobilidade no gelo, andar sobre líquidos e imunidade a lava.
        /// </summary>
        private void ApplyTerrasparkEffects() {
            // Corrida super veloz (efeito das botas de Hermes/Foguete)
            // No jogo original, accRunSpeed é definido para 6.75f por essas botas
            if (Player.accRunSpeed < 6.75f) {
                Player.accRunSpeed = 6.75f;
            }

            // 10% aumento de velocidade de movimento
            Player.moveSpeed += 0.1f;

            // Mobilidade no gelo (Ice Skates)
            Player.iceSkate = true;

            // Andar sobre água, mel, lava e shimmer (Water Walking / Lava Waders)
            Player.waterWalk = true;
            Player.waterWalk2 = true; // Permite andar sobre lava
            
            // Imunidade a blocos quentes (Meteorito/Hellstone)
            Player.fireWalk = true;

            // Imunidade a lava (Imunidade total ao dano e tempo infinito de submersão)
            Player.lavaImmune = true;
            Player.lavaTime = Player.lavaMax; // Reseta o tempo de submersão constantemente para ser infinito
        }
    }
}
