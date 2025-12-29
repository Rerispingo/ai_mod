# ai_mod - Terraria tModLoader Mod

## Visão Geral do Projeto

Este é um mod para Terraria desenvolvido usando tModLoader. O objetivo deste README é fornecer uma visão geral estruturada do projeto para facilitar a compreensão e manutenção por uma Inteligência Artificial.

## Pilha de Tecnologia

- **Plataforma:** Terraria (via tModLoader)
- **Linguagem:** C#
- **Framework:** tModLoader API

## Estrutura do Projeto

```
ai_mod/
├── Common/
│   ├── Configs/
│   │   └── HyperSpeedConfig.cs
│   ├── GlobalItems/
│   │   └── HyperSpeedGlobalItem.cs
│   └── Players/
│       └── HyperSpeedPlayer.cs
├── Content/
│   └── Items/
│       └── Accessories/
│           ├── HyperSpeedClock.cs
│           └── HyperSpeedClock.png
├── Localization/
│   ├── en-US_Mods.ai_mod.hjson
│   └── pt-BR_Mods.ai_mod.hjson
├── Properties/
│   └── launchSettings.json
├── README.md
├── ai_mod.cs
├── ai_mod.csproj
├── build.txt
├── description.txt
├── description_workshop.txt
├── icon.png
└── icon_small.png
```

## Arquivos Importantes

- `ai_mod.cs`: O arquivo principal do mod, contendo a classe Mod principal.
- `Common/`: Contém lógica compartilhada, configurações e gerenciamento de jogadores.
- `Content/`: Contém os itens, blocos e outros conteúdos do jogo.

## Convenções de Codificação

Este projeto segue as convenções de codificação padrão do C# e as diretrizes da API do tModLoader.

- **Nomenclatura:** Use `PascalCase` para nomes de classes, métodos e propriedades. Use `camelCase` para variáveis locais e parâmetros.
- **Comentários:** Comente o código de forma clara e concisa, explicando a lógica complexa ou partes não óbvias.
- **Organização:** Arquivos organizados em pastas por tipo (`Configs`, `GlobalItems`, `Players`, `Items`, etc.).

## Detalhes Específicos do Mod

### Itens Adicionados

- **Relógio de Hiper Velocidade (Hyper Speed Clock):**
    - Um acessório que aumenta atributos de combate de todas as classes.
    - **Configurável:** Os bônus podem ser ajustados através do menu de configurações do mod.
    - **Bônus Configuráveis:**
        - **Velocidade de Ataque:** Slider de 0 a 300% (Padrão: 100%).
        - **Velocidade de Mineração:** Slider de 0 a 1000% (Padrão: 100%). Afeta picaretas, machados e martelos. Inclui bônus de dano a paredes para quebra instantânea.
        - **Velocidade de Posicionamento:** Slider de 0 a 1000% (Padrão: 100%). Afeta blocos, paredes, tintas, líquidos (baldes), etc.
        - **Alcance de Blocos:** Slider de 0 a 50 blocos (Padrão: 0). Afeta alcance de mineração e construção (via `tileBoost` e `blockRange`).
        - **Bônus de Dano:** Slider de 0 a 300% (Padrão: 0%).
        - **Bônus de Crítico:** Slider de 0 a 100% (Padrão: 0%).
        - **Mana Infinita:** Quando ativado, o jogador possui mana ilimitada.
        - **Voo Infinito:** Quando ativado, o tempo de voo com asas ou botas é resetado constantemente.
        - **Munição Infinita:** Quando ativado, armas não consomem munição ao disparar.
        - **Minions e Sentinelas Infinitos:** Quando ativado, aumenta o limite de minions e sentinelas em +200.
    - **Receita:** Pode ser fabricado livremente (sem itens e sem bancada).
    - **Correção de Frequência:** Utiliza um `GlobalItem` para reduzir o `useTime` e `useAnimation` dos itens com base no bônus configurado (Combate, Mineração ou Posicionamento).
    - **Velocidade de Projétil:** Dobra a velocidade dos projéteis disparados.
    - Localização disponível em Inglês e Português.

## Instruções de Desenvolvimento

Para trabalhar neste mod, você precisará ter o tModLoader instalado e configurado para desenvolvimento.

### Construir o Mod

1.  Abra o arquivo `ai_mod.csproj` em um IDE compatível com C# (como Visual Studio ou Rider).
2.  Certifique-se de que todas as dependências do tModLoader estejam corretamente referenciadas.
3.  Compile o projeto. O tModLoader geralmente detecta automaticamente os mods na pasta `ModSources` e os compila ao iniciar o jogo.

### Executar o Mod

1.  Inicie o Terraria através do tModLoader.
2.  No menu principal do tModLoader, vá para a seção "Mods".
3.  Encontre "ai_mod" na lista e certifique-se de que esteja habilitado.
4.  Recarregue os mods, se necessário.
5.  Inicie um jogo para testar o mod.
