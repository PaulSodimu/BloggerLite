# BloggerLite
BloggerLite is a light weight blogging engine made for developers. Blogger lite can be easily added to an existing MVC application to enable blog like posts.

How to install it

You can add BloggerLite to your project by running this nuget command in the package manager console:

Install-Package BloggerLite -Pre
How to use it

Once the installation has been completed several files will be added to your project.

A new connection string will be added to your web.config file. Modify any required values so that the connection string points at the db you want to use. 
It is important that the name of the connection string stays the same.

In the App_Start folder a file called BlogRoutes will have been created there. Copy the routes from the region 'Routes' to your route config file.

Once this has been done your blog is good to go. Build and run the solution then navigate to yoursite/blog .
