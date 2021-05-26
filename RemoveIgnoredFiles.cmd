@echo off
git clean -dfX
git rm -rf --cached .
git add .
git status
git commit -m "Ignored files cleaned"
