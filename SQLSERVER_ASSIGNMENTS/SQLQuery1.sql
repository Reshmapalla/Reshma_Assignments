create database Sqlassignment2
use Sqlassignment2

--create department table
create table department(
Dept_no varchar(5) Primary Key,
Dept_Name VArchar(30),
Location varchar(30))

--insert values into department table
insert into department values('d1','Research','Dallas'),('d2','Accounting','Seattle'),('d3','Marketing','Dallas')

--creating employee table
create table employee(empno int primary key,
emp_fname varchar(10),
emp_lname varchar(10),
dept_no varchar(5),
Foreign key(dept_no) references department(Dept_no))

--inserting value
insert into employee values(25348,'Matthew','smith','d3'),(10102,'Ann','Jhones','d3'),(18316,'John','Barrimore','d1'),(29346,'Jmaes','James','d2')

--create Project table
create table Project(Project_no varchar(5) primary key ,project_name varchar(30),Budget money)

--inserting values
insert into Project values('p1','Apollo',120000),('p2','Gemini',95000),('p3','Mercury',185600)

--creating Works_on table 
Create table works_on (emp_no int,
project_no varchar(5),
job varchar(10),
enter_date date,
foreign key(project_no) references Project(Project_no),
foreign key(emp_no) references employee(empno))

--inserting values
insert into works_on values(10102,'p1','Analyst','1997.10.1'),
(10102,'p3','manager','1999.1.1'),
(25348,'p2','Clerk','1998.2.15'),
(18316,'p2',Null,'1998.6.1'),
(29346,'p2',Null,'1997.12.15'),
(25348,'p3','Analyst','1998.10.15'),
(18316,'p1','manager','1998.4.15'),
(29346,'p1',null,'1998.8.1'),
(18316,'p2','Clerk','1992.2.1'),
(10102,'p3','Clerk','1997.11.15'),
(29346,'p1','Clerk','1998.1.4')


--1 Get all row of the works_on table
select * from works_on

--2 Get all row of the works_on table
select emp_no from works_on
where job='Clerk'

/*3Get the employee numbers for employees working in project p2,
and having employee numbers smaller than 10000. */
select emp_no from works_on
where project_no='p2' and emp_no>10000;

/*4Get the employee numbers for all employees who didn’t enter their
project in 1998.*/

select distinct(emp_no)
from works_on
where year(enter_date)!='1998';

/*5Get the employee numbers for all employees who have a leading
job( i.e., Analyst or Manager) in project p1*/

select emp_no from works_on
where job in('Analyst','manager') and  project_no='p1' 

/*. 6Get the enter dates for all employess in project p2 whose jobs
have not been determined yet.*/

select enter_date from works_on
where project_no='p2' and job is null;

/*7Get the employee numbers and last names of all employees
whose first names contain two letter t’s.*/
select empno,emp_lname from employee
where emp_fname like '%tt%'

/*8Get the employee numbers and first names of all employees
whose last names have a letter o or a as the second character and
end with the letters es.*/select empno,emp_fnamefrom employeewhere emp_lname like '__o%es' or emp_lname like '_a%es'
/*9Get the employee numbers of all employees whose departments
are located in Seattle.*/

select e.empno 
from employee e join department d
on e.dept_no=d.Dept_no
where [Location]='Seattle'

select * from employee
select * from department

/*10.Find the last and first names of all employess who entered
their projects on 04.01.1998*/

select e.emp_fname,e.emp_lname
from employee e join works_on w
on e.empno=w.emp_no
where w.enter_date='1998.2.15'

/*11.Group all departments using their locations.*/

select [location],count(Dept_no),String_AGG(Dept_Name,',')
from department
group by [location]

--12.Find the biggest employee number.
select max(empno)
from employee

--13.Get the jobs that are done by more than two employees

select job,count(emp_no) as counts
from works_on
group by job 
having count(emp_no)>2 and job is not null

/*14.Find the employee numbers of all employees who are clerks
or work for department d3.*/

select distinct(w.emp_no) from works_on w
join employee e
on e.empno=w.emp_no
where w.job='Clerk' or e.dept_no='d3'
