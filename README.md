
<img width="1024" height="250" alt="Biblioteca Pessoal - H" src="https://github.com/user-attachments/assets/8fb01eef-1684-490b-9b54-679be6893769" />


<div align="Center">
  <h1>Sistema de Gerenciamento de Biblioteca Pessoal</h1>
  
  ![Badge em Desenvolvimento](http://img.shields.io/static/v1?label=STATUS&message=EM%20DESENVOLVIMENTO&color=GREEN&style=for-the-badge)

  <img src="https://img.shields.io/badge/.NET-8.0-blue"/>
  <img src="https://img.shields.io/badge/ASP.NET-Framework-blue"/>
  <img src="https://img.shields.io/badge/Entity-Framework-blue"/>
  <img src="https://img.shields.io/badge/Identity-Framework-blue"/>
  
</div>

<ul>
  <li><h3> 📢 O Problema Real: </h3></li>
  <p>
    Ajudar usuários a catalogar os livros que possuem, registrar empréstimos para amigos e manter uma lista de desejos.
  </p>

  <li><h3> 🔨 Funcionalidades Principais: </h3></li>
  
   <ul>
    <li>
      <b>Autenticação:</b> O usuário precisa criar uma conta e fazer login para acessar sua biblioteca pessoal.
    </li>
    <li><b>Páginas (Views):</b></li>
     <!-- _______________________________________________________________________________________________ -->
    <ul>
      <li>Uma página principal (dashboard) que lista todos os livros do usuário logado.</li>
      <li>Um formulário para adicionar um novo livro (título, autor, gênero, etc.).</li>
      <li>Páginas para editar ou excluir um livro.</li>
      <li>Funcionalidade para registrar um empréstimo (para quem emprestou e a data).</li>
    </ul>
     <!-- _______________________________________________________________________________________________ -->
    <li><b>Autorização:</b> Um usuário só pode ver e gerenciar os seus próprios livros. Ele não pode, de forma alguma, acessar a biblioteca de outro usuário.</li>
   </ul>
   <!-- _______________________________________________________________________________________________ -->
   <li><h3>🗃️ Modelagem de Dados (Entity Framework):</h3></li>
   <ul>
     <li><b>Genero:</b> (Id, NomeGenero)</li>
     <li><b>Livro:</b> (Id, Titulo, Autor, CapaUrl, IdGenero, IdUsuario)</li>
     <li><b>Emprestimo:</b> (Id, NomePessoa, DataEmprestimo, DataDevolucao, IdLivro)</li>
     <li>A classe <b>ApplicationUser</b> (do Identity) será relacionada com <b>Livro</b> e possui chave primaria númerica.</li>
   </ul>
</ul>
<!-- _______________________________________________________________________________________________ -->
<hr>

- <h3>👨‍👩‍👧‍👦 Cadastro e Login:</h3>

<p>Todo o sistema de usuários está sendo gerenciado atraves do <b>Intity Framework</b> com customisação do usuário padrão da ferramenta. As páginas destinadas a todo essa processso possuem <b>layout</b> imdependente do restante da aplicação visando a melhor comodida das informações, abaixo segue algumas imagens:</p>

<span>Página de login</span>
<img width="1919" height="865" alt="Captura de tela 2025-10-15 160014" src="https://github.com/user-attachments/assets/408f88a0-4508-414d-89b4-af28f217609f" />

<br/>
<span>Página de cadastro</span>
<img width="1901" height="866" alt="Captura de tela 2025-10-15 160042" src="https://github.com/user-attachments/assets/379167d9-4b8a-4c6c-b7a7-eb51fd284b5d" />

<br/>
<br/>

<span>Página de atualização</span>
<img width="1919" height="871" alt="Captura de tela 2025-10-15 160433" src="https://github.com/user-attachments/assets/c9db8793-7efc-4dc1-a9fc-c57a88bd8a0a" />

<br/>

<span>Página de exclusão</span>
<img width="1919" height="866" alt="Captura de tela 2025-10-15 160451" src="https://github.com/user-attachments/assets/5f0b8e0c-132e-4f86-90a8-2e1cba0ff06e" />

- <h3>📖 Livros:</h3>

<p>O sistema permite realizar o cadastro de todos os livros que o usuário possui tendo a opção de inserir sua capa ou não, nos bastidores essa situação é tratada para que o sistema se comporte da maniera correta em cadasituação.
 Além do cadastro possui todos as opreações de atualização, exclusão e visualização das informações do mesmo, tudo isso é gerenciado pelo <b>Entity Framework</b> com o <b>SqLite</b> por se tratar de um sistema de banco de dados mais simples que atende totalmente a situação atual do projeto.
</p>

<span>Página Inicial</span>
<img width="1903" height="865" alt="Captura de tela 2025-10-16 103522" src="https://github.com/user-attachments/assets/b09abc47-eb86-4888-8a78-cfc56f249f0f" />

<br/>

<span>Cadastrar livro</span>
<img width="1919" height="861" alt="Captura de tela 2025-10-16 103559" src="https://github.com/user-attachments/assets/94c39d7c-68a4-4d43-8a6d-caf183e5ffda" />

<br/>

<span>Detalhes livro</span>
<img width="1919" height="862" alt="Captura de tela 2025-10-16 103616" src="https://github.com/user-attachments/assets/f4d4f15e-0800-4be4-b877-2db547f5748a" />

<br/>

<span>Editar livro</span>
<img width="1919" height="866" alt="Captura de tela 2025-10-16 103641" src="https://github.com/user-attachments/assets/a089cacb-c154-419c-ae7f-de7da49f3d61" />

<br/>

<span>Excluir livro</span>
<img width="1919" height="867" alt="Captura de tela 2025-10-16 103631" src="https://github.com/user-attachments/assets/11900d95-4101-43a9-8863-4680e802bdad" />

<hr/>

## 🤩 Versão mais recente: 1.0
<p> Essa versão foi dedicada para lançar a primeira parte funcionau do projeto sendo relacioanda a todo o registro de livros da biblioteca pessoal.</p>

## 🆕 Próximas features:

- Implementar o registro de impréstimos.
- Tratar erros de preenchimento de cadastro.
- Incluir mensagens para tornar o sistema mais simpático com o usuário.
- Adicionar recuperação de senha.
- Tornar obrigatório a confirmação de e-mail.
- Implementar sistema de redifinição de senha quando usuário estiver logado.

<hr/>

<h3>Guia rápido para configurar e executar o projeto localmente.</h3>

## Requisitos
- .NET SDK 8.x instalado (ex.: 8.0.x)
- (Opcional) SQLite viewer para inspeção do arquivo de banco
- (Opcional) dotnet-ef CLI para gerenciar migrações

## Dependências NuGet (lista exata)
- AutoMapper.Extensions.Microsoft.DependencyInjection — 12.0.1  
- BCrypt.Net-Next — 4.0.3  
- Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore — 8.0.18  
- Microsoft.AspNetCore.Identity.EntityFrameworkCore — 8.0.18  
- Microsoft.AspNetCore.Identity.UI — 8.0.18  
- Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation — 8.0.20  
- Microsoft.EntityFrameworkCore.Sqlite — 8.0.18  
- Microsoft.EntityFrameworkCore.Tools — 8.0.18

## Passos para configurar (Windows PowerShell / CMD)
1. Abra o terminal no diretório do projeto:
```bash
cd "c:\Users\ca22i\OneDrive\Documentos\BibliotecaPessoal"
```

2. Restaurar pacotes:
```bash
dotnet restore
```

3. (Recomendado) Instalar/atualizar dotnet-ef:
```bash
dotnet tool install --global dotnet-ef --version 8.0.18
# ou, se já instalado:
dotnet tool update --global dotnet-ef --version 8.0.18
```

4. Aplicar migrações / criar banco:
- Se já existem migrações:
```bash
dotnet ef database update
```
- Para criar migração inicial e aplicar:
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

5. Executar a aplicação:
```bash
dotnet run
```
A aplicação estará disponível em `https://localhost:5001` ou `http://localhost:5000` (conforme saída do `dotnet run`).

## Comandos úteis para reinstalar pacotes
(se necessário)
```bash
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
dotnet add package BCrypt.Net-Next --version 4.0.3
dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore --version 8.0.18
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 8.0.18
dotnet add package Microsoft.AspNetCore.Identity.UI --version 8.0.18
dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation --version 8.0.20
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.18
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.18
```

## Observações e problemas comuns
- Erro "The view 'Index' was not found": o projeto pode tentar renderizar `Views/Home/Index.cshtml` pela rota padrão. Soluções:
  - Restaurar a view `Views/Home/Index.cshtml`, ou
  - Alterar a rota padrão em `Program.cs`, ou
  - Fazer o controller retornar outro tipo de resultado (ex.: `Content`, `RedirectToAction`, etc.).
- O arquivo `app.db` está configurado para ser copiado para saída — confirme que a connection string aponta para ele se for usá-lo.
- Verifique se segredos sensíveis (credential/connection strings) não foram comitados — use User Secrets em desenvolvimento.
