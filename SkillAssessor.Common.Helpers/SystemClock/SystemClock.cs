namespace SkillAssessor.Common.Helpers.SystemClock;

public class SystemClock : ISystemClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}