**Show User**
----
  Returns json data about a single user.

* **URL**

  api/user/{id}

* **Method:**

  `GET`
  
*  **URL Params**

   **Required:**
 
   `id=[integer]`

* **Data Params**

  None

* **Success Response:**

  * **Code:** 200 <br />
    **Content:** `{ "id" : 1, "firstName":"Mark","lastName":"Zon","dateOfBirth":"1981-01-25T05:00:00","email":"mark@gmail.com","password":"zon"}`
 
* **Error Response:**

  * **Code:** 404 NOT FOUND <br />
    **Content:** `{ error : "User doesn't exist." }`

----
  **Show Users**
----
  Returns list of json data of all users.

* **URL**

  api/user  
  api/user/all

* **Method:**

  `GET`
  
*  **URL Params**

   **Not Required:**
    
* **Data Params**

  None

* **Success Response:**

  * **Code:** 200 <br />
    **Content:** `{ "id" : 1, "firstName":"Mark","lastName":"Zon","dateOfBirth":"1981-01-25T05:00:00","email":"mark@gmail.com","password":"zon"},
                  { "id":2,"firstName":"tom","lastName":"cruz","dateOfBirth":"2021-03-30T14:47:57.36","email":"tom@gmail.com","password":"cruz"}`
 
* **Error Response:**

  * **Code:** 404 NOT FOUND <br />
    **Content:** `{ error : "User doesn't exist." }`

----
  **Add User**
----
  Add a new user by passing User json object.

* **URL**

  api/user  
  api/user/create  
  api/user/register

* **Method:**

  `POST`
  
*  **URL Params**

   **Not Required:**
 
* **Data Params**

  { "firstName":"Mark","lastName":"Zon","dateOfBirth":"1981-01-25T05:00:00","email":"mark@gmail.com","password":"zon"}

* **Success Response:**

  * **Code:** 200 <br />
    **Content:** 1
 
* **Error Response:**

  * **Code:** 400 BAD REQUEST <br />
    **Content:** 

----
  **Delete User**
----
  Delete User by user id.

* **URL**

  api/user  
  api/user/remove  
  api/user/delete

* **Method:**

  `DELETE`
  
*  **URL Params**

   **Required:**
   
   `id=[integer]`
 
* **Data Params**

  None

* **Success Response:**

  * **Code:** 200 <br />
    **Content:** 1
 
* **Error Response:**

  * **Code:** 404 NOT FOUND <br />
    **Content:** 
    
----
  **Update User**
----
  Update User by user id.

* **URL**

  api/user  
  api/user/update  
  api/user/modify

* **Method:**

  `PUT`
  
*  **URL Params**

   **Not Required:**
       
* **Data Params**

  { "id" : 1, "firstName":"Mark","lastName":"Zon","dateOfBirth":"1981-01-25T05:00:00","email":"mark@gmail.com","password":"zon"}

* **Success Response:**

  * **Code:** 200 <br />
    **Content:** 1
 
* **Error Response:**

  * **Code:** 404 NOT FOUND <br />
    **Content:** 
