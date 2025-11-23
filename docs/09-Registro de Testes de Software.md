# 🧪 Registro de Testes de Software – ProtecSys

**Versão do Documento:** `1.1`  
**Data de Elaboração:** `2025-11-23`  
**Sistema:** `ProtecSys — Sistema de Denúncias Corporativas`  
**Testador(a):** `Henrique Alves`

---

# ✔ Matriz de Cobertura – Requisitos Funcionais × Casos de Teste

| RF  | Descrição Resumida | Casos de Teste |
|-----|--------------------|----------------|
| RF-01 | Registrar denúncia (anônima ou identificada) | CT-03 |
| RF-02 | Gerar protocolo único | CT-03 |
| RF-03 | Editar denúncia aberta/em análise | CT-06 |
| RF-04 | Excluir denúncia aberta/em análise | CT-07 |
| RF-05 | Notificar administrador sobre alterações | CT-03, CT-06, CT-07 |
| RF-06 | Acompanhar status da denúncia | CT-05 |
| RF-07 | Administradores visualizam todas as denúncias | CT-05 |
| RF-08 | Localização em tempo real no modo SOS | CT-04 |
| RF-09 | Notificação prioritária ao admin no SOS | CT-04 |
| RF-10 | Cadastro de usuários (nome, e-mail, senha) | CT-01 |
| RF-11 | Autenticação de usuários e admins | CT-02 |
| RF-12 | Logout do sistema | CT-08 |
| RF-13 | Cadastro seguro de administradores | CT-09 |

---

# 📌 CT-01 – Cadastro de Novo Usuário

**ID:** `CT-01`  
**Requisito Associado:** `RF-10` — Cadastro de novos usuários.  
**Objetivo:** Validar criação de conta e regras de validação.

### Pré-condições
- Sistema online.
- E-mail utilizado não deve existir no sistema.

### Passos
1. Acessar `/Usuario/CriarConta`.  
2. Preencher **nome, e-mail e senha**.  
3. Confirmar cadastro.  
4. Verificar redirecionamento.

### Cenários

| Cenário | Entrada | Resultado Esperado |
|--------|---------|--------------------|
| Sucesso | Dados válidos | Usuário criado e redirecionado. |
| Falha – campo vazio | Nome/e-mail/senha faltando | Mensagem de erro. |
| E-mail existente | E-mail já registrado | "E-mail já cadastrado". |

### Critério de Êxito
Usuário criado apenas com dados válidos e únicos.

---

# 📌 CT-02 – Autenticação de Usuário e Administrador

**ID:** `CT-02`  
**Requisito Associado:** `RF-11`  
**Objetivo:** Validar login e perfis diferentes.

### Pré-condições
- Existir usuário e administrador cadastrados.

### Passos
1. Acessar `/Login`.  
2. Informar credenciais.  
3. Clicar em **Entrar**.

### Cenários

| Cenário | Entrada | Resultado Esperado |
|--------|---------|--------------------|
| Login usuário | Credenciais válidas | Redirecionar para `/Denuncia/Index`. |
| Login admin | Credenciais válidas | Redirecionar para `/Admin/Dashboard`. |
| Credenciais inválidas | Dados incorretos | "E-mail ou senha inválidos". |

### Telas (Usuário e Admin)

#### Usuário
<img width="1127" height="712" alt="2" src="https://github.com/user-attachments/assets/3351c0df-268d-49e4-aaf6-c96dfb48d666" />

#### Admin
<img width="1033" height="665" alt="3" src="https://github.com/user-attachments/assets/4adf163b-b329-4255-bb5d-1eb0c41124fa" />

---

# 📌 CT-03 – Registrar Nova Denúncia

**ID:** `CT-03`  
**Requisitos Associados:** `RF-01`, `RF-02`, `RF-05`  
**Objetivo:** Verificar criação completa da denúncia.

### Pré-condições
- Usuário autenticado.

### Passos
1. Acessar `/Denuncia/Create`.  
2. Selecionar tipo de denúncia.  
3. Escolher **anônima** ou **identificada**.  
4. Informar descrição e localização.  
5. Clicar em **Criar Denúncia**.

