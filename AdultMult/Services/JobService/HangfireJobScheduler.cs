using Hangfire;
using System;

namespace AdultMult.Services
{
    public class HangfireJobScheduler
    {
        public static void SchedulerReccuringJobs()
        {
            RecurringJob.RemoveIfExists(nameof(Job));
            RecurringJob.AddOrUpdate<Job>(nameof(Job),
            job => job.Run(JobCancellationToken.Null),
            Cron.Daily(12, 0), TimeZoneInfo.Local);
        }
    }
}
