REM build script for MyGet builds

set config=%1
if "%config%" == "" (
   set config=Release
)

REM Build
dotnet restore

REM Detect MSBuild 15.0 path
if exist "%programfiles(x86)%\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" (
    set msbuild="%programfiles(x86)%\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe"
)
if exist "%programfiles(x86)%\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\MSBuild.exe" (
    set msbuild="%programfiles(x86)%\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\MSBuild.exe"
)
if exist "%programfiles(x86)%\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\MSBuild.exe" (
    set msbuild="%programfiles(x86)%\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\MSBuild.exe"
)

REM *** NOTE *** When running this locally, use the versionS without quotes around %msbuild%.
REM              MyGet requires the quotes, but the command line doesn't like them.  Don't ask me...

REM call %msbuild% Manatee.Json.sln /p:Configuration="%config%" /m:1 /v:m /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false
call "%msbuild%" Manatee.Json.sln /p:Configuration="%config%" /m:1 /v:m /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false

REM Package

REM call "%msbuild%" Manatee.Json.sln /t:pack /p:Configuration=Release
call "%msbuild%" Manatee.Json.sln /t:pack /p:Configuration=Release
