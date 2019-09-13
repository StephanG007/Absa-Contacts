# ABSA Contacts #

*How to run*
This site is made up of two separate projects that both have to be run.
To run the API, in the commandline from the API folder, run:
  > dotnet run
The frontend is an Angular, Single Page Application.  In order to run it:
1. First download the required packages with:
  > npm install
1. Then, run the project with:
  > npm start
  
## Notes ##

If the API does not detect it's SQLite Database, it will generate one and autopopulate it with data generated from 
[JSON Generator]https://www.json-generator.com/

The site will automatically load all the users initially, but the search still works.  Remember to press enter!

If you enter a working image URL into the profile form, it will update to display the image.

The Edit Contact button doesn't work yet, but it should be trivial to implement.
