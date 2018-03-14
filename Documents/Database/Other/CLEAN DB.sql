truncate Allocation;

truncate EmployeeSkill;
truncate EmployeeDepartment;
truncate EmployeeOrganizationRole;

delete  from Project where Id > 0;

delete  from ProjectRole where Id > 0;
delete  from MasterRole where Id > 0;
delete  from MasterProjectType where Id > 0;
delete from MasterSkill where Id > 0;
delete from MasterDepartment where Id > 0;
delete from MasterOrganizationRole where Id > 0;
delete from MasterClient where Id > 0;



delete from  IdentityEmployeeGroup where GroupId <> 115;
delete from IdentityGroupRight where GroupId <> 115;
delete from IdentityGroup where Id <> 115;

delete  from Employee where Id NOT IN ( 1,17,27);
