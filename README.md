# Assignment 5 Solution

This solution targets **.NET 8.0** and follows the assignment requirement to create a separate class library for each problem, with a matching MSTest project for unit tests.

## Projects

- `Problem1` / `Problem1.Tests` — Factory Pattern for children's toys
- `Problem2` / `Problem2.Tests` — Builder Pattern for computer creation
- `Problem3` / `Problem3.Tests` — Reactor-style mailroom dispatcher with scalable workers
- `Problem4` / `Problem4.Tests` — Observer Pattern for an auction system

## Suggested commands

```bash
dotnet restore
dotnet build
dotnet test
```

## Notes

- XML documentation is enabled in all class library projects.
- The implementation focuses on readability, validation, and testability.
- Problem 3 intentionally uses a dispatcher/handler design to model continuous incoming requests and worker scaling.
