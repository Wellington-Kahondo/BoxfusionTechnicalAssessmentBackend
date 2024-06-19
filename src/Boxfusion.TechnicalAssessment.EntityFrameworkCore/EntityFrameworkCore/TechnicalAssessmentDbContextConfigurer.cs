using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Boxfusion.TechnicalAssessment.EntityFrameworkCore
{
    public static class TechnicalAssessmentDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TechnicalAssessmentDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TechnicalAssessmentDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
