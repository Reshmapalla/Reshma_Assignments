create database Assignment_On_Views_Index
-- Create Department table
CREATE TABLE Department (
    Dept_no CHAR(2) PRIMARY KEY,
    Dept_name VARCHAR(50),
    location VARCHAR(50)
);

-- Insert data into Department table
INSERT INTO Department (Dept_no, Dept_name, location)
VALUES
('d1', 'Research', 'Dallas'),
('d2', 'Accounting', 'Seattle'),
('d3', 'Marketing', 'Dallas');

-- Create Employee table
CREATE TABLE Employee (
    emp_no INT PRIMARY KEY,
    emp_fname VARCHAR(50),
    emp_lname VARCHAR(50),
    dept_no CHAR(2),
    FOREIGN KEY (dept_no) REFERENCES Department(Dept_no)
);

-- Insert data into Employee table
INSERT INTO Employee (emp_no, emp_fname, emp_lname, dept_no)
VALUES
(25348, 'Matthew', 'Smith', 'd3'),
(10102, 'Ann', 'Jones', 'd3'),
(18316, 'John', 'Barrimore', 'd1'),
(29346, 'James', 'James', 'd2'),
(9031, 'Laura', 'Wilson', 'd1'), 
(28559, 'Nina', 'Clark', 'd2'),  
(2581, 'Oliver', 'King', 'd3'),  
(12345, 'Alice', 'Johnson', 'd1'),
(23456, 'Bob', 'Brown', 'd2'),
(34567, 'Charlie', 'Davis', 'd3'),
(45678, 'Diana', 'Evans', 'd1'),
(56789, 'Edward', 'Franklin', 'd3');

-- Create Project table
CREATE TABLE Project (
    project_no CHAR(2) PRIMARY KEY,
    project_name VARCHAR(50),
    Budget DECIMAL(10, 2)
);

-- Insert data into Project table
INSERT INTO Project (project_no, project_name, Budget)
VALUES
('p1', 'Apollo', 120000),
('p2', 'Gemini', 95000),
('p3', 'Mercury', 185600);

-- Create Works_on table
CREATE TABLE Works_on (
    emp_no INT,
    project_no CHAR(2),
    Job VARCHAR(50),
    enter_date DATE,
    PRIMARY KEY (emp_no, project_no),
    FOREIGN KEY (emp_no) REFERENCES Employee(emp_no),
    FOREIGN KEY (project_no) REFERENCES Project(project_no)
);

-- Insert data into Works_on table
INSERT INTO Works_on (emp_no, project_no, Job, enter_date)
VALUES
(10102, 'p1', 'Analyst', '1997-10-01'),
(10102, 'p3', 'manager', '1999-01-01'),
(25348, 'p2', 'Clerk', '1998-02-15'),
(18316, 'p2', NULL, '1998-06-01'),
(29346, 'p2', NULL, '1997-12-15'),
(2581, 'p3', 'Analyst', '1998-10-15'),
(9031, 'p1', 'Manager', '1998-04-15'),
(28559, 'p1', NULL, '1998-08-01'),
(28559, 'p2', 'Clerk', '1992-02-01'),
(9031, 'p3', 'Clerk', '1997-11-15'),
(29346, 'p1', 'Clerk', '1998-01-04');

--- 1. Create a view that comprises the data of all employees that work for the department d1

CREATE VIEW EmployeesInDepartmentD1 AS
SELECT emp_no, emp_fname, emp_lname, dept_no
FROM Employee
WHERE dept_no = 'd1';

SELECT * FROM EmployeesInDepartmentD1;

--- 2. For the project table, create a view that can be used by employees who are allowed to view all data of this table except the budget column.

CREATE VIEW ProjectsWithoutBudget AS
SELECT project_no, project_name
FROM Project;

SELECT * FROM ProjectsWithoutBudget;

---3. Create a vew that comprises the first and last names of all employees who entered heir projects in the second half of the year 1988.

select * from Employee
select * from Works_on

CREATE VIEW EmployeesEnteredProjectsSecondHalf1988 AS
SELECT e.emp_fname, e.emp_lname
FROM Employee e
JOIN Works_on w ON e.emp_no = w.emp_no
WHERE w.enter_date BETWEEN '1988-07-01' AND '1988-12-31';

SELECT * FROM EmployeesEnteredProjectsSecondHalf1988;

--- 4.  Solve the previous exercise so that the original columns f_name and l_name have new names in the view: first and last, respectively.

DROP VIEW EmployeesEnteredProjectsSecondHalf1988;
create VIEW EmployeesEnteredProjectsSecondHalf1988 AS
SELECT e.emp_fname AS first, e.emp_lname AS last
FROM Employee e
JOIN Works_on w ON e.emp_no = w.emp_no
WHERE w.enter_date BETWEEN '1988-07-01' AND '1988-12-31';

SELECT * FROM EmployeesEnteredProjectsSecondHalf1988;

---5. use the view in Exercise 3 to display full details of all employees whose last names begin with the letter M.
SELECT *
FROM EmployeesInDepartmentD1
WHERE emp_lname LIKE 'M%';

---6 . Create a view which comprises full details of all projects on which the employee named smith works .

CREATE VIEW ProjectsForEmployeeSmith AS
SELECT p.project_no, p.project_name, p.Budget, e.emp_no, e.emp_fname, e.emp_lname, w.Job, w.enter_date
FROM Project p
JOIN Works_on w ON p.project_no = w.project_no
JOIN Employee e ON w.emp_no = e.emp_no
WHERE e.emp_lname = 'Smith';

SELECT * FROM ProjectsForEmployeeSmith;

---7 . Using the ALTER VIEW statement, modify the condition in the view in Exercise-3. The modified view should comprise the data of all employees that work either for the department d1 or d2, or both
ALTER VIEW EmployeesInDepartmentD1 AS
SELECT emp_no, emp_fname, emp_lname, dept_no
FROM Employee
WHERE dept_no IN ('d1', 'd2');

SELECT * FROM EmployeesInDepartmentD1;