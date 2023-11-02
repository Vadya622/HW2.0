SELECT * FROM Sales.Customer;
SELECT * FROM Sales.Store ORDER BY Name;
SELECT TOP 10 * FROM HumanResources.Employee WHERE BirthDate > '1989-09-28';
SELECT NationalIDNumber, LoginID, JobTitle FROM HumanResources.Employee WHERE LoginID LIKE '%0' ORDER BY JobTitle DESC;
SELECT * FROM Person.Person WHERE YEAR(ModifiedDate) = 2008 AND MiddleName IS NOT NULL AND Title IS NULL;
SELECT DISTINCT d.Name
FROM HumanResources.EmployeeDepartmentHistory edh
INNER JOIN HumanResources.Department d ON edh.DepartmentID = d.DepartmentID;
SELECT TerritoryID, SUM(CommissionPct) as TotalCommission
FROM Sales.SalesPerson
WHERE CommissionPct > 0
GROUP BY TerritoryID;
SELECT TOP 1 WITH TIES * FROM HumanResources.Employee ORDER BY VacationHours DESC;
SELECT * FROM HumanResources.Employee WHERE JobTitle IN ('Торговый представитель', 'Администратор сети', 'Менеджер сети');
SELECT e.*, po.*
FROM HumanResources.Employee e
LEFT JOIN Purchasing.PurchaseOrderHeader po ON e.BusinessEntityID = po.EmployeeID;