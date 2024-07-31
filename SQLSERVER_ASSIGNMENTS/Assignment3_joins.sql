select * from [dbo].[Project]
select * from [dbo].[works_on]

 select * from [dbo].[department]
select * from [dbo].[employee]
/*1.Create:
a. Equijoin
b. Natural join
c. Cartesian product
for the project and works_on tables(refer Assignment1)*/.
select  p.project_name,w.emp_no,w.job
from [dbo].[Project] p join [dbo].[works_on] w
on p.Project_no=w.project_no

select p.Project_no, p.project_name,w.emp_no,w.job
from [dbo].[Project] p join [dbo].[works_on] w
on p.Project_no=w.project_no

select p.*,w.* from [dbo].[Project] p cross join [dbo].[works_on] w


/*1.Get the employee numbers and job titles of all employees working on
project Gemini*/

select  w.emp_no,w.job
from [dbo].[works_on] w join [dbo].[Project] p
on w.project_no=p.Project_no
where p.project_name='Gemini'

/*. 2.Get the first and last names of all employees that work for
departments Research or Acounting.*/

select e.emp_fname,e.emp_lname
from [dbo].[employee] e join department d
on e.dept_no=d.Dept_no
where d.Dept_Name in ('Research','Accounting')

/*.3. Get the enter dates of all clerks that belong to the department d1.*/

select w.enter_date from [dbo].[works_on] w
join employee e
on e.empno=w.emp_no
where w.job='clerk' and e.dept_no='d1'

/*.4. Get the names of projects on which two or more clerks are working.*/

select p.project_name,count(w.job) countOfjob from [dbo].[Project] p
join works_on w
on w.project_no=p.Project_no
group by p.project_name
having count(w.job) >1

 --5. Get the names of projects on which two or more clerks are working

select p.project_name 
from Project p 
join Works_on won p.project_no=w.project_no 
where job='clerk' 
group by p.project_name  
having count(w.emp_no )>=2

--- * 6. Get the first and last names of the employees that are manager and that work on project Mercury

select e.emp_fname,e.emp_lname 
from Employee e 
join Works_on w on e.emp_no=w.emp_no 
join  project p on w.project_no = p.project_no
where job='manager' and project_name='mercury'

--- * 7. Get the first and last names of all employee who entered the project at the same time as at least one other employee.

select e.emp_fname,e.emp_lname
from Employee e
join Works_on w on e.emp_no=w.emp_no
where w.enter_date in (select enter_date from Works_on  group by enter_date having count(emp_no)>1 )

--- * 8. Get the employee numbers of the employees living in the same location and belonging to the same department as one another.

select * from Employee
select * from Department

select e.emp_no 
from Employee e 
join Department d on e.dept_no =d.Dept_no
join Employee e2 on e.emp_no=e2.emp_no   
join Department d2 on d.Dept_no =d2.Dept_no   
where e.dept_no=e2.dept_no and d.location =d2.location


--- * 9.Get the employee numbers of all employees belonging to the Marketing department.Find two equivalent solutions using:


---   * 9.A  the JOIN operator

select e.emp_no  
from Employee e 
join Department d on e.dept_no =d.Dept_no 
where Dept_name='marketing'

--- * 9.B  The correlated subquery.

select e.emp_no
from Employee e   
where e.dept_no =(select d.dept_no from Department d   where Dept_name ='marketing')



--- * Modifying a Table’s Content***

--- * 1. Insert the data of a new employee called Julia Long, whose employee number is 1111. Her department number is not known yet.

insert into Employee (emp_no ,emp_fname ,emp_lname) values(1111,'Julia','Long')


--- * 2. Create a new table called emp_d1_d2 with all employees who work for department d1 or d2, and load the corresponding rows from the employee table.

create table emp_d1_d2 (emp_no int ,emp_fname varchar(20),emp_lname varchar(20),dept_no char(5))
insert into emp_d1_d2 (emp_no,emp_fname ,emp_lname ,dept_no ) select emp_no,emp_fname ,emp_lname ,dept_no from Employee where dept_no in ('d1','d2')
select * from emp_d1_d2

--- * 3. Modify the job of all the employees in project p1 who are managers. They have to work as clerks from now on.
select * from Works_on
select * from Project 

select * from Employee
select * from Department

update  works_on set job='clerks' where project_no ='p1' and job='manager'
