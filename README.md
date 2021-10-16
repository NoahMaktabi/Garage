<h1>Garage -- School project</h1>

<h2>Requirements:</h2>
A garage class with generic collection that holds all the parked vehilces in the garage. 
A vehicle class as base class which holds the common properties of the vehicles. 
5 different types of vehicles ex: car, truck etc. that inherite from vehicle and has own properties. 

<h5>Functions: </h5>

-Show/list all vehicles. 

-Show/list vehicles by type. 

-Add vehicle to the garage. 

-Remove vehicle.

-Search vehicle by license plate.

-Search vehicle by some other parameter. 


<h2>project implementation</h2>
The project was created using the clean architecture design pattern and is devided into 4 different project: 

1- Domain: 
Project type: C# Class Library. The Domain layer contains the definition of the objects (vehicles) that the app uses. 
Here we only define the shape of the Vehicle class and the classes that inherit from Vehicle. The Domain layer has no dependencies.

2- Persistence:
Project type: C# Class Library. This layer contains the data files (json) and a class to work with those files. 
The class has methods that reads and writes to files. 
This layer has a dependency on Domain.

3- Application:
Project type: C# Class Library The Application layer contains the business logic for the app. 
The idea is that we can use the Domain and Application layer with any kind of project, so those are constants when the Presentation can change. 
It can be swapped with WPF, MVC etc...

This layer contains all the logic for the garage. All methods are contained in here. 
The Application layer has a dependency on Domain.

4- Presentation: 
Project type: C# Console App. 
Here we create a Menu class inside MenuSystem folder. 
In this class a modern menu is defined. The menu will only allow for selections via pressing up or down arrows. 
The user won't be able to type input unless it's necessary. 
The Presentation layer has a dependency on Application.
