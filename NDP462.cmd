@echo off
::start NDP462-KB3151800-x86-x64-AllOS-CHS.exe
ECHO Microsoft .NET Framework 4.6.2 is installing  
NDP462.exe /q /norestart
if exist MouseRec.exe ( start MouseRec.exe ) else ( exit )
