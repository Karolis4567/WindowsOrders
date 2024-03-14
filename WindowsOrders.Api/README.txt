Requirements 
1. Create new database tables Using Code First In Entity Framework.
2. Blazor WebAssembly app with an interface to show data from DB.
3. Make an ability to change and save data in the application: state, name, and dimensions.
4. Add the ability to create and delete orders, windows and elements.
5. Optional: Interface validations. DTO. Separated BLL and DAL projects.


1. Database was created using EF. Database could be created using migrations. 
Main project for migrations  - WindowsOrders.Api
To review solution two startup projects should be set -  WindowsOrders.Api and WindowsOrders.Web 

3. In this solution all fiels are made editable.
4. Solution has ability to create, edit and delete orders.
5. Solution was splitted into Api, BLL, DAL, Web projects,
Dto's are used in solution,
Basic validations where done to interface. Fields which needs to be populated with 
data are marked with red border.


