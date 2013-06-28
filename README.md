ReSharper8 beta test runner bug.

Two branches here, one called 'passing' one called 'failing'.

In failing, if you "run all unit tests in project" configuration related tests randomly fail.
If you remove an assembly also in the solution (one class, does nothing) the tests pass.

Seems to be related to reading configuration files, causing hundreds of tests to fail in an actual codebase.