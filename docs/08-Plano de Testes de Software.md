# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

| Caso de Teste | CT01 – Cadastrar Perfil |
|---------------|--------------------------|
| **Requisito Associado** | RF-00X – A aplicação deve apresentar, na página principal, a funcionalidade de cadastro de usuários para que esses consigam criar e gerenciar seu perfil. |
| **Objetivo do Teste** | Verificar se o usuário consegue criar uma conta. |
| **Passos** | - Acessar site <br> - Clicar em "Criar Conta" <br> - Preencher dados obrigatórios <br> - Aceitar termos <br> - Clicar em "Registrar" |
| **Critério de Êxito** | Conta criada com confirmação. |

---

| Caso de Teste | CT02 – Registrar Denúncia Identificada |
|---------------|-----------------------------------------|
| **Requisito Associado** | RF-001 – O sistema deve permitir que usuários autenticados registrem denúncias com descrição e anexos opcionais. |
| **Objetivo do Teste** | Garantir que o usuário autenticado consiga registrar uma denúncia. |
| **Passos** | - Login <br> - Acessar "Registrar Denúncia" <br> - Preencher descrição <br> - Inserir anexos (opcional) <br> - Enviar |
| **Critério de Êxito** | Denúncia registrada com número de protocolo. |

---

| Caso de Teste | CT03 – Inclusão de Localização na Denúncia |
|---------------|---------------------------------------------|
| **Requisito Associado** | RF-002 – O sistema deve permitir que o usuário informe a localização da ocorrência. |
| **Objetivo do Teste** | Confirmar que o usuário consiga informar local da ocorrência. |
| **Passos** | - Login <br> - "Registrar Denúncia" <br> - Informar descrição <br> - Adicionar localização <br> - Enviar |
| **Critério de Êxito** | Denúncia registrada com endereço armazenado corretamente. |

---

| Caso de Teste | CT04 – Preenchimento de Campos Obrigatórios |
|---------------|----------------------------------------------|
| **Requisito Associado** | RF-003 – O sistema deve validar o preenchimento de todos os campos obrigatórios. |
| **Objetivo do Teste** | Verificar se o sistema impede envio de denúncia sem dados essenciais. |
| **Passos** | - Acessar "Registrar Denúncia" <br> - Tentar enviar sem preencher descrição |
| **Critério de Êxito** | Sistema bloqueia envio e exibe alerta sobre campo obrigatório. |

---

| Caso de Teste | CT05 – Consultar Status da Denúncia |
|---------------|--------------------------------------|
| **Requisito Associado** | RF-004 – O sistema deve permitir que o usuário acompanhe suas denúncias. |
| **Objetivo do Teste** | Validar se o usuário consegue acompanhar suas denúncias. |
| **Passos** | - Login <br> - Acessar "Minhas Denúncias" <br> - Selecionar denúncia <br> - Visualizar status |
| **Critério de Êxito** | Status exibido corretamente. |

---

| Caso de Teste | CT06 – Registrar Denúncia Anônima |
|---------------|------------------------------------|
| **Requisito Associado** | RF-005 – O sistema deve permitir denúncias anônimas. |
| **Objetivo do Teste** | Validar o envio de denúncia sem identificação do usuário. |
| **Passos** | - Acessar "Registrar Denúncia" sem login <br> - Preencher descrição <br> - Anexar arquivos (opcional) <br> - Enviar |
| **Critério de Êxito** | Denúncia aceita e protocolo gerado sem vinculação de usuário. |

---

| Caso de Teste | CT07 – Excluir Denúncia Antes da Análise |
|---------------|-------------------------------------------|
| **Requisito Associado** | RF-006 – O sistema deve permitir que o usuário cancele denúncias antes da análise. |
| **Objetivo do Teste** | Garantir que o usuário possa cancelar denúncia antes de ser analisada. |
| **Passos** | - Login <br> - "Minhas Denúncias" <br> - Selecionar denúncia pendente <br> - Cancelar <br> - Confirmar |
| **Critério de Êxito** | Denúncia cancelada e status atualizado para "Cancelada pelo Usuário". |

---

| Caso de Teste | CT08 – Filtrar Denúncias por Status |
|---------------|--------------------------------------|
| **Requisito Associado** | RF-007 – O sistema deve permitir filtros de denúncias por status. |
| **Objetivo do Teste** | Validar que o sistema exiba corretamente denúncias conforme filtros aplicados. |
| **Passos** | - Login administrador <br> - "Painel de Denúncias" <br> - Selecionar filtro (ex: “Em análise”) <br> - Aplicar |
| **Critério de Êxito** | Lista exibida apenas com denúncias do status selecionado. |

---

| Caso de Teste | CT09 – Redefinir Senha por E-mail |
|---------------|------------------------------------|
| **Requisito Associado** | RF-008 – O sistema deve permitir redefinição de senha por e-mail. |
| **Objetivo do Teste** | Verificar se o usuário consegue redefinir senha por e-mail. |
| **Passos** | - Acessar login <br> - Clicar em "Esqueci minha senha" <br> - Informar e-mail <br> - Acessar link recebido <br> - Definir nova senha |
| **Critério de Êxito** | Senha redefinida com sucesso. |

---

| Caso de Teste | CT10 – Denúncia com Palavras Proibidas (Filtro de Conteúdo) |
|---------------|--------------------------------------------------------------|
| **Requisito Associado** | RF-009 – O sistema deve validar e impedir palavras ofensivas/inadequadas. |
| **Objetivo do Teste** | Verificar se o sistema identifica e bloqueia palavras proibidas. |
| **Passos** | - Login <br> - "Registrar Denúncia" <br> - Inserir descrição com palavras proibidas <br> - Enviar |
| **Critério de Êxito** | Sistema rejeita envio e exibe mensagem de alerta. |

