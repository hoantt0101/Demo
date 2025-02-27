using NUnit.Framework;

[assembly: Parallelizable(ParallelScope.Fixtures)] // Enable parallel execution for all tests in the assembly
[assembly: LevelOfParallelism(4)] // Number of parallel threads
