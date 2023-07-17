# Sistema de Agendamento API

Projeto realizado com o intuito de criar uma API simples para agendamento de consultas.

 <p align="center">
<img src="https://img.shields.io/static/v1?label=STATUS&message=%20FINISH&color=RED&style=for-the-badge"/>
</p>

---

## 🖨️ Como clonar o projeto:

```
  # Clone o repositório
  git clone https://github.com/Leonnardo21/sistema-agendamento-api.git
```

---

## Configuração

### Acesso a banco de dados

<p>No arquivo ConnectHealthContext.cs encontrado na pasta Data você deve configurar os seguintes parâmetros:</p>
<b>Server</b> - Onde irá colocar o servidor em que o banco está hospedado. <br/>
<b>Database</b> - Onde qual será o nome do banco de dados a ser utilizado. <br/>
<b>User ID</b> - Qual o usuário estará acessando o banco. <br/>
<b>Password</b> - Senha de acesso ao banco de dados.

```
options.UseSqlServer("Server=<Server>;Database=<Database>;User ID=sa;Password=<Password>;TrustServerCertificate=true")
```

---

## Rotas

<p>Rotas da classe Usuário</p>

<b>GET</b> - "v1/users"
<b>GET BY ID</b> - "v1/users/{id:int}"
<b>POST</b> - "v1/users"
<b>UPDATE</b> - "v1/users/{id:int}"
<b>DELETE</b> - "v1/users/{id:int}"

<p>Rotas da classe Profissional</p>

<b>GET</b> - "v1/professional"
<b>GET BY ID</b> - "v1/professional/{id:int}"
<b>POST</b> - "v1/professional"
<b>UPDATE</b> - "v1/professional/{id:int}"
<b>DELETE</b> - "v1/professional/{id:int}"

<p>Rotas da classe Agendamento</p>

<b>GET</b> - "v1/scheduling"
<b>GET BY ID</b> - "v1/scheduling/{id:int}"
<b>POST</b> - "v1/scheduling"
<b>UPDATE</b> - "v1/scheduling/{id:int}"
<b>DELETE</b> - "v1/scheduling/{id:int}"

---

## ☑️ Tecnologias:

- [C#](https://dotnet.microsoft.com/en-us/download)
- [Entity Framework](https://www.nuget.org/packages/EntityFramework/)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

## Pacotes Utilizados

<p>OBS: Para instalação dos pacotes, utilizar o comando: </p>
```
dotnet restore
```

- [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/EntityFramework/)
- [Microsoft.EntityFrameworkCore.Design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/7.0.5)
- [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/7.0.5)

---

## ⚠️ Licença:

Esse projeto está sob a [licença MIT](https://github.com/Leonnardo21/sistema-agendamento-api/LICENSE).

---
