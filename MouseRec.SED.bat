@echo off
set pt=%~dp0

if "%1%"=="cs" goto cs
if "%1%"=="vb" goto vb

goto end

REM 生成SED脚本 for vb
:vb
echo [Version] >%pt%MouseRec.SED
echo Class=IEXPRESS >>%pt%MouseRec.SED
echo SEDVersion=^3 >>%pt%MouseRec.SED
echo [Options] >>%pt%MouseRec.SED
echo PackagePurpose=^InstallApp >>%pt%MouseRec.SED
echo ShowInstallProgramWindow=^0 >>%pt%MouseRec.SED
echo HideExtractAnimation=^1 >>%pt%MouseRec.SED
echo UseLongFileName=^0 >>%pt%MouseRec.SED
echo InsideCompressed=^0 >>%pt%MouseRec.SED
echo CAB_FixedSize=^0 >>%pt%MouseRec.SED
echo CAB_ResvCodeSigning=^0 >>%pt%MouseRec.SED
echo RebootMode=^N >>%pt%MouseRec.SED
echo InstallPrompt=%%InstallPrompt%% >>%pt%MouseRec.SED
echo DisplayLicense=%%DisplayLicense%% >>%pt%MouseRec.SED
echo FinishMessage=%%FinishMessage%% >>%pt%MouseRec.SED
echo TargetName=%%TargetName%% >>%pt%MouseRec.SED
echo FriendlyName=%%FriendlyName%% >>%pt%MouseRec.SED
echo AppLaunched=%%AppLaunched%% >>%pt%MouseRec.SED
echo PostInstallCmd=%%PostInstallCmd%% >>%pt%MouseRec.SED
echo AdminQuietInstCmd=%%AdminQuietInstCmd%% >>%pt%MouseRec.SED
echo UserQuietInstCmd=%%UserQuietInstCmd%% >>%pt%MouseRec.SED
echo SourceFiles=^SourceFiles >>%pt%MouseRec.SED
echo [Strings] >>%pt%MouseRec.SED
echo InstallPrompt=^ >>%pt%MouseRec.SED
echo DisplayLicense=^ >>%pt%MouseRec.SED
echo FinishMessage=^ >>%pt%MouseRec.SED
echo TargetName=%pt%bin\build\Setup\MouseRec.v1.22.EXE >>%pt%MouseRec.SED
echo FriendlyName=^MouseRec >>%pt%MouseRec.SED
echo AppLaunched=^MouseRec.exe >>%pt%MouseRec.SED
echo PostInstallCmd=^<None^> >>%pt%MouseRec.SED
echo AdminQuietInstCmd=^ >>%pt%MouseRec.SED
echo UserQuietInstCmd=^ >>%pt%MouseRec.SED
echo FILE0=^"Licenses.txt^" >>%pt%MouseRec.SED
echo FILE1=^"MouseRec.exe^" >>%pt%MouseRec.SED
echo FILE2=^"MouseRec.exe.config^" >>%pt%MouseRec.SED
echo FILE3=^"NDP462.cmd^" >>%pt%MouseRec.SED
echo FILE4=^"NDP462.exe^" >>%pt%MouseRec.SED
echo FILE5=^"readme.rtf^" >>%pt%MouseRec.SED
echo [SourceFiles] >>%pt%MouseRec.SED
echo SourceFiles0=%pt%bin\build\ >>%pt%MouseRec.SED
echo [SourceFiles0] >>%pt%MouseRec.SED
echo %%FILE0%%=^ >>%pt%MouseRec.SED
echo %%FILE1%%=^ >>%pt%MouseRec.SED
echo %%FILE2%%=^ >>%pt%MouseRec.SED
echo %%FILE3%%=^ >>%pt%MouseRec.SED
echo %%FILE4%%=^ >>%pt%MouseRec.SED
echo %%FILE5%%=^ >>%pt%MouseRec.SED

goto end

REM 生成SED脚本 for cs
:cs
echo [Version] >%pt%MouseRec.SED
echo Class=IEXPRESS >>%pt%MouseRec.SED
echo SEDVersion=^3 >>%pt%MouseRec.SED
echo [Options] >>%pt%MouseRec.SED
echo PackagePurpose=^InstallApp >>%pt%MouseRec.SED
echo ShowInstallProgramWindow=^0 >>%pt%MouseRec.SED
echo HideExtractAnimation=^1 >>%pt%MouseRec.SED
echo UseLongFileName=^0 >>%pt%MouseRec.SED
echo InsideCompressed=^0 >>%pt%MouseRec.SED
echo CAB_FixedSize=^0 >>%pt%MouseRec.SED
echo CAB_ResvCodeSigning=^0 >>%pt%MouseRec.SED
echo RebootMode=^N >>%pt%MouseRec.SED
echo InstallPrompt=%%InstallPrompt%% >>%pt%MouseRec.SED
echo DisplayLicense=%%DisplayLicense%% >>%pt%MouseRec.SED
echo FinishMessage=%%FinishMessage%% >>%pt%MouseRec.SED
echo TargetName=%%TargetName%% >>%pt%MouseRec.SED
echo FriendlyName=%%FriendlyName%% >>%pt%MouseRec.SED
echo AppLaunched=%%AppLaunched%% >>%pt%MouseRec.SED
echo PostInstallCmd=%%PostInstallCmd%% >>%pt%MouseRec.SED
echo AdminQuietInstCmd=%%AdminQuietInstCmd%% >>%pt%MouseRec.SED
echo UserQuietInstCmd=%%UserQuietInstCmd%% >>%pt%MouseRec.SED
echo SourceFiles=^SourceFiles >>%pt%MouseRec.SED
echo [Strings] >>%pt%MouseRec.SED
echo InstallPrompt=^ >>%pt%MouseRec.SED
echo DisplayLicense=^ >>%pt%MouseRec.SED
echo FinishMessage=^ >>%pt%MouseRec.SED
echo TargetName=%pt%bin\build\Setup\MouseRec1255.EXE >>%pt%MouseRec.SED
echo FriendlyName=^MouseRec >>%pt%MouseRec.SED
echo AppLaunched=^MouseRec.exe >>%pt%MouseRec.SED
echo PostInstallCmd=^<None^> >>%pt%MouseRec.SED
echo AdminQuietInstCmd=^ >>%pt%MouseRec.SED
echo UserQuietInstCmd=^ >>%pt%MouseRec.SED
echo FILE0=^"Licenses.txt^" >>%pt%MouseRec.SED
echo FILE1=^"MouseRec.exe^" >>%pt%MouseRec.SED
echo FILE2=^"MouseRec.exe.config^" >>%pt%MouseRec.SED
echo FILE3=^"readme.rtf^" >>%pt%MouseRec.SED
echo [SourceFiles] >>%pt%MouseRec.SED
echo SourceFiles0=%pt%bin\build\ >>%pt%MouseRec.SED
echo [SourceFiles0] >>%pt%MouseRec.SED
echo %%FILE0%%=^ >>%pt%MouseRec.SED
echo %%FILE1%%=^ >>%pt%MouseRec.SED
echo %%FILE2%%=^ >>%pt%MouseRec.SED
echo %%FILE3%%=^ >>%pt%MouseRec.SED
goto end

:end