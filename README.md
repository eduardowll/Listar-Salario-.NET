Projeto Técnico – Estágio Pessoa Desenvolvedora .NET

Este projeto foi desenvolvido como parte do processo seletivo da ESIG Group.
O objetivo é criar uma aplicação ASP.NET Web Forms integrada a um banco de dados SQL Server, para gerenciamento de Pessoa, Cargo e cálculo de salários.

✔️ Funcionalidades Implementadas

Itens Obrigatórios:

•
Listagem de Salários: Na tela principal (Default.aspx), exibe os dados consolidados da tabela pessoa_salario.

•
Botão de Calcular/Recalcular Salários: Executa a Stored Procedure sp_atualizar_pessoa_salario no banco de dados para atualizar os valores.

•
Stored Procedure sp_atualizar_pessoa_salario: Responsável por popular e recalcular a tabela pessoa_salario a partir das tabelas Pessoa e Cargo.

Diferenciais Implementados:

•
Processamento Assíncrono no Botão de Recálculo: Utilização de UpdatePanel e AsyncPostBackTrigger para uma melhor experiência do usuário, evitando o postback completo da página.

•
CRUD de Pessoa:

•
Cadastro de novas pessoas (CadastroPessoa.aspx).

•
Alteração de Cargo via GridView com DropDownList (atualizando salário automaticamente).

•
Exclusão de pessoas diretamente da listagem.



•
Estrutura em Camadas:

•
Models para as entidades.

•
Repository para acesso ao banco de dados (CRUD com SqlConnection / SqlCommand).



💡 Escolhas Tecnológicas e Justificativas

•
Banco de Dados SQL Server Express: A escolha pelo SQL Server Express foi estratégica para o ambiente de desenvolvimento. Dada a necessidade de um banco de dados relacional e a busca por um setup leve, o SQL Express se mostrou ideal, oferecendo as funcionalidades necessárias sem sobrecarregar os recursos do hardware local, especialmente em comparação com alternativas mais robustas como o Oracle.

▶️ Como Rodar Localmente

Pré-requisitos

•
Visual Studio 2022 (com suporte a ASP.NET Web Forms).

•
SQL Server Express (ou outro banco de dados relacional compatível).

•
SQL Server Management Studio (SSMS) (ou outra ferramenta para gerenciar seu banco de dados).

•
.NET Framework 4.7.2 ou superior.

Configuração do Banco de Dados

1.
Crie o Banco de Dados: No SSMS, crie um banco de dados chamado ProjetoESIG.

Configuração do Projeto

1.
No arquivo Web.config do projeto, configure a string de conexão na seção <connectionStrings>:

•
Ajuste o Data Source conforme o nome da sua instância do SQL Server (ex: SEUSERVIDOR\SQLEXPRESS).



Executando a Aplicação

1.
Abra o projeto no Visual Studio 2022.

2.
Compile e rode a aplicação utilizando o IIS Express.

3.
Acesse a aplicação através do endereço http://localhost:[porta]/ (a porta será exibida pelo Visual Studio).

📌 Considerações Finais

Esta estrutura foi pensada para ser simples, clara e fiel ao enunciado da atividade, ao mesmo tempo em que incorpora boas práticas de desenvolvimento e gerenciamento de banco de dados.

▶️ Vídeo de Demonstração

https://youtu.be/_6lAGQ-IXVk

