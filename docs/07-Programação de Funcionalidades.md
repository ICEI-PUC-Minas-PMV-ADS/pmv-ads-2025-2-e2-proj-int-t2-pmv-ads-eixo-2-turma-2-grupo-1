# 🚨 Sistema ProtecSys – Documentação Técnica Completa

---

# 4. Programação de Funcionalidades

## 4.1. Introdução

Esta seção documenta a implementação técnica completa do sistema **ProtecSys**, relacionando cada Requisito Funcional (RF) aos arquivos de código que o implementam.

A arquitetura utiliza:

- ASP.NET Core MVC (C#)  
- Entity Framework Core  
- SQL Server  
- HTML5, CSS3, JavaScript, Bootstrap  
- GitHub para versionamento  

Cada funcionalidade é mapeada diretamente aos artefatos desenvolvidos.

---

## 4.2. Tecnologias Utilizadas

| Tecnologia | Propósito |
|-----------|-----------|
| Microsoft Visual Studio | IDE para desenvolvimento e depuração |
| C# / ASP.NET Core MVC | Backend, APIs e regras de negócio |
| Entity Framework Core | ORM para manipulação do banco SQL Server |
| HTML5 / CSS3 / JavaScript | Estrutura e comportamento das interfaces |
| Bootstrap | Layout responsivo |
| SQL Server | Armazenamento persistente |
| GitHub | Controle de versão e documentação |

---

## 4.3. Mapeamento dos Requisitos Funcionais para Artefatos

| ID | Descrição | Artefatos Produzidos | Responsável |
|----|-----------|----------------------|-------------|
| **RF-01** | Registrar denúncia identificada ou anônima com tipo, descrição e localização | Backend: `DenunciaController.cs` (Create POST), `Denuncia.cs`.<br>Frontend: `Views/Denuncia/Create.cshtml`, `usuario-style.css`. | Henrique Alves |
| **RF-02** | Gerar protocolo único automaticamente | Backend: `GerarProtocolo()` em `DenunciaController.cs`. | Henrique Alves |
| **RF-03** | Alterar denúncia (status aberta/em análise) | Backend: `Edit (GET/POST)` em `DenunciaController.cs`.<br>Frontend: `Views/Denuncia/Edit.cshtml`. | Henrique Alves |
| **RF-04** | Excluir denúncia (status aberta/em análise) | Backend: `Delete (GET)` e `DeleteConfirmed (POST)` em `DenunciaController.cs`.<br>Frontend: `Views/Denuncia/Delete.cshtml`. | Henrique Alves |
| **RF-05** | Notificar administrador ao alterar/incluir/excluir denúncia | Backend: Métodos de notificação no `AdminController.cs`.<br>Frontend: JS no Dashboard administrativo. | Henrique Alves |
| **RF-06** | Acompanhar status da denúncia | Backend: Enum `StatusDenuncia` em `Denuncia.cs`.<br>Frontend: `Views/Denuncia/Index.cshtml`, `Details.cshtml`. | Henrique Alves |
| **RF-07** | Administrador visualiza todas as denúncias | Backend: `AdminController.cs` → `Index`.<br>Frontend: `Views/Admin/Index.cshtml`. | Henrique Alves |
| **RF-08** | Administrador atribui denúncia a um setor | Backend: `AdminController.cs` → `AtualizarStatus`.<br>Frontend: `Views/Admin/GerenciarDenuncia.cshtml` + JS. | Henrique Alves |
| **RF-09** | Ativar modo SOS com localização em tempo real | Backend: `Usuario.cs` (Latitude, Longitude, EmPerigo).<br>Frontend: `LocalizacaoEmTempoReal.cshtml` + JS. | Henrique Alves |
| **RF-10** | Notificação prioritária ao administrador | Backend: `UsuariosEmPerigoCount`, `GetUsuariosEmPerigo` em `AdminController.cs`.<br>Frontend: Dashboard com modal e atualização via JS. | Henrique Alves |
| **RF-11** | Cadastro de usuários | Backend: `UsuarioController.cs` → `Cadastro (POST)`.<br>Frontend: `Views/Usuario/Cadastro.cshtml`. | Henrique Alves |
| **RF-12** | Login de usuários e administradores | Backend: `UsuarioController.cs` e `AdminController.cs` → `Login (POST)`.<br>Frontend: `Views/Usuario/Login.cshtml`, `Views/Admin/Login.cshtml`. | Kerlison Luan |
| **RF-13** | Logout | Backend: `Logout()` em `UsuarioController.cs` e `AdminController.cs`.<br>Frontend: `_UsuarioLayout.cshtml` e `_AdminLayout.cshtml`. | Kerlison Luan |
| **RF-14** | Cadastro seguro de administradores | Backend: `Usuario.cs` → `IsAdmin`.<br>Cadastro via script SQL seguro ou método interno. | Kerlison Luan |

---

## 4.4. Instruções de Acesso e Verificação

### 4.4.1. Link da Aplicação Hospedada  
https://sistema-denuncias-ebabgchra2a3frbe.canadacentral-01.azurewebsites.net/

