
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

<p>Todo o sistema de usuários está sendo gerenciado atraves do <b>Intity Framework</b> com customisação do usuário padrão da ferramenta. As páginas destinadas a todo essa processso possuem <b>layout</b> imdependente do restante da aplicação visando a melhor comodida das informações.</p>