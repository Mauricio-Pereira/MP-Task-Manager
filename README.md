
# MP Task Manager

Um gerenciador de tarefas simples, desenvolvido em .NET, Blazor WebAssembly e utilizando uma API com suporte a MySQL.

## 📖 Descrição

Este projeto tem como objetivo permitir o gerenciamento de tarefas diárias com funcionalidades como criação, edição, exclusão e exibição de tarefas em formato de lista e calendário semanal. 

O **MP Task Manager** é composto por:

1. **Backend**: API desenvolvida em .NET 8 com suporte a MySQL e MediatR.
2. **Frontend**: Interface feita em Blazor WebAssembly com uma experiência moderna para o usuário.
3. **Banco de Dados**: Persistência utilizando MySQL.

---

## 🚀 Funcionalidades

### 🌟 API
- CRUD de tarefas.
- Suporte à paginação.
- Validação de dados no backend.
- Suporte a datas personalizadas com `CustomDateTimeConverter`.

### 🌟 Blazor Frontend
- Listagem de tarefas em uma interface limpa.
- Visualização de tarefas em um calendário semanal.
- Modal para criar, editar e deletar tarefas.
- Filtros para navegação entre semanas no calendário.
- Seleção de data para visualização específica no calendário.

---

## 🛠️ Tecnologias Utilizadas

### Backend
- **.NET 8**
- **Entity Framework Core** com MySQL
- **MediatR**
- **AutoMapper**
- **Swashbuckle** para documentação Swagger
- **Custom DateTime Converter** para formatos de datas.

### Frontend
- **Blazor WebAssembly**
- **Bootstrap** para estilização.

---

## 📂 Estrutura do Projeto

### Diretórios principais:
- `MPTaskManager.Api`: Backend contendo os serviços, repositórios, DTOs, e configuração do MediatR.
- `MPTaskManager.Web`: Frontend com Blazor WebAssembly e componentes como modais e visualizações.
---

## 📝 Pré-requisitos

Certifique-se de que você tem as seguintes ferramentas instaladas:

- **.NET 8 SDK**
- **Visual Studio 2022** ou **JetBrains Rider**
- **MySQL Server**
- **Postman** (opcional, para testar a API diretamente)

---

## ⚙️ Configuração

1. Clone este repositório:
   ```bash
   git clone https://github.com/Mauricio-Pereira/MP-Task-Manager.git
   cd mp-task-manager
   ```

2. Configure o banco de dados no arquivo `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Port=3306;Database=BlazorTaskManagerDb;User=root;Password=SUA_SENHA;"
   }
   ```
   

3. Execute as migrações para criar o banco de dados:
   ```bash
   dotnet ef database update --project MPTaskManager.Api
   ```

4. Configure a solução para rodar múltiplos projetos (API e Blazor).

5. Execute o projeto:
   ```bash
   dotnet run --project MPTaskManager.Api
   dotnet run --project MPTaskManager.Web
   ```

---

## 🧪 Endpoints da API

### Base URL
`http://localhost:5001`

### Endpoints disponíveis:
- `GET /api/task` - Lista todas as tarefas.
- `GET /api/task/page/{page}` - Lista tarefas com suporte à paginação.
- `GET /api/task/{id}` - Retorna uma tarefa pelo ID.
- `POST /api/task` - Cria uma nova tarefa.
- `PUT /api/task/{id}` - Atualiza uma tarefa existente.
- `DELETE /api/task/{id}` - Exclui uma tarefa.

---

## 💻 Interface Frontend

### Funcionalidades:
1. **Lista de Tarefas**:
    - Exibe todas as tarefas com botões para edição e exclusão.
    - Paginação para navegação entre as tarefas.
2. **Calendário Semanal**:
    - Exibe as tarefas por dia da semana.
    - Navegação entre semanas e seleção de semanas específicas.
    - Visualização de tarefas em formato de cartões com cores diferentes para cada status.
      - **Amarelo**: Tarefa pendente e com prazo válido.
      - **Vermelho**: Tarefa pendente e com prazo expirado.
      - **Verde**: Tarefa concluída.

---

## 📸 Screenshots

### Lista de Tarefas
![Lista_de_Tarefas](Screenshots/lista-tarefas.png)


### Calendário Semanal
![Calendário Semanal](Screenshots/calendario.png)
---

## 🔧 Manutenção e Contribuição

1. Faça um fork do repositório.
2. Crie uma branch para a sua feature:
   ```bash
   git checkout -b minha-feature
   ```
3. Faça as alterações e commit:
   ```bash
   git commit -m "Minha nova feature"
   ```
4. Envie a branch:
   ```bash
   git push origin minha-feature
   ```
5. Abra um Pull Request.

---

## 🛡️ Licença

Este projeto está sob a licença MIT. Consulte o arquivo `LICENSE` para mais informações.

---

## 📧 Contato

**Maurício Pereira**  
[LinkedIn](https://www.linkedin.com/in/mauriciovpereira/) | [Email](mailto:mauricio.pvieira1@gmail.com)
```

Esse arquivo contém informações claras e organizadas para usuários e desenvolvedores interessados no projeto. Você pode personalizar os links e textos conforme necessário.