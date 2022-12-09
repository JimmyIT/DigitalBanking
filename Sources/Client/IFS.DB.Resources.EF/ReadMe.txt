================================ Entity Frameword Core EF ===========================
New project .Net Core -> Class Library(.Net Core)
Tools –> NuGet Package Manager –> Package Manager Console
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools 

Need to exclude table without primary keys. We need to define a list of tables need to be gernerated.

	Scaffold-DbContext "Server=.\SQL2019;Database=DigitalBanking;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -Context DigitalBankingDBContext -force -Tables "UILanguageResources"