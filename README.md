# InvestorsApp

A simple Angular + Web API app to display and add investors


## Contents

1. [Code overview](#code-overview)
2. [Notes](#notes)


## Code overview

- **investorsapp.client** Angular project
- **InvestorsApp.Server** contains API controllers
- **InvestorsApp.Core** contains shared DTOs. No logic.
- **InvestorsApp.Infrastructure** contains service implementations, repositories and maps
    database entities to DTOs
- **InvestorsApp.Server.Tests** contains API unit tests


## Notes

Extra things to add if real solution (and more time):

- Paging and sorting in API, rather than return all and hardcode to name
- More Angular unit tests
- Better Angular service error handling
- Error logging