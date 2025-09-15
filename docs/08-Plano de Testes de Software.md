# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

### **CT01 – Cadastrar Perfil**
- **Objetivo:** Verificar se o usuário consegue criar uma conta.
- **Passos:**  
  Acessar site → Clicar em "Criar Conta" → Preencher dados → Aceitar termos → Registrar.
- **Critério de Êxito:** Conta criada com confirmação.

---

### **CT02 – Registrar Denúncia Identificada**
- **Objetivo:** Garantir que o usuário autenticado consiga registrar uma denúncia.
- **Passos:**  
  Login → Acessar "Registrar Denúncia" → Preencher descrição → Inserir anexos (opcional) → Enviar.
- **Critério de Êxito:** Denúncia registrada com número de protocolo.

---

### **CT03 – Inclusão de Localização na Denúncia**
- **Objetivo:** Confirmar que o usuário consiga informar local da ocorrência.
- **Passos:**  
  Login → "Registrar Denúncia" → Informar descrição → Adicionar localização → Enviar.
- **Critério de Êxito:** Denúncia registrada com endereço armazenado corretamente.

---

### **CT04 – Preenchimento de Campos Obrigatórios**
- **Objetivo:** Verificar se o sistema impede envio de denúncia sem dados essenciais.
- **Passos:**  
  Acessar "Registrar Denúncia" → Tentar enviar sem preencher descrição.
- **Critério de Êxito:** Sistema bloqueia envio e exibe alerta sobre campo obrigatório.
---

### **CT05 – Consultar Status da Denúncia**
- **Objetivo:** Validar se o usuário consegue acompanhar suas denúncias.
- **Passos:**  
  Login → Acessar "Minhas Denúncias" → Selecionar denúncia → Visualizar status.
- **Critério de Êxito:** Status exibido corretamente
---

### **CT06 – Registrar Denúncia Anônima**
- **Objetivo:** Validar o envio de denúncia sem identificação do usuário.
- **Passos:**  
  Acessar "Registrar Denúncia" sem login → Preencher descrição → Anexar arquivos (opcional) → Enviar.
- **Critério de Êxito:** Denúncia aceita e protocolo gerado sem vinculação de usuário.

---

### **CT07 – Excluir Denúncia Antes da Análise**
- **Objetivo:** Garantir que o usuário possa cancelar denúncia antes de ser analisada.
- **Passos:**  
  Login → "Minhas Denúncias" → Selecionar denúncia pendente → Cancelar → Confirmar.
- **Critério de Êxito:** Denúncia cancelada e status atualizado para "Cancelada pelo Usuário".

---

### **CT08 – Filtrar Denúncias por Status**
- **Objetivo:** Validar que o sistema exiba corretamente denúncias conforme filtros aplicados.
- **Passos:**  
  Login administrador → "Painel de Denúncias" → Selecionar filtro (ex: “Em análise”) → Aplicar.
- **Critério de Êxito:** Lista exibida apenas com denúncias do status selecionado.

---

### **CT09 – Redefinir Senha por E-mail**
- **Objetivo:** Verificar se o usuário consegue redefinir senha por e-mail.
- **Passos:**  
  Login → "Esqueci minha senha" → Informar e-mail → Acessar link → Nova senha.
- **Critério de Êxito:** Senha redefinida com sucesso.

---

### **CT10 – Denúncia com Palavras Proibidas (Filtro de Conteúdo)**
- **Objetivo:** Verificar se o sistema identifica e bloqueia palavras ofensivas/inadequadas.
- **Passos:**  
  Login → "Registrar Denúncia" → Inserir descrição com palavras proibidas → Enviar.
- **Critério de Êxito:** Sistema rejeita envio e exibe mensagem de alerta.

---
