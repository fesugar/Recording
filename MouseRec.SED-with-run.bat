@echo off
set pt=%~dp0

if "%1%"=="cs" goto cs
if "%1%"=="vb" goto vb

goto end

REM SED for vb
:vb
echo [Version] >%pt%bin\MouseRec.SED
echo Class=IEXPRESS >>%pt%bin\MouseRec.SED
echo SEDVersion=^3 >>%pt%bin\MouseRec.SED
echo [Options] >>%pt%bin\MouseRec.SED
echo PackagePurpose=^InstallApp >>%pt%bin\MouseRec.SED
echo ShowInstallProgramWindow=^0 >>%pt%bin\MouseRec.SED
echo HideExtractAnimation=^0 >>%pt%bin\MouseRec.SED
echo UseLongFileName=^0 >>%pt%bin\MouseRec.SED
echo InsideCompressed=^0 >>%pt%bin\MouseRec.SED
echo CAB_FixedSize=^0 >>%pt%bin\MouseRec.SED
echo CAB_ResvCodeSigning=^0 >>%pt%bin\MouseRec.SED
echo RebootMode=^N >>%pt%bin\MouseRec.SED
echo InstallPrompt=%%InstallPrompt%% >>%pt%bin\MouseRec.SED
echo DisplayLicense=%%DisplayLicense%% >>%pt%bin\MouseRec.SED
echo FinishMessage=%%FinishMessage%% >>%pt%bin\MouseRec.SED
echo TargetName=%%TargetName%% >>%pt%bin\MouseRec.SED
echo FriendlyName=%%FriendlyName%% >>%pt%bin\MouseRec.SED
echo AppLaunched=%%AppLaunched%% >>%pt%bin\MouseRec.SED
echo PostInstallCmd=%%PostInstallCmd%% >>%pt%bin\MouseRec.SED
echo AdminQuietInstCmd=%%AdminQuietInstCmd%% >>%pt%bin\MouseRec.SED
echo UserQuietInstCmd=%%UserQuietInstCmd%% >>%pt%bin\MouseRec.SED
echo SourceFiles=^SourceFiles >>%pt%bin\MouseRec.SED
echo [Strings] >>%pt%bin\MouseRec.SED
echo InstallPrompt=^ >>%pt%bin\MouseRec.SED
echo DisplayLicense=^ >>%pt%bin\MouseRec.SED
echo FinishMessage=^ >>%pt%bin\MouseRec.SED
echo TargetName=%pt%bin\build\Setup\MouseRec.v1.22.EXE >>%pt%bin\MouseRec.SED
echo FriendlyName=^MouseRec >>%pt%bin\MouseRec.SED
echo AppLaunched=^MouseRec_run.exe >>%pt%bin\MouseRec.SED
echo PostInstallCmd=^<None^> >>%pt%bin\MouseRec.SED
echo AdminQuietInstCmd=^ >>%pt%bin\MouseRec.SED
echo UserQuietInstCmd=^ >>%pt%bin\MouseRec.SED
echo FILE0=^"Notes.txt^" >>%pt%bin\MouseRec.SED
echo FILE1=^"MouseRec.exe^" >>%pt%bin\MouseRec.SED
echo FILE2=^"MouseRec.exe.config^" >>%pt%bin\MouseRec.SED
echo FILE3=^"NDP462.cmd^" >>%pt%bin\MouseRec.SED
echo FILE4=^"NDP462.exe^" >>%pt%bin\MouseRec.SED
echo FILE5=^"readme.rtf^" >>%pt%bin\MouseRec.SED
echo FILE6=^"LICENSE^" >>%pt%bin\MouseRec.SED
echo FILE7=^"MouseRec_run.exe^" >>%pt%bin\MouseRec.SED
if exist bin\build\Up.exe ( echo FILE8=^"Up.exe^" >>%pt%bin\MouseRec.SED )
echo [SourceFiles] >>%pt%bin\MouseRec.SED
echo SourceFiles0=%pt%bin\build\ >>%pt%bin\MouseRec.SED
echo [SourceFiles0] >>%pt%bin\MouseRec.SED
echo %%FILE0%%=^ >>%pt%bin\MouseRec.SED
echo %%FILE1%%=^ >>%pt%bin\MouseRec.SED
echo %%FILE2%%=^ >>%pt%bin\MouseRec.SED
echo %%FILE3%%=^ >>%pt%bin\MouseRec.SED
echo %%FILE4%%=^ >>%pt%bin\MouseRec.SED
echo %%FILE5%%=^ >>%pt%bin\MouseRec.SED
echo %%FILE6%%=^ >>%pt%bin\MouseRec.SED
echo %%FILE7%%=^ >>%pt%bin\MouseRec.SED
if exist bin\build\Up.exe ( echo %%FILE8%%=^ >>%pt%bin\MouseRec.SED )
goto end

