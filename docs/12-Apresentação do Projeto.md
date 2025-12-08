
# Apresentação

<span style="color:red">Pré-requisitos: Todos os demais artefatos</span>

## Título do Projeto

PROTECSys

## Identidade Visual (Marca, Design)

### 🎨 Design System & Identidade Visual - PROTECSys

Bem-vindo ao guia de estilo e identidade visual do **PROTECSys**. Este documento serve como referência central para garantir a consistência de design, cores e tipografia em toda a aplicação.

O objetivo visual é manter uma temática sóbria, moderna e profissional, utilizando cores que transmitam segurança e clareza.

---

## 💎 Logotipo

A marca **PROTECSys** é composta por uma tipografia geométrica forte com um destaque de cor na terminação, simbolizando tecnologia e proteção.

| Versão | Descrição |
| :--- | :--- |
| **Principal** | Fundo escuro (`#333333`) com texto em Branco e sufixo em Azul (`#1976D2`). |
| **Monocromática** | Uso em fundos de alta complexidade ou impressões P&B. |

> **Nota:** Mantenha sempre o _padding_ (respiro) ao redor do logotipo, conforme demonstrado nos arquivos de layout.

---

## 🎨 Paleta de Cores

A paleta foi selecionada para oferecer alto contraste em interfaces escuras (Dark Mode) e feedbacks claros ao usuário.

### Cores Primárias e Neutras
Estas são as cores base da estrutura do layout (fundos, textos e marca).

