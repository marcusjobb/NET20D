@echo off

xcopy /S /Y . "%USERPROFILE%\Documents\Visual Studio 2019\" 
del "%USERPROFILE%\Documents\Visual Studio 2019\CopyStuff.cmd"