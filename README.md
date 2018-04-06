# Library
C# and xaml application for Windows 8.

In Library there are 2 categories: books and journals. Each category has 3 defferent genres. User can take item from library and return it. 


UI explanation:

Solution contains 2 files:

## Main page contains two parts. 

### 1. "Login" for existing users.

Username: user

Password: user

![Alt text](https://github.com/olgush/Library/blob/master/Library/Assets/screenshot1.JPG "Login")

### 2. "Sing up" for new users.

![Alt text](https://github.com/olgush/Library/blob/master/Library/Assets/screenshot2.JPG "SingUp")

## Internal Library page contains 4 parts. 

### 1. Search

![Alt text](https://github.com/olgush/Library/blob/master/Library/Assets/screenshot3.JPG "Search")

### 2. Items found in Library

![Alt text](https://github.com/olgush/Library/blob/master/Library/Assets/screenshot4.JPG "Library")

### 3. Items taken to read

![Alt text](https://github.com/olgush/Library/blob/master/Library/Assets/screenshot5.JPG "TakenItems")

### 4. Control panel

![Alt text](https://github.com/olgush/Library/blob/master/Library/Assets/screenshot6.JPG "Menu")

# Implementation

## SubProject ClassLibarary
Classes Book and Journal are inherrited from AbstractItem class. In future other items can be easy added to the library, for example Audio.

IManageLibrary interface to manage library. Class ItemCollection is implementing all methods from IManageLibrary interface.
LibraryManager is the class for Library itself, which inherits ItemCollection with all methods.


The same logic for users. User is the abstract class for all users. In future other users can be easy added to the library, for example admin.

IManageUsers interface to manage users. Class UserCollection is implementing all methods from IManageUsers interface.
Class UserManager has data about all current users. Also UserManager inherits UserCollection with all methods.

![Alt text](https://github.com/olgush/Library/blob/master/Library/Assets/screenshot7.JPG "ClassLibarary")

## SubProject Libarary

Created to manage UI for main and user's pages and handle all related events.



