Requirements 
1. Create new database tables Using Code First In Entity Framework.
2. Blazor WebAssembly app with an interface to show data from DB.
3. Make an ability to change and save data in the application: state, name, and dimensions.
4. Add the ability to create and delete orders, windows and elements.
5. Optional: Interface validations. DTO. Separated BLL and DAL projects.


1. Database was created using EF. 
Database on your system could be created using migrations. 
Main project for migrations  - WindowsOrders.Api

To review solution two startup projects should be set -  WindowsOrders.Api and WindowsOrders.Web 

Project WindowsOrders.DAL .sql scripts 
* InsertTestData.sql - Insert test data into database created with migrations
* InsertUsStates.sql - Insert Us States information. Us States in app has predefined selection option
* InsertWindowsItemsTypes.sq - Insert window item types. Window item types has predefined selection option


3. All order fields are editable.
4. Orders could be created, edited or deleted.
5. Solution was splitted into Api, BLL, DAL, Web projects,

Dto's are used in solution,

Only very basic validations where implemented.
Fields which needs to be populated with data are marked with red border.

If needed those validations could be expanded..


