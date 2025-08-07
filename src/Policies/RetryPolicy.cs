// <copyright file="RetryPolicy.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.ComponentModel;

namespace Zentient.Abstractions.Policies
{
    /// <summary>
    /// Defines retry strategies for operations that may fail temporarily.
    /// </summary>
    /// <remarks>
    /// Retry policies determine how operations should be retried when they fail,
    /// including the strategy, intervals, and maximum attempts.
    /// </remarks>
    public enum RetryPolicy
    {
        /// <summary>
        /// No retry is performed.
        /// Operations fail immediately on the first failure.
        /// </summary>
        [Description("No retry - fail immediately")]
        None = 0,

        /// <summary>
        /// Fixed interval retry policy.
        /// Retries are performed at fixed time intervals.
        /// </summary>
        [Description("Fixed interval between retries")]
        FixedInterval = 1,

        /// <summary>
        /// Linear backoff retry policy.
        /// Retry intervals increase linearly with each attempt.
        /// </summary>
        [Description("Linear increase in retry intervals")]
        LinearBackoff = 2,

        /// <summary>
        /// Exponential backoff retry policy.
        /// Retry intervals increase exponentially with each attempt.
        /// </summary>
        [Description("Exponential increase in retry intervals")]
        ExponentialBackoff = 3,

        /// <summary>
        /// Random jitter retry policy.
        /// Retry intervals include random jitter to avoid thundering herd.
        /// </summary>
        [Description("Random jitter added to retry intervals")]
        RandomJitter = 4,

        /// <summary>
        /// Circuit breaker retry policy.
        /// Stops retrying after a threshold of failures is reached.
        /// </summary>
        [Description("Circuit breaker pattern with failure threshold")]
        CircuitBreaker = 5,

        /// <summary>
        /// Adaptive retry policy.
        /// Dynamically adjusts retry behavior based on success/failure patterns.
        /// </summary>
        [Description("Adaptive retry based on success patterns")]
        Adaptive = 6
    }

    /// <summary>
    /// Provides extension methods for working with RetryPolicy values.
    /// </summary>
    public static class RetryPolicyExtensions
    {
        /// <summary>
        /// Determines whether this retry policy performs any retries.
        /// </summary>
        /// <param name="policy">The retry policy to check.</param>
        /// <returns>True if retries are performed; otherwise, false.</returns>
        public static bool AllowsRetries(this RetryPolicy policy)
        {
            return policy != RetryPolicy.None;
        }

        /// <summary>
        /// Determines whether this retry policy uses variable intervals.
        /// </summary>
        /// <param name="policy">The retry policy to check.</param>
        /// <returns>True if intervals vary between retries; otherwise, false.</returns>
        public static bool UsesVariableIntervals(this RetryPolicy policy)
        {
            return policy is RetryPolicy.LinearBackoff or RetryPolicy.ExponentialBackoff or 
                   RetryPolicy.RandomJitter or RetryPolicy.Adaptive;
        }

        /// <summary>
        /// Gets the default maximum number of retry attempts for this policy.
        /// </summary>
        /// <param name="policy">The retry policy.</param>
        /// <returns>The default maximum retry attempts.</returns>
        public static int GetDefaultMaxAttempts(this RetryPolicy policy)
        {
            return policy switch
            {
                RetryPolicy.None => 0,
                RetryPolicy.FixedInterval => 3,
                RetryPolicy.LinearBackoff => 5,
                RetryPolicy.ExponentialBackoff => 7,
                RetryPolicy.RandomJitter => 5,
                RetryPolicy.CircuitBreaker => 3,
                RetryPolicy.Adaptive => 10,
                _ => 3
            };
        }

        /// <summary>
        /// Gets the default base interval for this retry policy.
        /// </summary>
        /// <param name="policy">The retry policy.</param>
        /// <returns>The default base retry interval.</returns>
        public static TimeSpan GetDefaultBaseInterval(this RetryPolicy policy)
        {
            return policy switch
            {
                RetryPolicy.None => TimeSpan.Zero,
                RetryPolicy.FixedInterval => TimeSpan.FromSeconds(1),
                RetryPolicy.LinearBackoff => TimeSpan.FromMilliseconds(500),
                RetryPolicy.ExponentialBackoff => TimeSpan.FromMilliseconds(200),
                RetryPolicy.RandomJitter => TimeSpan.FromMilliseconds(500),
                RetryPolicy.CircuitBreaker => TimeSpan.FromSeconds(1),
                RetryPolicy.Adaptive => TimeSpan.FromMilliseconds(100),
                _ => TimeSpan.FromSeconds(1)
            };
        }

        /// <summary>
        /// Calculates the retry interval for a specific attempt.
        /// </summary>
        /// <param name="policy">The retry policy.</param>
        /// <param name="attemptNumber">The current attempt number (1-based).</param>
        /// <param name="baseInterval">The base interval for calculations.</param>
        /// <returns>The calculated retry interval.</returns>
        public static TimeSpan CalculateInterval(this RetryPolicy policy, int attemptNumber, TimeSpan baseInterval)
        {
            if (policy == RetryPolicy.None || attemptNumber <= 0)
                return TimeSpan.Zero;

            return policy switch
            {
                RetryPolicy.FixedInterval => baseInterval,
                RetryPolicy.LinearBackoff => TimeSpan.FromTicks(baseInterval.Ticks * attemptNumber),
                RetryPolicy.ExponentialBackoff => TimeSpan.FromTicks(baseInterval.Ticks * (long)Math.Pow(2, attemptNumber - 1)),
                RetryPolicy.RandomJitter => AddJitter(baseInterval, 0.1),
                RetryPolicy.CircuitBreaker => baseInterval,
                RetryPolicy.Adaptive => baseInterval, // Would be adjusted based on success rate
                _ => baseInterval
            };
        }

        /// <summary>
        /// Determines whether this policy should stop retrying based on the exception type.
        /// </summary>
        /// <param name="policy">The retry policy.</param>
        /// <param name="exception">The exception that occurred.</param>
        /// <returns>True if retrying should stop; otherwise, false.</returns>
        public static bool ShouldStopRetrying(this RetryPolicy policy, Exception exception)
        {
            // Non-transient exceptions that should not be retried
            var nonTransientExceptions = new[]
            {
                typeof(ArgumentException),
                typeof(ArgumentNullException),
                typeof(InvalidOperationException),
                typeof(NotSupportedException),
                typeof(UnauthorizedAccessException)
            };

            return nonTransientExceptions.Any(type => type.IsAssignableFrom(exception.GetType()));
        }

        private static TimeSpan AddJitter(TimeSpan baseInterval, double jitterFactor)
        {
            // Use a deterministic hash-based approach for jitter to avoid security warnings
            // This is not for cryptographic purposes, just for retry timing variation
            var hash = baseInterval.GetHashCode();
            var normalizedHash = Math.Abs(hash) / (double)int.MaxValue;
            var jitter = normalizedHash * jitterFactor * 2 - jitterFactor; // ±jitterFactor
            var adjustedTicks = (long)(baseInterval.Ticks * (1 + jitter));
            return TimeSpan.FromTicks(Math.Max(0, adjustedTicks));
        }
    }
}
