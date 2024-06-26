// Ignore Spelling: App Apps

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Models;

namespace ToDoListApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<TaskApp> TaskApps { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskApp>()
                .Property(t => t.Priority)
                .HasConversion<string>();

            modelBuilder.Entity<TaskApp>()
                .Property(t => t.Status)
                .HasConversion<string>();

                /*
                 1. **`protected override void OnModelCreating(ModelBuilder modelBuilder)`**:
                - This method overrides the `OnModelCreating` method of the `DbContext` class. It is used to further configure the model that was discovered by convention from the entity classes.

                2. **`base.OnModelCreating(modelBuilder)`**:
                - Calls the base class implementation of `OnModelCreating` to ensure any configuration provided by the base class is applied.

                3. **`modelBuilder.Entity<Task>()`**:
                - Configures the `Task` entity.

                4. **`.Property(t => t.Priority)`**:
                - Specifies the configuration for the `Priority` property of the `Task` entity.

                5. **`.HasConversion<string>()`**:
                - Configures the `Priority` property to be stored as a `string` in the database, even if it is defined as an `enum` or another type in the C# code.

                6. **`.Property(t => t.Status)`**:
                - Specifies the configuration for the `Status` property of the `Task` entity.

                7. **`.HasConversion<string>()`**:
                - Configures the `Status` property to be stored as a `string` in the database, even if it is defined as an `enum` or another type in the C# code.

                ### Why Use `.HasConversion<string>()`?

                - **Enums to Strings**: If `Priority` and `Status` are enums in your C# code, using `.HasConversion<string>()` will store their string representations in the database instead of their integer values. This can make the database more readable and easier to understand, as the string values will be more descriptive than numeric values.
  
                - **Type Conversion**: If you have properties that are not naturally stored as strings but you want them to be stored as strings in the database, this method allows you to explicitly define that conversion.

                ### Example Enum

                If you have enums defined for `Priority` and `Status`, like this:

                ```csharp
                public enum Priority
                {
                Low,
                Medium,
                High
                }

                public enum Status
                {
                Pending,
                Completed
                }
                ```

                Using `.HasConversion<string>()` will ensure that the values are stored as "Low", "Medium", "High", "Pending", and "Completed" in the database.

                ### Without `.HasConversion<string>()`

                If you don't use `.HasConversion<string>()`, and `Priority` and `Status` are enums, EF Core would store their integer values by default. For example, `Low` might be stored as `0`, `Medium` as `1`, `Pending` as `0`, and `Completed` as `1`.

                Using `.HasConversion<string>()` enhances the readability and clarity of your data in the database.
            */
        }
    }
}
