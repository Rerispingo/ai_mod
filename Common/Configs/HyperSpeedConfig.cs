using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ai_mod.Common.Configs
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

        [DefaultValue(0)]
        [Range(0, 150)]
        [Slider]
        public int MoveSpeedBonus;

        [DefaultValue(0)]
        [Range(0, 150)]
        [Slider]
        public int AccelerationBonus;

        [DefaultValue(0)]
        [Range(0, 300)]
        [Slider]
        public int DamageBonus;

        [DefaultValue(0)]
        [Range(0, 100)]
        [Slider]
        public int CritBonus;

        [Header("Extras")]

        [DefaultValue(0)]
        [Range(0, 50)]
        [Slider]
        public int TileRangeBonus;

        [DefaultValue(false)]
        public bool InfiniteMana;

        [DefaultValue(false)]
        public bool InfiniteFlight;

        [DefaultValue(false)]
        public bool InfiniteAmmo;

        [DefaultValue(false)]
        public bool InfiniteMinions;
    }
}
