using Gestor_Libros_EF.Models;

namespace Gestor_Libros_EF.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (context.Books.Any()) return;

            context.Books.AddRange(
                new Book { Title = "Cien años de soledad", Author = "Gabriel García Márquez", Genre = "Realismo mágico", YearPublished = 1967, Description = "La historia de la familia Buendía en el pueblo ficticio de Macondo." },
                new Book { Title = "Don Quijote de la Mancha", Author = "Miguel de Cervantes", Genre = "Novela", YearPublished = 1605, Description = "Las aventuras del hidalgo Alonso Quijano que se cree caballero andante." },
                new Book { Title = "1984", Author = "George Orwell", Genre = "Distopía", YearPublished = 1949, Description = "Una sociedad totalitaria vigilada por el omnipresente Gran Hermano." },
                new Book { Title = "El principito", Author = "Antoine de Saint-Exupéry", Genre = "Fábula", YearPublished = 1943, Description = "Un principito viaja por planetas aprendiendo sobre la vida y el amor." },
                new Book { Title = "Crimen y castigo", Author = "Fiódor Dostoyevski", Genre = "Novela psicológica", YearPublished = 1866, Description = "Un estudiante comete un crimen y lucha con su propia conciencia." }
            );

            context.SaveChanges();
        }
    }
}
