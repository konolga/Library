# Library
C# and xaml application for Windows 8.

In Library there are 2 categories: books and journals. Each category has 3 defferent genres. User can take item from library and return it. 


UI explanation:

![Alt text](relative/path/to/img.jpg?raw=true "Title")

Solution contains 2 files:

## Main page contains two parts. 

### 1. "Login" for existing users.

Username: user

Password: user

![Alt text](relative/path/to/img.jpg?raw=true "Login")

### 2. "Sing up" for new users.

![Alt text](relative/path/to/img.jpg?raw=true "SingUp")

## Internal Library page contains 4 parts. 

### 1. Search

![Alt text](relative/path/to/img.jpg?raw=true "Search")

### 2. Items found in Library

![Alt text](relative/path/to/img.jpg?raw=true "Library")

### 3. Items taken to read

![Alt text](relative/path/to/img.jpg?raw=true "TakenItems")

### 4. Control panel

![Alt text](relative/path/to/img.jpg?raw=true "Menu")

# Implementation

## SubProject ClassLibarary
Classes Book and Journal are inherrited from AbstractItem class. In future other items can be easy added to the library, for example Audio.

IManageLibrary interface to manage library. Class ItemCollection is implementing all methods from IManageLibrary interface.
LibraryManager is the class for Library itself, which inherits ItemCollection with all methods.


The same logic for users. User is the abstract class for all users. In future other users can be easy added to the library, for example admin.

IManageUsers interface to manage users. Class UserCollection is implementing all methods from IManageUsers interface.
Class UserManager has data about all current users. Also UserManager inherits UserCollection with all methods.

![Alt text](relative/path/to/img.jpg?raw=true "ClassLibarary")

## SubProject Libarary

Created to manage UI for main and user's pages and handle all related events.



