# s33577-apbd-cw2-OOP-s33577
A console application for managing Equipment and rentals. Biult for APBD tutorial 2.


## How to Run
```
  1. git clone https://github.com/s33577/s33577-apbd-cw2-OOP-s33577.git
  2. cd s33577-apbd-cw2-OOP-s33577/ConsoleApp1/ConsoleApp1
  3. dotnet run
```

## What the System does
Interactive console menu with specific options:

  1. Add users (Students or Employees)
  2. Add equipment
  3. View all equipment and their availability status
  4. View all avaiable equipment
  5. View All users
  6. Mark equipment as unavaiable
  7. Rent equipment
  8. Return equipment
  9. View Active rentals for a specifc user
  10. View Overdue rentals
  11. Overall Raport
  12. QUIT (Terminate Session)

After Running the code the Console UI should look like this:
```
Equipment Rental System
**** MENU ****
1. Add user
2. Add equipment
3. List all equipment
4. List all Avaiable equipment
5. List all users
6. Mark equipment as unavailable
RENTALS
7. Rent equipment
8. Return equipment
9. Show active rentals for a user
10. Show overdue rentals
REPORTS
11. Summary Report
END Session
13. QUIT
Enter an option:
```

## Project Structure
ConsoleApp1/
  Program.cs -> Console menu and user interaction
  
  RentalSystem.cs -> All system logic
  
  Rental.cs -> Domain object
  
  User.cs -> Abstract class for all users
  
  Student.cs -> Student class with max 2 active rentals
  
  Employee.cs -> Employee class with max 5 active rentals
  
  Equipment.cs -> Abstract class for all equipment
  
  Laptop.cs -> Laptop class viewed as an equipment
  
  Phone.cs -> Phone class viewed as an equipment
  
  TV.cs -> TV class viewed as an equipment

## Design 

```Program.cs``` Only handels input from the user and uses Object ```_service``` to hadel user inputs with RentalSystem methods.

```Rental.cs``` Calculates and handles marking for return option on a single rental event.

```User``` An Abstract class working as an blueprint for classes ```Student``` and ```Employee```. 

```Equipment``` An Abstract class working as an blueprint for classes ```Laptop```, ```Phone```, ```Tv```.

```RentalSystem``` Main logic for the program. It holds three internal lists users, inventroy, and rentals. Every business rule is enforced here: checking availability, checking the users active rental count against their limit, returning items, calculating the final system report and all other methods mentioned in the console menu. It does not require to change Object user and Equipment since it works against their base type thathen then concrete subclasses.

## Business Rules
Student max 2 active rentals
Employee max 5 active rentals
Late penalty rate
Unavailable quipment cannot be rented




  

