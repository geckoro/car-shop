WPF MVVM application of a car shop, uses EF Core to build and manage the database (SQL Server).

Two dialogs with a generic table in the middle, allowing CRUD operations.

There are some things that have been left out, for example allowing the user to add cars to a client. My only excuse is lack of time. I also had in plan to write a bunch of unit tests, but didn't have the chance to. For that, I would've probably gone for MSTest, mocking the services with Moq and doing the asserts with FluentAssertions.
