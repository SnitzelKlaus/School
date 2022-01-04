______________________

Movie Web App
______________________

To get the website working install sql and execute 'MovieNightDB'

That's all!

-----------------
Problem solutions
-----------------
If there's problems, start by checking the 'SqlConnection' string in 'MovieManager' class:

private static string SqlConnection = @"Data Source=(Local)\MSSQLSERVER01;Initial Catalog=MovieNight; Integrated Security=SSPI";

'MSSQLSERVER01' is the name of my database, find yours and change it to your database. This should solve any problems that may occur.

If problem persist, contact me by mail: 'snitzelklaus@gmail.com'