| Amostra | Hex | Cor | Uso Principal |
| :---: | :--- | :--- | :--- |
| ![#1976D2](https://via.placeholder.com/15/1976D2/000000?text=+) | `#1976D2` | **Brand Blue** | Cor primária, botões de ação (CTA), links, destaque do logo. |
| ![#333333](https://via.placeholder.com/15/333333/000000?text=+) | `#333333` | **Dark Grey** | Fundo principal, cards, headers. |
| ![#BCBCBC](https://via.placeholder.com/15/BCBCBC/000000?text=+) | `#BCBCBC` | **Light Grey** | Textos secundários, bordas, ícones inativos. |

### Cores Semânticas (Feedback)
Cores funcionais utilizadas para comunicar estados do sistema ao usuário.

| Amostra | Hex | Cor | Significado |
| :---: | :--- | :--- | :--- |
| ![#388E3C](https://via.placeholder.com/15/388E3C/000000?text=+) | `#388E3C` | **Success Green** | Validações, sucesso, confirmações. |
| ![#FBC02D](https://via.placeholder.com/15/FBC02D/000000?text=+) | `#FBC02D` | **Warning Yellow** | Alertas, atenção, status pendente. |
| ![#D32F2F](https://via.placeholder.com/15/D32F2F/000000?text=+) | `#D32F2F` | **Danger Red** | Erros, falhas, ações destrutivas (excluir). |

---

## 🔤 Tipografia

A hierarquia tipográfica combina fontes geométricas para títulos com fontes funcionais para leitura.

### 1. Títulos e Marca (Display)
**Font Family:** `Lemon Milk`
* **Uso:** Logotipo principal e grandes destaques.
* **Características:** Geométrica, moderna, caixa alta.

### 2. Subtítulos e Destaques
**Font Family:** `Bebas Neue`
* **Uso:** Cabeçalhos de seções, números grandes, cartões de dashboard.
* **Peso:** Regular / Bold.

### 3. Corpo de Texto e UI
**Font Family:** `Roboto`
* **Uso:** Parágrafos, labels de formulários, botões, tabelas.
* **Pesos:**
    * *Light (300)*: Textos grandes ou detalhes sutis.
    * *Regular (400)*: Texto padrão.
    * *Bold (700)*: Ênfase em dados importantes.

---

## 🧩 Iconografia

Utilizamos a biblioteca **FontAwesome** para manter a consistência visual dos ícones.

* **Estilo:** Solid ou Regular (manter consistência).
* **Fonte:** [FontAwesome Official](https://fontawesome.com/)
* **Exemplos de uso:**
    * `<i class="fas fa-user"></i>` para perfil.
    * `<i class="fas fa-shield-alt"></i>` para segurança/proteção.

---

## 💻 Implementação (CSS Variables)

Para agilizar o desenvolvimento, utilize as variáveis CSS abaixo baseadas na paleta aprovada:

```css
:root {
  /* Brand Colors */
  --color-primary: #1976D2;
  --color-background: #333333;
  --color-text-secondary: #BCBCBC;
  --color-text-white: #FFFFFF;

  /* Semantic Colors */
  --color-success: #388E3C;
  --color-warning: #FBC02D;
  --color-danger: #D32F2F;

  /* Fonts */
  --font-display: 'Lemon Milk', sans-serif;
  --font-header: 'Bebas Neue', cursive;
  --font-body: 'Roboto', sans-serif;
}

```

> **Links Úteis**:
> - [10 dicas de design para slides](https://rockcontent.com/blog/design-para-slides/)
> - [7 dicas de design para criar apresentações de PowerPoint incríveis e eficientes](https://www.shutterstock.com/pt/blog/7-dicas-de-design-para-criar-apresentacoes-de-powerpoint-incriveis-e-eficientes)
> - [Especialista do TED dá 10 dicas para criar slides eficazes e bonitos](https://soap.com.br/blog/especialista-do-ted-da-10-dicas-para-criar-slides-eficazes-e-bonitos)

## Conjunto de Slides (Estrutura)

[Slides – PROTECSYS](slides.pdf)

 
> **Links Úteis**:
> - [A regra 10-20-30 para apresentações de sucesso](https://revistapegn.globo.com/Noticias/noticia/2014/07/regra-10-20-30-para-apresentacoes-de-sucesso.html)
> - [Top Tips for Effective Presentations](https://www.skillsyouneed.com/present/presentation-tips.html)
> - [How to make a great presentation](https://www.ted.com/playlists/574/how_to_make_a_great_presentation)
>

## Vídeo de apresentação - Etapa 01



https://github.com/user-attachments/assets/5dd93ab9-f658-4eaf-bb6e-21ab53425c3c



## Vídeo de apresentação - Etapa 05


https://github.com/user-attachments/assets/dd44c29f-9c8a-410a-b33f-6957d5cce5ff



### Orientações para Produção do Vídeo Pitch (Etapa 05)

O vídeo, em formato de _pitch_, deve ter no máximo 3 minutos e apresentar, de forma objetiva e envolvente, o problema identificado, sua relevância e a solução desenvolvida. 
Lembre-se: o objetivo é convencer o público da importância e impacto do seu trabalho.

Para isso, segue uma sugestão de estrutura a ser seguida:
- Comece com uma frase, dado ou situação que prenda a atenção do público.
- Evite apresentações longas de equipe — o foco inicial é gerar interesse.
- Descreva o problema identificado. 
- Mostre, de preferência com números, como o problema afeta pessoas ou organizações no dia a dia.
- Descreva consequências, prejuízos ou dificuldades causadas pela situação atual.
- Reforce a urgência ou relevância de resolvê-lo.
- Resuma muito brevemente a proposta de solução.
- Explique de forma simples como a solução funciona.
- Mostre o diferencial da proposta (o que a torna única ou melhor que alternativas existentes).
- Gaste, pelo menos, 50% do tempo total do vídeo, apresentando uma demonstração da ferramenta desenvolvida, ressaltando suas funcionalidades, como essas funcionalidades atendem ao problema identificado e foque em interações-chave que reforcem o valor da solução para o usuário final.
- Finalize com uma frase de impacto ou um convite à ação (por exemplo: “Com nossa solução, empresas e usuários podem…”).

### Dicas extras 
- Antes de gravar, escreva um roteiro detalhado com falas, tempo estimado e cenas.
- Treine a apresentação para manter ritmo e naturalidade ou utilize alguma ferramenta de IA para a narração.
- Grave em partes se necessário e edite para encaixar no tempo máximo.
- Seja objetivo(a): cada segundo conta.
- Evite termos técnicos excessivos — use linguagem clara e acessível.
- Transmita entusiasmo e confiança no projeto.
