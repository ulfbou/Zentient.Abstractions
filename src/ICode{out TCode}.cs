// <copyright file="IEnvelope.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions
{
    /// <summary>
    /// Represents a universal, protocol-agnostic code for an operation outcome or detail.
    /// </summary>
    /// <typeparam name="TCode">The code type, representing the domain or category of the code.</typeparam>
    public interface ICode<out TCode> : ICode 
        where TCode : ICodeType 
    {
        /// <summary>Gets the strongly typed code value for this instance.</summary>
        /// <value>
        /// The code value of type <typeparamref name="TCode"/>, representing the domain or category of the code.
        /// </value>
        TCode TypedValue { get; }
    }
}
