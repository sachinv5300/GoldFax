# GoldFax
Key Points Used-
	1-MVVM Architecture pattern
	2-Converters (convert integer 0 to '' for ID property)
	3-inheritance (Viewmodelbase contains only property changed)
	4-singleton design pattern (Database Connection use one instance)
	5-Material Design/Metrowindow(Datagrid and Window design)
	6-ResourceDictionary (Common styles)
  7-Exception Handing (logging)	

Steps to Run project
	Step 1: All Required references are kept in MDL directory 
  Step 2: create new database of GoldFaxDB (or can directly create table in   existing database)  pass this connection string to step 5
	Step 3: create table name as "BookTransaction" 
	Step 4: Add Temp Records
	Step 5: set "DbConnectionString" key value in config file 
	step 6: Run Application

SQL scripts
	Create Table script 
		CREATE TABLE BookTransaction (
			ID int IDENTITY(1,1) PRIMARY KEY,
			BookName varchar(255) NOT NULL,
			BorrowedDate datetime,
			DeliveredDate datetime	);

	Insert Temp Record script 
		INSERT INTO BookTransaction (BookName, BorrowedDate, DeliveredDate)
		VALUES ('The Monk who sold his ferrari', GetDate(),GetDate()),
		 ('Rich Dad Poor Dad', GetDate(),GetDate()),
		 ('The Alchemist', GetDate(),GetDate()),
		 ('Sophies World', GetDate(),GetDate()),
		 ('The Pilgrimage', GetDate(),GetDate()),
		 ('Vagabonding', GetDate(),GetDate()),
		 ('Sophies World', GetDate(),GetDate()),
		 ('How to Win Friends', GetDate(),GetDate()),
		 ('The 4 Hour Workweek', GetDate(),GetDate()),
		 ('The Education of Millionaires', GetDate(),GetDate()),
		 ('The 48 Laws of Power', GetDate(),GetDate()),
		 ('Mastery', GetDate(),GetDate()),
		 ('The Personal MBA', GetDate(),GetDate());
	Select Record script 
select ID,isnull(BookName,'') as BookName,BorrowedDate,DeliveredDate from BookTransaction with(nolock)
