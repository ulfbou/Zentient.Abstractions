// <copyright file="IOptionsType{out TValue}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zentient.Abstractions.Common;

namespace Zentient.Abstractions.Options
{
    /// <summary>
    /// Represents a type definition for a set of options or configuration values,
    /// strongly typed to the concrete value type it defines.
    /// </summary>
    /// <typeparam name="TValue">The concrete type of the option values (e.g., MyServiceOptions).</typeparam>
    public interface IOptionsType<out TValue> : IOptionsType
    {
        /// <summary>Gets the type of the value associated with the policy options.</summary>
        Type ValueType { get; }
    }
}
