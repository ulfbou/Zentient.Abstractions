// <copyright file="IPipelineStepDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Common.Definitions;

namespace Zentient.Abstractions.Pipelines.Definitions
{
    /// <summary>
    /// Represents a metadata-rich definition of a pipeline step.
    /// </summary>
    /// <remarks>
    /// This interface provides the contract for a single step within a pipeline,
    /// including display information, execution order, and extensible metadata
    /// for configuration such as retry policies, timeouts, and other contextual data.
    /// </remarks>
    public interface IPipelineStepDefinition : ITypeDefinition, IHasMetadata
    {
        /// <summary>
        /// Gets the human-readable display name of the pipeline step.
        /// </summary>
        /// <value>
        /// A non-null, non-empty string representing the display name.
        /// </value>
        string DisplayName { get; }

        /// <summary>
        /// Gets the execution order of the pipeline step within its pipeline.
        /// </summary>
        /// <value>
        /// An integer representing the step's position; lower values are executed first.
        /// </value>
        int Order { get; }
    }
}
