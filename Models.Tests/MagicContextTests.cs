using System.Data.Entity;
using NUnit.Framework;

namespace Models.Tests
{
    public class MagicContextTests
    {
        [Test]
        public void CreateDatabase()
        {
            Database.SetInitializer(new DropCreateDatabaseAlwaysWithSeed());
            using (var context = new MagicContext())
            {
                context.Database.Initialize(true);
            }
        }
    }
}
