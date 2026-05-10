# Restaurangguide – Restaurant Guide System

Restaurangguide is a web-based restaurant guide system developed for both residents and visitors in Gothenburg. The purpose of the project is to make it easy to discover and explore restaurants in the city, including both popular and lesser-known restaurants.

Unlike large anonymous review platforms, this system focuses on a more local and personal user experience centered around Gothenburg’s restaurant scene.

---

# Project Overview

The project consists of two connected applications:

1. ASP.NET Web API  
2. ASP.NET Core MVC Application

⚠️ Important:  
Both the API project and the MVC project must run simultaneously for the system to function correctly.  
The MVC application fetches restaurant data from the API using HTTP requests.

---

# Features

## API Features (CRUD Functionality)

The API includes full CRUD functionality (Create, Read, Update, Delete) for administrators.

An administrator can:

- Add new restaurants
- Update restaurant information
- Delete restaurants
- Manage restaurant reviews

---

## MVC Application Features

The MVC application is the user-facing part of the system where users can:

- View restaurant names
- View restaurant images
- View restaurant prices
- Read restaurant descriptions
- Read restaurant reviews
- Write reviews for restaurants
- Scroll through available restaurants in a visual interface

---

# Technologies Used

## Programming Language
- C#

## Frameworks
- ASP.NET Core MVC
- ASP.NET Web API

## Database
- SQLite

## Data Exchange
- JSON

## Communication
- HttpClient

---

# System Architecture

The MVC application communicates with the API using HTTP requests.

### Flow:

1. The MVC application sends an HTTP request to the API.
2. The API retrieves restaurant data from the SQLite database.
3. The API returns the data in JSON format.
4. The MVC application displays the restaurant information to the user.

---

## 1. Clone the Repository

```bash
git clone https://github.com/SuhayraAhmed/ResturangGuiden.git

# Admin Login

Administrators can log in and access the API CRUD functionality.

## Admin Credentials

```text
Email: restaurang@guiden.se
Password: Admin123
## 1. Clone the Repository
---

