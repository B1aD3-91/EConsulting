# EConsulting
Решение состоит из 4х компонетов:
•	WebApi
•	WebApiTests
•	WebClient
•	DbCloneApp

1.	WebApi – для работы с базой данных используется ORM EntityFramework. Строка подкючения к SQL серверу прописана с файле appsettings.json. 
Строка подключения: 
"ConnectionStrings": {
    "MSDBConnection": "Data Source=(localdb)\\MSSQLLocalDB;Database=EConsulting;Trusted_Connection=True;"
  }
	Используется подход CodeFirst. Для создания базы данных из модели используеться метод DataBase.EnsureCreate(). При изменении модели лучше использовать миграцию. В Package Manager Console используем сл. набор комманд:
	Для использования сл. команд необходимо установить Microsoft.EntityFrameworkCore.Tools из менеджера пакетов NuGet
	Add-Migration <название миграции>
	Update-Database
	Точки входа для запросов:
•	Для получения диапазона дат из базы используйте GET запрос по пути /api/TimeRange/get/yyyy-MM-dd/yyyy-MM-dd
Где yyyy-MM-dd – год-месяц-день начальной и конечой дат диапазона соответственно. 
•	Для добавления нового диапазона дат в базу используйте PUT запрос по пути /api/TimeRange/get/create. Данные для добавления в базу передавайте в теле сообщения
Пример: 
{
  “start” : “2020-10-10”,
  “end” : “2020-10-10”
}
	В файле launschSettings.json настройки для запуска приложения через IIS или Kernel сервер. 

