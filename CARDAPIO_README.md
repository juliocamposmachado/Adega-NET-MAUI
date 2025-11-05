# 🍺 Cardápio Implementado - Adega Rádio Tatuapé FM

## ✅ O que foi implementado

### 1. **Site (index.html)** 
Adicionada seção completa de cardápio com design responsivo e elegante:

#### Categorias implementadas:
- 🍺 **Cervejas** (6 produtos)
  - Heineken Lata 350ml - R$ 5,90
  - Corona Extra 355ml - R$ 8,50
  - Budweiser Long Neck - R$ 6,90
  - Stella Artois 330ml - R$ 7,20
  - Brahma Duplo Malte - R$ 4,50
  - Skol Beats 313ml - R$ 5,90

- 🍷 **Vinhos** (6 produtos)
  - Casillero del Diablo Tinto - R$ 42,90
  - Frontera Cabernet 750ml - R$ 29,90
  - Santa Helena Reservado - R$ 35,00
  - Gato Negro Merlot 750ml - R$ 31,50
  - Sunrise Branco Suave - R$ 18,90
  - Almadén Tinto Seco 750ml - R$ 19,90

- 🥃 **Destilados** (6 produtos)
  - Johnnie Walker Red 1L - R$ 89,90
  - Jack Daniel's 1L - R$ 149,90
  - Absolut Vodka 1L - R$ 79,90
  - Smirnoff 998ml - R$ 54,90
  - Tanqueray Gin 750ml - R$ 119,90
  - Havana Club 3 Anos 750ml - R$ 69,90

- ⚡ **Energéticos** (4 produtos)
  - Red Bull 250ml - R$ 11,90
  - Monster Energy 473ml - R$ 12,50
  - TNT Energy 269ml - R$ 4,90
  - Burn Energy 260ml - R$ 6,50

- 🥤 **Refrigerantes** (4 produtos)
  - Coca-Cola 2L - R$ 9,90
  - Guaraná Antarctica 2L - R$ 8,90
  - Sprite Lata 350ml - R$ 3,50
  - Fanta Laranja 2L - R$ 8,50

- 💧 **Águas & Sucos** (4 produtos)
  - Água Crystal 500ml - R$ 2,50
  - Água Com Gás Perrier - R$ 6,90
  - Del Valle 1L (Diversos) - R$ 7,90
  - Água de Coco Kero 1L - R$ 8,50

**Total: 32 produtos cadastrados**

### 2. **App MAUI - Estrutura Backend**

#### Arquivo JSON (`Resources/Raw/cardapio.json`)
- ✅ Dados completos de todos os produtos
- ✅ Informações de estoque por produto
- ✅ Metadados (formas de pagamento, entrega, contato)
- ✅ Estruturado e pronto para consumo

#### Models criados:
1. **`Produto.cs`**
   - Propriedades: Id, Nome, Preco, Volume, Imagem, Estoque, CategoriaId
   - Propriedades computadas: PrecoFormatado, Disponivel, StatusEstoque

2. **`Categoria.cs`**
   - Propriedades: Id, Nome, Icone, Lista de Produtos
   - Propriedades computadas: QuantidadeProdutos, TituloComIcone

3. **`Cardapio.cs`** (e classes auxiliares)
   - InformacoesAdega
   - InfoEntrega (com DescricaoCompleta, TaxaFormatada)
   - ContatoAdega (com WhatsappFormatado, EnderecoCompleto)

#### Service criado:
**`CardapioService.cs`**
- ✅ Carrega JSON do arquivo embarcado
- ✅ Cache em memória para performance
- ✅ Deserialização type-safe
- ✅ Tratamento de erros
- ✅ Conversão automática para modelos internos

## 🚀 Como usar no App MAUI

### 1. Registrar o serviço no `MauiProgram.cs`:

```csharp
builder.Services.AddSingleton<CardapioService>();
```

### 2. Injetar e usar em uma página/ViewModel:

