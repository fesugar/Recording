
@echo off

color 17
Title 生成CAB自解压独立程序

REM msbuild config

set config=Release

set outputdir=%~dp0bin\Release

set commonflags=/p:Configuration=%config%;AllowUnsafeBlocks=true /p:CLSCompliant=False



if %PROCESSOR_ARCHITECTURE%==x86 (

         set msbuild="%WINDIR%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe"

) else ( set msbuild="%WINDIR%\Microsoft.NET\Framework64\v4.0.30319\MSBuild.exe"

)


:begin
cls
Echo. 请选择需要的操作
Echo     1 . MouseRec_CSharp　
Echo     2 . MouseRec_VB 
Echo     3 . clean
Echo     4 . Exit 

Set /P Choice= 　　　　　请选择要进行的操作数字 ，然后按回车：
If not "%Choice%"=="" (
  If "%Choice%"=="4" exit
  If "%Choice%"=="3" call clean.bat && exit /b 1
  If "%Choice%"=="2" goto vb
  If "%Choice%"=="1" goto cs
)
::pause>nul
goto :begin

REM this script for MouseRec_VB
:vb
echo ---------------------------------------------------------------------

echo Building ...

%msbuild% "%~dp0MouseRec_VB\MouseRec_VB.vbproj" %commonflags% /tv:4.0 /p:TargetFrameworkVersion=v4.5 /p:Platform="Any Cpu" /p:OutputPath="%outputdir%"

if errorlevel 1 goto build-error

set pt=%~dp0
del bin\build\ /s /q
rd bin\build\ /s /q
xcopy NDP462.exe bin\build\ /i /f /v /h /y
xcopy NDP462.cmd bin\build\ /i /f /v /h /y
:: 基本上都安装了.NET 4 多余的，还容易误报 xcopy Release\run.exe bin\ /i /f /v /h /y
xcopy bin\Release\Io_Api.dll bin\build\ /i /f /v /h /y
xcopy bin\Release\Io_Api.pdb bin\build\ /i /f /v /h /y
xcopy bin\Release\MouseRec.exe bin\build\ /i /f /v /h /y
xcopy bin\Release\MouseRec.exe.config bin\build\ /i /f /v /h /y
xcopy bin\Release\MouseRec.pdb bin\build\ /i /f /v /h /y
xcopy bin\Release\MouseRec.xml bin\build\ /i /f /v /h /y
xcopy licenses.txt bin\build\ /i /f /v /h /y
xcopy readme.rtf bin\build\ /i /f /v /h /y
::xcopy MouseRec\Class_SystemHook.vb bin\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.Design.dll bin\build\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.dll bin\build\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.Fonts.dll bin\build\ /i /f /v /h /y
::xcopy Io_Api\Class_io_apis.cs bin\ /i /f /v /h /y

::合并DLL  EXE
"%pt%tools\ILMerge\ILMerge.exe"  /ndebug /target:winexe /targetplatform:v4 /out:"%pt%bin\build\newMouseRec.exe" /log "%pt%bin\build\MouseRec.exe" "%pt%bin\build\MetroFramework.Design.dll" "%pt%bin\build\MetroFramework.dll" "%pt%bin\build\MetroFramework.Fonts.dll" "%pt%bin\build\Io_Api.dll"

del bin\build\MouseRec.exe
del bin\build\MetroFramework.Design.dll
del bin\build\MetroFramework.dll
del bin\build\MetroFramework.Fonts.dll
del bin\build\Io_Api.dll
del bin\build\Io_Api.pdb
call "%pt%MouseRec.SED.bat" vb
goto rename

REM this script for MouseRec_CSharp
:cs
echo ---------------------------------------------------------------------

echo Building ...

%msbuild% "%~dp0MouseRec_CSharp\MouseRec_CSharp.csproj" %commonflags% /tv:4.0 /p:TargetFrameworkVersion=v4.5 /p:Platform="Any Cpu" /p:OutputPath="%outputdir%"

if errorlevel 1 goto build-error

set pt=%~dp0
del bin\build\ /s /q
rd bin\build\ /s /q
::xcopy NDP462.exe bin\ /i /f /v /h /y
::xcopy NDP462.cmd bin\ /i /f /v /h /y
xcopy bin\Release\Io_Api.dll bin\build\ /i /f /v /h /y
xcopy bin\Release\MouseRec.exe bin\build\ /i /f /v /h /y
xcopy bin\Release\MouseRec.exe.config bin\build\ /i /f /v /h /y
xcopy licenses.txt bin\build\ /i /f /v /h /y
xcopy readme.rtf bin\build\ /i /f /v /h /y
::xcopy MouseRec\Class_SystemHook.vb bin\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.Design.dll bin\build\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.dll bin\build\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.Fonts.dll bin\build\ /i /f /v /h /y
xcopy packages\MouseKeyHook.5.6.0\lib\net40\Gma.System.MouseKeyHook.dll bin\build\ /i /f /v /h /y
::xcopy Io_Api\Class_io_apis.cs bin\ /i /f /v /h /y

::合并DLL  EXE
"%pt%tools\ILMerge\ILMerge.exe"  /ndebug /target:winexe /targetplatform:v4 /out:"%pt%bin\build\newMouseRec.exe" /log "%pt%bin\build\MouseRec.exe" "%pt%bin\build\MetroFramework.Design.dll" "%pt%bin\build\MetroFramework.dll" "%pt%bin\build\MetroFramework.Fonts.dll" "%pt%bin\build\Io_Api.dll" "%pt%bin\build\Gma.System.MouseKeyHook.dll"

del bin\build\MouseRec.exe
del bin\build\MetroFramework.Design.dll
del bin\build\MetroFramework.dll
del bin\build\MetroFramework.Fonts.dll
del bin\build\Gma.System.MouseKeyHook.dll
del bin\build\Io_Api.dll
call "%pt%MouseRec.SED.bat" cs
goto rename


:build-error

echo Failed to compile...
exit /b 1

REM rename
:rename
if exist %pt%bin\build\newMouseRec.exe (rename %pt%bin\build\newMouseRec.exe MouseRec.exe) else (echo ERROR) 


iexpress /n %pt%MouseRec.SED

explorer %pt%bin\build\Setup
