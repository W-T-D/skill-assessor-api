using Amazon.DynamoDBv2.DataModel;

namespace SkillAssessor.AssessmentService.Entity.Assessment;

public sealed class AssessmentHistory
{
    [DynamoDBHashKey]
    public Guid Id { get; set; }

    public Guid AssessorId { get; set; }

    public Guid RequesterId { get; set; }

    public DateTime Date { get; set; }

    public AssessmentStatus Status { get; set; }

    public bool IsRequestApproved { get; set; }

    public Guid SkillLevelId { get; set; }
}