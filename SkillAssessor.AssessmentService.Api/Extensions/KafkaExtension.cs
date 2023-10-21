using Confluent.Kafka;

namespace SkillAssessor.AssessmentService.Api.Extensions;

public static class KafkaExtension
{
    public static IServiceCollection AddKafka(this IServiceCollection services)
    {
        services.AddKafkaClient().Configure(options =>
        {
            options.Configure(new ProducerConfig
            {
                StatisticsIntervalMs = 500
            });
        });

        return services;
    }
}