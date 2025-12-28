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
├── Localization/
│   └── en-US_Mods.ai_mod.hjson
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

## Convenções de Codificação

Este projeto segue as convenções de codificação padrão do C# e as diretrizes da API do tModLoader. Recomenda-se o uso de um formatador de código (como o fornecido pelo Visual Studio ou Rider) para manter a consistência.

- **Nomenclatura:** Use `PascalCase` para nomes de classes, métodos e propriedades. Use `camelCase` para variáveis locais e parâmetros.
- **Comentários:** Comente o código de forma clara e concisa, explicando a lógica complexa ou partes não óbvias.
- **Organização:** Mantenha os arquivos e pastas organizados de forma lógica, agrupando funcionalidades relacionadas.

## Detalhes Específicos do Mod

### Itens Adicionados

- **Relógio de Hiper Velocidade (Hyper Speed Clock):**
    - Um acessório que aumenta a velocidade de ataque de todas as classes.
    - **Configurável:** O bônus de velocidade pode ser ajustado entre 0% e 300% através do menu de configurações do mod.
    - **Receita:** Pode ser fabricado livremente (sem itens e sem bancada).
    - **Correção de Frequência:** Utiliza um `GlobalItem` para reduzir o `useTime` e `useAnimation` de todas as armas com base no bônus configurado. Isso garante que a frequência de disparos de projéteis também seja aumentada proporcionalmente.
    - **Velocidade de Projétil:** Dobra a velocidade dos projéteis disparados.
    - Localização disponível em Inglês e Português.

### Configurações
- **Bônus de Velocidade de Ataque:** Slider de 0 a 300% (Padrão: 100%).

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