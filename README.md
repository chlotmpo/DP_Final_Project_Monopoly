# Monopoly Game in C# 
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

![image](https://user-images.githubusercontent.com/76529865/148659551-6f967770-dfce-4031-9ce2-2eb394ba799a.png)
![image](https://user-images.githubusercontent.com/76529865/148659552-445a9421-46d7-4055-b7e7-31ca7cca255f.png)


**PLAYER TURN** :
Now the game is initialized. Now the players’ turn will begin. Here is how a typical turn is played for a player. 
The player rolls the dice and advanced the number of corresponding cells. 

![image](https://user-images.githubusercontent.com/76529865/148659603-09ca291a-62f8-47d0-ac61-4b845c0b75c6.png)

If the player has not made a doubled dice, his turn ends. Otherwise, he plays again. After 3 doubled dice in a row, he goes to prison

Message when the player made a doubled dice :

![image](https://user-images.githubusercontent.com/76529865/148659612-fcb699b5-d937-4ec4-9e53-a33b382ff521.png)

Message when the player made 3 doubled dice in a row : 

![image](https://user-images.githubusercontent.com/76529865/148659620-b6874604-b216-4977-9c96-eeef03e54d00.png)

If the player lands on a **PROPERTY CELL** : The property informations are presented to the player. The player decides whether to buy it or not. The program then verifies that it has enough money and, if necessary, the property is sold and belongs to him. 

![image](https://user-images.githubusercontent.com/76529865/148659667-84536c5e-f9e4-4fe2-981d-4e44cdfe1f39.png)

A message is then sent to all observers (players).

![image](https://user-images.githubusercontent.com/76529865/148659682-c99bbb8a-be1b-4f2d-b966-22039d06e650.png)

If the player lands on a **CHANCE CELL or a COMMUNITY CHEST CELL** : A random number is then generated. The program then displays the corresponding message. These cards can bring money, take it out, take the player to jail, get the player out of jail, or do nothing. 

![image](https://user-images.githubusercontent.com/76529865/148659698-e942a688-be41-4c80-a352-1284c94a4f6d.png)

![image](https://user-images.githubusercontent.com/76529865/148659699-bbfed970-4520-4b77-8a2a-54e3dc36d2dd.png)

If the player lands on the **JAIL CELL** : He is simply visiting the prison. The program displays the current situation of the jail, if some players are in it or not. 

![image](https://user-images.githubusercontent.com/76529865/148659707-9f55165d-ef53-486d-99a3-742317f5b194.png)

If the player lands on the **GO TO JAIL CELL** : He goes immediatly to jail. 

![image](https://user-images.githubusercontent.com/76529865/148659726-e92f1be2-c750-4fe3-9aa9-2f7466039ae7.png)

At the end of each turn, the players’ situation is displayed. 

![image](https://user-images.githubusercontent.com/76529865/148659735-4284f552-f78c-4202-8482-5a4041e8d14f.png)

**SPECIAL SITUATIONS** :

When a player **IS IN JAIL** : He’s going to roll the dice when it’s his turn. If he gets a double, then he can get out. Otherwise, he doesn’t move forward and is patient in prison. After 3 truns without doubles, he goes out in any case. 

![image](https://user-images.githubusercontent.com/76529865/148659754-8cec2ff8-b6da-41e6-923e-eb4fab19124c.png)


When a player **OWNED SEVERAL RAILROADS** : If a player arrives at a railroad already purchased by a player and the latter has several railroads then the amount to be paid will be multiplied by the number of stations owned.

![image](https://user-images.githubusercontent.com/76529865/148659762-e6a74ef1-c2c3-485f-a5a3-16d7941136a6.png)


When a player **OWNED ALL THE PROPERTIES OF THE SAME FAMILY** : If a player has all the properties of the same color or all the companies then if a player passes on one of these properties, the price to pay will be doubled. 

![image](https://user-images.githubusercontent.com/76529865/148659772-9c886cd2-4b17-4ad4-80a2-e4850cd6acb2.png)


**A PLAYER LOSES** :
A player loses the game when he does not have enough money to pay another player, or a cell on which he landed. He is then removed from the game and all the properties he bought are put back into the game. 

![image](https://user-images.githubusercontent.com/76529865/148659782-81f29863-5de5-41ab-84d2-53ae0144f61e.png)


**WIN THE GAME**:
To win the game, one player muste have ruined all the others. When all the others have no more money and he is the last player to compete, he is then declared the winner. The following message appears in the console. The game is over.

![image](https://user-images.githubusercontent.com/76529865/148659797-d1743ef2-7926-43ed-8605-d5ec4a562384.png)








