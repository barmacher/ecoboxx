using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportsPersistence
{
    public class DbInitializer
    {
        public static void Initialize(ReportsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
