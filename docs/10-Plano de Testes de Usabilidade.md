# Plano de Testes de Usabilidade

##  Objetivos
- Verificar se os usuários conseguem registrar e acompanhar denúncias sem dificuldades.  
- Identificar barreiras na navegação e interação com o sistema.  
- Avaliar a eficiência e a satisfação do usuário ao utilizar a interface.  
- Testar a acessibilidade para diferentes perfis de usuários (cidadão, órgão público, policial e administrador).  
- Coletar insights para aprimorar a experiência do usuário com base em observações reais.  

---

##  Métodos de Avaliação
- **Observação direta**: Acompanhar o usuário durante a execução das tarefas.  
- **Think Aloud**: Solicitar que o usuário verbalize seus pensamentos enquanto realiza as ações.  
- **Questionário SUS (System Usability Scale)**: Para medir a satisfação após os testes.  
- **Análise de tempo de execução**: Cronometrar o tempo para completar cada tarefa.  
- **Taxa de sucesso**: Porcentagem de usuários que completaram cada tarefa com sucesso.  

---

##  Seleção dos Participantes

### 1. Perfil dos Participantes
- **Cidadão Denunciante**  
  Pessoa comum que deseja registrar uma denúncia.  
  Familiaridade básica com tecnologia.  

- **Órgão Público**  
  Representante de entidades de fiscalização ou assistência.  
  Experiência com gestão de processos administrativos é desejável.  

- **Policial**  
  Responsável por analisar e acompanhar denúncias criminais.  
  Nível intermediário com uso de sistemas corporativos.  

- **Administrador**  
  Membro da equipe que gerencia a plataforma, com foco em segurança e manutenção.  
  Experiência com sistemas de gestão e suporte.  

### 2. Diversidade de Usuários
- Faixa etária (jovens, adultos e idosos).  
- Grau de instrução (fundamental ao superior).  
- Familiaridade com tecnologia (novatos a experientes).  
- Acessibilidade (ao menos 1 participante com deficiência visual, auditiva ou motora leve).  

### 3. Quantidade Recomendada
- **Total**: 5 a 10 usuários  
  - 3 cidadãos denunciantes  
  - 2 representantes de órgãos públicos  
  - 2 policiais  
  - 1 administrador  

---

##  Ambiente de Teste
- Plataforma web em ambiente de homologação  
- Navegadores: Google Chrome e Firefox  
- Conexão estável de internet  

---

##  Pré-requisitos
- Disponibilidade para participar de uma sessão de até 60 minutos.  
- Assinatura de termo de consentimento (em caso de gravação ou coleta de feedback estruturado).  

---

##  Cenários de Testes

### Cenário 1 – Cadastro de Usuário
- **Objetivo**: Avaliar a clareza e facilidade do processo de cadastro.  
- **Contexto**: Um cidadão deseja utilizar a plataforma para registrar denúncias.  
- **Tarefa**: Realizar o cadastro como cidadão, policial, órgão público ou administrador.  
- **Critério de sucesso**: O sistema confirma o cadastro e direciona ao painel inicial.  
- **Requisito Funcional**: RF-001 - Permitir que todos os perfis se cadastrem no sistema (**Alta**).  

---

### Cenário 2 – Registro de Denúncia
- **Objetivo**: Avaliar a clareza do formulário e a facilidade de registrar uma denúncia.  
- **Contexto**: Um cidadão deseja denunciar uma irregularidade.  
- **Tarefa**: Preencher título, descrição, localização e anexar uma foto.  
- **Critério de sucesso**: A denúncia aparece no painel do usuário.  
- **Requisito Funcional**: RF-002 - Permitir registro de denúncias com anexos (**Alta**).  

---

### Cenário 3 – Acompanhamento de Denúncia
- **Objetivo**: Verificar se o cidadão entende o fluxo de acompanhamento.  
- **Contexto**: Um usuário deseja verificar o status da denúncia já registrada.  
- **Tarefa**: Acessar o histórico e visualizar o andamento da denúncia.  
- **Critério de sucesso**: O status é exibido claramente (ex: em análise, encaminhada, concluída).  
- **Requisito Funcional**: RF-003 - Permitir acompanhamento de denúncias (**Alta**).  

