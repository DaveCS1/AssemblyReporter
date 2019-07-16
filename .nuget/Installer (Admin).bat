@ECHO OFF

REM Batch Constants
SET CONSOLE_COLUMNS=%1
SET CONSOLE_LINES=%1

SET DEFAULT_CONSOLE_COLUMNS=70
SET DEFAULT_CONSOLE_LINES=30

SET DEFAULT_FILE_LOCATION=%~dpnx0
SET DEFAULT_FILE_DIRECTORY=%~dp0

REM Menu Constants
SET CONSOLE_RETURN_TO_MENU_TEXT=Press any Key to return to menu...
SET CONSOLE_EXIT_TEXT=Press any Key to exit...
SET CONSOLE_LINE_DIVIDER=________________________________________________________________

REM Installer Constants
SET INSTALLER_NAME=Installer

REM Application configuration
SET APP_NAME=NuGet
SET APP_FILE_EXTENSION=.exe
SET APP_FILE_NAME=%APP_NAME%%APP_FILE_EXTENSION%
SET APP_TITLE=%APP_NAME% Command Line Interface (CLI)

REM Installer configuration
SET INSTALLER_TITLE=%APP_TITLE% - %INSTALLER_NAME%
SET INSTALLATION_DESTINATION_DIRECTORY=%SystemRoot%\

REM Environment variable pairs
SET ENVIRONMENT_VARIABLE=%APP_NAME%
SET ENVIRONMENT_VALUE=%INSTALLATION_DESTINATION_DIRECTORY%\%APP_NAME%%APP_FILE_EXTENSION%

REM Online repository source
SET DOWNLOAD_URL=https://dist.nuget.org/win-x86-commandline/latest/nuget%APP_FILE_EXTENSION%

REM Source installer file/s
SET INSTALL_FILE_FULLPATH=%DEFAULT_FILE_DIRECTORY%%APP_FILE_NAME%
SET INSTALLER_DESTINATION_FILE_FULLPATH=%INSTALLATION_DESTINATION_DIRECTORY%\%APP_FILE_NAME%

REM Main Entry Point.
:MAIN_ENTRY_POINT

    REM Initialize console
    TITLE %INSTALLER_TITLE%

    REM Adjust window size
    MODE CON COLS=%DEFAULT_CONSOLE_COLUMNS% LINES=%DEFAULT_CONSOLE_LINES%

    REM Configure color
    COLOR 07 

    REM Initialize variables
    FOR /F "Tokens=1,2 delims=: " %%a IN ('MODE CON^|FINDSTR "Columns"') DO SET CONSOLE_COLUMNS=%%b
    FOR /F "Tokens=1,2 delims=: " %%a IN ('MODE CON^|FINDSTR "Lines"') DO SET CONSOLE_LINES=%%b

    REM The installer description.
    ECHO    ****************************************************************
    ECHO    ***     %INSTALLER_TITLE%       ***
    ECHO    ****************************************************************
    ECHO.
    ECHO    This installer will guide you through the process of installing,
    ECHO    modifying or removing the %APP_TITLE% on
    ECHO    this operating system.
    ECHO    %CONSOLE_LINE_DIVIDER%
    ECHO.
    
    REM Prepare the setup environment.
    GOTO :IS_ADMINISTRATOR

    REM Display options
    GOTO :DISPLAY_MENU
    ECHO.
GOTO :EXIT_INSTALLER

REM Download the latest version.
:APPLICATION_DOWNLOAD
    ECHO.
    ECHO    Downloading the latest version...
    ECHO    %CONSOLE_LINE_DIVIDER%
    ECHO.
    ECHO    Repository Source:
    ECHO    %DOWNLOAD_URL%
    ECHO.
    ECHO    Target:
    ECHO.
    ECHO    Path:
    ECHO    %DEFAULT_FILE_DIRECTORY%
    ECHO.
    ECHO    File Name:
    ECHO    %APP_FILE_NAME%
    ECHO    %CONSOLE_LINE_DIVIDER%
    ECHO.

    REM Downloads the file.
    CALL CURL --progress-bar %DOWNLOAD_URL% > "%INSTALL_FILE_FULLPATH%"
   
    ECHO.
    ECHO    Output:
    ECHO.
    ECHO    Path:
    ECHO    %DEFAULT_FILE_DIRECTORY%
    ECHO.
    ECHO    File Name:
    ECHO    %APP_FILE_NAME%
    ECHO    %CONSOLE_LINE_DIVIDER%
    ECHO.
    ECHO    The file has finished downloading!
    ECHO    %CONSOLE_RETURN_TO_MENU_TEXT%
    PAUSE >NUL
    CLS
GOTO :DISPLAY_MENU

REM The end of the file.
:EXIT_INSTALLER
    ECHO    %CONSOLE_LINE_DIVIDER%
    ECHO.
    ECHO    %CONSOLE_EXIT_TEXT%

    REM The following PAUSE command prevents it from showing its text.
    PAUSE >NUL
EXIT

