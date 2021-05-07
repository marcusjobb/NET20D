rem @echo off
IF [%1] == [] GOTO Error
git add .
git commit -m "%1"
git push
GOTO End
:Error
echo You need to write a comment before comitting
echo usage: PushEverything "Added new files"