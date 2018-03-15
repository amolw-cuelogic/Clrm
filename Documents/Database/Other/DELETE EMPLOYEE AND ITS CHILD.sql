
set @empId = 26;
delete from EmployeeDepartment where EmployeeId = @empId;
delete from EmployeeSkill where EmployeeId = @empId;
delete from EmployeeOrganizationRole where EmployeeId = @empId;
delete from IdentityEmployeeGroup where EmployeeId = @empId;
delete from Employee where Id = @empId;
