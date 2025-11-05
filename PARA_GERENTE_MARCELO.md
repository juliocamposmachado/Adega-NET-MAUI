# 📋 PARA: Gerente de Projetos Marcelo

---

## 👋 Olá Marcelo!

A estrutura base do projeto **Adega Rádio Tatuapé FM** em **.NET MAUI** foi criada com sucesso, seguindo todas as diretrizes técnicas que você estabeleceu.

---

## ✅ O Que Já Foi Implementado

### 1. Estrutura do Projeto
- ✅ **Aplicativo MAUI** multiplataforma (Android, iOS, Windows, MacCatalyst)
- ✅ **API REST** ASP.NET Core 9.0
- ✅ Arquitetura em **3 camadas** conforme especificado
- ✅ **.gitignore** protegendo credenciais OAuth2 e chaves sensíveis

### 2. Documentação Completa
- ✅ **README.md principal** com toda justificativa técnica
- ✅ Explicação da arquitetura 3 camadas
- ✅ Conformidade LGPD detalhada
- ✅ Roadmap de 4 fases de desenvolvimento

### 3. Segurança e Conformidade
- ✅ Estrutura preparada para **OAuth2** (Google/Microsoft/Facebook)
- ✅ Sem armazenamento local de senhas (conformidade LGPD)
- ✅ Preparado para **JWT Bearer Tokens**
- ✅ HTTPS obrigatório

---

## 📚 Documentação Disponível

**IMPORTANTE:** Toda a documentação técnica, arquitetura, justificativas e roadmap estão disponíveis no arquivo:

```
📄 README.md
```

**Localização:** Raiz do projeto (`C:\Adega NET MAUI\README.md`)

**Repositório GitHub:**
https://github.com/juliocamposmachado/Adega-NET-MAUI

---

## 🚀 Próximos Passos para Implementação

### FASE 1: Configuração OAuth2 (Prioridade Máxima)

#### 1️⃣ Google OAuth2

