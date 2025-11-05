# 📝 Changelog - Adega Rádio Tatuapé FM

## [1.0.0] - 2025-11-05

### ✨ Adicionado
- **🍺 Cardápio Completo**
  - 32 produtos em 6 categorias
  - Cervejas, Vinhos, Destilados, Energéticos, Refrigerantes, Águas & Sucos
  - Preços e informações de estoque por produto
  
- **📱 Models do App MAUI**
  - `Produto.cs` - Modelo de produto com propriedades computadas
  - `Categoria.cs` - Modelo de categoria com lista de produtos
  - `Cardapio.cs` - Modelo completo com informações da adega
  
- **⚙️ Serviços**
  - `CardapioService.cs` - Serviço para carregar dados do JSON
  - Sistema de cache em memória para performance
  - Deserialização type-safe com tratamento de erros
  
- **🌐 Site (Landing Page)**
  - Seção de cardápio responsiva no index.html
  - Design moderno com efeitos hover
  - Informações de pagamento e entrega
  - Visual consistente com tema dourado/vinho

- **📦 Dados Estruturados**
  - `cardapio.json` - Arquivo JSON com todos os produtos
  - Informações de entrega Uber Direct
  - Formas de pagamento aceitas
  - Dados de contato e localização

### 🔧 Modificado
- **APK Android** atualizado com cardápio integrado
  - Tamanho: 14.35 MB
  - Build Debug com cardapio.json embarcado
  
- **EXE Windows** atualizado com cardápio integrado  
  - Tamanho: 103.82 MB
  - Build Debug com todos os recursos

### 📚 Documentação
- `CARDAPIO_README.md` - Guia completo de uso do cardápio
- Exemplos de código C# e XAML
- Instruções de integração
- Próximos passos sugeridos

### 🚀 Deploy
- Site atualizado no Vercel: https://adega-net-maui.vercel.app
- APK disponível para download direto no site
- Código fonte no GitHub: https://github.com/juliocamposmachado/Adega-NET-MAUI

---

## [0.1.0] - Inicial

### ✨ Adicionado (anterior)
- Projeto .NET MAUI multiplataforma
- Backend ASP.NET Core Web API
- Estrutura OAuth2 para autenticação
- Configuração inicial do projeto
- README.md com documentação técnica
- PARA_GERENTE_MARCELO.md com guia de implementação
- COMO_INSTALAR.md com instruções de instalação
- Landing page inicial com splash screen
- Builds APK (Android) e EXE (Windows)

---

## 📊 Estatísticas da Versão Atual

### Produtos Cadastrados
- 🍺 Cervejas: 6 produtos (R$ 4,50 - R$ 8,50)
- 🍷 Vinhos: 6 produtos (R$ 18,90 - R$ 42,90)
- 🥃 Destilados: 6 produtos (R$ 54,90 - R$ 149,90)
- ⚡ Energéticos: 4 produtos (R$ 4,90 - R$ 12,50)
- 🥤 Refrigerantes: 4 produtos (R$ 3,50 - R$ 9,90)
- 💧 Águas & Sucos: 4 produtos (R$ 2,50 - R$ 8,50)

**Total: 32 produtos**

### Arquivos do Projeto
- Models: 3 arquivos
- Services: 1 arquivo
- JSON: 1 arquivo (304 linhas)
- Documentação: 4 arquivos

### Tecnologias
- .NET 9.0
- C# 12
- MAUI
- System.Text.Json
- OAuth2 (planejado)
- JWT (planejado)

---

## 🎯 Próximas Versões Planejadas

### [1.1.0] - UI do Cardápio
- Telas XAML para exibição do cardápio
- ViewModels com MVVM
- Navegação entre categorias
- Detalhes de produtos

### [1.2.0] - Carrinho de Compras
- Adicionar/remover produtos
- Cálculo de totais
- Validação de estoque

### [1.3.0] - Integração Backend
- API RESTful para cardápio
- Sincronização de estoque
- Autenticação JWT

### [2.0.0] - MVP Completo
- Uber Direct integrado
- Pagamento via Mercado Pago
- Rastreamento de pedidos
- Notificações push

---

🎸 **Desenvolvido com Rock'n'Roll pela Rádio Tatuapé FM**

