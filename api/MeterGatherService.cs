using System.Diagnostics.Metrics;

namespace api
{
    public interface IMeterGatherService
    {
        void UserCreated();
    }

    public class MeterGatherService : IMeterGatherService
    {
        private readonly Counter<int> userCreationCount;
        public MeterGatherService(IMeterFactory meterFactory)
        {
            var meter = meterFactory.Create("api.project");
            userCreationCount = meter.CreateCounter<int>("user.creation");
        }

        public void UserCreated()
        {
            userCreationCount.Add(1);
        }
    }
}