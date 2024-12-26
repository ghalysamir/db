README

CompanyProject

Overview

CompanyProject is a system designed to manage users, roles, and posts efficiently. The project uses a simple database schema that supports relationships between different entities. It is built with C# and Entity Framework Core for seamless database interaction.


---

Features

User Management:
Manage basic user information such as name, age, email, and password.

Role Management:
Support for roles like "Admin," "Editor," etc., with the ability to associate them with users.

Post Management:
Handle posts created by users, including likes and shares.

User-Role Relationship:
Establish a many-to-many relationship between users and roles through a bridge table.



---

Technologies Used

Backend:

C#

ASP.NET Core

Entity Framework Core


Database:

MySQL or any database supported by EF Core




---

Database Schema

Entities

1. Users Table

Id: Primary Key

Name: User's name

Age: User's age

Email: Unique email address

Password: User's password



2. Roles Table

Id: Primary Key

RoleName: Unique name of the role



3. Posts Table

Id: Primary Key

Title: Post title

Category: Post category

Body: Post content

Likes: Number of likes

Share: Number of shares

User_Id: Foreign Key to the Users table



4. User_Role Table

User_Id: Foreign Key to the Users table

Role_Id: Foreign Key to the Roles table

Composite Primary Key: (User_Id, Role_Id)





---

How to Run the Project

Prerequisites

1. Install .NET SDK

Ensure that .NET 6 or later is installed on your machine.



2. Database Setup

Set up the database (MySQL) and update the connection string in the project configuration.




Steps

1. Clone the Repository

git clone  https://github.com/ghalysamir/db.git
cd CompanyProject


2. Apply Migrations

dotnet ef database update


3. Run the Application

dotnet run






