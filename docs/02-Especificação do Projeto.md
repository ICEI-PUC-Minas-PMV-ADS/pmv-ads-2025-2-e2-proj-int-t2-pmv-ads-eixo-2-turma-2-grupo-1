# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Personas
<img width="672" height="505" alt="persona 1" src="https://github.com/user-attachments/assets/4f138aa3-ba7c-4c40-8c20-4bccd50f2b2f" />
<img width="672" height="505" alt="persona 2" src="https://github.com/user-attachments/assets/f08b98ae-0d57-435f-b3ed-7d812c1e784e" />
<img width="672" height="505" alt="persona 3" src="https://github.com/user-attachments/assets/fcb4e12b-7ded-46d9-a55c-9bf80c919f47" />
<img width="672" height="505" alt="persona 4" src="https://github.com/user-attachments/assets/6be5878b-8136-4e85-867a-9e250f1d18e4" />
<img width="672" height="505" alt="persona 5" src="https://github.com/user-attachments/assets/131e0dcf-73f2-4bd7-9627-4f2b21ddf42c" />



## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA`| QUERO/PRECISO ... `FUNCIONALIDADE` |PARA ... `MOTIVO/VALOR`                 |
|--------------------|------------------------------------|----------------------------------------|
|Atendente de call center  | Quero registrar denúncias de assédio moral | Para garantir que minhas queixas sejam analisadas sem represálias |
|Atendente de call center | Quero receber uma notificação de confirmação ao registrar minha denúncia | Para ter segurança de que foi recebida pelo sistema |
|Estudante universitário | Quero registrar denúncias de violência de forma anônima | Para proteger minha identidade |
|Estudante universitário | Quero acompanhar o status da minha denúncia | Para saber se está sendo analisada ou concluída |
|Professora | Quero registrar denúncias de violência doméstica envolvendo alunos | Para que sejam tomadas medidas de proteção |
|Professora | Quero receber orientação no sistema sobre como formalizar denúncias | Para para que meus relatos tenham validade legal |
|Motorista de Ônibus | Quero registrar denúncias sobre más condições de segurança nos veículos | Para proteger passageiros e colegas de trabalho |
|Motorista de Ônibus | Quero acompanhar o status da minha denúncia | Para verificar se as melhorias estão sendo implementadas |
|Administrador do Sistema | Quero visualizar todas as denúncias registradas | Para analisar e priorizar as que exigem ação imediata |
|Administrador do Sistema | Quero atribuir denúncias aos setores responsáveis | Para garantir que sejam resolvidas corretamente |
|Administrador do Sistema | Quero atualizar o status das denúncias (em análise, concluída) | Para manter os usuários informados sobre o andamento |



> **Links Úteis**:
> - [Histórias de usuários com exemplos e template](https://www.atlassian.com/br/agile/project-management/user-stories)
> - [Como escrever boas histórias de usuário (User Stories)](https://medium.com/vertice/como-escrever-boas-users-stories-hist%C3%B3rias-de-usu%C3%A1rios-b29c75043fac)
> - [User Stories: requisitos que humanos entendem](https://www.luiztools.com.br/post/user-stories-descricao-de-requisitos-que-humanos-entendem/)
> - [Histórias de Usuários: mais exemplos](https://www.reqview.com/doc/user-stories-example.html)
> - [9 Common User Story Mistakes](https://airfocus.com/blog/user-story-mistakes/)

## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais
| ID    | Descrição do Requisito                                                                                                        | Prioridade |
| ----- | ----------------------------------------------------------------------------------------------------------------------------- | ---------- |
| RF-01 | O sistema deve permitir que o usuário registre uma denúncia de forma anônima ou identificada, selecione o tipo de denúncia (produto, serviço, violência, estabelecimento, etc.).  forneça uma descrição detalhada e a localização da denúncia. | Alta       |
| RF-02 | O sistema deve gerar automaticamente um número de protocolo único para cada denúncia registrada.                              | Média      |
| RF-03 | O sistema deve permitir que o usuário altere uma denúncia já registrada, desde que esteja em status "aberta" ou "em análise". | Alta       |
| RF-04 | O sistema deve permitir que o usuário exclua uma denúncia registrada, desde que esteja em status "aberta" ou "em análise".    | Média      |
| RF-05 | O sistema deve notificar o administrador caso haja alteração, inclusão ou exclusão de denúncia.                               | Alta       |
| RF-06 | O sistema deve permitir que o usuário acompanhe o status da denúncia (aberta, em análise, concluída).                         | Média      |
| RF-07 | O sistema deve permitir que administradores visualizem todas as denúncias cadastradas.                                        | Média      |
| RF-08 | O administrador deve poder atribuir a denúncia a um setor responsável para análise ou resolução.                              | Alta       |
| RF-09 | O sistema deve permitir que o usuário ative o compartilhamento da sua localização em tempo real durante o modo SOS.           | Alta       |
| RF-10 | O sistema deve notificar ao administrador com prioridade quando acionar o modo “SOS”.                                         | Alta       |
| RF-11 | O sistema deve permitir que novos usuários se cadastrem fornecendo nome, e-mail e senha.                                      | Alta       |
| RF-12 | O sistema deve permitir a autenticação (login) de usuários e administradores através de e-mail e senha.                       | Alta       |
| RF-13 | O sistema deve permitir que um usuário autenticado encerre sua sessão (logout).                                               | Média      |
| RF-14 | O sistema deve possuir um método seguro para o cadastro de novos administradores (não público).                               | Alta       |


### Requisitos não Funcionais

| ID     | Descrição                                                            | Prioridade |
| ------ | -------------------------------------------------------------------- | ---------- |
| RNF-01 | O sistema deve ser desenvolvido usando: HTML, CSS, C# e SQL          | Média      |
| RNF-02 | O sistema deve ser responsivo a telas menores                        | Alta       |
| RNF-03 | O sistema deve estar disponível via servidor online                  | Média      |
| RNF-04 | O sistema deve ter todos os dados criptografados e seguros           | Alta       |
| RNF-05 | O sistema deve estabelecer protocolos HTTPS                          | Alta       |
| RNF-06 | O sistema deve ter disponibilidade 24 horas durante 7 dias da semana | Alta       |



## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |


Enumere as restrições à sua solução. Lembre-se de que as restrições geralmente limitam a solução candidata.

> **Links Úteis**:
> - [O que são Requisitos Funcionais e Requisitos Não Funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [O que são requisitos funcionais e requisitos não funcionais?](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)

## Diagrama de Casos de Uso


<img width="886" height="763" alt="image" src="https://github.com/user-attachments/assets/c0d94d85-4c62-4752-b506-51de7274c872" />




O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

As referências abaixo irão auxiliá-lo na geração do artefato “Diagrama de Casos de Uso”.

> **Links Úteis**:
> - [Criando Casos de Uso](https://www.ibm.com/docs/pt-br/elm/6.0?topic=requirements-creating-use-cases)
> - [Como Criar Diagrama de Caso de Uso: Tutorial Passo a Passo](https://gitmind.com/pt/fazer-diagrama-de-caso-uso.html/)
> - [Lucidchart](https://www.lucidchart.com/)
> - [Astah](https://astah.net/)
> - [Diagrams](https://app.diagrams.net/)
