# Exam2
A study project containig a web application managing a resistor databse.
Http API is implemented. The data is stored in MongoDB.

The following http methods are supported:
- Post"": adds new resistor to database with parameters given in body of the request
- Get"id": finds a resistor by id
- Get"": searches a resistor by criteria in query
- Patch"id": updates resistor using data in request body
- Delete "id": deletes a resistor with given id from database
