# BlogPosts
Assigment for .NET Developer (Open Web API)

Open WebApi-BlogPosts (ASP.NET Core)

Detailed instructions:
 - Execute Dbscript.sql to generate database with schemas and data (used MSSQL).
 - Note: please change FILENAME path before you execute db script(use your path).
 - Change connectionString in 'appsettings.json' file
 - Url for calling SwaggerUI in browser: call: http://localhost:<port>/swagger

 
 
Example for testing endpoint api/tags:
  - click "GET" button 
  - click "Try it out" button so that you can execute the method
  - click "Execute" button 
  - section "Response body" contains result from database
  *Some endpoints require parameter, e.g. get posts by slug (need to pass parameter)
  
Test data examples:

1. GET Tags
	Request url: http://localhost:(port)/api/tags
	Response status code: 200 (Success)
	Response body:
	[
	  "2018",
	  "iOS",
	  "innovation",
	  "Angular"
	]

2. GET Posts
	Request url: http://localhost:(port)/api/posts
	Response status code: 200 (Success)
	Response body:
	[
	  {
		"slug": "internet-trends-2020",
		"title": "Internet trends 2020",
		"description": "Post for Internet trends 2020",
		"body": "An opinionated commentary, of the most important presentation of the year",
		"tagList": [
		  "Angular"
		],
		"createdAt": "2020-04-01T12:37:18.8710651",
		"updatedAt": "2020-04-01T12:37:23.2164062"
	  },
	  {
		"slug": "test-ct-2020",
		"title": "Test CT 2020",
		"description": "Testing post?",
		"body": "An opinionated commentary, of the most important presentation of the year",
		"tagList": [
		  "innovation"
		],
		"createdAt": "2020-04-01T02:15:11.9882643",
		"updatedAt": "2020-04-01T02:15:11.9882703"
	  },
	  {
		"slug": "internet-trends-2018",
		"title": "Internet Trends 2018",
		"description": "Ever wonder how?",
		"body": "An opinionated commentary, of the most important presentation of the year",
		"tagList": [
		  "2018"
		],
		"createdAt": "2020-04-01T02:04:07.9655631",
		"updatedAt": "2020-04-01T02:04:07.9657156"
	  }
	]
	
   GET Posts by tag (optional)
	Request url: http://localhost:(port)/api/posts?tag=Angular
	Response status code: 200 (Success)
	Response body:
	[
	  {
		"slug": "internet-trends-2020",
		"title": "Internet trends 2020",
		"description": "Post for Internet trends 2020",
		"body": "An opinionated commentary, of the most important presentation of the year",
		"tagList": [
		  "Angular"
		],
		"createdAt": "2020-04-01T12:37:18.8710651",
		"updatedAt": "2020-04-01T12:37:23.2164062"
	  }
	]
	
3. POST BlogPost
	Request url: http://localhost:(port)/api/posts
	Request body:
	{
	  "BlogPost": {
		"Title": "Augmented Reality iOS Application",
		"Description": "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
		"Body": "The app is simple to use, and will help you decide on your best furniture fit.",
		"Tags": [
		  "iOS","AR"
		]
	  }
	}
	Response status code: 200 (Success)
	Response body:
	{
	  "slug": "augmented-reality-ios-application",
	  "title": "Augmented Reality iOS Application",
	  "description": "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
	  "body": "The app is simple to use, and will help you decide on your best furniture fit.",
	  "tagList": [
		"iOS",
		"AR"
	  ],
	  "createdAt": "2020-04-01T13:28:02.6148087+02:00",
	  "updatedAt": "2020-04-01T13:28:02.6150541+02:00"
	}
 
4. DELETE BlogPost
	Request url: http://localhost:(port)/api/posts/test-ct-2020
	Response status code: 200 (Success)
	Response body:
	Record successfully deleted!
	
5. PUT BlogPost
	Request url: http://localhost:(port)/api/posts/bugzilla
	Request body:
	{
	  "BlogPost": {
		"Title": "internet-trends-2018",
		"Description": "An opinionated commentary, of the most important presentation of the year"
	  }
	}
	Response status code: 200 (Success)
	Response body:
	{
	  "slug": "internet-trends-2018",
	  "title": "internet-trends-2018",
	  "description": "An opinionated commentary, of the most important presentation of the year",
	  "body": "An opinionated commentary, of the most important presentation of the year",
	  "tagList": [
		"2018"
	  ],
	  "createdAt": "0001-01-01T00:00:00",
	  "updatedAt": "2020-04-01T15:02:07.7752126+02:00"
	}
