using Confluent.Kafka;
using Serilog.Events;

namespace SkillAssessor.Common.Logging.Producer;

public sealed class LogProducer : ILogProducer
{
    private readonly IProducer<string, string> _producer;
    
    
    public LogProducer(IProducer<string, string> producer)
    {
        _producer = producer;
    }
    
    
    public void Produce(LogEventLevel level, string correlationId, string message)
    {
        var kafkaMessage = new Message<string, string>
        {
            Key = correlationId,
            Value = message
        };
        
        switch (level)
        {
            case LogEventLevel.Verbose:
                _producer.ProduceAsync(KafkaSinkConfiguration.VerboseTopic, kafkaMessage);
                break;
            case LogEventLevel.Debug:
                _producer.ProduceAsync(KafkaSinkConfiguration.DebugTopic, kafkaMessage);
                break;
            case LogEventLevel.Information:
                _producer.ProduceAsync(KafkaSinkConfiguration.InformationTopic, kafkaMessage);
                break;
            case LogEventLevel.Warning:
                _producer.ProduceAsync(KafkaSinkConfiguration.WarningTopic, kafkaMessage);
                break;
            case LogEventLevel.Error:
                _producer.ProduceAsync(KafkaSinkConfiguration.ErrorTopic, kafkaMessage);
                break;
            case LogEventLevel.Fatal:
                _producer.ProduceAsync(KafkaSinkConfiguration.FatalTopic, kafkaMessage);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(level), 
                    level, "Log level not found");
        }
    }
}