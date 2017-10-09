rem create database user
createuser.exe -U postgres -P sync_vr

rem Create database
createdb.exe -U postgres sync_vr

psql.exe -U sync_vr -f create-tables.sql
pause
