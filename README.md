# User Management System

## Info

#### This system provides basic operations to manage with users and user permissions. There are features like adding, editing, viewing, deleting users, and also to assign a specific permission with some user.
#### Application is ASP.NET Core Web API 6.0. Used RDBMS is SQL Server Express, connection string in appsetings file point to localhost server and database name "mistral_users". ORM used in project is the EntityFramework Core 6. There is just one migration, for creating database. Application don't seed any initial data.

## API Specification

### GET api/users?pageNumber=&pageSize=

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

#### Create user with basic required information.
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
### PUT api/users/{id}

#### Edit user information provided by the model for specific user.
#### Return the whole edited user object or, in case of fail, the right message.

```
{
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "status": "string"
}
```

### DELETE api/users/{id}

#### Removes specific user from the database and returns the message in case of the fail.

```
{
  "statusCode": 200,
  "message": "User succesfully removed!"
}
```

### GET api/permissions

#### Returns all the permissions stored in database.

```
[
  {
    "id": 1,
    "code": "r/w",
    "description": "user can read and write posts to site"
  },
  {
    "id": 2,
    "code": "r",
    "description": "user can read post"
  },
  {
    "id": 3,
    "code": "mod",
    "description": "user can modify posts"
  }
]
```
### POST api/permissions

#### Creates the new permission

```
{
  "code": "string",
  "description": "string"
}
```
### GET api/permissions/{userID}

#### Provides a list of all permissions assigned to specified user.

```
{
  "userId": 1,
  "permissions": [
    {
      "id": 1,
      "code": "r/w",
      "description": "user can read and write posts to site"
    }
  ]
}
```

### GET api/permission/assign?permissionId=&userId=

#### Assign permission to user, both of them are provided via identifiers.
#### Returns the modified list of permissions for specified user.
```
{
  "userId": 1,
  "permissions": [
    {
      "id": 1,
      "code": "r/w",
      "description": "user can read and write posts to site"
    },
    {
      "id": 5,
      "code": "modify pic",
      "description": "modify pictures"
    }
  ]
}
```

### GET api/permission/remove?permissionId=&userId=

#### Remove selected permission from permission list of the specific user
#### Returns the modified list of permissions for specific user.

```
{
  "userId": 1,
  "permissions": [
    {
      "id": 1,
      "code": "r/w",
      "description": "user can read and write posts to site"
    }
  ]
}
```

### Exception handling

#### Exception handling with result with following JSON in case of any thrown exception in application.

```
{
  "statusCode": 500,
  "message": "Internal server error orccured!"
}

```

#### Expected behavior results are also handled like on following result

```
{
  "statusCode": 404,
  "message": "User not found!"
}
```