**Ação necessária:**
1. Acessar [Google Cloud Console](https://console.cloud.google.com)
2. Criar novo projeto: "Adega Rádio Tatuapé FM"
3. Ativar "Google+ API" ou "Google Identity"
4. Criar credenciais OAuth 2.0:
   - **Tipo:** Aplicativo Android/iOS/Web
   - **URIs de redirecionamento autorizados:**
     - `com.adega.tatuape:/oauth2redirect` (mobile)
     - `https://localhost:5001/signin-google` (API local)
     - `https://[seu-dominio]/signin-google` (produção)
5. Baixar `client_secret.json` (não commitar!)
6. Guardar **Client ID** e **Client Secret**

**Onde configurar no projeto:**
```
AdegaRadioTatuape.API/appsettings.json
```

#### 2️⃣ Microsoft Account (Azure AD)

**Ação necessária:**
1. Acessar [Azure Portal](https://portal.azure.com)
2. Azure Active Directory → App registrations → New registration
3. Nome: "Adega Rádio Tatuapé FM"
4. Tipo: Contas Microsoft pessoais e organizacionais
5. URIs de redirecionamento:
   - `com.adega.tatuape:/oauth2redirect`
   - `https://localhost:5001/signin-microsoft`
6. Certificates & secrets → New client secret
7. Guardar **Application (client) ID** e **Client Secret**

**Onde configurar no projeto:**
```
AdegaRadioTatuape.API/appsettings.json
```

#### 3️⃣ Facebook Login

**Ação necessária:**
1. Acessar [Facebook Developers](https://developers.facebook.com)
2. Criar novo aplicativo
3. Adicionar produto "Facebook Login"
4. URIs OAuth válidos:
   - `com.adega.tatuape:/oauth2redirect`
   - `https://localhost:5001/signin-facebook`
5. Guardar **App ID** e **App Secret**

**Onde configurar no projeto:**
```
AdegaRadioTatuape.API/appsettings.json
```

---

### FASE 2: Implementação Backend (API)

#### Estrutura a Criar na API:

```
AdegaRadioTatuape.API/
├── Controllers/
│   ├── AuthController.cs          # ✅ CRIAR - Autenticação OAuth2
│   ├── ProductsController.cs      # ⏳ Fase 2
│   ├── OrdersController.cs        # ⏳ Fase 3
│   └── UsersController.cs         # ⏳ Fase 2
│
├── Services/
│   ├── AuthService.cs             # ✅ CRIAR - Lógica JWT
│   ├── TokenService.cs            # ✅ CRIAR - Geração/Validação JWT
│   └── OAuth2Service.cs           # ✅ CRIAR - Integração provedores
│
├── Models/
│   ├── User.cs                    # ✅ CRIAR - Entidade usuário
│   ├── LoginRequest.cs            # ✅ CRIAR - DTO login
│   └── LoginResponse.cs           # ✅ CRIAR - DTO resposta
│
├── Data/
│   ├── AppDbContext.cs            # ✅ CRIAR - EF Core Context
│   └── Migrations/                # ⏳ Criar após DbContext
│
└── Authentication/
    ├── JwtSettings.cs             # ✅ CRIAR - Config JWT
    └── OAuth2Settings.cs          # ✅ CRIAR - Config OAuth2
```

---

### FASE 3: Implementação Frontend (MAUI App)

#### Estrutura a Criar no App:

```
AdegaRadioTatuape/
├── Views/
│   ├── LoginPage.xaml             # ✅ CRIAR - Tela de login
│   ├── HomePage.xaml              # ⏳ Fase 2
│   └── ProductsPage.xaml          # ⏳ Fase 2
│
├── ViewModels/
│   ├── LoginViewModel.cs          # ✅ CRIAR - Lógica login
│   ├── BaseViewModel.cs           # ✅ CRIAR - Base MVVM
│   └── HomeViewModel.cs           # ⏳ Fase 2
│
├── Services/
│   ├── ApiService.cs              # ✅ CRIAR - Chamadas HTTP
│   ├── AuthService.cs             # ✅ CRIAR - Gerencia tokens
│   └── SecureStorageService.cs    # ✅ CRIAR - Armazena JWT
│
└── Models/
    ├── User.cs                    # ✅ CRIAR - Modelo usuário
    └── LoginRequest.cs            # ✅ CRIAR - Request login
```

---

## 🔐 Configuração de Segurança (CRÍTICO)

### Arquivo de Configuração da API

**Criar:** `AdegaRadioTatuape.API/appsettings.json`

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  
  "JwtSettings": {
    "SecretKey": "GERAR_CHAVE_SEGURA_256_BITS_AQUI",
    "Issuer": "AdegaRadioTatuapeFM",
    "Audience": "AdegaMobileApp",
    "ExpirationInMinutes": 60
  },
  
  "OAuth2": {
    "Google": {
      "ClientId": "SEU_GOOGLE_CLIENT_ID_AQUI",
      "ClientSecret": "SEU_GOOGLE_CLIENT_SECRET_AQUI"
    },
    "Microsoft": {
      "ClientId": "SEU_MICROSOFT_CLIENT_ID_AQUI",
      "ClientSecret": "SEU_MICROSOFT_CLIENT_SECRET_AQUI",
      "TenantId": "common"
    },
    "Facebook": {
      "AppId": "SEU_FACEBOOK_APP_ID_AQUI",
      "AppSecret": "SEU_FACEBOOK_APP_SECRET_AQUI"
    }
  },
  
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=AdegaDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

**⚠️ IMPORTANTE:** Este arquivo **NÃO deve ser commitado** com credenciais reais. O `.gitignore` já está configurado para protegê-lo.

---

## 📦 Pacotes NuGet Necessários

### Para a API (Backend):

```bash
cd AdegaRadioTatuape.API

# Autenticação JWT
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

# OAuth2 Providers
dotnet add package Microsoft.AspNetCore.Authentication.Google
dotnet add package Microsoft.AspNetCore.Authentication.MicrosoftAccount
dotnet add package Microsoft.AspNetCore.Authentication.Facebook

# Entity Framework Core
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools

# Swagger (documentação API)
dotnet add package Swashbuckle.AspNetCore
```

### Para o App MAUI (Frontend):

```bash
cd AdegaRadioTatuape

# MVVM Toolkit
dotnet add package CommunityToolkit.Mvvm

# HTTP Client
dotnet add package Microsoft.Extensions.Http

# Armazenamento seguro de tokens
# (já incluído no .NET MAUI)
```

---

## 🗄️ Banco de Dados

### Criar Banco via Entity Framework Core

Após configurar o `AppDbContext.cs`:

```bash
cd AdegaRadioTatuape.API

# Criar migration inicial
dotnet ef migrations add InitialCreate

# Aplicar ao banco de dados
dotnet ef database update
```

---

## 🧪 Testes Iniciais

### 1. Testar API

```bash
cd AdegaRadioTatuape.API
dotnet run
```

Acesse: https://localhost:5001/swagger

### 2. Testar App MAUI

**No Visual Studio:**
1. Definir `AdegaRadioTatuape` como projeto de inicialização
2. Selecionar plataforma (Android Emulator / Windows Machine)
3. Pressionar F5

---

## ⚠️ Decisões Importantes (Conforme suas diretrizes)

### ✅ Decisões Confirmadas:

1. **Sem pagamento integrado no app** 
   - Evita custos de homologação PCI DSS
   - Simplifica conformidade regulatória
   - Pagamentos continuam via PIX/maquininha na entrega

2. **OAuth2 obrigatório**
   - Sem armazenamento de senhas
   - Conformidade total com LGPD
   - Responsabilidade de segurança delegada aos provedores

3. **JWT com expiração de 60 minutos**
   - Renovação automática via refresh tokens (implementar na Fase 2)
   - Logout automático por inatividade

4. **SQL Server como banco padrão**
   - Pode migrar para Oracle posteriormente (compatível com EF Core)

---

## 📞 Próximos Passos Imediatos

### Prioridade ALTA (Esta Semana):

1. **Configurar credenciais OAuth2** nos consoles (Google/Microsoft/Facebook)
2. **Instalar pacotes NuGet** na API
3. **Criar AuthController e AuthService** básicos
4. **Testar autenticação** via Swagger

### Prioridade MÉDIA (Próxima Semana):

1. Implementar tela de login no MAUI
2. Integrar login com a API
3. Armazenar JWT no SecureStorage
4. Testes em dispositivo físico Android

### Prioridade BAIXA (Fase 2):

1. Catálogo de produtos
2. Carrinho de compras
3. Integração WhatsApp para finalização

---

## 📚 Documentação de Referência

### Documentos do Projeto:
- **README.md** - Documentação completa do projeto
- **Este arquivo** - Guia de continuação para o gerente

### Documentação Microsoft:
- [.NET MAUI](https://learn.microsoft.com/dotnet/maui/)
- [ASP.NET Core Authentication](https://learn.microsoft.com/aspnet/core/security/authentication/)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)

### OAuth2 Providers:
- [Google OAuth2](https://developers.google.com/identity/protocols/oauth2)
- [Microsoft Identity](https://learn.microsoft.com/azure/active-directory/)
- [Facebook Login](https://developers.facebook.com/docs/facebook-login/)

---

## 🎯 Métricas de Sucesso - Fase 1 (MVP)

### Critérios de Aceitação:

- ✅ Usuário consegue fazer login via Google
- ✅ Usuário consegue fazer login via Microsoft
- ✅ Usuário consegue fazer login via Facebook
- ✅ JWT é gerado e armazenado com segurança
- ✅ Token expira após 60 minutos
- ✅ API valida tokens corretamente
- ✅ App funciona em Android e Windows

---

## 💡 Dicas Importantes

1. **Nunca commite credenciais** - O `.gitignore` já protege, mas sempre revise
2. **Use HTTPS obrigatório** - Mesmo em desenvolvimento local
3. **Teste em dispositivo real** - Emuladores podem ter limitações com OAuth2
4. **Monitore logs** - ASP.NET Core tem logging excelente integrado
5. **Documente mudanças** - Mantenha o README.md atualizado

---

## 📧 Contato

**Desenvolvedor:** Julio Campos Machado  
**Estudante de:** Gestão Pública - Universidade Anhembi Morumbi  
**Localização:** Rua Dante Pellacani, 92 - Tatuapé, São Paulo/SP  

---

## ✅ Checklist de Implementação

### Fase 1 - MVP (4-6 semanas)

- [ ] Configurar OAuth2 (Google/Microsoft/Facebook)
- [ ] Implementar AuthController na API
- [ ] Implementar JWT TokenService
- [ ] Criar banco de dados (EF Core Migrations)
- [ ] Criar tela de login no MAUI
- [ ] Integrar login com API
- [ ] Armazenar tokens com segurança
- [ ] Testes em dispositivos reais
- [ ] Validar conformidade LGPD
- [ ] Documentar APIs (Swagger)

### Fase 2 - Catálogo (6-8 semanas)

- [ ] Implementar ProductsController
- [ ] Tela de listagem de produtos
- [ ] Filtros e busca
- [ ] Carrinho de compras
- [ ] Finalização via WhatsApp

### Fase 3 - Pedidos (4-6 semanas)

- [ ] OrdersController
- [ ] Histórico de pedidos
- [ ] Rastreamento Uber Direct
- [ ] Notificações push

### Fase 4 - Admin (4-6 semanas)

- [ ] Dashboard administrativo
- [ ] Gestão de estoque
- [ ] Relatórios
- [ ] Analytics

---

**🎸 Desenvolvido com Rock'n'Roll pela Rádio Tatuapé FM**

**Data:** 05/11/2024  
**Status:** Estrutura Base Completa ✅  
**Próxima Fase:** Implementação OAuth2 🚀

---

_Marcelo, qualquer dúvida sobre a arquitetura ou próximos passos, consulte o README.md ou entre em contato com a equipe de desenvolvimento._

