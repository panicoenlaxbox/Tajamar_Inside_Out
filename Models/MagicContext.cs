using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Models
{
    public class MagicContext : DbContext
    {
        public MagicContext() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Magic;Integrated Security=SSPI;MultipleActiveResultSets=True;Application Name=Magic")
        {
            Database.SetInitializer(new MagicDatabaseInitializer());
        }

        public DbSet<Card> Cards { get; set; }

        public override int SaveChanges()
        {
            var objectContext = ((IObjectContextAdapter)this).ObjectContext;
            var entries = objectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified);

            foreach (var entry in entries)
            {
                var currentValues = entry.CurrentValues;
                var fieldMetadata = currentValues.DataRecordInfo.FieldMetadata;
                var fields = fieldMetadata.Where(f => f.FieldType.TypeUsage.EdmType.Name == "String");
                foreach (var field in fields)
                {
                    var ordinal = field.Ordinal;
                    var currentValue = currentValues[ordinal] as string;
                    if (currentValue != null && currentValue.All(char.IsWhiteSpace))
                    {
                        currentValues.SetValue(ordinal, null);
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}