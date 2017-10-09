# Sync VR App

Sync VR is an demonstration of virtual reality technology in the comercial space.


## Requirements
The following is required to build the project.

* [postgresql] v10
* [unity] v2017.1.1f1 (5d30cf096e79) Personal

## Instructions

### Windows

#### Server
First install [postgresql] to your local computer and set user password to something simple like `1234`. 

Add the [postgresql] installation path to your [win-env-variables]. Now you should be able to run the installed command line tools from any terminal.

Before running any comands, run the following to ensure proper console code page.

```
chcp 1252
```

Run `win-build.bat` to automatically build the database which can be found under `/Server/sql/win-build.bat`. 

## Unix
...

### Server
...

[//]: # (These are reference links used in the body of this note and get stripped out when the markdown processor does its job. There is no need to format nicely because it shouldn't be seen. Thanks SO - http://stackoverflow.com/questions/4823468/store-comments-in-markdown-syntax)

[postgresql]: <https://www.postgresql.org/>
[win-env-variables]: <https://www.computerhope.com/issues/ch000549.htm
[unity]: <https://unity3d.com/>
