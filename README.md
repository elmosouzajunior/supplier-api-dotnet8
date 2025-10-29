# 🧾 Supplier API – CRUD de Fornecedores (.NET 8)

API RESTful desenvolvida em **.NET 8** para gerenciamento de fornecedores, seguindo princípios de **Clean Architecture**.  
O projeto utiliza **Entity Framework Core (SQLite)** para persistência de dados, **AutoMapper** para mapeamento de objetos e **Swagger** para documentação interativa da API.

---

## 🚀 Tecnologias Utilizadas
- **.NET 8 (ASP.NET Core Web API)**
- **Entity Framework Core (SQLite)**
- **AutoMapper**
- **Swagger / Swashbuckle**
- **Dependency Injection (DI)**
- **Clean Architecture (Domain, Application, Infrastructure, Api)**

---

## 📂 Estrutura da Solução

```
SupplierSolution/
 ├── Supplier.Api/                # Camada de apresentação (Controllers, Swagger)
 ├── Supplier.Application/        # Camada de regras de negócio (Services, DTOs, Profiles)
 ├── Supplier.Domain/             # Entidades e interfaces de repositório
 ├── Supplier.Infrastructure/     # Persistência de dados (EF Core, SQLite)
 └── Supplier.Tests/              # Testes unitários (XUnit)
```

---

## ⚙️ Configuração do Projeto

### 🪶 Banco de Dados
O projeto utiliza **SQLite** como banco local.  
O arquivo `suppliers.db` é criado automaticamente ao executar a aplicação pela primeira vez.

---

## ▶️ Como Executar o Projeto

1. **Clone este repositório**
   ```bash
   git clone https://github.com/elmosouza/supplier-api-dotnet8.git
   ```

2. **Abra a solução no Visual Studio 2022 ou superior**

3. **Selecione o projeto `Supplier.Api` como Startup Project**

4. **Execute a aplicação (Ctrl + F5)**

5. **Acesse o Swagger UI:**
   ```
   https://localhost:7178/swagger
   ```

---

## 🧠 Endpoints Principais

| Método | Endpoint | Descrição |
|--------|-----------|------------|
| **GET** | `/api/suppliers` | Retorna todos os fornecedores |
| **GET** | `/api/suppliers/{id}` | Retorna um fornecedor pelo ID |
| **POST** | `/api/suppliers` | Cria um novo fornecedor |
| **PUT** | `/api/suppliers/{id}` | Atualiza um fornecedor existente |
| **DELETE** | `/api/suppliers/{id}` | Remove um fornecedor |

---

## 🧩 Exemplo de Payload (POST /api/suppliers)
```json
{
  "name": "Fornecedor XPTO",
  "taxId": "12345678000199",
  "email": "contato@xpto.com",
  "phone": "11999999999"
}
```

---

## 🗃️ Exemplo de Entidade (Supplier)
```csharp
public class Supplier
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string TaxId { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
```

---

## 🧭 Boas Práticas Adotadas
- Injeção de dependência entre camadas  
- Uso de DTOs e Profiles do AutoMapper  
- Repository Pattern para persistência  
- Criação automática do banco via `Database.Migrate()`  
- Documentação via Swagger  

---

## 🧰 Possíveis Melhorias Futuras
- Implementar autenticação JWT  
- Configurar pipeline CI/CD (GitHub Actions)  
- Publicar API no Azure App Service  

---

## 👨‍💻 Autor
**Elmo Souza**  
📧 [elmosouzajunior@gmail.com](mailto:elmosouzajunior@gmail.com)  
🌐 [linkedin.com/in/elmosouza](https://linkedin.com/in/elmosouza)  
💻 [github.com/elmosouza](https://github.com/elmosouza)

---
