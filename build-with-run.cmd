REM Visual studio needs to be installed.
@echo off

color 17
Title Building cab self-extracting package with dotnet462

if exist bin\Release\MouseRec_run.exe (echo pass) else (exit)

:begin
cls
ECHO.
ECHO This package must install visual studio and generate a compiled project
ECHO.
Echo. Please select the number you want ?
Echo     1 . self-extracting MouseRec_CSharp
Echo     2 . self-extracting MouseRec_VB
Echo     3 . Exit 

Set /P Choice=        Select the number and press enter:
If not "%Choice%"=="" (
  If "%Choice%"=="3" exit
  If "%Choice%"=="2" goto vb
  If "%Choice%"=="1" goto cs
)
::pause>nul
goto :begin

REM this script for MouseRec_VB
:vb
echo ---------------------------------------------------------------------


set pt=%~dp0
del bin\build\ /s /q
rd bin\build\ /s /q
xcopy NDP462.exe bin\build\ /i /f /v /h /y
xcopy NDP462.cmd bin\build\ /i /f /v /h /y
xcopy bin\Release\Io_Api.dll bin\build\ /i /f /v /h /y
xcopy bin\Release\Io_Api.pdb bin\build\ /i /f /v /h /y
xcopy bin\Release\MouseRec.exe bin\build\ /i /f /v /h /y
xcopy bin\Release\MouseRec.exe.config bin\build\ /i /f /v /h /y
xcopy bin\Release\MouseRec_run.exe bin\build\ /i /f /v /h /y
xcopy bin\Release\MouseRec.pdb bin\build\ /i /f /v /h /y
xcopy bin\Release\MouseRec.xml bin\build\ /i /f /v /h /y
xcopy Notes.txt bin\build\ /i /f /v /h /y
xcopy LICENSE bin\build\ /i /f /v /h /y
xcopy readme.rtf bin\build\ /i /f /v /h /y
if exist bin\Release\Up.exe ( xcopy bin\Release\Up.exe bin\build\ /i /f /v /h /y )
::xcopy MouseRec\Class_SystemHook.vb bin\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.Design.dll bin\build\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.dll bin\build\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.Fonts.dll bin\build\ /i /f /v /h /y
::xcopy Io_Api\Class_io_apis.cs bin\ /i /f /v /h /y

::INTO DLL  EXE
"%pt%tools\ILMerge\ILMerge.exe"  /ndebug /target:winexe /targetplatform:v4 /out:"%pt%bin\build\newMouseRec.exe" /log "%pt%bin\build\MouseRec.exe" "%pt%bin\build\MetroFramework.Design.dll" "%pt%bin\build\MetroFramework.dll" "%pt%bin\build\MetroFramework.Fonts.dll" "%pt%bin\build\Io_Api.dll"

del bin\build\MouseRec.exe
del bin\build\MetroFramework.Design.dll
del bin\build\MetroFramework.dll
del bin\build\MetroFramework.Fonts.dll
del bin\build\Io_Api.dll
del bin\build\Io_Api.pdb
call "%pt%MouseRec.SED-with-run" vb
goto rename

REM this script for MouseRec_CSharp
:cs
echo ---------------------------------------------------------------------

set pt=%~dp0
del bin\build\ /s /q
rd bin\build\ /s /q
::xcopy NDP462.exe bin\ /i /f /v /h /y
::xcopy NDP462.cmd bin\ /i /f /v /h /y
xcopy bin\Release\Io_Api.dll bin\build\ /i /f /v /h /y
xcopy bin\Release\MouseRec.exe bin\build\ /i /f /v /h /y
xcopy bin\Release\MouseRec.exe.config bin\build\ /i /f /v /h /y
xcopy bin\Release\MouseRec_run.exe bin\build\ /i /f /v /h /y
xcopy Notes.txt bin\build\ /i /f /v /h /y
xcopy NDP462.cmd bin\build\ /i /f /v /h /y
xcopy NDP462.exe bin\build\ /i /f /v /h /y
xcopy LICENSE bin\build\ /i /f /v /h /y
xcopy readme.rtf bin\build\ /i /f /v /h /y
if exist bin\Release\Up.exe ( xcopy bin\Release\Up.exe bin\build\ /i /f /v /h /y )
::xcopy MouseRec\Class_SystemHook.vb bin\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.Design.dll bin\build\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.dll bin\build\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.Fonts.dll bin\build\ /i /f /v /h /y
xcopy packages\MouseKeyHook.5.6.0\lib\net40\Gma.System.MouseKeyHook.dll bin\build\ /i /f /v /h /y
::xcopy Io_Api\Class_io_apis.cs bin\ /i /f /v /h /y

::INTO DLL  EXE
"%pt%tools\ILMerge\ILMerge.exe"  /ndebug /target:winexe /targetplatform:v4 /out:"%pt%bin\build\newMouseRec.exe" /log "%pt%bin\build\MouseRec.exe" "%pt%bin\build\MetroFramework.Design.dll" "%pt%bin\build\MetroFramework.dll" "%pt%bin\build\MetroFramework.Fonts.dll" "%pt%bin\build\Io_Api.dll" "%pt%bin\build\Gma.System.MouseKeyHook.dll"

del bin\build\MouseRec.exe
del bin\build\MetroFramework.Design.dll
del bin\build\MetroFramework.dll
del bin\build\MetroFramework.Fonts.dll
del bin\build\Gma.System.MouseKeyHook.dll
del bin\build\Io_Api.dll
call "%pt%MouseRec.SED-with-run" cs
goto rename

REM rename
:rename
if exist %pt%bin\build\newMouseRec.exe (rename %pt%bin\build\newMouseRec.exe MouseRec.exe) else (echo ERROR) 

if "%PROCESSOR_ARCHITECTURE%" == "AMD64" (
   cmd /c %SystemRoot%\SysWOW64\iexpress.exe /n %pt%bin\MouseRec.SED
) ELSE IF "%PROCESSOR_ARCHITEW6432%" == "AMD64" (
   cmd /c %SystemRoot%\SysWOW64\iexpress.exe /n %pt%bin\MouseRec.SED
) ELSE (
   cmd /c %SystemRoot%\system32\iexpress.exe /n %pt%bin\MouseRec.SED
)

cmd /c explorer %pt%bin\build\Setup
