using CoderByte_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderByte_DAL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInterviewDataContext(
            this IServiceCollection services,
            string connectionString)
        {
            return services.AddDbContext<InterviewContext>(
                options =>
                {
                    options.UseSqlServer(connectionString);

                });
        }
    }

}
