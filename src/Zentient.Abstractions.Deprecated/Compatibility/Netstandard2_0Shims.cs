// <copyright file="MaybeNullWhenAttribute.cs" company="Zentient Framework Team">
// Copyright © 2025 Zentient Framework Team. All rights reserved.
// </copyright>

#if NETSTANDARD2_0
namespace System.Diagnostics.CodeAnalysis
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.ReturnValue)]
    internal sealed class Netstandard2_0Shims : Attribute
    {
        public Netstandard2_0Shims(bool returnValue) { }
    }
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.ReturnValue)]
    internal sealed class NotNullIfNotNullAttribute : Attribute
    {
        public NotNullIfNotNullAttribute(string parameterName) { }
    }
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.ReturnValue)]
    internal sealed class NotNullWhenAttribute : Attribute
    {
        public NotNullWhenAttribute(bool returnValue) { }
    }
}
namespace System.Collections.Generic
{
    public interface IAsyncEnumerable<out T> { }
    public interface IAsyncEnumerator<out T> : IDisposable
    {
        T Current { get; }
        Task<bool> MoveNextAsync();
    }
}

namespace System.Threading.Tasks
{
    public struct ValueTask
    {
        private readonly Task _task;
        public ValueTask(Task task) { _task = task; }
        public Task AsTask() => _task ?? Task.CompletedTask;
    }
    public struct ValueTask<T>
    {
        private readonly Task<T> _task;
        public ValueTask(Task<T> task) { _task = task; }
        public Task<T> AsTask() => _task ?? Task.FromResult(default(T)!);
    }
}
#endif
