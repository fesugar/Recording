@echo off
color 17
Title ����CAB�Խ�ѹ��������
:begin
cls
Echo. ��ѡ����Ҫ�Ĳ���
Echo     1 MouseRec_CSharp��
Echo     2 MouseRec_VB 
Echo     3 Exit 

Set /P Choice= ������������ѡ��Ҫ���еĲ������� ��Ȼ�󰴻س���
If not "%Choice%"=="" (
  If "%Choice%"=="3" exit
  If "%Choice%"=="2" goto vb
  If "%Choice%"=="1" goto cs
)
pause>nul
goto :begin

REM this script for MouseRec_VB
:vb
set pt=%~dp0
del bin\ /s /q
rd bin\ /s /q
xcopy NDP462.exe bin\ /i /f /v /h /y
xcopy NDP462.cmd bin\ /i /f /v /h /y
:: �����϶���װ��.NET 4 ����ģ��������� xcopy Release\run.exe bin\ /i /f /v /h /y
xcopy Release\Io_Api.dll bin\ /i /f /v /h /y
xcopy Release\Io_Api.pdb bin\ /i /f /v /h /y
xcopy Release\MouseRec.exe bin\ /i /f /v /h /y
xcopy Release\MouseRec.exe.config bin\ /i /f /v /h /y
xcopy Release\MouseRec.pdb bin\ /i /f /v /h /y
xcopy Release\MouseRec.xml bin\ /i /f /v /h /y
xcopy licenses.txt bin\ /i /f /v /h /y
xcopy readme.rtf bin\ /i /f /v /h /y
::xcopy MouseRec\Class_SystemHook.vb bin\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.Design.dll bin\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.dll bin\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.Fonts.dll bin\ /i /f /v /h /y
::xcopy Io_Api\Class_io_apis.cs bin\ /i /f /v /h /y

::�ϲ�DLL  EXE
"%pt%ILMerge\ILMerge.exe"  /ndebug /target:winexe /targetplatform:v4 /out:%pt%bin\newMouseRec.exe /log %pt%bin\MouseRec.exe %pt%bin\MetroFramework.Design.dll %pt%bin\MetroFramework.dll %pt%bin\MetroFramework.Fonts.dll %pt%bin\Io_Api.dll

del bin\MouseRec.exe
del bin\MetroFramework.Design.dll
del bin\MetroFramework.dll
del bin\MetroFramework.Fonts.dll
del bin\Io_Api.dll
del bin\Io_Api.pdb
call %pt%MouseRec.SED.bat vb
goto build

REM this script for MouseRec_CSharp
:cs
set pt=%~dp0
del bin\ /s /q
rd bin\ /s /q
::xcopy NDP462.exe bin\ /i /f /v /h /y
::xcopy NDP462.cmd bin\ /i /f /v /h /y
xcopy Release\Io_Api.dll bin\ /i /f /v /h /y
xcopy Release\MouseRec.exe bin\ /i /f /v /h /y
xcopy Release\MouseRec.exe.config bin\ /i /f /v /h /y
xcopy licenses.txt bin\ /i /f /v /h /y
xcopy readme.rtf bin\ /i /f /v /h /y
::xcopy MouseRec\Class_SystemHook.vb bin\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.Design.dll bin\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.dll bin\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.Fonts.dll bin\ /i /f /v /h /y
xcopy packages\MouseKeyHook.5.6.0\lib\net40\Gma.System.MouseKeyHook.dll bin\ /i /f /v /h /y
::xcopy Io_Api\Class_io_apis.cs bin\ /i /f /v /h /y

::�ϲ�DLL  EXE
"%pt%ILMerge\ILMerge.exe"  /ndebug /target:winexe /targetplatform:v4 /out:%pt%bin\newMouseRec.exe /log %pt%bin\MouseRec.exe %pt%bin\MetroFramework.Design.dll %pt%bin\MetroFramework.dll %pt%bin\MetroFramework.Fonts.dll %pt%bin\Io_Api.dll %pt%bin\Gma.System.MouseKeyHook.dll

del bin\MouseRec.exe
del bin\MetroFramework.Design.dll
del bin\MetroFramework.dll
del bin\MetroFramework.Fonts.dll
del bin\Gma.System.MouseKeyHook.dll
del bin\Io_Api.dll
call %pt%MouseRec.SED.bat cs
goto build

REM build
:build
if exist %pt%bin\newMouseRec.exe (rename %pt%bin\newMouseRec.exe MouseRec.exe) else (echo ERROR) 


iexpress /n %pt%MouseRec.SED

explorer %pt%bin\Setup
