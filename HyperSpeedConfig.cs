using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ai_mod
{
    /// <summary>
    /// Configuração do mod para ajustar os bônus do HyperSpeedClock.
    /// </summary>
    public class HyperSpeedConfig : ModConfig
    {
        // Configurações do lado do cliente (ClientSide) ou servidor (ServerSide). 
        // Geralmente bônus de itens são ServerSide para consistência no multiplayer.
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Header("Ajustes")]
        
        [DefaultValue(100)]
        [Range(0, 300)]
        [Slider]
        public int AttackSpeedBonus;

        [DefaultValue(false)]
        public bool InfiniteMana;

        [DefaultValue(false)]
        public bool InfiniteFlight;

        [DefaultValue(false)]
        public bool InfiniteAmmo;
    }
}
