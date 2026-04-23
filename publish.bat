@echo off

:: Auto-elevate to admin
net session >nul 2>&1
if %errorlevel% neq 0 (
    powershell -Command "Start-Process '%~f0' -Verb RunAs"
    exit /b
)

set /p DEST="Destination folder: "

if "%DEST%"=="" (
    echo No folder provided. Aborting.
    pause
    exit /b 1
)

if exist "%DEST%" (
    echo Cleaning existing folder...
    rmdir /s /q "%DEST%"
)

echo.
echo Publishing to: %DEST%
echo.

dotnet publish "%~dp0VaultReviewer\VaultReviewer.csproj" -c Release -o "%DEST%"

if %errorlevel% equ 0 (
    echo.
    echo Published successfully to: %DEST%
) else (
    echo.
    echo Publish failed.
)

pause
