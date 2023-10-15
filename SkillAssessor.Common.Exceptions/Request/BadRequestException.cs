namespace SkillAssessor.Common.Exceptions.Request;

public class BadRequestException : Exception
{
    public BadRequestException() { }
    
    public BadRequestException(string message) : base(message) { }
}