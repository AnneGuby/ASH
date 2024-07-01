CREATE TABLE [dbo].[EmployeeType](
	[ID] [INT] IDENTITY(1,1) NOT NULL,
	[TypeName] [VARCHAR](20) NOT NULL,
 CONSTRAINT [PK_EmployeeType_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON  [PRIMARY]


CREATE TABLE [dbo].[Employee](
	[ID] [INT] IDENTITY(1,1) NOT NULL,
	[FirstName] [VARCHAR](30) NOT NULL,
	[LastName] [VARCHAR](50) NOT NULL,
	[Address1] [VARCHAR](100) NOT NULL,
	[EmployeeTypeId] [INT] NOT NULL,
	[PayPerHour] [DECIMAL](10, 2) NULL, 
	[AnnualSalary] [DECIMAL](10, 2) NULL, 
	[MaxExpenseAmount] [DECIMAL](10, 2) NULL, 
 CONSTRAINT [PK_Employee_ID] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 100) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE dbo.Employee ADD CONSTRAINT FK_Employee_EmployeeType 
	FOREIGN KEY(EmployeeTypeId) REFERENCES dbo.EmployeeType(Id);

INSERT INTO EmployeeType ([TypeName]) VALUES  ('Employees'), ('Managers'), ('Supervisors')