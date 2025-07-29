// <copyright file="IMeter.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zentient.Abstractions.Metadata;

namespace Zentient.Abstractions.Observability.Metrics
{
    /// <summary>Records basic counters and gauges with optional tags.</summary>
    public interface IMeter
    {
        /// <summary>Increments a named counter by the specified amount.</summary>
        void AddCounter(
            string name,
            double value = 1,
            IMetadata? tags = null);

        /// <summary>Updates a named gauge with the latest value.</summary>
        void SetGauge(
            string name,
            double value,
            IMetadata? tags = null);
    }
}