---

### Cenário 4 – Edição e Cancelamento de Denúncia
- **Objetivo**: Avaliar a usabilidade para editar ou cancelar uma denúncia.  
- **Contexto**: O cidadão percebeu erro ou desistiu da denúncia.  
- **Tarefa**: Editar os detalhes da denúncia ou cancelá-la.  
- **Critério de sucesso**: O sistema confirma a ação e atualiza o status.  
- **Requisito Funcional**: RF-004 - Permitir edição e cancelamento (**Média**).  

---

### Cenário 5 – Pesquisa de Denúncias (Órgão Público)
- **Objetivo**: Avaliar se os órgãos encontram denúncias relevantes.  
- **Contexto**: Um órgão público deseja localizar denúncias relacionadas à sua área.  
- **Tarefa**: Pesquisar por localização, tipo de denúncia ou palavra-chave.  
- **Critério de sucesso**: A busca retorna resultados relevantes.  
- **Requisito Funcional**: RF-005 - Permitir busca e filtro avançado (**Alta**).  

---

### Cenário 6 – Análise de Denúncia (Policial)
- **Objetivo**: Avaliar se policiais conseguem analisar denúncias com clareza.  
- **Contexto**: Um policial precisa validar uma denúncia e atualizar seu status.  
- **Tarefa**: Acessar uma denúncia, revisar informações e alterar o status.  
- **Critério de sucesso**: O sistema atualiza o status com feedback visual.  
- **Requisito Funcional**: RF-006 - Permitir análise e atualização de denúncias (**Alta**).  

---

### Cenário 7 – Notificações
- **Objetivo**: Avaliar se usuários entendem as notificações recebidas.  
- **Contexto**: O cidadão recebe atualização sobre sua denúncia.  
- **Tarefa**: Ler e interpretar a notificação recebida.  
- **Critério de sucesso**: O usuário identifica corretamente a mudança de status.  
- **Requisito Funcional**: RF-007 - Enviar notificações automáticas (**Alta**).  

---

### Cenário 8 – Gestão de Usuários (Administrador)
- **Objetivo**: Avaliar se o administrador consegue moderar o sistema.  
- **Contexto**: Um administrador precisa bloquear ou excluir usuários suspeitos.  
- **Tarefa**: Localizar um usuário e aplicar a ação.  
- **Critério de sucesso**: O sistema confirma a exclusão/bloqueio e remove o acesso.  
- **Requisito Funcional**: RF-008 - Permitir gerenciamento de usuários (**Alta**).  

---

### Cenário 9 – Logout
- **Objetivo**: Avaliar a clareza e facilidade para fazer logout.  
- **Contexto**: Um usuário deseja encerrar a sessão por segurança.  
- **Tarefa**: Localizar a opção de logout e sair do sistema.  
- **Critério de sucesso**: O usuário é desconectado e redirecionado à tela de login.  
- **Requisito Funcional**: RF-009 - Permitir logout seguro (**Média**).  

---

### Cenário 10 – Navegação e Homepage
- **Objetivo**: Avaliar a clareza da navegação pela página inicial.  
- **Contexto**: O usuário acessa a plataforma pela primeira vez.  
- **Tarefa**: Localizar as principais funcionalidades (denúncias, perfil, histórico).  
- **Critério de sucesso**: O usuário encontra facilmente as seções desejadas.  
- **Requisito Funcional**: RF-010 - Navegação intuitiva pela homepage (**Alta**).  

---

## 📊 Critérios de Sucesso
- ≥ 85% de sucesso nas tarefas de alta prioridade.  
- ≥ 80 pontos na média geral do questionário SUS.  
- Nenhuma tarefa crítica com taxa de erro superior a 20%.  
