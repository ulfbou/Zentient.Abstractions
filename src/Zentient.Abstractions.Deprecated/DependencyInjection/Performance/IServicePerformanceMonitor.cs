// <copyright file="IServicePerformanceMonitor.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.DependencyInjection.Registration;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.DependencyInjection.Performance
{
    /// <summary>
    /// Provides performance monitoring and optimization capabilities for dependency injection operations.
    /// </summary>
    public interface IServicePerformanceMonitor
    {
        /// <summary>
        /// Gets performance metrics for the current session.
        /// </summary>
        IServicePerformanceMetrics Metrics { get; }

        /// <summary>
        /// Starts tracking a service resolution operation.
        /// </summary>
        /// <param name="serviceType">The type of service being resolved.</param>
        /// <param name="descriptor">The service descriptor being used.</param>
        /// <returns>A tracking context for the resolution operation.</returns>
        IResolutionTrackingContext StartResolution(Type serviceType, IServiceDescriptor descriptor);

        /// <summary>
        /// Records a successful service resolution.
        /// </summary>
        /// <param name="context">The tracking context for the resolution.</param>
        /// <param name="instance">The resolved service instance.</param>
        /// <param name="wasCached">Whether the instance was retrieved from cache.</param>
        void RecordResolutionSuccess(IResolutionTrackingContext context, object instance, bool wasCached);

        /// <summary>
        /// Records a failed service resolution.
        /// </summary>
        /// <param name="context">The tracking context for the resolution.</param>
        /// <param name="exception">The exception that caused the failure.</param>
        void RecordResolutionFailure(IResolutionTrackingContext context, Exception exception);

        /// <summary>
        /// Records a service registration operation.
        /// </summary>
        /// <param name="descriptor">The service descriptor that was registered.</param>
        /// <param name="registrationTime">The time taken to register the service.</param>
        void RecordRegistration(IServiceDescriptor descriptor, TimeSpan registrationTime);

        /// <summary>
        /// Gets performance recommendations based on collected metrics.
        /// </summary>
        /// <returns>A collection of performance optimization recommendations.</returns>
        IReadOnlyCollection<IPerformanceRecommendation> GetRecommendations();

        /// <summary>
        /// Resets all performance metrics and starts fresh tracking.
        /// </summary>
        void Reset();

        /// <summary>
        /// Creates a performance report for the specified time period.
        /// </summary>
        /// <param name="startTime">The start time for the report period.</param>
        /// <param name="endTime">The end time for the report period.</param>
        /// <returns>A performance report for the specified period.</returns>
        IPerformanceReport CreateReport(DateTimeOffset startTime, DateTimeOffset endTime);
    }

    /// <summary>
    /// Represents performance metrics for dependency injection operations.
    /// </summary>
    public interface IServicePerformanceMetrics
    {
        /// <summary>
        /// Gets the total number of service resolutions performed.
        /// </summary>
        long TotalResolutions { get; }

        /// <summary>
        /// Gets the number of successful service resolutions.
        /// </summary>
        long SuccessfulResolutions { get; }

        /// <summary>
        /// Gets the number of failed service resolutions.
        /// </summary>
        long FailedResolutions { get; }

        /// <summary>
        /// Gets the total number of cached resolutions.
        /// </summary>
        long CachedResolutions { get; }

        /// <summary>
        /// Gets the average resolution time across all resolutions.
        /// </summary>
        TimeSpan AverageResolutionTime { get; }

        /// <summary>
        /// Gets the median resolution time.
        /// </summary>
        TimeSpan MedianResolutionTime { get; }

        /// <summary>
        /// Gets the 95th percentile resolution time.
        /// </summary>
        TimeSpan P95ResolutionTime { get; }

        /// <summary>
        /// Gets the 99th percentile resolution time.
        /// </summary>
        TimeSpan P99ResolutionTime { get; }

        /// <summary>
        /// Gets the fastest resolution time recorded.
        /// </summary>
        TimeSpan FastestResolutionTime { get; }

        /// <summary>
        /// Gets the slowest resolution time recorded.
        /// </summary>
        TimeSpan SlowestResolutionTime { get; }

        /// <summary>
        /// Gets the cache hit ratio as a percentage.
        /// </summary>
        double CacheHitRatio { get; }

        /// <summary>
        /// Gets performance metrics grouped by service type.
        /// </summary>
        IReadOnlyDictionary<Type, IServiceTypeMetrics> MetricsByServiceType { get; }

        /// <summary>
        /// Gets performance metrics grouped by service lifetime.
        /// </summary>
        IReadOnlyDictionary<ServiceLifetime, IServiceLifetimeMetrics> MetricsByLifetime { get; }

        /// <summary>
        /// Gets the time when metrics collection started.
        /// </summary>
        DateTimeOffset StartTime { get; }

        /// <summary>
        /// Gets the time of the last recorded operation.
        /// </summary>
        DateTimeOffset LastOperationTime { get; }

        /// <summary>
        /// Gets memory usage statistics for resolved services.
        /// </summary>
        IMemoryUsageMetrics MemoryUsage { get; }
    }

    /// <summary>
    /// Represents performance metrics for a specific service type.
    /// </summary>
    public interface IServiceTypeMetrics
    {
        /// <summary>
        /// Gets the service type these metrics apply to.
        /// </summary>
        Type ServiceType { get; }

        /// <summary>
        /// Gets the total number of resolutions for this service type.
        /// </summary>
        long ResolutionCount { get; }

        /// <summary>
        /// Gets the average resolution time for this service type.
        /// </summary>
        TimeSpan AverageResolutionTime { get; }

        /// <summary>
        /// Gets the failure rate for this service type as a percentage.
        /// </summary>
        double FailureRate { get; }

        /// <summary>
        /// Gets the cache hit rate for this service type as a percentage.
        /// </summary>
        double CacheHitRate { get; }

        /// <summary>
        /// Gets the estimated memory usage per instance for this service type.
        /// </summary>
        long EstimatedMemoryPerInstance { get; }
    }

    /// <summary>
    /// Represents performance metrics for a specific service lifetime.
    /// </summary>
    public interface IServiceLifetimeMetrics
    {
        /// <summary>
        /// Gets the service lifetime these metrics apply to.
        /// </summary>
        ServiceLifetime Lifetime { get; }

        /// <summary>
        /// Gets the total number of resolutions for this lifetime.
        /// </summary>
        long ResolutionCount { get; }

        /// <summary>
        /// Gets the average resolution time for this lifetime.
        /// </summary>
        TimeSpan AverageResolutionTime { get; }

        /// <summary>
        /// Gets the number of active instances for this lifetime.
        /// </summary>
        long ActiveInstances { get; }

        /// <summary>
        /// Gets the total memory usage for this lifetime.
        /// </summary>
        long TotalMemoryUsage { get; }
    }

    /// <summary>
    /// Represents memory usage metrics for dependency injection operations.
    /// </summary>
    public interface IMemoryUsageMetrics
    {
        /// <summary>
        /// Gets the total memory allocated for service instances.
        /// </summary>
        long TotalAllocatedMemory { get; }

        /// <summary>
        /// Gets the current memory usage for active service instances.
        /// </summary>
        long CurrentMemoryUsage { get; }

        /// <summary>
        /// Gets the peak memory usage recorded.
        /// </summary>
        long PeakMemoryUsage { get; }

        /// <summary>
        /// Gets the number of garbage collections triggered by service instances.
        /// </summary>
        long GarbageCollections { get; }

        /// <summary>
        /// Gets memory usage breakdown by service lifetime.
        /// </summary>
        IReadOnlyDictionary<ServiceLifetime, long> MemoryByLifetime { get; }
    }

    /// <summary>
    /// Represents a tracking context for a service resolution operation.
    /// </summary>
    public interface IResolutionTrackingContext : IDisposable
    {
        /// <summary>
        /// Gets the unique identifier for this tracking context.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the service type being resolved.
        /// </summary>
        Type ServiceType { get; }

        /// <summary>
        /// Gets the service descriptor being used for resolution.
        /// </summary>
        IServiceDescriptor Descriptor { get; }

        /// <summary>
        /// Gets the start time of the resolution operation.
        /// </summary>
        DateTimeOffset StartTime { get; }

        /// <summary>
        /// Gets the elapsed time since the operation started.
        /// </summary>
        TimeSpan ElapsedTime { get; }

        /// <summary>
        /// Gets metadata associated with this tracking context.
        /// </summary>
        IMetadata Metadata { get; }

        /// <summary>
        /// Adds metadata to the tracking context.
        /// </summary>
        /// <typeparam name="TValue">The type of the metadata value.</typeparam>
        /// <param name="key">The metadata key.</param>
        /// <param name="value">The metadata value.</param>
        void AddMetadata<TValue>(string key, TValue value);
    }

    /// <summary>
    /// Represents a performance optimization recommendation.
    /// </summary>
    public interface IPerformanceRecommendation
    {
        /// <summary>
        /// Gets the severity level of this recommendation.
        /// </summary>
        RecommendationSeverity Severity { get; }

        /// <summary>
        /// Gets the category of this recommendation.
        /// </summary>
        RecommendationCategory Category { get; }

        /// <summary>
        /// Gets the title of this recommendation.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets the detailed description of this recommendation.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the suggested action to implement this recommendation.
        /// </summary>
        string SuggestedAction { get; }

        /// <summary>
        /// Gets the estimated performance improvement if this recommendation is implemented.
        /// </summary>
        string EstimatedImprovement { get; }

        /// <summary>
        /// Gets the service types this recommendation applies to.
        /// </summary>
        IReadOnlyCollection<Type> AffectedServiceTypes { get; }

        /// <summary>
        /// Gets metadata associated with this recommendation.
        /// </summary>
        IMetadata Metadata { get; }
    }

    /// <summary>
    /// Represents the severity level of a performance recommendation.
    /// </summary>
    public enum RecommendationSeverity
    {
        /// <summary>Low priority optimization suggestion.</summary>
        Low = 0,

        /// <summary>Medium priority optimization that could provide moderate benefits.</summary>
        Medium = 1,

        /// <summary>High priority optimization that could provide significant benefits.</summary>
        High = 2,

        /// <summary>Critical optimization required to prevent performance issues.</summary>
        Critical = 3
    }

    /// <summary>
    /// Represents the category of a performance recommendation.
    /// </summary>
    public enum RecommendationCategory
    {
        /// <summary>Recommendation related to service lifetime management.</summary>
        Lifetime = 0,

        /// <summary>Recommendation related to caching strategies.</summary>
        Caching = 1,

        /// <summary>Recommendation related to memory usage optimization.</summary>
        Memory = 2,

        /// <summary>Recommendation related to dependency resolution patterns.</summary>
        Resolution = 3,

        /// <summary>Recommendation related to service registration patterns.</summary>
        Registration = 4,

        /// <summary>Recommendation related to validation and error handling.</summary>
        Validation = 5,

        /// <summary>Recommendation related to general architectural improvements.</summary>
        Architecture = 6
    }

    /// <summary>
    /// Represents a comprehensive performance report.
    /// </summary>
    public interface IPerformanceReport
    {
        /// <summary>
        /// Gets the time period this report covers.
        /// </summary>
        (DateTimeOffset Start, DateTimeOffset End) Period { get; }

        /// <summary>
        /// Gets the performance metrics for the report period.
        /// </summary>
        IServicePerformanceMetrics Metrics { get; }

        /// <summary>
        /// Gets performance recommendations based on the report data.
        /// </summary>
        IReadOnlyCollection<IPerformanceRecommendation> Recommendations { get; }

        /// <summary>
        /// Gets the top performing service types by resolution speed.
        /// </summary>
        IReadOnlyCollection<IServiceTypeMetrics> TopPerformingServices { get; }

        /// <summary>
        /// Gets the worst performing service types by resolution speed.
        /// </summary>
        IReadOnlyCollection<IServiceTypeMetrics> WorstPerformingServices { get; }

        /// <summary>
        /// Gets services with the highest memory usage.
        /// </summary>
        IReadOnlyCollection<IServiceTypeMetrics> HighMemoryUsageServices { get; }

        /// <summary>
        /// Gets services with the highest failure rates.
        /// </summary>
        IReadOnlyCollection<IServiceTypeMetrics> HighFailureRateServices { get; }

        /// <summary>
        /// Gets metadata associated with this performance report.
        /// </summary>
        IMetadata ReportMetadata { get; }

        /// <summary>
        /// Exports the performance report to a formatted string.
        /// </summary>
        /// <param name="format">The export format (e.g., "json", "xml", "text").</param>
        /// <returns>The formatted performance report.</returns>
        string Export(string format = "text");
    }
}
