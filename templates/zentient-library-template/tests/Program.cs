// Program.cs - Entry point for test executable
// This file is required when Microsoft.NET.Test.Sdk sets OutputType=Exe
// but is not actually used during normal test execution

namespace Zentient.LibraryTemplate.Tests;

/// <summary>
/// Program entry point for test project.
/// This is required when Microsoft.NET.Test.Sdk sets OutputType=Exe
/// but the actual test execution happens through the test runner.
///
/// NOTE: This file is necessary because Microsoft.NET.Test.Sdk automatically
/// sets OutputType=Exe for test projects, which requires a Main method.
/// During normal test execution via 'dotnet test', this Main method is not called.
/// </summary>
public static class Program
{
    /// <summary>
    /// Main entry point - not used during normal test execution.
    /// The test runner handles execution through a different mechanism.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
    public static void Main(string[] args)
    {
        // This method is required for OutputType=Exe but not used during test execution
        // The test runner handles execution through a different mechanism
        Console.WriteLine("This is a test project. Use 'dotnet test' to run tests.");
        Console.WriteLine("Available test classes:");
        Console.WriteLine("  - ConfigurationBuilderTests: Tests for the sample ConfigurationBuilder class");
    }
}
