CALL `CuelogicResourceManagement`.`myproc`();


select ExtractValue('<a>z<b/></a>', '/a');

SET @xml= '
<?xml version="1.0" encoding="utf-16"?>
<ArrayOfIdentityGroupRight xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <IdentityGroupRight>
    <Id>1</Id>
    <GroupId>1</GroupId>
    <RightId>1</RightId>
    <Action>4</Action>
    <IsValid>true</IsValid>
    <CreatedBy>1</CreatedBy>
    <CreatedOn>2018-02-02T00:00:00</CreatedOn>
    <UpdatedBy>2</UpdatedBy>
    <UpdatedOn>0001-01-01T00:00:00</UpdatedOn>
    <RightTitle>Group</RightTitle>
    <CreatedByName>Amol Wabale</CreatedByName>
    <UpdatedByName>Vivek Phadke</UpdatedByName>
    <BooleanRight>
      <Read>true</Read>
      <Write>false</Write>
      <Delete>false</Delete>
    </BooleanRight>
  </IdentityGroupRight>
  <IdentityGroupRight>
    <Id>2</Id>
    <GroupId>1</GroupId>
    <RightId>2</RightId>
    <Action>6</Action>
    <IsValid>true</IsValid>
    <CreatedBy>1</CreatedBy>
    <CreatedOn>2018-02-02T00:00:00</CreatedOn>
    <UpdatedBy>0</UpdatedBy>
    <UpdatedOn>0001-01-01T00:00:00</UpdatedOn>
    <RightTitle>User Group</RightTitle>
    <CreatedByName>Amol Wabale</CreatedByName>
    <BooleanRight>
      <Read>true</Read>
      <Write>true</Write>
      <Delete>false</Delete>
    </BooleanRight>
  </IdentityGroupRight>
  <IdentityGroupRight>
    <Id>3</Id>
    <GroupId>1</GroupId>
    <RightId>3</RightId>
    <Action>7</Action>
    <IsValid>true</IsValid>
    <CreatedBy>1</CreatedBy>
    <CreatedOn>2018-02-02T00:00:00</CreatedOn>
    <UpdatedBy>2</UpdatedBy>
    <UpdatedOn>0001-01-01T00:00:00</UpdatedOn>
    <RightTitle>Employee</RightTitle>
    <CreatedByName>Amol Wabale</CreatedByName>
    <UpdatedByName>Vivek Phadke</UpdatedByName>
    <BooleanRight>
      <Read>true</Read>
      <Write>true</Write>
      <Delete>true</Delete>
    </BooleanRight>
  </IdentityGroupRight>
</ArrayOfIdentityGroupRight>
';
SELECT @xml, ExtractValue(@xml, '/ArrayOfIdentityGroupRight/IdentityGroupRight[3]/RightId') as val;
SELECT @xml, ExtractValue(@xml, 'count(/ArrayOfIdentityGroupRight/IdentityGroupRight)');
        
     
       
SET @xml= '<aaa><result>
        <id>1</id>
        </result>
        <result>
        <id>2</id>
        </result>
        <result>
        <id>3</id>
        </result>
        <result>
        <id>4</id>
        </result>
        <result>
        <id>5</id>
        </result>
        <result>
        <id>7</id>
        </result>
        <result>
        <id>6</id>
        </result>
        <result>
        <id>8</id>
        </result>
        <result>
        <id>9</id>
        </result>
        <result>
        <id>10</id>
        </result>
        <result>
        <id>11</id>
        </result>        
    </aaa>';

SELECT SUBSTRING_INDEX(SUBSTRING_INDEX(ExtractValue(@xml, '//id'), ' ', n.n), ' ', -1) value
  FROM (select SUBSTRING_INDEX(ExtractValue(@xml, '//id'), ' ', 1)) t CROSS JOIN 
  (
   SELECT a.N + b.N * 10 + 1 n
     FROM 
    (SELECT 0 AS N UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9) a
   ,(SELECT 0 AS N UNION ALL SELECT 1 UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4 UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8 UNION ALL SELECT 9) b
    ORDER BY n 
   ) n
 WHERE n.n <= 1 + (LENGTH(ExtractValue(@xml, '//id')) - LENGTH(REPLACE(ExtractValue(@xml, '//id'), ' ', '')))