# FigureMvcWebApi

This project implements 2 way get rectangles.

First way it is get rectangles with help UI page Rectangles - MVC aproach.
Second way get this figure with help Swagger - Web API aproach.

DI implemented with help ninject. 

The project split on subprojects for comfortable work and loose coupling code.

Home page is empty.

Sql part was implemented with help Code First Approach with migration scripts. 
For create database need set up connection string and run following code from root project's folder:

<code>update-database -Project "FigureMvcWebApi.Model.Database"</code>

Front end handler with help jQuery and Razor page.

Code coverege Unit tests, only two controllers.