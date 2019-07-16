@ECHO OFF
ECHO "Building solution/project file using batch."
ECHO.
SET PATH=C:\Windows\Microsoft.NET\Framework\v4.0.30319\

REM Set the solution to shortened path
SET SolutionPath="..\AssemblyReporter.sln"

ECHO Start Time - %Time%

MSbuild %SolutionPath% /p:Configuration=Release /p:Platform="Any CPU"

ECHO End Time - %Time%

SET /P Wait=Build Process Completed...