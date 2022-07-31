# User Management System

## Info

#### This system provides basic operations to manage with users and user permissions. There are features like adding, editing, viewing, deleting user, and also to assign a specific permission with some user.
#### Used RDBMS is SQL Server Express, connection string in appsetings file point to localhost server and database name "mistral_users". There is just one migration, for creating database. Application don't seed any initial data.

## API Specification

### GET api/users?pageNumber=&pagesize=?

#### Return all users, with paginated result, both parameters has it's default values, pageNumber is 1 and pageSize is set to be 10 by default.

'''
  "pageNumber": 1,
  "pageSize": 10,
  "count": 10,
  "users": [
    {
      "id": 12,
      "firstName": "string",
      "lastName": "string",
      "userName": "string10",
      "email": "string",
      "status": "string"
    },
    {
      "id": 11,
      "firstName": "string",
      "lastName": "string",
      "userName": "string9",
      "email": "string",
      "status": "string"
    },
    {
      "id": 10,
      "firstName": "string",
      "lastName": "string",
      "userName": "string8",
      "email": "string",
      "status": "string"
    },
    {
      "id": 9,
      "firstName": "string",
      "lastName": "string",
      "userName": "string7",
      "email": "string",
      "status": "string"
    },
    {
      "id": 8,
      "firstName": "string",
      "lastName": "string",
      "userName": "string6",
      "email": "string",
      "status": "string"
    },
    {
      "id": 7,
      "firstName": "string",
      "lastName": "string",
      "userName": "string5",
      "email": "string",
      "status": "string"
    },
    {
      "id": 6,
      "firstName": "string",
      "lastName": "string",
      "userName": "string4",
      "email": "string",
      "status": "string"
    },
    {
      "id": 4,
      "firstName": "string",
      "lastName": "string",
      "userName": "string2",
      "email": "string",
      "status": "string"
    },
    {
      "id": 3,
      "firstName": "John",
      "lastName": "Smith",
      "userName": "johnnn",
      "email": "john@mail.com",
      "status": "active"
    },
    {
      "id": 1,
      "firstName": "Senaid",
      "lastName": "Maksumic",
      "userName": "senmax",
      "email": "senaid@live.com",
      "status": "offline"
    }
  ]
}
'''
