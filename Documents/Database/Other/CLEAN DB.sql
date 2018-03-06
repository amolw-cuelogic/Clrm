truncate Allocation;
delete  from project where Id > 0;
truncate EmployeeSkill;
truncate EmployeeDepartment;
truncate EmployeeOrganizationRole;
truncate IdentityEmployeeGroup;
delete  from MasterProjectRole where Id > 0;
delete  from MasterProjectType where Id > 0;
delete from MasterSkill where Id > 0;
delete from MasterDepartment where Id > 0;
delete from MasterOrganizationRole where Id > 0;
delete from MasterClient where Id > 0;

delete from IdentityGroupRight where GroupId <> 109;
delete from IdentityGroup where Id <> 109;

delete  from Employee where Id > 1;
