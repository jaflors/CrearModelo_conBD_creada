# CrearModelo_conBD_creada
Creamos un proyecto con una base de datos ya creada en ASP.NET CORE 3.1


Crear migracion desde la base de datos 
===================================================================================================
Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" 
Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

actualizar modelos cuando cambia la base de datos
=========================================================================
Scaffold-DbContext "Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" 
Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models-force

Agregar Identity a proyecto existente
======================================================================================================
librerias a agregar 
=======================

 package Microsoft.VisualStudio.Web.CodeGeneration.Design
 package Microsoft.EntityFrameworkCore.Design
 package Microsoft.AspNetCore.Identity.EntityFrameworkCore
 package Microsoft.AspNetCore.Identity.UI
 package Microsoft.EntityFrameworkCore.SqlServer
 package Microsoft.EntityFrameworkCore.Tools

Proceso para crear el Identity teniendo una base de datos creada:
Desde el Explorador de soluciones , haga clic con el botón derecho en el proyecto > Agregar > Nuevo elemento con scaffolding .
En el panel izquierdo del cuadro de diálogo Agregar nuevo elemento con scaffolding , seleccione Identidad . Seleccione Identidad en el panel central. Seleccione el botón Agregar .
En el cuadro de diálogo Agregar identidad , seleccione las opciones que desee.
Seleccione su página de diseño existente para que su archivo de diseño no se sobrescriba con un marcado incorrecto. Cuando _Layout.cshtmlse selecciona un archivo existente, no se sobrescribe . Por ejemplo:
~/Pages/Shared/_Layout.cshtmlpara proyectos de Razor Pages o Blazor Server con infraestructura existente de Razor Pages.
~/Views/Shared/_Layout.cshtmlpara proyectos de MVC o proyectos de Blazor Server con infraestructura de MVC existente.
Para usar su contexto de datos existente, seleccione al menos un archivo para anular. Debe seleccionar al menos un archivo para agregar su contexto de datos.
Seleccione su clase de contexto de datos.
Seleccione Agregar .
Para crear un nuevo contexto de usuario y posiblemente crear una clase de usuario personalizada para Identidad:
importante !!
si ya se tiene una clase context que hereda de la clase context modificar a public class DataContex : IdentityDbContext

Seleccione el botón + para crear una nueva clase de contexto de datos . Acepte el valor predeterminado o especifique una clase (por ejemplo, MyApplication.Data.ApplicationDbContext).
Seleccione Agregar .

agregar en el layout  este fragmento de codigo

<partial name="_LoginPartial" />

configurar el starup
agregar en el ConfigureServices el siente codigo 

 services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<especifica nuestra clase context>
            ().AddDefaultTokenProviders();

el la parte de configure agregar

      app.UseAuthentication();

despues de las rutas de los controladores agregar 

 endpoints.MapRazorPages();


