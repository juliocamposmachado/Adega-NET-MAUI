# Adega Rádio Tatuapé FM - Aplicativo .NET MAUI

## 📱 Sobre o Projeto

Aplicativo multiplataforma desenvolvido em .NET MAUI para a **Adega Rádio Tatuapé FM Express**, oferecendo uma experiência moderna e integrada para pedidos de bebidas com entrega rápida via Uber Direct.

Este projeto representa a migração integral para o ecossistema .NET MAUI, unificando frontend, backend e acesso a dados em uma arquitetura robusta e escalável.

---

<img width="1365" height="767" alt="image" src="https://github.com/user-attachments/assets/80941e92-6833-4a39-b4a8-73ee97ccfe81" />


## 🎯 Justificativa Técnica da Migração

### Por que .NET MAUI?

O **.NET MAUI (Multi-platform App UI)** é a evolução do Xamarin, oferecendo:

- ✅ **Base de código única** em C# e XAML para Android, iOS, Windows e Web
- ✅ **Performance nativa** com compilação otimizada para cada plataforma
- ✅ **Integração natural** com APIs RESTful e autenticação moderna
- ✅ **Produtividade elevada** com Visual Studio Community
- ✅ **Conformidade LGPD** através de autenticação OAuth2 (Google/Microsoft/Facebook)

---

## 🏗️ Arquitetura do Sistema

### Camadas da Aplicação

```
┌─────────────────────────────────────────┐
│   📱 CAMADA 1: APLICATIVO MAUI         │
│   - Interface XAML                      │
│   - Lógica de negócio em C#            │
│   - Multiplataforma (Android/iOS/Win)  │
└─────────────────────────────────────────┘
                    ↕️ HTTPS/JWT
┌─────────────────────────────────────────┐
│   🌐 CAMADA 2: API REST (ASP.NET Core) │
│   - Endpoints seguros (Bearer Token)   │
│   - Autenticação JWT + SHA256          │
│   - Controllers e Services             │
└─────────────────────────────────────────┘
                    ↕️ Entity Framework Core
┌─────────────────────────────────────────┐
│   💾 CAMADA 3: BANCO DE DADOS          │
│   - SQL Server / Oracle                │
│   - Migrations automatizadas           │
│   - Controle de versão de schema      │
└─────────────────────────────────────────┘
```

---

## 🔐 Segurança e Conformidade LGPD

### Autenticação OAuth2

**Seguindo as diretrizes do Gerente de Projetos Marcelo**, a autenticação será realizada exclusivamente através de provedores externos:

- 🔵 **Google OAuth2**
- 🔵 **Microsoft Account**
- 🔵 **Facebook Login**

### Proteção de Dados (LGPD - Lei nº 13.709/2018)

- ❌ **Não armazenamos senhas** localmente
- ❌ **Não armazenamos dados bancários** (pagamentos via PIX/maquininha)
- ✅ Tokens JWT com **expiração automática**
- ✅ Comunicação **HTTPS obrigatória**
- ✅ Criptografia **SHA256** para dados sensíveis

---

## 🚀 MVP - Fase 1 (Prova de Conceito)

### Escopo Inicial

✅ **Tela de Login** com autenticação OAuth2  
✅ Integração com API backend  
✅ Validação de JWT e políticas de segurança  
✅ Testes de performance em dispositivos reais  

### O que NÃO estará na Fase 1

❌ **Pagamento direto no app** (evita custos de homologação e cofres de cartão)  
❌ Integração com gateway de pagamento  
❌ Armazenamento de dados bancários  

**Pagamentos continuam via:** PIX ou Maquininha (na entrega)

---

## 📂 Estrutura do Projeto

```
C:\Adega NET MAUI\
│
├── AdegaRadioTatuape\           # 📱 Aplicativo MAUI
│   ├── Platforms\               # Código específico de plataforma
│   │   ├── Android\
│   │   ├── iOS\
│   │   ├── Windows\
│   │   └── MacCatalyst\
│   ├── Resources\               # Imagens, fontes, estilos
│   ├── Views\                   # Páginas XAML
│   ├── ViewModels\              # Lógica de apresentação
│   ├── Services\                # Chamadas à API
│   ├── Models\                  # Modelos de dados
│   └── App.xaml                 # Aplicativo principal
│
├── AdegaRadioTatuape.API\       # 🌐 Backend ASP.NET Core
│   ├── Controllers\             # Endpoints REST
│   ├── Services\                # Lógica de negócio
│   ├── Models\                  # Entidades do banco
│   ├── Data\                    # Contexto EF Core
│   ├── Authentication\          # JWT + OAuth2
│   └── Program.cs               # Configuração da API
│
└── README.md                    # Este arquivo
```

