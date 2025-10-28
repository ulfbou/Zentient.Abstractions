// <copyright file="IActivity.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Contexts;
using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Observability.Tracing
{
    /// <summary>
    /// Represents a unit of work or span in a trace. Disposing closes the activity.
    /// </summary>
    public interface IActivity : IIdentifiable, IDisposable
    {
        /// <summary>Adds or updates a tag on this activity.</summary>
        /// <param name="key">The tag key.</param>
        /// <param name="value">The tag value.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="key"/> is null or empty, or if <paramref name="value"/> is null.
        /// </exception>
        void AddTag(string key, object value);

        /// <summary>Sets the completion status of this activity.</summary>
        /// <param name="status">The status to set.</param>
        void SetStatus(ActivityStatus status);
    }
}
