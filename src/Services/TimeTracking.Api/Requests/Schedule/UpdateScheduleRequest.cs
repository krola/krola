namespace Krola.TimeTracking.Api.Requests.Schedule
{
    public class UpdateScheduleRequest
    {
        public string Name { get; set; }

        public bool AllowWithNoTimesheet { get; set; }

        public bool Enabled { get; set; }
    }
}
