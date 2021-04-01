# CygnetHRD

# Introduction

CygnetHRD application provide API endpoint for user register and login feature. This application builds on ASP.NET Core 5.0 WebAPI using Repository Pattern and Unit of Work with Dapper. 
This solution having four different package all which having different purpose.

# CygnetHRD.WebAPI

This application having Web API Controllers to access client required endpoints.
It is simple WebApi that performs CRUD operation using Dapper and Repository Pattern / Unit Of work. 

User directly access this application endpoints and get and set data as per their requirements.

Dependent on <b>CygnetHRD.Repository</b> application.

# CygnetHRD.Repository

This application builds on .net core 5.0 class library. This application having Dapper along with implementations of Repository and other interfaces. 

Here, we will add the implementation of the Interfaces for all entities.

Dependent on <b>CygnetHRD.Application</b> application.

# CygnetHRD.Application

This application builds on .net core 5.0 class library. This application having all the Interfaces required to implement.

This is the Application Layer, where we define the interfaces for Repositories here, and implement these interfaces at another layer that is associated with Data access, in our case, Dapper.

Dependent on <b>CygnetHRD.Entity</b> application.

# CygnetHRD.Entity

This application builds on .net core 5.0 class library. This application having all the required Domain Models. 

The Entity layer is not going to depend on any other Project.
