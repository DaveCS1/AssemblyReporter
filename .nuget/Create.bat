@ECHO OFF

REM CONSTANTS

REM Dimensions
SET DEFAULT_CONSOLE_COLUMNS=100
SET DEFAULT_CONSOLE_LINES=30

REM Colors
SET DEFAULT_CONSOLE_FOREGROUND_COLOR=1
SET DEFAULT_CONSOLE_BACKGROUND_COLOR=E

REM The batch file name without the extension.
SET BATCH_FILE_NAME=%~n0

REM The batch file extension.
SET BATCH_FILE_EXTENSION=%~x0

REM The batch file including the extension.
SET BATCH_FILE_FULLNAME=%~n0%~x0

REM The directory of the batch file.
SET BATCH_FILE_DIRECTORY=%~dp0

REM The full path to the batch directory and the file name.
SET BATCH_FILE_FULLPATH=%~dpnx0

REM The current working directory.
SET WORKING_DIRECTORY=%cd%

REM Window Title
SET CONSOLE_TITLE=NuGet Package Creator

REM Initialize
:MAIN_ENTRY_POINT
    TITLE %CONSOLE_TITLE%

    REM Adjust window size
    MODE CON COLS=%DEFAULT_CONSOLE_COLUMNS% LINES=%DEFAULT_CONSOLE_LINES%

    REM Configure color
    COLOR %DEFAULT_CONSOLE_FOREGROUND_COLOR%%DEFAULT_CONSOLE_BACKGROUND_COLOR%

    REM Add code here...
    ECHO.
    ECHO This wizard will help you create a NuGet package.
    ECHO.

    CALL %NuGet% spec AssemblyReport

    ECHO.
    ECHO Press any Key to exit...
    PAUSE >NUL

REM Exit the console by going to the end of the file.
GOTO :EOF