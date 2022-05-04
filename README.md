# New Beginnings API Microservice
A microservice to manage participant registry for New Beginnings that supports adding, updating, removing and retrieving personal information for participants.

## Installation & Run
```bash
# Clone this project with Git
git clone https://github.com/tessiechoo/NewBeginnings.git
```

Open the project via the sln file in Visual Studio, Build Project and Run.

## API

Use POSTMAN to test API calls with settings provided.

Endpoint : https://localhost:44395/participant
 
 Sample Body
```
{
    "ReferenceNumber" : "KFG-345",
    "FirstName" : "Jane",
    "LastName" : "Doe",
    "PhoneNumber" : "(123)456-7890",
    "Address" : {
        "Id" : 1,
        "AddressLine1" : "123 ABC St",
        "AddressLine2" : "",
        "City" : "Durham",
        "State": "NC",
        "Zipcode" : "25670"
    }
```

#### /participant

* `POST` : Add a new participant

#### /participant/:referenceNumber

* `GET` : Get a participant based on reference number
* `PUT` : Update an existing participant or add new if does not exist
* `DELETE` : Delete a participant based on reference number


