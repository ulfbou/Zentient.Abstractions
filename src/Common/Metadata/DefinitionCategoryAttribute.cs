// <copyright file="DefinitionCategoryAttribute.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zentient.Abstractions.Common.Metadata
{
    /// <summary>
    /// Marks a definition with a category for grouping and filtering.
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class, Inherited = false)]
    public sealed class DefinitionCategoryAttribute : Attribute
    {
        public DefinitionCategoryAttribute(string categoryName) => CategoryName = categoryName;
        public string CategoryName { get; }
    }
}
