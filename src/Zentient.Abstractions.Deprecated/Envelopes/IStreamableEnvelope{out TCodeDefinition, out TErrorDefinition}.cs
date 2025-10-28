// <copyright file="IStreamableEnvelope{out TCodeDefinition, out TErrorDefinition}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System.IO;
using Zentient.Abstractions.Codes;
using Zentient.Abstractions.Codes.Definitions;
using Zentient.Abstractions.Errors;
using Zentient.Abstractions.Errors.Definitions;

namespace Zentient.Abstractions.Envelopes
{
    /// <summary>Represents an envelope carrying a stream payload.</summary>
    /// <typeparam name="TCodeDefinition">The type of the code.</typeparam>
    /// <typeparam name="TErrorDefinition">The type of the error.</typeparam>
    public interface IStreamableEnvelope<out TCodeDefinition, out TErrorDefinition> : IEnvelope<TCodeDefinition, TErrorDefinition>
        where TCodeDefinition : ICodeDefinition
        where TErrorDefinition : IErrorDefinition
    {
        /// <summary>The stream payload.</summary>
        /// <value>The stream.</value>
        Stream Stream { get; }
    }
 }