### Critério de Êxito
- Denúncia criada com status **Aberta**.  
- Protocolo único gerado.  
- Notificação enviada ao admin.  

### Tela
<img width="1483" height="860" alt="4" src="https://github.com/user-attachments/assets/bc27bb8d-eece-4595-ae1b-5a4460d36a29" />

---

# 📌 CT-04 – Ativação do Modo SOS

**ID:** `CT-04`  
**Requisitos Associados:** `RF-08`, `RF-09`  
**Objetivo:** Validar localização em tempo real e alerta prioritário.

### Pré-condições
- Usuário e administrador logados.

### Passos
**Aba do Usuário:**  
1. Acessar `/Denuncia/LocalizacaoEmTempoReal`.  
2. Clicar em **"ATIVAR MODO PERIGO"**.

**Aba do Administrador:**  
3. acessar `/Admin/Dashboard`.  
4. Ver contador inicial (ex.: `0`).  
5. Ver contador após SOS (ex.: `1`).  

### Critério de Êxito
- Admin recebe notificação prioritária.  
- Localização em tempo real exibida.  

### Telas

#### Usuário
<img width="1871" height="846" alt="5" src="https://github.com/user-attachments/assets/968c4636-5058-4b84-a74a-86ca167a71e7" />

#### Admin
<img width="1877" height="803" alt="6" src="https://github.com/user-attachments/assets/01aa2937-778d-4f71-b09d-fa0ae37456b1" />

---

# 📌 CT-05 – Gerenciamento de Status da Denúncia (Admin)

**ID:** `CT-05`  
**Requisitos Associados:** `RF-06`, `RF-07`  
**Objetivo:** Validar acompanhamento e alteração de status.

### Pré-condições
- Admin autenticado.
- Existir denúncia criada.

### Passos
1. Acessar `/Admin/Index`.  
2. Abrir denúncia em **Detalhes**.  
3. Alterar status.  
4. Salvar.

### Critério de Êxito
- Status alterado corretamente.  
- Exibição atualizada no painel.  

### Tela
<img width="1932" height="792" alt="7" src="https://github.com/user-attachments/assets/09652245-d6f5-4520-8167-d5681269d2c6" />

---

# 📌 CT-06 – Editar Denúncia

**ID:** `CT-06`  
**Requisito Associado:** `RF-03`  
**Objetivo:** Validar edição nos status permitidos.

### Pré-condições
- Denúncia **Aberta** ou **Em Análise**.

### Passos
1. Acessar `/Denuncia/Edit/{id}`.  
2. Editar detalhes.  
3. Salvar.

### Critério de Êxito
- Denúncia atualizada corretamente.  
- Notificação ao admin.

---

# 📌 CT-07 – Excluir Denúncia

**ID:** `CT-07`  
**Requisito Associado:** `RF-04`  
**Objetivo:** Validar regras de exclusão.

### Pré-condições
- Denúncia aberta ou em análise.

### Passos
1. Acessar `/Denuncia/Delete/{id}`.  
2. Confirmar exclusão.

### Critério de Êxito
- Denúncia excluída.  
- Admin notificado (RF-05).

---

# 📌 CT-08 – Logout

**ID:** `CT-08`  
**Requisito Associado:** `RF-12`  
**Objetivo:** Validar encerramento de sessão.

### Passos
1. Clicar em **Logout**.  
2. Tentar acessar uma página protegida.

### Resultado Esperado
- Sistema deve impedir acesso após logout.

---

# 📌 CT-09 – Cadastro Seguro de Administradores

**ID:** `CT-09`  
**Requisito Associado:** `RF-13`  
**Objetivo:** Validar cadastro restrito de administradores.


### Passos
1. So pode ser cadastrado pelo membro do suporte da "ProtecSys"

### Resultado Esperado
- Administrador criado com segurança.  

---

# 📄 Histórico de Versões

| Versão | Data | Autor | Descrição |
|--------|-------|--------|-----------|
| 1.0 | 2025-11-23 | Henrique Alves | Versão inicial |
| 1.1 | 2025-11-23 | Henrique Alves | Adaptação aos RFs|

