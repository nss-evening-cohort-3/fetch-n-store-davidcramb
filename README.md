#Fetch 'N Store

The goal of this exercise is to assist the student in understanding the request and response cycle ofthe HTTP protocol while reviewing aspects of AngularJS, AJAX and the repository pattern. This is a multi-part exercise requiring both in-class and ouside of class work.

## Rules

1. Students must start assignment in class.
2. Implement the required features in order as defined in this read me.
3. Implement a tested Repository Pattern.
4. Implement the needed User Experience leveraging the following User Story:

```
As an Anonymous User,
I want to be able to make an HTTP request using a HTTP Method and URL I specify,
So that I can examine the response times.
```

### Part 1: Boilerpate and Setup

Create an ASP.NET MVC Web Application (w/ Authentication and a Unit Test project). Install and Setup angular.


### Part 2: UI Implementation & AJAX

Your Home page should have a drop-down, text input form element with a "Fetch" button, all centered on the page. The user should be able to supply an HTTP Method and URL. Clicking the "Fetch" button will make an AJAX call to the specified URL. On the completion of the ALAX call, the response **status code**, **URL**, HTTP **method** used for the original request and **response time** should be displayed on the page.

Your drop-down element should contain/allow for the user to use the **GET** and **HEAD** HTTP methods.

(Instructor may supply students a mockup for this page)


### Part 3: Gather Responses

Add a "Store" button to your Home page that will **POST** the **status code**, **URL** and **response time** for each request in your Web Application's Database. This will require the student to implement a `POST /api/Response` API endpoint (i.e. requiring the use of the **POST** HTTP method).


### Part 4: Save to Database

Define a `Response` model and related repository for the purpose of persisting responses in the database. The repository should be unit tested. Your `Response` model should store, **status code**, **URL**, **response time**, HTTP **method** used and time of request. Student must demonstrate understanding of this task by first provide a trivial ERD of the `Request` model.

### Part 5: Show me the Responses

Students will implement a `GET /api/Response`  that will display a list of all persisted responses from the database. Angular will be used to obtain response data from our API endpoint.
