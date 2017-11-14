using System;

using Metrics;
using Metrics.InfluxDB;

namespace FsMeetup2.App_Start
{
    public class MetricsConfig
    {
        public static void ConfigureMetrics()
        {
            var metricsConfig = new { Host = "192.168.99.100", DatabaseName = "Demo", UpdateIntervalSec = 3 };

            Metric.Config
                .WithReporting(report =>
                    report.WithInfluxDbHttp(metricsConfig.Host, 8086, metricsConfig.DatabaseName,
                        TimeSpan.FromSeconds(metricsConfig.UpdateIntervalSec)))
                .WithAllCounters();
        }
    }
}