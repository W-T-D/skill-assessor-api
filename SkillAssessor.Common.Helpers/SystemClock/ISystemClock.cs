namespace SkillAssessor.Common.Helpers.SystemClock;

public interface ISystemClock
{
    DateTime UtcNow { get; }
}