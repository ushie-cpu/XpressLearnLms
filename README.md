# 📚 Xpress LMS API

A high-performance Learning Management System (LMS) backend built with **.NET**, **Dapper**, and **SQL Server**.
This project demonstrates scalable API design, efficient data access, and bulk data seeding using Mockaroo.

---

## 🚀 Features

* ⚡ High-performance data access using **Dapper**
* 🧱 Clean architecture (Controller → Service → Data Layer)
* 🗄️ SQL Server relational database design
* 📥 Bulk data seeding using **Mockaroo + BULK INSERT**
* 👥 User management (Student, Instructor, Admin)
* 📘 Course management
* 📊 Supports relational data (Users, Courses, Attempts)

---

## 🛠️ Tech Stack

* .NET Core Web API
* Dapper
* SQL Server
* Mockaroo (for generating test data)

---

## 📦 Database Setup

### 1. Create Database

```sql
CREATE DATABASE XpressLmsDB;
```

---

### 2. Create Tables

Ensure your `Users` table looks like:

```sql
CREATE TABLE Users (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    FirstName NVARCHAR(100),
    LastName NVARCHAR(100),
    Email NVARCHAR(150),
    PasswordHash NVARCHAR(255),
    Role INT,
    CreatedAt DATETIME NULL
);
```

---

## 📥 Seeding Data (Mockaroo)

### Step 1: Generate Data

Go to 👉 [https://mockaroo.com](https://mockaroo.com)

Create fields:

| Column       | Type          |
| ------------ | ------------- |
| Id           | GUID          |
| FirstName    | First Name    |
| LastName     | Last Name     |
| Email        | Email Address |
| PasswordHash | Password Hash |
| Role         | Number (0–2)  |
| CreatedAt    | Datetime      |

Download as **CSV**.

---

### Step 2: Move File

Place the file in:

```
C:\temp\MOCK_DATA.csv
```

---

### Step 3: Bulk Insert

Run this in SQL Server:

```sql
BULK INSERT dbo.Users
FROM 'C:\temp\MOCK_DATA.csv'
WITH (
    FIRSTROW = 2,
    FIELDTERMINATOR = ',',
    ROWTERMINATOR = '0x0d0a',
    CODEPAGE = '65001',
    TABLOCK
);
```

---

### Step 4: Verify

```sql
SELECT TOP 10 * FROM Users;
```

---

## ⚠️ Common Issues & Fixes

### ❌ 0 Rows Inserted

* Ensure correct `ROWTERMINATOR = '0x0d0a'`

### ❌ Conversion Error (Id)

* Ensure Mockaroo `Id` type = **GUID**

### ❌ File Not Found

* Move file to `C:\temp`

---

## 📂 Project Structure

```
/Api
/Core
/Data
/Models
/Repository
/Services
/Shared
/Test
```

* **Api** → Handle HTTP requests
* **Core** → Constants and helpers
* **Data** →  Dapper queries/Database,SQL script and MockData file
* **Models** → DTOs & Entities
* **Repository** → Query Commands
* **Services** → Business logic
* **Shared** → Shared configurations
* **Test** → Unit test

---

## 📡 API Endpoints

Base URL:

```
/api
```

### 👥 Users

#### ➤ Get All Users

```
GET /api/users    https://localhost:7075/api/users?page=1&pageSize=10

CURL
curl -X 'GET' \
  'https://localhost:7075/api/users?page=1&pageSize=10' \
  -H 'accept: */*'
```

#### ➤ Get User By Id

```
GET /api/users/{id}
```

#### ➤ Create User

```
POST /api/users
```

Request Body:

```json
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john@example.com",
  "passwordHash": "hashed_password",
  "role": 1
}
```

#### ➤ Update User

```
PUT /api/users/{id}
```

#### ➤ Delete User

```
DELETE /api/users/{id}
```

---

### 📘 Courses

#### ➤ Get All Courses

```
```

#### ➤ Get Course By Id

```
GET /api/courses/{id}
```

#### ➤ Create Course

```
POST /api/courses    https://localhost:7075/api/course
```
CURL
curl -X 'POST' \
  'https://localhost:7075/api/course' \
  -H 'accept: */*' \
  -H 'Content-Type: multipart/form-data' \
  -F 'Title=string' \
  -F 'Description=string' \
  -F 'CategoryId=3fa85f64-5717-4562-b3fc-2c963f66afa6' \
  -F 'InstructorId=3fa85f64-5717-4562-b3fc-2c963f66afa6' \
  -F 'Thumbnail=string'
  
Request Body:

```json
{
  "title": "C# Fundamentals",
  "description": "Learn the basics of C#",
  "categoryId": "GUID_HERE",
  "instructorId": "GUID_HERE",
  "thumbnail": "choose file"
}
```

#### ➤ Update Course

```
PUT /api/courses/{id}
```

#### ➤ Delete Course

```
DELETE /api/courses/{id}
```

---






#### ➤ Get All Category

```
GET /api/category   https://localhost:7075/api/Category
```
CURL
curl -X 'GET' \
  'https://localhost:7075/api/Category' \
  -H 'accept: */*'
  
```

#### ➤ Create Category

```
POST /api/courses/{id}
```

#### ➤ Delete Category

```
DELETE /api/category/{id}
```

---
### 📊 Attempts

#### ➤ Get All Attempts

```
GET /api/attempts
```

#### ➤ Get Attempts By User

```
GET /api/attempts/user/{userId}
```

#### ➤ Create Attempt

```
POST /api/attempts
```

Request Body:

```json
{
  "userId": "GUID_HERE",
  "courseId": "GUID_HERE",
  "score": 85
}
```

---

### 🏆 Leaderboard (Optional Feature)

#### ➤ Get Top Users

```
GET /api/leaderboard
```

Returns users ranked by performance (e.g., average score).

---

## 🧠 Key Concepts

* Dapper for lightweight ORM performance
* Bulk data operations in SQL Server
* Clean separation of concerns
* Relational database design

---

## 🚀 Future Improvements

* Add authentication (JWT)
* Add pagination & filtering
* Add caching (Redis)
* Add logging & monitoring

---

## 👨‍💻 Author

Built by **John Ushie**
.NET Backend Engineer

---
