# Arquitetura da Solução

A arquitetura da solução define como o sistema de denúncias é estruturado, detalhando os componentes principais, interações entre usuários e administradores e o ambiente de hospedagem, garantindo segurança, desempenho e escalabilidade.

## Componentes do Sistema

### Frontend (Interface do Usuário)

- Desenvolvido em HTML, CSS e JavaScript.
- Responsivo, funcionando em desktop e dispositivos móveis.
- Permite aos **usuários**:
  - Cadastrar-se (UC-09)
  - Autenticar-se (UC-10)
  - Registrar denúncias (UC-01)
  - Alterar denúncias (UC-02)
  - Excluir denúncias (UC-03)
  - Acompanhar status (UC-04)
  - Acionar o modo “Estou em Perigo” (UC-06)
- Permite aos **administradores**:
  - Visualizar todas as denúncias (UC-05)
  - Atualizar status (UC-07)
  - Atribuir denúncias (UC-08)

### Backend (Servidor e Lógica de Negócio)

- Desenvolvido em C# com ASP.NET.
- Gerencia autenticação e autorização, processamento de denúncias e integração com o banco de dados.
- Trata notificações em tempo real (UC-N) e fluxo do modo SOS (UC-6.1).
- Garante segurança, confidencialidade e integridade das informações.

### Banco de Dados

- MySQL hospedado no Azure, armazenando dados de usuários, denúncias e status.
- Mantém histórico de denúncias, integridade das informações e suporta consultas do painel administrativo.

### Área Administrativa

- Interface para administradores visualizarem, analisarem e atualizarem denúncias.
- Permite:
  - Alterar status (Aberta, Em análise, Concluída)
  - Atribuir denúncias a setores ou responsáveis
  - Monitorar ocorrências em tempo real

### Módulo de Notificações e Suporte

- Envia alertas sobre novas denúncias, alterações ou exclusões.
- Suporta o modo SOS, enviando localização em tempo real para administradores.
- Disponibiliza orientações jurídicas e psicológicas básicas.

### Sub-rotinas e Casos de Uso Específicos

- **UC-1.1 / UC-1.2:** Seleção de tipo de denúncia, descrição e localização.
- **UC-6.1:** Compartilhamento de localização em tempo real.
- **UC-N:** Notificação de administradores para todos os eventos relevantes (nova denúncia, alteração, exclusão, SOS).

## Ambiente de Hospedagem

- Azure como plataforma de hospedagem web e banco de dados.
- Servidor web seguro com HTTPS para transmissão protegida de dados.
- Banco de dados MySQL no Azure com backups automáticos e escalabilidade.
- Acesso disponível de qualquer dispositivo com internet, garantindo alta disponibilidade e confiabilidade.


## Diagrama de Classes

O diagrama de classes ilustra graficamente como será a estrutura do software, e como cada uma das classes da sua estrutura estarão interligadas. Essas classes servem de modelo para materializar os objetos que executarão na memória.
<img width="772" height="678" alt="image" src="https://github.com/user-attachments/assets/4150dd8d-1f87-4eab-8e19-13bcd31d5e1c" />



## Modelo ER (Projeto Conceitual)

O Modelo ER representa através de um diagrama como as entidades (coisas, objetos) se relacionam entre si na aplicação interativa.

![faculdadexx](https://github.com/user-attachments/assets/e5617a67-e99f-44f3-b380-9f240bebb0d6)




## Projeto da Base de Dados

O projeto da base de dados corresponde à representação das entidades e relacionamentos identificadas no Modelo ER, no formato de tabelas, com colunas e chaves primárias/estrangeiras necessárias para representar corretamente as restrições de integridade.
 
Para mais informações, consulte o microfundamento "Modelagem de Dados".
<img width="665" height="643" alt="diagrama banco de dados" src="https://github.com/user-attachments/assets/7701f367-c0cd-4e64-b35e-934ced0f0a2e" />



## ATENÇÃO!!!

Os três artefatos — **Diagrama de Classes, Modelo ER e Projeto da Base de Dados** — devem ser desenvolvidos de forma sequencial e integrada, garantindo total coerência e compatibilidade entre eles. O diagrama de classes orienta a estrutura e o comportamento do software; o modelo ER traduz essa estrutura para o nível conceitual dos dados; e o projeto da base de dados materializa essas definições no formato físico (tabelas, colunas, chaves e restrições). A construção isolada ou desconexa desses elementos pode gerar inconsistências, dificultar a implementação e comprometer a qualidade do sistema.

## Tecnologias Utilizadas

Descreva aqui qual(is) tecnologias você vai usar para resolver o seu problema, ou seja, implementar a sua solução. Liste todas as tecnologias envolvidas, linguagens a serem utilizadas, serviços web, frameworks, bibliotecas, IDEs de desenvolvimento, e ferramentas.

Apresente também uma figura explicando como as tecnologias estão relacionadas ou como uma interação do usuário com o sistema vai ser conduzida, por onde ela passa até retornar uma resposta ao usuário.

## Hospedagem

Explique como a hospedagem e o lançamento da plataforma foi feita.

> **Links Úteis**:
>
> - [Website com GitHub Pages](https://pages.github.com/)
> - [Programação colaborativa com Repl.it](https://repl.it/)
> - [Getting Started with Heroku](https://devcenter.heroku.com/start)
> - [Publicando Seu Site No Heroku](http://pythonclub.com.br/publicando-seu-hello-world-no-heroku.html)
