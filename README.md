# LibsysGrp3
A library application for school project. Made by group 3 (Fredrik Molén, Elchin Jabbari, Aata Miettinen, Simon Järnström, Firas Hanna).

It's a complete graphical library-application system with Users, Librarians and Cheif Librarians. Where users can search and borrow books and librarians have an interface to orginize the library and return books. 

![Screenshot](https://github.com/mol1987/LibsysGrp3/blob/master/Database/LibsysGrp3WPF.png)
## Installation

* Use the 'reconstruct_tables.sql' script to recreate the whole Microsoft SQL database with data and stored procedures.


* Add a 'App.config' file to the LibsysGrp3WPF project. And add the correct database info to the file, in the connectionString. Add this to the file: 

```C#
<?xml version="1.0"?>
<configuration>
  <connectionStrings>
    <add name="LibsysAzure"
    connectionString="Data Source=;Initial Catalog=;User Id=;Password="/>
  </connectionStrings>
</configuration>
```
![App.config](https://github.com/mol1987/LibsysGrp3/blob/master/Database/Appconfig-how.png)
## Usage
Press to login button to the uppermost right and login with:
```
User:
Personummer: 198005051234
Lösenord: 1234

Librarian:
Personummer: 198012121212
Lösenord: 123

Cheif Librarian:
Personummer: 198009079555
Lösenord: test
```

## Technical info

Written in C# and uses the WPF API with the MVVM pattern.
Uses Microsoft SQL for the Database.
Unit tests are done with Xunit.
