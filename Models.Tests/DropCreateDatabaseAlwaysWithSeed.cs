using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;

namespace Models.Tests
{
    public class DropCreateDatabaseAlwaysWithSeed : DropCreateDatabaseAlways<MagicContext>
    {
        protected override void Seed(MagicContext context)
        {

        }
    }
}