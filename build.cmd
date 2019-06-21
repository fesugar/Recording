set pt=%~dp0
del bin\ /s /q
rd bin\ /s /q
xcopy NDP462.exe bin\ /i /f /v /h /y
xcopy NDP462.cmd bin\ /i /f /v /h /y
:: 基本上都安装了.NET 4 多余的，还容易误报 xcopy Release\run.exe bin\ /i /f /v /h /y
xcopy Release\Io_Api.dll bin\ /i /f /v /h /y
xcopy Release\Io_Api.pdb bin\ /i /f /v /h /y
xcopy Release\MouseRec.exe bin\ /i /f /v /h /y
xcopy Release\MouseRec.exe.config bin\ /i /f /v /h /y
xcopy Release\MouseRec.pdb bin\ /i /f /v /h /y
xcopy Release\MouseRec.xml bin\ /i /f /v /h /y
xcopy MouseRec\licenses.txt bin\ /i /f /v /h /y
xcopy MouseRec\readme.rtf bin\ /i /f /v /h /y
::xcopy MouseRec\Class_SystemHook.vb bin\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.Design.dll bin\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.dll bin\ /i /f /v /h /y
xcopy packages\MetroModernUI.1.4.0.0\lib\net\MetroFramework.Fonts.dll bin\ /i /f /v /h /y
::xcopy Io_Api\Class_io_apis.cs bin\ /i /f /v /h /y

::合并DLL  EXE
"C:\Program Files (x86)\Microsoft\ILMerge\ILMerge.exe"  /ndebug /target:winexe /targetplatform:v4 /out:%pt%\bin\newMouseRec.exe /log %pt%\bin\MouseRec.exe %pt%\bin\MetroFramework.Design.dll %pt%\bin\MetroFramework.dll %pt%\bin\MetroFramework.Fonts.dll %pt%\bin\Io_Api.dll

del bin\MouseRec.exe
del bin\MetroFramework.Design.dll
del bin\MetroFramework.dll
del bin\MetroFramework.Fonts.dll
del bin\Io_Api.dll
del bin\Io_Api.pdb

if exist %pt%\bin\newMouseRec.exe (rename %pt%\bin\newMouseRec.exe MouseRec.exe) else (echo ERROR) 


iexpress
