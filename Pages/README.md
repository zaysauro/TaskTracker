# 📝 TaskTracker  
Fullstack C# app (ASP.NET Core 7 + SQLite + Razor Pages) with a simple REST API.  

Aplicativo **Fullstack em C#** (ASP.NET Core 7 + SQLite + Razor Pages) com uma API REST simples.  

---

## 🚀 Features | Recursos  
- CRUD de tarefas  
- Filtros (Todas / Pendentes / Concluídas) + busca  
- Contadores por status  
- API REST em `/api/tasks`  
- Banco SQLite local (`tasks.db`)  
- Pronto para rodar em **GitHub Codespaces** e **Replit** (porta 8080)  

---

## 🧠 Run in GitHub Codespaces | Rodando no Codespaces (GitHub)
1. Open the repository → **Code → Codespaces → Create codespace on main**  
2. In the terminal, run:  
   ```bash
   dotnet restore
   dotnet run
   ```
3. Open the URL shown in the terminal.  

---

## 💻 Run in Replit | Rodando no Replit
1. Go to **Create Repl → Import from GitHub** and paste your repo URL.  
2. In the shell, run:  
   ```bash
   dotnet restore
   dotnet run
   ```
3. Click **Open in new tab** to see the app.  

---

## 🌐 API Endpoints  
| Method | Route | Description |  
|:--|:--|:--|  
| **GET** | `/api/tasks` | List all tasks / Lista todas as tarefas |  
| **POST** | `/api/tasks` | Create a new task (`{"title":"Study C#","isDone":false}`) |  
| **DELETE** | `/api/tasks/{id}` | Delete a task by ID / Remove uma tarefa pelo ID |  

---

**Port 8080 is automatically set in `Program.cs`.**  
A porta 8080 é configurada automaticamente em `Program.cs`.  
