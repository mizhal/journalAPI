using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Journal2API.Models;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Journal2API.Tests
{
    class JournalInitializerForTesting : DropCreateDatabaseAlways<JournalContext>
    {
        protected override void Seed(JournalContext context)
        {
            base.Seed(context);

            var fixtures_path = @".\Fixtures\all.yml";

            var fixtures = new StreamReader(fixtures_path);

            var deserializer = new Deserializer(namingConvention: new CamelCaseNamingConvention());

            deserializer.Deserialize(fixtures);
        }
    }
}
