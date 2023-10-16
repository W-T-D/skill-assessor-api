using Serilog.Events;

namespace SkillAssessor.Common.Logging.Producer;

public interface ILogProducer
{
    void Produce(LogEventLevel level, string correlationId, string message);
}