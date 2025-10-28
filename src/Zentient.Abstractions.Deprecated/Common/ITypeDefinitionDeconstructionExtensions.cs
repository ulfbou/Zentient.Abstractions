// <copyright file="ITypeDefinitionDeconstructionExtensions.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using Zentient.Abstractions.Relations;
using System.Collections.Generic;
using Zentient.Abstractions.Common.Definitions;
using Zentient.Abstractions.Relations.Definitions;

namespace Zentient.Abstractions.Common
{
    /// <summary>
    /// Provides extension methods for deconstructing <see cref="ITypeDefinition"/> into its common and frequently used components.
    /// </summary>
    public static class ITypeDefinitionDeconstructionExtensions
    {
        /// <summary>
        /// Deconstructs an <see cref="ITypeDefinition"/> into its unique identifier, logical name, version, description, category name, category, and relations.
        /// </summary>
        /// <param name="definition">The type definition instance to deconstruct.</param>
        /// <param name="id">The unique identifier of the type definition.</param>
        /// <param name="name">The logical name of the type definition.</param>
        /// <param name="version">The version of the type definition.</param>
        /// <param name="description">The description of the type definition.</param>
        /// <param name="categoryName">The category name of the type definition.</param>
        /// <param name="category">The category object of the type definition.</param>
        /// <param name="relations">The collection of relation types associated with the type definition.</param>
        public static void Deconstruct(
            this ITypeDefinition definition,
            out string id,
            out string name,
            out string version,
            out string description,
            out string categoryName,
            out IRelationCategory? category,
            out IReadOnlyCollection<IRelationDefinition> relations)
        {
            Guard.AgainstNull(definition, nameof(definition));
            id = definition.Id;
            name = definition.Name;
            version = definition.Version;
            description = definition.Description;
            categoryName = definition.CategoryName;
            category = definition.Category;
            relations = definition.Relations;
        }

        /// <summary>
        /// Deconstructs an <see cref="ITypeDefinition"/> into its unique identifier, logical name, version, and description.
        /// </summary>
        /// <param name="definition">The type definition instance to deconstruct.</param>
        /// <param name="id">The unique identifier of the type definition.</param>
        /// <param name="name">The logical name of the type definition.</param>
        /// <param name="version">The version of the type definition.</param>
        /// <param name="description">The description of the type definition.</param>
        public static void Deconstruct(
            this ITypeDefinition definition,
            out string id,
            out string name,
            out string version,
            out string description)
        {
            Guard.AgainstNull(definition, nameof(definition));
            id = definition.Id;
            name = definition.Name;
            version = definition.Version;
            description = definition.Description;
        }

        /// <summary>
        /// Deconstructs an <see cref="ITypeDefinition"/> into its unique identifier, logical name, version, description, and category name.
        /// </summary>
        /// <param name="definition">The type definition instance to deconstruct.</param>
        /// <param name="id">The unique identifier of the type definition.</param>
        /// <param name="name">The logical name of the type definition.</param>
        /// <param name="version">The version of the type definition.</param>
        /// <param name="description">The description of the type definition.</param>
        /// <param name="categoryName">The category name of the type definition.</param>
        public static void Deconstruct(
            this ITypeDefinition definition,
            out string id,
            out string name,
            out string version,
            out string description,
            out string categoryName)
        {
            Guard.AgainstNull(definition, nameof(definition));
            id = definition.Id;
            name = definition.Name;
            version = definition.Version;
            description = definition.Description;
            categoryName = definition.CategoryName;
        }

        /// <summary>
        /// Deconstructs an <see cref="ITypeDefinition"/> into its unique identifier, logical name, version, description, category name, and category.
        /// </summary>
        /// <param name="definition">The type definition instance to deconstruct.</param>
        /// <param name="id">The unique identifier of the type definition.</param>
        /// <param name="name">The logical name of the type definition.</param>
        /// <param name="version">The version of the type definition.</param>
        /// <param name="description">The description of the type definition.</param>
        /// <param name="categoryName">The category name of the type definition.</param>
        /// <param name="category">The category object of the type definition.</param>
        public static void Deconstruct(
            this ITypeDefinition definition,
            out string id,
            out string name,
            out string version,
            out string description,
            out string categoryName,
            out IRelationCategory? category)
        {
            Guard.AgainstNull(definition, nameof(definition));
            id = definition.Id;
            name = definition.Name;
            version = definition.Version;
            description = definition.Description;
            categoryName = definition.CategoryName;
            category = definition.Category;
        }

        /// <summary>
        /// Deconstructs an <see cref="ITypeDefinition"/> into its unique identifier, logical name, version, description, and relations.
        /// </summary>
        /// <param name="definition">The type definition instance to deconstruct.</param>
        /// <param name="id">The unique identifier of the type definition.</param>
        /// <param name="name">The logical name of the type definition.</param>
        /// <param name="version">The version of the type definition.</param>
        /// <param name="description">The description of the type definition.</param>
        /// <param name="relations">The collection of relation types associated with the type definition.</param>
        public static void Deconstruct(
            this ITypeDefinition definition,
            out string id,
            out string name,
            out string version,
            out string description,
            out IReadOnlyCollection<IRelationDefinition> relations)
        {
            Guard.AgainstNull(definition, nameof(definition));
            id = definition.Id;
            name = definition.Name;
            version = definition.Version;
            description = definition.Description;
            relations = definition.Relations;
        }
    }
}
