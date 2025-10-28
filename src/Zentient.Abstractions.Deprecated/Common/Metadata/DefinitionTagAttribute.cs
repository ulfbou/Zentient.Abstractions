// <copyright file="DefinitionTagAttribute.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Common.Metadata
{
    /// <summary>
    /// Marks a definition with one or more tags for semantic filtering.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, Inherited = false)]
    public sealed class DefinitionTagAttribute : Attribute
    {
        public DefinitionTagAttribute(params string[] tags) => Tags = tags;
        public string[] Tags { get; }
    }
}
