using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;

namespace SkillAssessor.Common.Logging;

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