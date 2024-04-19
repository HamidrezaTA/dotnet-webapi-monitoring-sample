using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace api
{
    public class ApiHealthChecker : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {

            //     try
            //     {
            //         // Simulate a database connection check
            //         // Replace this with actual database connection logic
            //         await Task.Delay(1000, cancellationToken); // Simulate a delay

            //         // If the check is successful, return a healthy result
            //         return HealthCheckResult.Healthy("healthy.");
            //     }
            //     catch (Exception ex)
            //     {
            //         // If the check fails, return an unhealthy result
            //         return HealthCheckResult.Unhealthy("Unhealthy", ex);
            //     }
            // }

            return HealthCheckResult.Unhealthy("Unhealthy");
        }
    }
}