# Plano de Testes de Usabilidade

## Objetivos

-Verificar se os usuários conseguem registrar e acompanhar denúncias sem dificuldades.
-Identificar barreiras na navegação e interação com o sistema.
-Avaliar a eficiência e satisfação dos usuários com a interface.
-Testar a acessibilidade para diferentes perfis de usuários (cidadão, denunciante anônimo, administrador, analista responsável).
-Coletar insights para aprimorar a experiência do usuário com base em observações reais.

## Métodos de Avaliação

Observação direta: acompanhar o usuário durante a execução das tarefas.

Think Aloud: solicitar que o usuário verbalize seus pensamentos ao interagir com o sistema.

Questionário SUS (System Usability Scale): medir satisfação após os testes.

Análise de tempo de execução: cronometrar o tempo para completar cada tarefa.

Taxa de sucesso: porcentagem de usuários que completaram cada tarefa com sucesso.

Seleção dos Participantes
1. Perfis dos Participantes

Cidadão Identificado
Pessoas que desejam registrar denúncias informando seus dados.
Familiaridade básica com tecnologia.

Denunciante Anônimo
Usuários que desejam enviar denúncia sem se identificar.
Podem ter baixa experiência digital.

Analista/Órgão Responsável
Funcionários que analisam, classificam e dão andamento às denúncias.
Experiência com sistemas administrativos.

Administrador
Responsável pela gestão do sistema (usuários, denúncias, permissões).
Perfil técnico e de moderação.

2. Diversidade de Usuários

Faixa etária variada (jovens, adultos, idosos).

Diferentes níveis de escolaridade.

Diferente grau de familiaridade com tecnologia.

Pelo menos 1 participante com deficiência (visual, auditiva ou motora leve).

3. Quantidade Recomendada

5 a 10 usuários:

3 cidadãos/denunciantes

2 denunciantes anônimos

2 analistas

1 administrador

Ambiente de Teste

Plataforma web (homologação).

Navegadores Google Chrome e Firefox.

Conexão estável de internet.

Pré-requisitos

Disponibilidade para sessão de até 60 minutos.

Assinatura de termo de consentimento (caso haja gravação ou coleta estruturada).

Cenários de Teste
Cenário 1 – Cadastro de Usuário

Objetivo: Avaliar clareza e facilidade no cadastro.

Contexto: Um cidadão deseja se cadastrar para registrar denúncias identificadas.

Tarefa: Realizar cadastro como usuário.

Critério de Sucesso: Mensagem de confirmação exibida e acesso liberado.

Requisito Funcional: RF-001 – Permitir cadastro de usuários. (Alta prioridade)

Cenário 2 – Registro de Denúncia Identificada

Objetivo: Avaliar clareza do formulário e facilidade de envio.

Contexto: Um usuário logado deseja registrar uma denúncia.

Tarefa: Preencher descrição, anexar arquivo e enviar denúncia.

Critério de Sucesso: Sistema gera protocolo e confirma registro.

Requisito Funcional: RF-002 – Permitir registro de denúncias identificadas. (Alta prioridade)

Cenário 3 – Registro de Denúncia Anônima

Objetivo: Validar se o usuário anônimo consegue enviar denúncia sem barreiras.

Contexto: Um cidadão não deseja se identificar.

Tarefa: Acessar opção "Denúncia Anônima" → Preencher descrição → Enviar.

Critério de Sucesso: Denúncia registrada com protocolo anônimo.

Requisito Funcional: RF-003 – Permitir denúncias anônimas. (Alta prioridade)

Cenário 4 – Upload de Anexo

Objetivo: Avaliar facilidade em anexar arquivos (imagem, vídeo, documento).

Contexto: Usuário quer adicionar evidência à denúncia.

Tarefa: Enviar denúncia com foto.

Critério de Sucesso: Arquivo aceito e denúncia registrada.

Requisito Funcional: RF-004 – Permitir anexos em denúncias. (Média prioridade)

Cenário 5 – Consulta de Status

Objetivo: Verificar se o usuário encontra facilmente o status de sua denúncia.

Contexto: Usuário logado deseja acompanhar andamento da denúncia.

Tarefa: Acessar "Minhas Denúncias" e consultar protocolo.

Critério de Sucesso: Status exibido corretamente.

Requisito Funcional: RF-005 – Permitir consulta de denúncias. (Alta prioridade)

Cenário 6 – Recuperar Protocolo Anônimo

Objetivo: Validar se o denunciante anônimo consegue acompanhar sua denúncia.

Contexto: Denunciante anônimo possui apenas número de protocolo.

Tarefa: Acessar "Consultar Denúncia" → Informar protocolo → Verificar status.

Critério de Sucesso: Status exibido corretamente.

Requisito Funcional: RF-006 – Permitir consulta via protocolo. (Média prioridade)

Cenário 7 – Análise de Denúncia (Analista)

Objetivo: Avaliar se o analista consegue processar denúncias com clareza.

Contexto: Analista acessa painel para analisar denúncias.

Tarefa: Acessar denúncia → Registrar análise → Alterar status.

Critério de Sucesso: Denúncia atualizada e salva corretamente.

Requisito Funcional: RF-007 – Permitir análise e resposta. (Alta prioridade)

Cenário 8 – Gestão de Usuários (Administrador)

Objetivo: Avaliar facilidade do administrador em gerenciar usuários.

Contexto: Administrador precisa bloquear um usuário suspeito.

Tarefa: Localizar usuário → Bloquear → Confirmar ação.

Critério de Sucesso: Usuário bloqueado e sem acesso ao sistema.

Requisito Funcional: RF-008 – Permitir gerenciamento de usuários. (Alta prioridade)

Cenário 9 – Logout

Objetivo: Verificar se o logout é simples e seguro.

Contexto: Usuário deseja sair do sistema.

Tarefa: Clicar em "Sair" no menu.

Critério de Sucesso: Sessão encerrada e redirecionamento para login.

Requisito Funcional: RF-009 – Permitir logout seguro. (Média prioridade)

Cenário 10 – Navegação Geral

Objetivo: Avaliar se os usuários encontram facilmente as principais funções.

Contexto: Novo usuário acessa a homepage.

Tarefa: Localizar funcionalidades: registrar denúncia, consultar status, perfil.

Critério de Sucesso: Usuário encontra funções intuitivamente.

Requisito Funcional: RF-010 – Facilitar navegação pela homepage. (Alta prioridade)

Critério de Sucesso Geral

≥ 85% de sucesso nas tarefas de alta prioridade.

≥ 80 pontos de média no SUS.

Nenhuma tarefa crítica com taxa de erro superior a 20%.
