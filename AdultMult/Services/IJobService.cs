using System;
using System.Threading.Tasks;

namespace AdultMult.Services
{
    public interface IJobService
    {
        Task RunAtTimeOf(DateTime now);
    }
}
