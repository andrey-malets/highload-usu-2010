using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using USU.HighLoad.Storage.StorageDataContract;

namespace DataManagerTests
{
    [TestFixture]
    public class DataManagerTest
    {
        [Test]
        public void CanGenerateSchema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(DataRecord).Assembly);

            new SchemaExport(cfg).Execute(false, true, false);
        }
    }
}
