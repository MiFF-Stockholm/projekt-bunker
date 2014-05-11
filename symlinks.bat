@ECHO OFF

ECHO Symlinks creates a link between two folders. 
ECHO The folders must be on the same hard drive.
ECHO The disk must be NTFS.

ECHO.
ECHO Exempel: C:\Unity\Assets get a link to C:\Dropbox\Unity\Assets
ECHO "C:\Unity\Assets" is the start location "Start". 
ECHO And "C:\Dropbox\Unity\Assets" is the target location "target".
ECHO.
ECHO A little tip: YOU CAN NOT USE CTRL + V BUY YOU CAN RIGHT CLICK AND COPY. 
ECHO.
ECHO Type the Start locations path.
ECHO For example: C:\Unity
SET /P start=Start:
ECHO.
ECHO Type the name of the link.
ECHO For example: Assets
SET /P namn=Lenkens namn:
ECHO.
ECHO Type the Target locations path.
ECHO For example: C:\Dropbox\Unity\Assets
SET /P target=Target:
ECHO.
MKLINK /J "%start%\%namn%" "%target%"
ECHO.

ECHO Press any key to exit...
PAUSE>null