```csharp
using AdegaRadioTatuape.Services;
using AdegaRadioTatuape.Models;

public class CardapioPage : ContentPage
{
    private readonly CardapioService _cardapioService;

    public CardapioPage(CardapioService cardapioService)
    {
        _cardapioService = cardapioService;
        InitializeComponent();
        CarregarDados();
    }

    private async void CarregarDados()
    {
        var cardapio = await _cardapioService.CarregarCardapioAsync();
        
        // Exibir categorias
        foreach (var categoria in cardapio.Categorias)
        {
            Console.WriteLine($"{categoria.Icone} {categoria.Nome}");
            
            foreach (var produto in categoria.Produtos)
            {
                Console.WriteLine($"  - {produto.Nome} ({produto.PrecoFormatado})");
                Console.WriteLine($"    {produto.StatusEstoque}");
            }
        }
    }
}
```

### 3. Exemplo de binding XAML:

```xml
<CollectionView ItemsSource="{Binding Categorias}">
    <CollectionView.ItemTemplate>
        <DataTemplate>
            <Frame>
                <StackLayout>
                    <Label Text="{Binding TituloComIcone}" FontSize="20" FontAttributes="Bold"/>
                    
                    <CollectionView ItemsSource="{Binding Produtos}">
                        <CollectionView.ItemTemplate>
                            <DataTemplate>
                                <Grid ColumnDefinitions="*,Auto">
                                    <Label Grid.Column="0" Text="{Binding Nome}"/>
                                    <Label Grid.Column="1" Text="{Binding PrecoFormatado}" 
                                           TextColor="#D4AF37" FontAttributes="Bold"/>
                                </Grid>
                            </DataTemplate>
                        </CollectionView.ItemTemplate>
                    </CollectionView>
                </StackLayout>
            </Frame>
        </DataTemplate>
    </CollectionView.ItemTemplate>
</CollectionView>
```

## 📊 Informações Adicionais

### Formas de Pagamento
- Pix
- Cartão de Crédito
- Cartão de Débito

### Entrega
- **Tipo:** Uber Direct
- **Tempo médio:** 30-45 minutos
- **Taxa:** R$ 5,00

### Contato
- **WhatsApp:** (11) 97060-3441
- **Endereço:** Rua Dante Pellacani, 92 - Tatuapé, São Paulo/SP
- **CEP:** 03334-070

## 🎯 Próximos passos sugeridos

1. **Criar ViewModels com MVVM**
   - CardapioViewModel
   - CarrinhoViewModel
   - ProdutoDetalhesViewModel

2. **Implementar telas XAML**
   - CardapioPage (lista de categorias)
   - ProdutosPage (grid de produtos por categoria)
   - ProdutoDetalhePage (detalhes + adicionar ao carrinho)
   - CarrinhoPage (resumo de pedido)

3. **Adicionar imagens de produtos**
   - Salvar imagens em `Resources/Images/Produtos/`
   - Atualizar binding para exibir imagens

4. **Integrar com API Backend**
   - Criar endpoints na API para cardápio
   - Sincronizar estoque em tempo real
   - Adicionar autenticação JWT

5. **Funcionalidades de carrinho**
   - Adicionar/remover produtos
   - Calcular subtotal + taxa de entrega
   - Validar estoque antes de finalizar

6. **Integração Uber Direct**
   - Implementar fluxo de pedido
   - Rastreamento em tempo real
   - Notificações push

## 🌐 Deploy

### Site atualizado em:
- **Vercel:** https://adega-net-maui.vercel.app
- **GitHub:** https://github.com/juliocamposmachado/Adega-NET-MAUI

### Commit realizado:
```
feat: adicionar cardápio completo ao app e site
- Seção de cardápio no index.html com 6 categorias
- Arquivo JSON com dados completos (32 produtos)
- Models: Produto, Categoria, Cardápio
- Service: CardapioService para carregar dados
- Pronto para integração na UI do MAUI
```

## 📝 Notas Técnicas

- **Framework:** .NET 9.0 / .NET MAUI
- **Serialização:** System.Text.Json (built-in)
- **Cache:** Em memória (singleton pattern)
- **Performance:** Carregamento assíncrono com cache
- **Tratamento de erros:** Try-catch com fallback para cardápio vazio

---

✅ **Status:** Cardápio completo implementado e pronto para uso!
🎸 **Desenvolvido com Rock'n'Roll pela Rádio Tatuapé FM**