REM SED for cs
:cs
echo [Version] >%pt%bin\MouseRec.SED
echo Class=IEXPRESS >>%pt%bin\MouseRec.SED
echo SEDVersion=^3 >>%pt%bin\MouseRec.SED
echo [Options] >>%pt%bin\MouseRec.SED
echo PackagePurpose=^InstallApp >>%pt%bin\MouseRec.SED
echo ShowInstallProgramWindow=^0 >>%pt%bin\MouseRec.SED
echo HideExtractAnimation=^0 >>%pt%bin\MouseRec.SED
echo UseLongFileName=^0 >>%pt%bin\MouseRec.SED
echo InsideCompressed=^0 >>%pt%bin\MouseRec.SED
echo CAB_FixedSize=^0 >>%pt%bin\MouseRec.SED
echo CAB_ResvCodeSigning=^0 >>%pt%bin\MouseRec.SED
echo RebootMode=^N >>%pt%bin\MouseRec.SED
echo InstallPrompt=%%InstallPrompt%% >>%pt%bin\MouseRec.SED
echo DisplayLicense=%%DisplayLicense%% >>%pt%bin\MouseRec.SED
echo FinishMessage=%%FinishMessage%% >>%pt%bin\MouseRec.SED
echo TargetName=%%TargetName%% >>%pt%bin\MouseRec.SED
echo FriendlyName=%%FriendlyName%% >>%pt%bin\MouseRec.SED
echo AppLaunched=%%AppLaunched%% >>%pt%bin\MouseRec.SED
echo PostInstallCmd=%%PostInstallCmd%% >>%pt%bin\MouseRec.SED
echo AdminQuietInstCmd=%%AdminQuietInstCmd%% >>%pt%bin\MouseRec.SED
echo UserQuietInstCmd=%%UserQuietInstCmd%% >>%pt%bin\MouseRec.SED
echo SourceFiles=^SourceFiles >>%pt%bin\MouseRec.SED
echo [Strings] >>%pt%bin\MouseRec.SED
echo InstallPrompt=^ >>%pt%bin\MouseRec.SED
echo DisplayLicense=^ >>%pt%bin\MouseRec.SED
echo FinishMessage=^ >>%pt%bin\MouseRec.SED
echo TargetName=%pt%bin\build\Setup\MouseRec1255.EXE >>%pt%bin\MouseRec.SED
echo FriendlyName=^MouseRec >>%pt%bin\MouseRec.SED
echo AppLaunched=^MouseRec_run.exe >>%pt%bin\MouseRec.SED
echo PostInstallCmd=^<None^> >>%pt%bin\MouseRec.SED
echo AdminQuietInstCmd=^ >>%pt%bin\MouseRec.SED
echo UserQuietInstCmd=^ >>%pt%bin\MouseRec.SED
echo FILE0=^"Notes.txt^" >>%pt%bin\MouseRec.SED
echo FILE1=^"MouseRec.exe^" >>%pt%bin\MouseRec.SED
echo FILE2=^"MouseRec.exe.config^" >>%pt%bin\MouseRec.SED
echo FILE3=^"readme.rtf^" >>%pt%bin\MouseRec.SED
echo FILE4=^"LICENSE^" >>%pt%bin\MouseRec.SED
echo FILE5=^"MouseRec_run.exe^" >>%pt%bin\MouseRec.SED
echo FILE6=^"NDP462.cmd^" >>%pt%bin\MouseRec.SED
echo FILE7=^"NDP462.exe^" >>%pt%bin\MouseRec.SED
if exist bin\build\Up.exe ( echo FILE8=^"Up.exe^" >>%pt%bin\MouseRec.SED )
echo [SourceFiles] >>%pt%bin\MouseRec.SED
echo SourceFiles0=%pt%bin\build\ >>%pt%bin\MouseRec.SED
echo [SourceFiles0] >>%pt%bin\MouseRec.SED
echo %%FILE0%%=^ >>%pt%bin\MouseRec.SED
echo %%FILE1%%=^ >>%pt%bin\MouseRec.SED
echo %%FILE2%%=^ >>%pt%bin\MouseRec.SED
echo %%FILE3%%=^ >>%pt%bin\MouseRec.SED
echo %%FILE4%%=^ >>%pt%bin\MouseRec.SED
echo %%FILE5%%=^ >>%pt%bin\MouseRec.SED
echo %%FILE6%%=^ >>%pt%bin\MouseRec.SED
echo %%FILE7%%=^ >>%pt%bin\MouseRec.SED
if exist bin\build\Up.exe ( echo %%FILE8%%=^ >>%pt%bin\MouseRec.SED )
goto end

:end