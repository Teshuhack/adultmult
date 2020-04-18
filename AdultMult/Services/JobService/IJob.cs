using System;
using System.Threading.Tasks;

namespace AdultMult.Services
{
    public interface IJob
    {
        Task RunAtTimeOf(DateTime now);
    }
}
