@echo off
::start NDP462-KB3151802-Web.exe
ECHO Microsoft .NET Framework 4.6.2 is installing  
start /B /WAIT NDP462.exe /passive /showfinalerror /showrmui /promptrestart
if exist MouseRec.exe ( start MouseRec.exe ) else ( exit )
