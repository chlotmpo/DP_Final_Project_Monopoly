# DP_Final_Project_Monopoly - Monopoly Game in C# 
Monopoly is a real-estate board game for two to eight players. The player's goal is to remain financially solvent while forcing opponents into bankruptcy by buying and developing pieces of property. Bankruptcy results in elimination from the game.
We implemented a simplified version of monopoly in C#, through common software development practices. The rest of this document details the implementation of our project.

## Table of Content 
1. [Design Implementation](#design_implementation)
2. [UML and Sequence diagrams](#uml_sequence_diag)
3. [Sequence of the game](#sequence_game)

## Design Implementation  <a name="design_implementation"></a>
During the analysis of the subject and the problems that could be encountered, we determined 3 situations for which the implementation of a design pattern proved to be relevant. 

### Singleton Pattern
**Situation / Problem**: As part of a monopoly game, there are several players but a single game board on which all the players play their turn. In our programm C#, we must therefore ensure that only one game board will be created since all players in a game have to play n the same one. 

**Solution** : The singleton pattern is a software design pattern that restricts the instantiation of a class to one « single » instance. This is useful when exactly one object is needed to coordinate actions accross the system. 
So we decided to implement the singleton pattern in a class called "_BoardSingleton_" which corresponds to the game board object. 

![image](https://user-images.githubusercontent.com/76529865/148659298-50329d36-82b4-4fc8-a6dc-970970cf0567.png)

### Factory Pattern
**Situation / Problem** : The monopoly game board consists of 40 cells, each of which is different. These boxes are grouped into 6 different types. Properties, chance cells, community chest cells, jail, tax cells and other special cells. All cells are characterized by a position in the board but have different properties, methods and behaviors. 

**Solution** : The factory method pattern is a creational pattern that uses factory methods to deal with the problem of creating objects without having to specify the exact class of the object that will be created. This is done by creating objects by calling a factory method—either specified in an interface and implemented by child classes, or implemented in a base class and optionally overridden by derived classes—rather than by calling a constructor.

We decided to implement this factory pattern by creating an interface "_ICell_" from which derives the classes "_Property_", "_Chance_", "_CommunityChest_", "_Jail_", "_Tax_" and " _Special_" then by creating an abstract class "_CellCreator_" which will lead to the creation of the cells according to their types (the latter being defined in an enumeration) and a class "_CellFactory_", which derives from the abstract class and which creates the objects corresponding to the types of the cells. 

![image](https://user-images.githubusercontent.com/76529865/148659442-6eb589e5-f0a6-46ad-9273-d923841b86b2.png)

### Observer Pattern
**Situation / Problem** : One of the hallmarks of monopoly is buying properties. When a player arrives on a property square, if it’s available, he can then buy it and become the owner. Players should therefore be aware when properties are purchased by a player and know that they will  have to pay if they pass by. 

**Solution** : The observer pattern is a software design pattern in which an object, named the subject, maintains a list of its dependents, called observers, and notifies them automatically of any state changes, usually by calling one of their methods.

So we decided to implement this design pattern to inform all players who wait their turn as soon as a player has bought a property. They are therefore aware of the situation and know that his property is no longer for sale and that they will have to pay a debt on the spot. We implemented an abstract class "_Abstract Observer_", from which derives the class "_Player_", the players are the observers. The "_Property_" class has a list of observers in attributes (which corresponds to all the players in the game) and methods to define when to warn the observers.

![image](https://user-images.githubusercontent.com/76529865/148659352-192c47bc-4205-41b3-92bc-96f7e8842f12.png)

## UML and Sequence diagrams <a name="uml_sequence_diag"></a>

## Squence of the game <a name="sequence_game"></a>
Here is a demonstration of a monopoly game for 4 players from our solution. 

When you launch the program, the following window opens : We press « Y » to play. We will then have to choose the number of players and their names.

![image](https://user-images.githubusercontent.com/76529865/148659498-8be3ebca-ce45-462f-9c85-102bc761fb89.png)
![image](https://user-images.githubusercontent.com/76529865/148659510-696d4763-7b95-4aee-b4d3-7459c7608a8e.png)