REM When the file was not found.
:FILE_NOT_FOUND
    ECHO    Issue:
    ECHO    The setup file does not exist. Try downloading the file!
    ECHO.
    ECHO    Path:
    ECHO    "%INSTALL_FILE_FULLPATH%"
    ECHO.
    ECHO    Directory:
    ECHO    %DEFAULT_FILE_DIRECTORY%
    ECHO.
    ECHO    File Name:
    ECHO    %APP_FILE_NAME%
    ECHO    %CONSOLE_LINE_DIVIDER%
    ECHO.
    ECHO    %CONSOLE_RETURN_TO_MENU_TEXT%
    PAUSE >NUL
    CLS
GOTO :DISPLAY_MENU

REM Executes when the application is checked for updates.
:APPLICATION_UPDATE_CHECK

    REM Check if the file exists first
    IF NOT EXIST %DEFAULT_FILE_DIRECTORY%%APP_FILE_NAME% ( GOTO :FILE_NOT_FOUND )

    ECHO.
    ECHO    Checking for new updates...
    ECHO    %CONSOLE_LINE_DIVIDER%
    ECHO.
    CALL "%INSTALL_FILE_FULLPATH%" update -self
    ECHO    %CONSOLE_LINE_DIVIDER%
    ECHO.
GOTO :DISPLAY_MENU

REM Executes when the installer is choosen.
:INSTALL_APPLICATION

    REM Check if the file exists first
    IF NOT EXIST %DEFAULT_FILE_DIRECTORY%%APP_FILE_NAME% ( GOTO :FILE_NOT_FOUND )

    ECHO.
    ECHO    Installing...
    ECHO    %CONSOLE_LINE_DIVIDER%
    ECHO.
    
    ECHO    Copying file/s to install directory.
    ECHO.
    
    REM  Copy the file to the destination.
    ECHO F|XCOPY /S /Q /Y /F "%INSTALL_FILE_FULLPATH%" "%INSTALLER_DESTINATION_FILE_FULLPATH%*"
    ECHO.
   
    ECHO    Registering the environment variables to the system.
    ECHO.
    ECHO    Name:
    ECHO    %ENVIRONMENT_VARIABLE%
    ECHO.
    ECHO    Value:
    ECHO    %ENVIRONMENT_VALUE%
    ECHO.
    SETX /M "%ENVIRONMENT_VARIABLE%" "%ENVIRONMENT_VALUE%"
    ECHO.
    ECHO    Installation has completed.
    ECHO.
GOTO :EXIT_INSTALLER

REM Executes when the uninstall is choosen.
:UNINSTALL_APPLICATION
    ECHO.
    ECHO    Uninstalling...
    ECHO    %CONSOLE_LINE_DIVIDER%
    ECHO.

    REM Delete file from folder. Unregister environment variable path.
    ECHO    Removing the file contents.
    ECHO.

    ECHO    Directory:
    ECHO    %INSTALLATION_DESTINATION_DIRECTORY%
    ECHO.

    ECHO    File Name:
    ECHO    %APP_FILE_NAME%
    ECHO.

    DEL /Q "%INSTALLER_DESTINATION_FILE_FULLPATH%"

    ECHO    Unregistering the environment variables.
    ECHO.
    ECHO    Name:
    ECHO    %ENVIRONMENT_VARIABLE%
    ECHO.
    REG DELETE "HKLM\SYSTEM\CurrentControlSet\Control\Session Manager\Environment" /F /V %ENVIRONMENT_VARIABLE%
    ECHO.
    ECHO    The uninstall has finished.

GOTO :EXIT_INSTALLER

REM Output the options menu.
:DISPLAY_MENU
    ECHO.
    ECHO                              Main Menu
    ECHO.

    REM Add: Download option

    ECHO    0   -   Install.
    ECHO    1   -   Uninstall.
    ECHO    2   -   Check for new updates.
    ECHO    3   -   Download the latest version.
    ECHO    4   -   Exit. 
    ECHO.

    REM The task to perform.
    SET /P ChoiceResult="Enter your choice (#): "

    REM Clear the console.
    CLS

    REM Execute the choosen function.
    IF %ChoiceResult%==0 ( GOTO :INSTALL_APPLICATION )
    IF %ChoiceResult%==1 ( GOTO :UNINSTALL_APPLICATION)
    IF %ChoiceResult%==2 ( GOTO :APPLICATION_UPDATE_CHECK )
    IF %ChoiceResult%==3 ( GOTO :APPLICATION_DOWNLOAD ) 
    IF %ChoiceResult%==4 ( EXIT )

GOTO :EXIT_INSTALLER

REM Detect whether this program is run as an administrator function.
:IS_ADMINISTRATOR
    ECHO    Detecting if this program is run as administrator...

    REM Validate the administrator permissions
    NET SESSION >NUL 2>&1

    REM Handle the validation result
    IF %ErrorLevel% == 0 (    
    ECHO.
    ECHO    Success: The elevated permissions are detected!
    ECHO    %CONSOLE_LINE_DIVIDER%
    ECHO.
    GOTO :DISPLAY_MENU
    ) ELSE (
    ECHO.
    COLOR 47
    ECHO    Error: The installer needs to be run as an administrator!
    GOTO :EXIT_INSTALLER
    )
:EOF