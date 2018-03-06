Insert Into MasterSkill
(`Skill`,`IsValid`,`CreatedBy`,`CreatedOn`)
Values
('C#',1,1,'2018-01-01'),
('Html',1,1,'2018-01-01'),
('Jquery',1,1,'2018-01-01'),
('Javascript',1,1,'2018-01-01'),
('SQL',1,1,'2018-01-01'),
('AngularJS 1',1,1,'2018-01-01'),
('Angular 4',1,1,'2018-01-01'),
('LINQ',1,1,'2018-01-01'),
('Entity Framework',1,1,'2018-01-01'),
('Ionic Cordova',1,1,'2018-01-01'),
('Scala',1,1,'2018-01-01'),
('Swift',1,1,'2018-01-01'),
('Python',1,1,'2018-01-01'),
('NodeJS',1,1,'2018-01-01');

Insert Into MasterDepartment
(`DepartmentName`,`DepartmentHead`,`IsValid`,`CreatedBy`,`CreatedOn`)
Values
('Delivery','Vivek Phadke',1,1,'2018-01-01'),
('HR','Uma Ramani',1,1,'2018-01-01'),
('Sales','Neel Vartikar',1,1,'2018-01-01'),
('Management','Nikhil Ambekar',1,1,'2018-01-01'),
('Technical','Vikrant Labde',1,1,'2018-01-01');

Insert Into MasterOrganizationRole
(`Role`,`IsValid`,`CreatedBy`,`CreatedOn`)
Values
('Software Engineer',1,1,'2018-01-01'),
('Sr. Software Engineer',1,1,'2018-01-01'),
('Devops',1,1,'2018-01-01'),
('Trainee Software Engineer',1,1,'2018-01-01'),
('Principle Engineer',1,1,'2018-01-01'),
('Project Manager',1,1,'2018-01-01'),
('Sr. Project Manager',1,1,'2018-01-01');

Insert Into MasterProjectRole
(`Role`,`Costing`,`IsValid`,`CreatedBy`,`CreatedOn`)
Values
('Developer',20000,1,1,'2018-01-01'),
('Product Developer',30000,1,1,'2018-01-01'),
('Technical Analyst',25000,1,1,'2018-01-01'),
('Ui Engineer',35000,1,1,'2018-01-01'),
('Backend Developer',50000,1,1,'2018-01-01');


Insert Into MasterProjectType
(`Type`,`IsValid`,`CreatedBy`,`CreatedOn`)
Values
('Billable',1,1,'2018-01-01'),
('Non Billable',1,1,'2018-01-01'),
('In House',1,1,'2018-01-01'),
('R & D',1,1,'2018-01-01');

Insert Into MasterClient
(`ClientName`,`CountryId`,`CityId`,`IsValid`,`CreatedBy`,`CreatedOn`)
Values
('Abbott Laboratories',2,6,1,1,'2018-01-01'),
('Aarons, Inc',2,6,1,1,'2018-01-01'),
('Walmart',2,6,1,1,'2018-01-01'),
('ExxonMobil',2,6,1,1,'2018-01-01');





