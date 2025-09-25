CREATE OR ALTER VIEW vwCategoriesHierarchy AS
SELECT 
    c.ID AS CategoryID,
    c.Name AS Category,
    c1.ID AS SubCategoryID,
    c1.Name AS SubCategory,
    c2.ID AS SubSubCategoryID,
    c2.Name AS SubSubCategory,
	c.ParentID
FROM Categories c
LEFT JOIN Categories c1 ON c1.ParentID = c.ID
LEFT JOIN Categories c2 ON c2.ParentID = c1.ID;