﻿dotnet ef dbcontext scaffold "Data Source=DESKTOP-S31CQ0B\SQLEXPRESS;Initial Catalog=Northwind;Trusted_Connection=True;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -o Models

dotnet ef dbcontext scaffold "Data Source=DESKTOP-S31CQ0B\SQLEXPRESS;Initial Catalog=Northwind;Trusted_Connection=True;MultipleActiveResultSets=true" Microsoft.EntityFrameworkCore.SqlServer -o Models -c MyDBContext --context-dir Contexts -f --data-annotations
