// <copyright file="IPolicy{out TPolicyType}.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

namespace Zentient.Abstractions.Policies
{
    /// <summary>
    /// Represents a policy that can be applied to an operation producing a result of type <typeparamref name="TPolicyType"/>.
    /// Supports combinators for building policy pipelines.
    /// </summary>
    /// <typeparam name="TPolicyType">The type of the result produced by the operation the policy is applied to.</typeparam>
    public interface IPolicy<out TPolicyType>
        where TPolicyType : IPolicyType
    {
        /// <summary>
        /// Executes the policy, wrapping the provided action within the given context.
        /// This method supports a middleware-like pattern, allowing the policy to
        /// perform operations before and/or after the action's execution.
        /// </summary>
        /// <typeparam name="TResult">The type of the result returned by the action.</typeparam>
        /// <param name="action">The function representing the next step in the execution chain,
        /// which accepts an <see cref="IPolicyContext"/> and returns a <see cref="Task{TResult}"/>.</param>
        /// <param name="context">The <see cref="IPolicyContext"/> for the current execution.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation's result.</returns>
        Task<TResult> Execute<TResult>(
            Func<IPolicyContext, Task<TResult>> action,
            IPolicyContext context);
    }
}
