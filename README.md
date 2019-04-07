# N-TIER WEB API APP
A C# project created for educational purposes in order to get acquainted with main approaches of designing and creating app with n-tier architecture including web API layer.
### DESCRIPTION
Solution Hierarchy:
This is a C# .Net solution-project, and it contains six sub-projects:
1.	[BllEntities](BllEntities): A class library project. Contains realization of entities related to ProductsBLL layer.
2.	[DataEntities](DataEntities): A class library project. Contains realization of entities related to DAL_EntityFrameWork layer.
3.	[DAL_EntityFrameWork](DAL_EntityFrameWork): A class library project. Contains realization of mechanisms of accessing database using Entity Framework.
4.	[ProductsBLL](ProductsBLL): A class library project. Contains realization of provided services in the current app.
5.	[Structure](Structure): A class library project. Contains interfaces related to the current app. 
6.	[WebApi](WebApi): A web API project. Contains realization and configuration of web API controllers which provide main functions of the app.
### Web API:
[Web API](WebApi) layer contains three API controllers:
1.	[Product categories controller](WebApi/Controllers): Web API controller which contains realization of CRUD functions for product categories and some filtering functions.
#### Route descriptions:
  * Get all categories: “api/categories” GET;
  * Get category by id: “api/categories/{id}” GET;
  * Get products with specified category id: “api/categories/{id}/products” GET;
  * Get suppliers who supply products with specified category id: “api/categories/{id}/products” GET;
  * Add category: “api/categories” POST;
  * Update category: “api/categories/{id}” PUT;
  * Delete category: “api/categories/{id}” DELETE.

2.  [Products controller](WebApi/Controllers): Web API controller which contains realization of CRUD functions for products.
#### Route descriptions:
* Get all products: “api/products” GET;
* Get product by id: “api/products/{id}” GET;
* Add product: “api/products” POST;
* Update product: “api/products/{id}” PUT;
* Delete product: “api/products/{id}” DELETE.

3.	[Suppliers controller](WebApi/Controllers): Web API controller which contains realization of CRUD functions for suppliers.
#### Route descriptions:
* Get all suppliers: “api/suppliers” GET;
* Get supplier by id: “api/ suppliers /{id}” GET;
* Add supplier: “api/ suppliers” POST;
* Update supplier: “api/ suppliers /{id}” PUT;
* Delete supplier: “api/ suppliers /{id}” DELETE.
### Exception handling:
Web API exception handling in the current project is managed using Exception Filter Attribute class. 
[Exception filters](WebApi/Exceptions): 
* ValidateModelAttribute: Filter which handles errors related to model state validation.
* NotFoundExceptionAttribute: Filter which handles errors related to ElementNotFoundException which occurs on BLL layer.

Exception filters are set globally in [WebApiConfig.cs](WebApi/App_Start/WebApiConfig.cs), as a result each web API controller related to the current project can handle those exceptions. 
### Dependency injection: 
In the current project dependency injection is managed using Ninject. There are two ninject modules in the app [BllModule.cs](ProductsBLL/Infrastructure/BllModule.cs) and [ServicesModule.cs](WebApi/Ninject/ServiceModule.cs).


