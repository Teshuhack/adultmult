using Hangfire;
using System;

namespace AdultMult.Services
{
    public class HangfireJobScheduler
    {
        public static void SchedulerReccuringJobs()
        {
            RecurringJob.RemoveIfExists(nameof(JobService));
            RecurringJob.AddOrUpdate<JobService>(nameof(JobService),
            job => job.Run(JobCancellationToken.Null),
            Cron.Minutely(), TimeZoneInfo.Local);
        }
    }
}
