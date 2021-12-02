# Gm IoT Gateway

![build and test](https://img.shields.io/github/workflow/status/Gmframework/Gm/build%20and%20test/dev?style=flat-square)
[![codecov](https://codecov.io/gh/Gmframework/Gm/branch/dev/graph/badge.svg?token=jUKLCxa6HF)](https://codecov.io/gh/Gmframework/Gm)
[![NuGet](https://img.shields.io/nuget/v/Volo.Gm.Core.svg?style=flat-square)](https://www.nuget.org/packages/Volo.Gm.Core)
[![NuGet (with prereleases)](https://img.shields.io/nuget/vpre/Volo.Gm.Core.svg?style=flat-square)](https://www.nuget.org/packages/Volo.Gm.Core)
[![MyGet (nightly builds)](https://img.shields.io/myget/Gm-nightly/vpre/Volo.Gm.svg?style=flat-square)](https://docs.Gm.io/en/Gm/latest/Nightly-Builds)
[![NuGet Download](https://img.shields.io/nuget/dt/Volo.Gm.Core.svg?style=flat-square)](https://www.nuget.org/packages/Volo.Gm.Core)

 **Gm IoT Gateway ** is a complete **infrastructure** based on the **ASP.NET Core** to create **modern gateway ** and **APIs** by following the software development **best practices** and the **latest technologies**.

## Getting Started

- [Quick Start](https://docs.Gm.io/en/Gm/latest/Tutorials/Todo/Index) is a single-part, quick-start tutorial to build a simple application with the Gm Framework. Start with this tutorial if you want to quickly understand how Gm works.
- [Getting Started guide](https://docs.Gm.io/en/Gm/latest/Getting-Started) can be used to create and run Gm based solutions with different options and details.
- [Web Application Development Tutorial](https://docs.Gm.io/en/Gm/latest/Tutorials/Part-1) is a complete tutorial to develop a full stack web application with all aspects of a real-life solution.

### Quick Start

Install the Gm CLI:

````bash
> dotnet tool install -g Volo.Gm.Cli
````

Create a new solution:

````bash
> Gm new BookStore -u mvc -d ef
````

> See the [CLI documentation](https://docs.Gm.io/en/Gm/latest/CLI) for all available options.

### UI Framework Options



### Database Provider Options



## What Gm Provides?

Gm provides a **full stack developer experience**.

### Architecture



Gm offers a complete, **modular** and **layered** software architecture based on **[Domain Driven Design](https://docs.Gm.io/en/Gm/latest/Domain-Driven-Design)** principles and patterns. It also provides the necessary infrastructure and guiding to [implement this architecture](https://docs.Gm.io/en/Gm/latest/Domain-Driven-Design-Implementation-Guide).

Gm Framework is suitable for **[microservice solutions](https://docs.Gm.io/en/Gm/latest/Microservice-Architecture)** as well as monolithic applications.

### Infrastructure

There are a lot of features provided by the Gm Framework to achieve real world scenarios easier, like [Event Bus](https://docs.Gm.io/en/Gm/latest/Event-Bus), [Background Job System](https://docs.Gm.io/en/Gm/latest/Background-Jobs), [Audit Logging](https://docs.Gm.io/en/Gm/latest/Audit-Logging), [BLOB Storing](https://docs.Gm.io/en/Gm/latest/Blob-Storing), [Data Seeding](https://docs.Gm.io/en/Gm/latest/Data-Seeding), [Data Filtering](https://docs.Gm.io/en/Gm/latest/Data-Filtering), etc.

### Cross Cutting Concerns

Gm also simplifies (and even automates wherever possible) cross cutting concerns and common non-functional requirements like [Exception Handling](https://docs.Gm.io/en/Gm/latest/Exception-Handling), [Validation](https://docs.Gm.io/en/Gm/latest/Validation), [Authorization](https://docs.Gm.io/en/Gm/latest/Authorization), [Localization](https://docs.Gm.io/en/Gm/latest/Localization), [Caching](https://docs.Gm.io/en/Gm/latest/Caching), [Dependency Injection](https://docs.Gm.io/en/Gm/latest/Dependency-Injection), [Setting Management](https://docs.Gm.io/en/Gm/latest/Settings), etc.

### Application Modules

Gm is a modular framework and the Application Modules provide **pre-built application functionalities**;

- [**Account**](https://docs.Gm.io/en/Gm/latest/Modules/Account): Provides UI for the account management and allows user to login/register to the application.
- **[Identity](https://docs.Gm.io/en/Gm/latest/Modules/Identity)**: Manages organization units, roles, users and their permissions, based on the Microsoft Identity library.
- [**IdentityServer**](https://docs.Gm.io/en/Gm/latest/Modules/IdentityServer): Integrates to IdentityServer4.
- [**Tenant Management**](https://docs.Gm.io/en/Gm/latest/Modules/Tenant-Management): Manages tenants for a [multi-tenant](https://docs.Gm.io/en/Gm/latest/Multi-Tenancy) (SaaS) application.

See the [Application Modules](https://docs.Gm.io/en/Gm/latest/Modules/Index) document for all pre-built modules.

### Startup Templates

The [Startup templates](https://docs.Gm.io/en/Gm/latest/Startup-Templates/Index) are pre-built Visual Studio solution templates. You can create your own solution based on these templates to **immediately start your development**.

## Gm Community

### Gm Community Web Site

The [Gm Community](https://community.Gm.io/) is a website to publish **articles** and share **knowledge** about the Gm Framework. You can also create content for the community!

### Blog

Follow the [Gm Blog](https://blog.Gm.io/) to learn the latest happenings in the Gm Framework.

### Samples

See the [sample projects](https://docs.Gm.io/en/Gm/latest/Samples/Index) built with the Gm Framework.

### Want to Contribute?

Gm is a community-driven open source project. See [the contribution guide](https://docs.Gm.io/en/Gm/latest/Contribution/Index) if you want to be a part of this project.

## Official Links

* <a href="https://Gm.io/" target="_blank">Main Web Site</a>
  * <a href="https://Gm.io/get-started" target="_blank">Get Started</a>
  * <a href="https://Gm.io/features" target="_blank">Features</a>
* <a href="https://docs.Gm.io/" target="_blank">Documentation</a>
* <a href="https://docs.Gm.io/en/Gm/latest/Samples/Index" target="_blank">Samples</a>
* <a href="https://blog.Gm.io/" target="_blank">Blog</a>
* <a href="https://community.Gm.io/" target="_blank">Community</a>
* <a href="https://stackoverflow.com/questions/tagged/Gm" target="_blank">Stack overflow</a>
* <a href="https://twitter.com/Gmframework" target="_blank">Twitter</a>

## Support the Gm Framework

Love Gm Framework? **Please give a star** to this repository :star:

## Gm Commercial

See also [Gm Commercial](https://commercial.Gm.io/) if you are looking for pre-built application modules, professional themes, code generation tooling and premium support for the Gm Framework.
