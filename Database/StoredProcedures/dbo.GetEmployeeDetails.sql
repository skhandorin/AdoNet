IF ( EXISTS ( SELECT [id] FROM sys.SYSOBJECTS WHERE [name]='GetEmployeeDetails' AND type='P' ) )
  DROP PROCEDURE dbo.GetEmployeeDetails
GO
create proc dbo.GetEmployeeDetails
  @businessEntityID int
as
  set nocount on

  select * 
    from HumanResources.Employee e
      join Person.Person p on p.BusinessEntityID = e.BusinessEntityID and p.PersonType = 'EM'
	  join HumanResources.EmployeeDepartmentHistory eh on eh.BusinessEntityID = e.BusinessEntityID
	  join HumanResources.Department d on d.DepartmentID = eh.DepartmentID
    where e.BusinessEntityID = @BusinessEntityID;

--
GO

