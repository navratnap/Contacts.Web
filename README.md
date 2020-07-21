# Contacts.Web

<br />

<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Application](#about-the-application)
  * [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
* [Folder Structure](#folder-structure)
* [Contact](#contact)


<!-- ABOUT THE PROJECT -->
## About The Application

This is the simple web application which is basically used to maintain the contact information, including adding/updating/deleting the contact information.
This application implements the Dependency Injection Design Pattern.

As this application uses MS Access as a database (due to unavailabilty of SQL Server) therefore, the queries are written inline.
If this changed to SQL Server in future then, it can either better done by writing the Stored Procedures or using the Entity Framework.

Automapper is used to map the models from the DA, BA and Web project, it eliminates the burden of mapping the models in all the layers manually.

### Built With
The Contacts application is built using the following tools:
* [Visual Studio 2015]
* [Microsoft Access 2010]
* [GitHub]


<!-- GETTING STARTED -->
## Getting Started

This Application is built using the following technologies:

* ASP.NET MVC 5
* Target Framework - 4.5.2
* OLEDB Provider - Microsoft.ACE.OLEDB.12.0
* Unity Container - v1.6.0
* Automapper - v7.0.1
* MS Test Framework


### Prerequisites

Install all the prequisites packages with their appropriate versions to run the application. To do this, read the packages.config file.
After adding all the required packages, build the solution.

Caution : 
If there are compilation errors, due to the dll referencing then, build the project in following manner:
* Contacts.Web Project
* Contacts.BusinessAccess
* Contacts.DataAccess
* Contacts.Web.Tests


<!-- Folder Structure -->
## Folder Structure

* Contacts.Web
  * App_Data
  * App_Start
  * Automapper
  * Common
  * Controllers
  * Models
  * Views
    * Contact
    * Home
  * BootStraper.cs
  * Global.aspx
  * Web.config

* Contacts.BusinessAccess
  * Mapper
  * Model
  * Repository
  * Services
  * DependencyExtension.cs
 
* Contacts.DataAccess
  * Model
  * DBRepository
  * DBService

Note: The Repository Folder contains all the interfaces and the class in Services folder implement these interfaces.

<!-- CONTACT -->
## Contact

For any query, email me at:
[Navratna Pawale] - navratna.p@hotmail.com

Project Link: [https://github.com/navratnap/Contacts.Web](https://github.com/navratnap/Contacts.Web)


