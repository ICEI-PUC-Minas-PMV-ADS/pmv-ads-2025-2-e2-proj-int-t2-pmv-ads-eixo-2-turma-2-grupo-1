# Registro de Testes de Software

# 🧪 Teste de Software – SistemaDenuncias

## Caso de Teste: **CT01 – Cadastrar Perfil**

### 🧾 Requisito Associado
**RF-001** – A aplicação deve apresentar, na página principal, a funcionalidade de cadastro de usuários para que esses consigam criar e gerenciar seu perfil.

---

### 🎯 Objetivo do Teste
Verificar se o usuário consegue criar uma conta com sucesso no sistema.

---

### 🧭 Passos para Execução
1. Acessar o site do **SistemaDenuncias**.  
2. Clicar no botão **“Não possuo conta”**.  
3. Preencher os campos obrigatórios:
   - Nome  
   - E-mail  
   - CPF  
   - Telefone  
   - Senha  
4. Clicar em **“Cadastrar”**.  
5. Verificar se a conta foi criada e se o usuário é redirecionado para a tela de login.

---

### ✅ Critério de Êxito
A conta deve ser criada com sucesso e o usuário deve visualizar a mensagem de confirmação de cadastro.

---

### 📸 Evidência – Tela de Cadastro
<img width="1792" height="782" alt="01" src="https://github.com/user-attachments/assets/0f840116-88ab-422b-a93a-2beb9523d834" />




---

## Caso de Teste: **CT02 – Login de Usuário**

### 🧾 Requisito Associado
**RF-002** – O sistema deve permitir que usuários cadastrados realizem login informando e-mail e senha válidos.

---

### 🎯 Objetivo do Teste
Verificar se o usuário consegue acessar o sistema utilizando as credenciais cadastradas.

---

### 🧭 Passos para Execução
1. Acessar a página de login.  
2. Inserir o **e-mail** e a **senha** cadastrados.  
3. Clicar em **“Entrar”**.  
4. Observar a resposta do sistema.

---

### ⚠️ Cenários de Validação
| Cenário | Entrada | Resultado Esperado |
|----------|----------|--------------------|
| 1 | Campos vazios | Exibir mensagem: “Informe o e-mail e a senha.” |
| 2 | Senha ausente | Exibir mensagem: “Senha invalida” |
| 3 | Credenciais incorretas | Exibir mensagem: “E-mail ou senha inválidos.” |
| 4 | Credenciais corretas | Acessar o sistema e exibir mensagem de boas-vindas. |

---

### 📸 Evidências – Tela de Login

#### 🔸 Cenário 1 – Campos Vazios
<img width="1821" height="760" alt="02" src="https://github.com/user-attachments/assets/2ef8c4f3-9ac8-4ffd-ab5e-12027cbba929" />


#### 🔸 Cenário 2 – Senha ausente
<img width="1787" height="597" alt="03" src="https://github.com/user-attachments/assets/74f3e892-372b-4975-851c-629e54195f97" />


#### 🔸 Cenário 3 – Credenciais Inválidas
<img width="1827" height="567" alt="04" src="https://github.com/user-attachments/assets/15c655f8-fa34-4059-bad5-64167c2aa968" />


#### 🔸 Cenário 4 – Login Bem-sucedido
<img width="1907" height="462" alt="05" src="https://github.com/user-attachments/assets/921b70a3-1206-49bf-b47b-0b523438f6fe" />


---

### ✅ Critério de Êxito
O usuário deve conseguir acessar o sistema apenas quando as credenciais informadas forem válidas.

---

### 📅 Data de Execução
24/10/2025

### 👨‍💻 Testador
**Henrique Alves Gonçalves**

---

© 2025 - SistemaDenuncias