---

## 🛠️ Tecnologias Utilizadas

### Frontend (MAUI App)
- **.NET 9.0**
- **C# 12**
- **XAML** para interfaces
- **MVVM Pattern**
- **CommunityToolkit.Mvvm**

### Backend (API)
- **ASP.NET Core 9.0**
- **Entity Framework Core**
- **JWT Authentication**
- **Swagger/OpenAPI**

### Banco de Dados
- **SQL Server** (ou Oracle conforme necessidade)
- **Entity Framework Core Migrations**

### Segurança
- **OAuth2** (Google, Microsoft, Facebook)
- **JWT Bearer Tokens**
- **SHA256** para hashing
- **HTTPS obrigatório**

---

## 📋 Pré-requisitos

### Desenvolvimento

- ✅ Windows 10/11 (recomendado)
- ✅ Visual Studio 2022 Community (v17.8+)
- ✅ .NET 9.0 SDK
- ✅ Workloads instalados:
  - `.NET MAUI`
  - `ASP.NET and web development`
  - `Mobile development with .NET`

### Execução

- Android: API 21+ (Android 5.0 Lollipop)
- iOS: iOS 11+
- Windows: Windows 10 1809+
- MacCatalyst: macOS 10.15+

---

## 🚀 Como Executar

### 1. Restaurar Dependências

```bash
cd "C:\Adega NET MAUI"
dotnet restore
```

### 2. Executar a API (Backend)

```bash
cd AdegaRadioTatuape.API
dotnet run
```

A API estará disponível em: `https://localhost:5001`

### 3. Executar o App MAUI

**No Visual Studio:**
1. Abra `AdegaRadioTatuape.sln`
2. Selecione a plataforma (Android/iOS/Windows)
3. Pressione F5 para debug

**Via CLI:**
```bash
cd AdegaRadioTatuape
dotnet build -t:Run -f net9.0-android
```

---

## 🔄 Roadmap do Projeto

### ✅ Fase 1 - MVP (Atual)
- [x] Estrutura base do projeto
- [ ] Tela de login OAuth2
- [ ] Integração com API
- [ ] Autenticação JWT

### 🔜 Fase 2 - Catálogo
- [ ] Listagem de produtos
- [ ] Filtros e busca
- [ ] Carrinho de compras
- [ ] Finalização via WhatsApp

### 🔜 Fase 3 - Pedidos
- [ ] Histórico de pedidos
- [ ] Rastreamento Uber Direct
- [ ] Notificações push
- [ ] Avaliações

### 🔜 Fase 4 - Admin
- [ ] Dashboard administrativo
- [ ] Gestão de estoque
- [ ] Relatórios
- [ ] Analytics

---

## 👥 Equipe

- **Gerente de Projetos:** Marcelo
- **Desenvolvedor:** Julio Campos Machado
- **Estudante de:** Gestão Pública - Universidade Anhembi Morumbi

---

## 📞 Contato

- **Endereço:** Rua Dante Pellacani, 92 - Tatuapé, São Paulo/SP
- **CEP:** 03334-070
- **WhatsApp:** (11) 97060-3441
- **Rádio:** [radiotatuapefm.com.br](https://radiotatuapefm.com.br)

---

## 📄 Licença

© 2024 Adega Rádio Tatuapé FM Express. Todos os direitos reservados.

---

## 🎯 Observações Importantes

### Decisões de Arquitetura

1. **Sem pagamento integrado no app** - Por decisão do gerente de projetos, evitando custos de homologação e simplificando conformidade com PCI DSS
2. **OAuth2 obrigatório** - Garantia de conformidade com LGPD
3. **JWT com expiração** - Segurança e renovação automática de sessões
4. **API RESTful stateless** - Escalabilidade horizontal

### Próximos Passos

1. Configurar credenciais OAuth2 (Google Cloud Console / Azure Portal)
2. Implementar endpoints de autenticação na API
3. Criar tela de login no MAUI
4. Integrar fluxo completo de autenticação
5. Testes em dispositivos físicos

---

**Desenvolvido com ❤️ e 🎸 Rock'n'Roll pela Rádio Tatuapé FM**

