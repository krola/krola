namespace Krola.TimeTracking.Api.Dto.Schedule
{
    public class UpdateScheduleDto
    {
        public string Name { get; set; }

        public bool AllowWithNoTimesheet { get; set; }

        public bool Enabled { get; set; }
    }
}
