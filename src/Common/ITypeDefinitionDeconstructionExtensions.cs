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
        /// <param name="typeDefinition">The type definition instance to deconstruct.</param>
        /// <param name="id">The unique identifier of the type definition.</param>
        /// <param name="name">The logical name of the type definition.</param>
        /// <param name="version">The version of the type definition.</param>
        /// <param name="description">The description of the type definition.</param>
        /// <param name="categoryName">The category name of the type definition.</param>
        /// <param name="category">The category object of the type definition.</param>
        /// <param name="relations">The collection of relation types associated with the type definition.</param>
        public static void Deconstruct(
            this ITypeDefinition typeDefinition,
            out string id,
            out string name,
            out string version,
            out string description,
            out string categoryName,
            out IRelationCategory? category,
            out IReadOnlyCollection<IRelationDefinition> relations)
        {
            ArgumentNullException.ThrowIfNull(typeDefinition, nameof(typeDefinition));
            id = typeDefinition.Id;
            name = typeDefinition.Name;
            version = typeDefinition.Version;
            description = typeDefinition.Description;
            categoryName = typeDefinition.CategoryName;
            category = typeDefinition.Category;
            relations = typeDefinition.Relations;
        }

        /// <summary>
        /// Deconstructs an <see cref="ITypeDefinition"/> into its unique identifier, logical name, version, and description.
        /// </summary>
        /// <param name="typeDefinition">The type definition instance to deconstruct.</param>
        /// <param name="id">The unique identifier of the type definition.</param>
        /// <param name="name">The logical name of the type definition.</param>
        /// <param name="version">The version of the type definition.</param>
        /// <param name="description">The description of the type definition.</param>
        public static void Deconstruct(
            this ITypeDefinition typeDefinition,
            out string id,
            out string name,
            out string version,
            out string description)
        {
            ArgumentNullException.ThrowIfNull(typeDefinition, nameof(typeDefinition));
            id = typeDefinition.Id;
            name = typeDefinition.Name;
            version = typeDefinition.Version;
            description = typeDefinition.Description;
        }

        /// <summary>
        /// Deconstructs an <see cref="ITypeDefinition"/> into its unique identifier, logical name, version, description, and category name.
        /// </summary>
        /// <param name="typeDefinition">The type definition instance to deconstruct.</param>
        /// <param name="id">The unique identifier of the type definition.</param>
        /// <param name="name">The logical name of the type definition.</param>
        /// <param name="version">The version of the type definition.</param>
        /// <param name="description">The description of the type definition.</param>
        /// <param name="categoryName">The category name of the type definition.</param>
        public static void Deconstruct(
            this ITypeDefinition typeDefinition,
            out string id,
            out string name,
            out string version,
            out string description,
            out string categoryName)
        {
            ArgumentNullException.ThrowIfNull(typeDefinition, nameof(typeDefinition));
            id = typeDefinition.Id;
            name = typeDefinition.Name;
            version = typeDefinition.Version;
            description = typeDefinition.Description;
            categoryName = typeDefinition.CategoryName;
        }

        /// <summary>
        /// Deconstructs an <see cref="ITypeDefinition"/> into its unique identifier, logical name, version, description, category name, and category.
        /// </summary>
        /// <param name="typeDefinition">The type definition instance to deconstruct.</param>
        /// <param name="id">The unique identifier of the type definition.</param>
        /// <param name="name">The logical name of the type definition.</param>
        /// <param name="version">The version of the type definition.</param>
        /// <param name="description">The description of the type definition.</param>
        /// <param name="categoryName">The category name of the type definition.</param>
        /// <param name="category">The category object of the type definition.</param>
        public static void Deconstruct(
            this ITypeDefinition typeDefinition,
            out string id,
            out string name,
            out string version,
            out string description,
            out string categoryName,
            out IRelationCategory? category)
        {
            ArgumentNullException.ThrowIfNull(typeDefinition, nameof(typeDefinition));
            id = typeDefinition.Id;
            name = typeDefinition.Name;
            version = typeDefinition.Version;
            description = typeDefinition.Description;
            categoryName = typeDefinition.CategoryName;
            category = typeDefinition.Category;
        }

        /// <summary>
        /// Deconstructs an <see cref="ITypeDefinition"/> into its unique identifier, logical name, version, description, and relations.
        /// </summary>
        /// <param name="typeDefinition">The type definition instance to deconstruct.</param>
        /// <param name="id">The unique identifier of the type definition.</param>
        /// <param name="name">The logical name of the type definition.</param>
        /// <param name="version">The version of the type definition.</param>
        /// <param name="description">The description of the type definition.</param>
        /// <param name="relations">The collection of relation types associated with the type definition.</param>
        public static void Deconstruct(
            this ITypeDefinition typeDefinition,
            out string id,
            out string name,
            out string version,
            out string description,
            out IReadOnlyCollection<IRelationDefinition> relations)
        {
            ArgumentNullException.ThrowIfNull(typeDefinition, nameof(typeDefinition));
            id = typeDefinition.Id;
            name = typeDefinition.Name;
            version = typeDefinition.Version;
            description = typeDefinition.Description;
            relations = typeDefinition.Relations;
        }
    }
}
