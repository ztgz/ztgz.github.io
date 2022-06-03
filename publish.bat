@echo off

for %%f in (.\docs\*) do (
  call :deleteBlazorFiles %%f
)

for /d %%d in (.\docs\*) do del /Q %%d

goto:Publish

:deleteBlazorFiles
  if %~1 == .\docs\.nojekyll EXIT /B 0
  if %~1 == .\docs\CNAME EXIT /B 0
  del %~1 
EXIT /B 0

:Publish  
@echo on
dotnet publish -r win-x64 --self-contained -p:PublishTrimmed=true -c Release -o docs
@echo off

FOR /D %%D in (.\docs\wwwroot\*) DO (
   move %%D .\docs\
)

FOR %%f in (.\docs\wwwroot\*) DO (
   move %%f .\docs\
)

echo Commit changes to github to publish online