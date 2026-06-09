using Gestor_Libros_EF.Models;

namespace Gestor_Libros_EF.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Books.Any()) return;

            context.Books.AddRange(
                new Book { Title = "Clean Code", Author = "Robert C. Martin", Genre = "Programación", YearPublished = 2008, Description = "Principios y buenas prácticas para escribir código limpio, legible y mantenible." },
                new Book { Title = "The Pragmatic Programmer", Author = "Andrew Hunt, David Thomas", Genre = "Ingeniería de Software", YearPublished = 1999, Description = "Consejos prácticos y filosóficos para convertirse en un programador más efectivo." },
                new Book { Title = "Design Patterns", Author = "Gang of Four", Genre = "Arquitectura de Software", YearPublished = 1994, Description = "Catálogo de 23 patrones de diseño reutilizables para problemas comunes en software orientado a objetos." },
                new Book { Title = "The Mythical Man-Month", Author = "Frederick P. Brooks", Genre = "Gestión de Software", YearPublished = 1975, Description = "Ensayos sobre ingeniería de software y los desafíos de gestionar proyectos grandes." },
                new Book { Title = "Introduction to Algorithms", Author = "Cormen, Leiserson, Rivest, Stein", Genre = "Algoritmos", YearPublished = 2009, Description = "Referencia fundamental sobre algoritmos y estructuras de datos con análisis de complejidad." }
            );

            context.SaveChanges();
        }
    }
}
