# 📒 API CRUD de Gerenciamento de Contatos

![Badge](https://img.shields.io/badge/.NET-8.0-blueviolet?style=for-the-badge)
![Badge](https://img.shields.io/badge/Entity%20Framework%20Core-8.0-green?style=for-the-badge)
![Badge](https://img.shields.io/badge/SQL%20Server-Database-red?style=for-the-badge)
![Badge](https://img.shields.io/badge/Status-Ativo-success?style=for-the-badge)

API RESTful desenvolvida em **.NET (C#)** para gerenciamento de contatos, seguindo boas práticas como injeção de dependência, Entity Framework Core e Migrations.  
Todos os endpoints podem ser testados via **Swagger**.

---

<img width="500" height="500" alt="Image" src="https://github.com/user-attachments/assets/f3e8d09a-330f-410f-9b31-65ddda0639e5" />

---

## 🚀 Funcionalidades

A API disponibiliza operações CRUD completas:

- **Criar (`POST`)** – adiciona um novo contato  
- **Listar (`GET`)** – retorna todos os contatos ou um contato por ID  
- **Atualizar (`PUT`)** – modifica um contato existente  
- **Excluir (`DELETE`)** – remove um contato  

---

## 🛠️ Tecnologias Utilizadas

- **.NET Core / C#**
- **Entity Framework Core**
- **SQL Server / SQL Express**
- **Swagger (Swashbuckle)**

---

## 🏗️ Arquitetura e Componentes

### 🔹 Entidade — `Contato`
Modelo que representa tanto a tabela no banco quanto os dados trafegados na API.  
Campos previstos:
- `Id`
- `Nome`
- `Telefone`
- `Ativo`

### 🔹 Contexto — `AgendaContext`
- Herda de `DbContext`
- Configura a conexão com o banco
- Contém o `DbSet<Contato>`

### 🔹 Controllers
Recebem o contexto via **injeção de dependência** e expõem endpoints via:
- `POST`
- `GET`
- `PUT`
- `DELETE`

### 🔹 Configuração do Banco
A string de conexão fica em:

appsettings.Development.json

yaml
Copy code

---

## ⚙️ Configuração e Execução

### 1️⃣ Instalar Pacotes Necessários

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-ef
2️⃣ Configurar a String de Conexão
Arquivo: appsettings.Development.json

json
Copy code
{
  "ConnectionStrings": {
    "ConexaoPadrao": "Server=(localdb)\\mssqllocaldb;Database=AgendaDB;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
O nome ConexaoPadrao deve ser o mesmo utilizado no Program.cs.

3️⃣ Criar e Aplicar Migrações
Criar a migration:

bash
Copy code
dotnet ef migrations add CriacaoTabelaContatos
Aplicar ao banco:

bash
Copy code
dotnet ef database update
4️⃣ Executar o Projeto
bash
Copy code
dotnet run
Acesse o Swagger em:

bash
Copy code
http://localhost:5000/swagger
📞 Endpoints
Método	Rota	Descrição
POST	/contatos	Criar novo contato
GET	/contatos	Listar contatos
GET	/contatos/{id}	Buscar contato por ID
PUT	/contatos/{id}	Atualizar contato
DELETE	/contatos/{id}	Excluir contato

📁 Estrutura do Projeto
txt
Copy code
Projeto/
│── Controllers/
│   └── ContatoController.cs
│── Data/
│   └── AgendaContext.cs
│── Models/
│   └── Contato.cs
│── Migrations/
│── appsettings.json
│── appsettings.Development.json
│── Program.cs
└── README.md
📝 Notas Importantes
Criar uma migration não cria a tabela automaticamente — use database update.

Certifique-se de que o projeto está configurado como Startup Project ao rodar comandos do EF Core.

Swagger já vem habilitado no ambiente de desenvolvimento.

🤝 Contribuições
Contribuições são bem-vindas!
Sinta-se à vontade para abrir issues e enviar pull requests.

📜 Licença
Este projeto é distribuído sob a licença MIT.

