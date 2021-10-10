using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CoderByte_DALL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInterviewDataContext(
            this IServiceCollection services,
            string connectionString,
            bool isDevelopment)
        {
            return services.AddDbContext<InterviewEntities>(
                options =>
                {
                    options.UseSqlServer(connectionString);
                    if (isDevelopment)
                    {
                        options.ConfigureWarnings(
                            warnings =>
                            {
                                // warnings.Throw(RelationalEventId.QueryClientEvaluationWarning);
                                // This is to block a seemingly spurious warning when comparing enums.
                                // e.g. predicate = predicate.And(job => job.Status >= MinimumStatus);
                                // Where job.Status and MinimumStatus are both enum type `TelemJobStatus`. (See `JobDirectoryFilter.ToExpression`).
                                // The Warning message is ```A SQL parameter or literal was generated for the type '"TelemJobStatus"' using the ValueConverter '"EnumToNumberConverter<TelemJobStatus, int>"'.
                                // Review the generated SQL for correctness and consider evaluating the target expression in-memory instead.```
                                // https://github.com/aspnet/EntityFrameworkCore/issues/12507
                                // warnings.Ignore(RelationalEventId.ValueConversionSqlLiteralWarning);
                            });
                        options.EnableSensitiveDataLogging();
                    }
                });
        }
    }
}
