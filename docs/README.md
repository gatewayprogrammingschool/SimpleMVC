# SimpleMVC
## What is it?
Simple MVC is a simple implementation of the GoF MVC pattern.
Simple MVC provides base functionality for creating asynchronous views,
controllers and models.  An optional feature of the implementation is a
pluggable adapter pattern for providing data access to the models.
Using this adapter pattern, it is possible to create a single model that
has data access to any number of data sources.

## How do you use it?
SimpleMVC uses the [SimpleDI](http://simpledi.gatewayprogramming.school)
dependency injection framework to provide instances of the adapters.  You 
thus can create both the adapters and loaders yourself, allowing complete
freedom to combine any combination of adapters and definitions of the
injection of those adapters.

For example, you can create a JSON-based dependency loader that is responsible
for instantiating a custom injector that will then create instances of the
adapters defined for that injector.  Using this method, you can define a pair
of JSON files, one that defines a SQL Server injector and one that defines
a mock injector.  Simply by using the SQL Server JSON file for deployment,
and the mock JSON file for testing, you can simulate your data access layer.

Views are standalone objects, whether they be a simple class implementing the
view interface, or a complex GUI written in Xamarin Forms or WPF XAML.  The 
functionality behind the view never changes.  Views are manipulated by the
user and those interactions trigger event handlers in the controllers that the
view is registered with.

Controllers are extensions of the SimpleControllerBase class that 
are defined to manage either the entirety of the application (possibly as
a singleton), or more granularly as the controller for a specific functional
area (such as a Member controller, or a Book controller).

## Where can I get it?

SimpleMVC is available on Nuget.org for easy inclusion in your .Net application
from within Visual Studio.  Simply open the Package Manager Console and type:

  install-package GPS.SimpleMVC
  
 That's it.  Nuget will go get the dependencies (in this case Newtonsoft.JSON
 and GPS.SimpleDI) as well as the 
 [SimpleMVC](https://www.nuget.org/packages/GPS.SimpleMVC/) package and add 
 them to your solution.
 
 Alternatively, you may download the package from
 [GitHub](https://github.com/gatewayprogrammingschool/SimpleMVC/releases).

## Where can I get help?
You can log and track issues on [GitHub](https://github.com/gatewayprogrammingschool/SimpleMVC/issues)
or you can send an email to ninja@gatewayprogramming.school.

## What's this Gateway Programming School?
Gateway Programming School (or GPS for short) is a programming school in
Clarksville, TN that is funding its startup costs through the creation of
useful applications, frameworks and text books.  GPS is a for profit school
with the express goal of providing a first-class education in business-oriented
computer programming in C#.


