// <copyright file="IPipelineDefinition.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Common;
using Zentient.Abstractions.Common.Definitions;

namespace Zentient.Abstractions.Pipelines.Definitions
{
    /// <summary>
    /// Represents a complete pipeline definition.
    /// </summary>
    /// <remarks>
    /// This is the core abstraction for dynamic pipeline creation and orchestration,
    /// providing access to the ordered collection of pipeline steps and extensible metadata.
    /// </remarks>
    public interface IPipelineDefinition : ITypeDefinition, IHasMetadata
    {
        /// <summary>
        /// Gets the ordered, read-only list of step definitions that comprise the pipeline.
        /// </summary>
        /// <value>
        /// An <see cref="IReadOnlyList{IPipelineStepDefinition}"/> containing all steps in execution order.
        /// </value>
        IReadOnlyList<IPipelineStepDefinition> Steps { get; }
    }
}
