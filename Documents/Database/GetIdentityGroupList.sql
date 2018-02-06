CREATE PROCEDURE `GetIdentityGroupList` ()
BEGIN
SELECT a.Id, a.GroupName,a.GroupDescription,a.IsValid,concat(b.FirstName ,' ', b.LastName) as Name, 
DATE_FORMAT(a.CreatedOn,'%d/%m/%Y') as CreatedOn
FROM CuelogicResourceManagement.IdentityGroup a
inner join Employee b on a.CreatedBy = b.Id
where a.IsValid = true;
END
