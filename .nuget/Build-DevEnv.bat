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
SET CONSOLE_TITLE=Console Solution Compiler

SET MSBUILD_PATH=%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
SET CSC_PATH=%windir%\Microsoft.NET\Framework\v4.0.30319\csc.exe

SET SOLUTION_PATH="..\AssemblyReporter.sln"
SET SOLUTION_COMPILE_OUTPUT="..\Output\"
SET DEVENV="C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\devenv.com"

REM Initialize
:MAIN_ENTRY_POINT
    TITLE %CONSOLE_TITLE% 

    REM Adjust window size
    MODE CON COLS=%DEFAULT_CONSOLE_COLUMNS% LINES=%DEFAULT_CONSOLE_LINES%

    REM Configure color
    COLOR %DEFAULT_CONSOLE_FOREGROUND_COLOR%%DEFAULT_CONSOLE_BACKGROUND_COLOR% 

    REM Add code here...
    ECHO Console Solution Compiler
    ECHO.
    ECHO Solution Path: %SOLUTION_PATH%
    ECHO.
    ECHO Output Path: %SOLUTION_COMPILE_OUTPUT%
    ECHO.

    Echo Start Time - %Time%
    ECHO.
    ECHO Solution:
    ECHO %SOLUTION_PATH% 
    ECHO.
    ECHO Compiling the solution... 

    %DEVENV% %SOLUTION_PATH% /rebuild release /projectconfig Release /out "CompilerResult.log"

    ECHO End Time - %Time%
    SET /P Wait=Build Process Completed...
    SET BUILD_STATUS=%ERRORLEVEL% 

    ECHO Press any Key to exit...
    PAUSE >NUL
   
if %BUILD_STATUS%==0 
(
    ECHO Build succeeded.
    ECHO.
    ECHO Press any Key to exit...
    PAUSE >NUL
)
else (
    ECHO Failed build! 
    ECHO.
    ECHO Press any Key to exit...
    PAUSE >NUL
	EXIT /b %BUILD_STATUS% 
)

    ECHO Press any Key to exit...
    PAUSE >NUL
GOTO :EOF