# User Management System

## Info

#### This system provides basic operations to manage with users and user permissions. There are features like adding, editing, viewing, deleting user, and also to assign a specific permission with some user.
#### Used RDBMS is SQL Server Express, connection string in appsetings file point to localhost server and database name "mistral_users". There is just one migration, for creating database. Application don't seed any initial data.

## API Specification

### GET api/users?pageNumber=&pagesize=?

#### Return all users, with paginated result, both parameters has it's default values, pageNumber is 1 and pageSize is set to be 10 by default.

```
  "pageNumber": 1,
  "pageSize": 10,
  "count": 3,
  "users": [
    {
      "id": 3,
      "firstName": "James",
      "lastName": "Viscusi",
      "userName": "James",
      "email": "james@mail.com",
      "status": "active"
    },
    {
      "id": 2,
      "firstName": "Marlene",
      "lastName": "Theriault",
      "userName": "marlene_the",
      "email": "marlene@mail.com",
      "status": "active"
    },
    {
      "id": 1,
      "firstName": "John",
      "lastName": "Smith",
      "userName": "JohnSmith",
      "email": "john@mail.com",
      "status": "active"
    }
  ]
}
```
### GET api/users/{id}

#### Return single object user found by it's id.

```
{
  "id": 1,
  "firstName": "John",
  "lastName": "Smith",
  "userName": "JohnSmith",
  "email": "john@mail.com",
  "status": "active"
}
```

### POST api/users

#### Create user with basic required information. Password will be ecrypted into database.
#### If user is created it will be returned, in case of fail an appropriate message is returned.

```
{
  "firstName": "string",
  "lastName": "string",
  "password": "string",
  "userName": "string",
  "email": "string",
  "status": "string"
}
```
