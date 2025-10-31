Online Management System (OMS)

This project is a role-based Online Management System (OMS) built with ASP.NET Core MVC, designed for managing students, departments, courses, and user roles within an educational or training institution.

 Features

Role-Based Authorization: Secure access control for Admin, Instructor, and Student roles.

User Management: Admin can list, create, edit roles, and manage user assignments to those roles.

Student Management (CRUD): Instructors and Admins can create, view, edit, and delete student records.

Department Management (CRUD): Departments support creation, editing, and soft-deletion (departments with students cannot be permanently deleted).

Course Management: Associates multiple courses with a department via a many-to-many relationship.

Degree Tracking: Allows instructors to record and update student degrees for specific courses.

Data Access: Implements the Repository Pattern for clean separation of data access logic.

 Technology Stack

Framework: ASP.NET Core 8.0 (MVC)

Database: SQL Server

ORM: Entity Framework Core 8.0

Authentication/Authorization: ASP.NET Core Identity (Cookie-based authentication)

Styling: Bootstrap 5

⚙️ Setup and Configuration

1. Database Connection Strings

The application uses two separate database contexts. Before running, you must update the connection strings in Program.cs and ITIDbContext.cs.

File: Program.cs

// Main Application Data
op.UseSqlServer("Data Source=OSAMA;Initial Catalog=ITI2;Integrated Security=True;Encrypt=true;Trust Server Certificate=True ");

// Authentication/Identity Data
op.UseSqlServer("Data Source=OSAMA;Initial Catalog=ITI2AuthDb;Integrated Security=True;Encrypt=true;Trust Server Certificate=True ");


(Note: Replace Data Source=OSAMA with your SQL Server instance name or connection details.)

2. Database Migrations and Seeding

The application contexts (ITIDbContext and AuthDbContext) are configured for automatic seeding in their OnModelCreating methods.

Context

Seeded Data

AuthDbContext

Roles: Admin, Instractour, Student



Default Admin User: Username/Email: admin@iti.gov



Default Admin Password: Admin@123

ITIDbContext

Departments: CS, IS, IT



Courses: C#, Java, Python

To initialize the database, run the necessary Entity Framework Core migration commands in your package manager console.

🏛️ Architecture Overview

The project follows a modular, layer-based architecture, utilizing Dependency Injection (DI) to manage components:

1. Data Access Layer (DAL)

ITIDbContext.cs: Main EF Core context for Student, Departments, Course, and StudentCourse.

AuthDbContext.cs: EF Core Identity context for users and roles.

2. Repository Layer (lab1.Repo)

IEntityRepo<T>: A generic interface defining the standard CRUD contract.

StudentRepo & DEpartmentRepo: Implement IEntityRepo<T>. The DEpartmentRepo implements soft deletion by setting a Status=false flag if a department has associated students.

DepartmentCourseRepo: Handles the complex many-to-many relationship for associating courses with departments.

3. Controller Layer

Controller

Authorization

Functionality

AccountController

Public

Handles User Registration (default role: Student), Login, and Logout.

StudentController

Admin, Instractour

Full CRUD operations for Student entities.

DepartmentController

Admin, Instractour

CRUD for Departments. Also manages editcourses and UpdateStudentDegree (recording student grades for courses).

AdminUserController

Admin

Views the list of all users, allows editing of user roles, and deletion of users.

HomeController

Public

Application landing page and standard views (Index, Privacy).

 Default Credentials

Use the following credentials to access the administrative features:

Role

Username (Email)

Password

Admin

admin@iti.gov

Admin@123

 Usage

Run the Application.

Login: Use the default Admin credentials (admin@iti.gov / Admin@123).

Manage Users & Roles: Navigate to the Users link (visible only to Admin) to assign the Instractour role to new accounts.

Manage Departments/Students: Navigate to the Department or Students dropdowns to manage core entities.

Grade Students: Use the View Courses action on a department to click through to Update Student Degree. The grades are recorded in the StudentCourse table.
