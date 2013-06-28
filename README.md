ReSharper8 beta test runner bug.

Two branches here, one called 'passing' one called 'failing' to show both states.
This is a replication of an issue in a real codebase, so some of the conditions may be irrelevant

Solution has a few nested solution folders.

* OtherCode [.NET45 project]
* OtherCode.Test.Unit [.NET45 test project]
* AnEx86Project [x86 .NET4 project]
* AnEx86Project.Test.Unit [x86 .NET4 test project]
* ReSharper8TestRunnerBugRepro [.NET35 project]
* ReSharper8TestRunnerBugRepro.Test.Unit [.NET40 test project]

When "Run all tests" is clicked

* OtherCode.Test.Unit = PASS
* AnEx86Project.Test.Unit = PASS
* ReSharper8TestRunnerBugRepro.Test.Unit = FAIL

The failure is *always* reading configuration files in our real solution, and the test in this repo replicates that.

When "ReSharper8TestRunnerBugRepro.Test.Unit" selected in test runner and clicked "Run Unit Tests"

* ReSharper8TestRunnerBugRepro.Test.Unit = PASS

When I remove OtherCode and OtherCode.Test.Unit

* AnEx86Project.Test.Unit = PASS
* ReSharper8TestRunnerBugRepro.Test.Unit = PASS