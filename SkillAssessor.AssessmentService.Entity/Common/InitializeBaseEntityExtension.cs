namespace SkillAssessor.AssessmentService.Entity.Common;

public static class InitializeBaseEntityExtension
{
    public static void InitializeEntity(this BaseEntity baseEntity)
    {
        if (string.IsNullOrEmpty(baseEntity.Id))
        {
            baseEntity.Id = Guid.NewGuid().ToString();
        }
    }
}