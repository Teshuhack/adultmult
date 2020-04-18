﻿using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace AdultMult.Services.JobService
{
    public class HangfireDashboardAuthorizationFilter: IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return true;
        }
    }
}
