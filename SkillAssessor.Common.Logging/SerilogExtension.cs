using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;
using SkillAssessor.Common.Logging.Enrichers;
using SkillAssessor.Common.Logging.Producer;
using ILogger = Serilog.ILogger;

namespace SkillAssessor.Common.Logging;

public static class SerilogExtension
{
    public static IServiceCollection AddSerilog(this IServiceCollection services)
    {
        services.AddSingleton<ILogEventEnricher, CorrelationIdEnricher>();
        services.AddSingleton<ILogEventSink, KafkaSink>();
        services.AddSingleton<ILogProducer, LogProducer>();

        services.AddSingleton<ILogger>(sp =>
        {
            var enricher = sp.GetRequiredService<ILogEventEnricher>();
            var sink = sp.GetRequiredService<ILogEventSink>();

            var config = new LoggerConfiguration()
                .WriteTo.Sink(sink)
                .MinimumLevel.Debug()
                .Enrich.With(enricher);

            return config.CreateLogger();
        });

        return services;
    }
}