// <copyright file="ActivityStatus.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Observability.Tracing
{
    /// <summary>Indicates the final status of an activity/span.</summary>
    public enum ActivityStatus
    {
        Unset,
        Ok,
        Error,
        Cancelled
    }
}
