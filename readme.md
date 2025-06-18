# Projeto do Curso: Introdução ao Entity Framework Core

Este repositório contém o projeto de acompanhamento do curso "Introdução ao Entity Framework Core" oferecido pelo [desenvolvedor.io](https://desenvolvedor.io/). O objetivo é explorar os fundamentos do Entity Framework Core em uma aplicação de console, utilizando SQL Server.

**⚠️ AVISO: Este projeto ainda está em desenvolvimento e é um trabalho em progresso, acompanhando as aulas do curso.**

## 🚀 Tecnologias Principais

* **Entity Framework Core:** ORM para interação com o banco de dados.
* **.NET 6:** Plataforma de desenvolvimento.
* **C#:** Linguagem de programação.
* **SQL Server:** Banco de dados relacional.
* **Console Application:** Tipo de aplicação demonstrativa.

## 🌟 Tópicos Abordados (Até o Momento)

O projeto foca nos seguintes conceitos do Entity Framework Core:

* Mapeamento de Entidades
* Operações CRUD (Criar, Ler, Atualizar, Excluir)
* Consultas LINQ
* Migrations para gerenciamento do banco de dados
* Relacionamentos entre entidades
* Configuração do `DbContext`

## ⚙️ Pré-requisitos

Para executar este projeto, você precisará de:

* **.NET SDK 6.0 ou superior**
* **SQL Server** (qualquer versão, como LocalDB)
* **Ferramentas de linha de comando do EF Core:**
    ```bash
    dotnet tool install --global dotnet-ef
    ```

## 🚀 Como Rodar o Projeto

1.  **Clone o Repositório:**
    ```bash
    git clone <URL_DO_SEU_REPOSITORIO>
    cd <NomeDaPastaDoProjeto>
    ```
2.  **Restaure os Pacotes:**
    ```bash
    dotnet restore
    ```
3.  **Ajuste a Connection String:**
    Verifique e ajuste a `ConnectionStrings` no arquivo de configuração (`appsettings.json` ou similar) para apontar para sua instância do SQL Server.
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CursoEFCoreDB;Trusted_Connection=True;MultipleActiveResultSets=true"
    }
    ```
4.  **Aplique as Migrations:**
    Na pasta do projeto principal, execute:
    ```bash
    dotnet ef database update
    ```
5.  **Execute a Aplicação:**
    ```bash
    dotnet run
    ```

## 🔗 Recursos Adicionais

* **Curso Original:** Para aprender mais, acesse o curso "Introdução ao Entity Framework Core" no [desenvolvedor.io](https://desenvolvedor.io/).

---