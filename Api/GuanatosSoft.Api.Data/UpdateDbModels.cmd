::SET CONNECTION_STRING="Server=(localdb)\MSSQLLocalDb;Initial Catalog=guanatos-soft-db;Persist Security Info=False;Integrated Security=True"
SET CONNECTION_STRING= "Server=tcp:guanatos-soft.database.windows.net,1433;Initial Catalog=guanatos-soft-db;Persist Security Info=False;User ID=godmode;Password=C0ntras3na;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

SET ENTITIES_FOLDER_NAME=Entities

dotnet ef dbcontext scaffold %CONNECTION_STRING% Microsoft.EntityFrameworkCore.SqlServer -o "%ENTITIES_FOLDER_NAME%" --data-annotations --force --schema Security --schema Business