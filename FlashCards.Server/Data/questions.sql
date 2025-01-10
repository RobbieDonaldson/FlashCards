insert into Questions (
      [SurveyId]
      ,[QuestionText]
      ,[AnswerText]
      ,[Active]
      ,[Created]
      ,[CreatedBy]
      ,[Updated]
      ,[UpdatedBy]
)
values
/*OOP*/
(1,'What are the four pillars of object oriented programming?','Abstraction, Encapsulation, Inheritance and Polymorphism.',1,GetDate(), 'REDJR', null, null),
(1,'What is Encapsulation?','Wrapping up all aspects of a thing into a defined object with features and behaviors. This ensures data security and code organization.',1,GetDate(), 'REDJR', null, null),
(1,'What is Abstraction?','Hiding away the implementation details inside something – sometimes a prototype, sometimes a function. So when you call the function you don''t have to understand exactly what it is doing.',1,GetDate(), 'REDJR', null, null),
(1,'What is Inheritance?','The idea that if an object shares features and behaviors with other objects, then you don''t need to define everything about it over and over again.',1,GetDate(), 'REDJR', null, null),
(1,'What is Polymorphism?','Allows objects of different classes to be treated as objects of the common base class. This enables code reuse, flexibility, and extensibility.',1,GetDate(), 'REDJR', null, null),
(1,'What are some advantages of using OOP?','OOP is very helpful in solving very complex level of problems. OOP promote code reuse, thereby reducing redundancy. OOP also helps to hide the unnecessary details with the help of Data Abstraction.',1,GetDate(), 'REDJR', null, null),
(1,'What are access modifiers?','Access modifiers are keywords used in object-oriented programming languages to control the accessibility of a class''s members (like methods and variables), determining which parts of a program can access and modify specific data within a class, thereby enforcing encapsulation principles.',1,GetDate(), 'REDJR', null, null),
(1,'What are the C# access modifiers?','Public, Private, Protected, Internal, Protected Internal, Private Protected and File .',1,GetDate(), 'REDJR', null, null),
(1,'Are there any limitations of Inheritance?','Yes. Inheritance needs more time to process, as it needs to navigate through multiple classes for its implementation. Also, the classes involved in Inheritance - the base class and the child class, are very tightly coupled together. So if one needs to make some changes, they might need to do nested changes in both classes. Inheritance might be complex for implementation, as well. So if not correctly implemented, this might lead to unexpected errors or incorrect outputs.',1,GetDate(), 'REDJR', null, null),
(1,'What are the various types of inheritance?','Single inheritance, Multiple inheritances, Multi-level inheritance, Hierarchical inheritance and Hybrid inheritance',1,GetDate(), 'REDJR', null, null),
/*c#*/
(2,'What is C#?','C# is a modern, general-purpose, object-oriented programming language and is part of the .net framework developed by Microsoft.',1,GetDate(), 'REDJR', null, null),
(2,'What is the difference between a class and an object?','Class is a blueprint and an object is an instance of that object',1,GetDate(), 'REDJR', null, null),
(2,'What are the two basic C# data types? Define them.','Value Types are allocated on the stack (static memory allocation) passed by copying.  Reference Types are allocated on the heap (dynamic memory allocation) passed by reference.',1,GetDate(), 'REDJR', null, null),
(2,'What is Dependency Injection?','Dependency injection, also known as inversion control, a software design pattern that enables loosely coupled  code.  The advantages are: di allows flexibility, more testable, reduced module complexity.',1,GetDate(), 'REDJR', null, null),
(2,'What is the Repository Pattern?','Repository Pattern is a design pattern that isolates data access behind interface abstractions.',1,GetDate(), 'REDJR', null, null),
(2,'What is the difference between Classes and Structs?','Structs are value types and classes are reference types.',1,GetDate(), 'REDJR', null, null),
(2,'Explain the difference between Constants and Readonly variables?','Constants are declared and initialized at compile time and the value can’t be changed.  Readonly is assigned at runtime.',1,GetDate(), 'REDJR', null, null),
(2,'What is boxing and unboxing?','Boxing is converting a value type into a reference type.  Unboxing is converting reference type into the value type.',1,GetDate(), 'REDJR', null, null),
(2,'What is a constructor?','A constructor has the same name as a class or struct and they initialize data members of a new object.',1,GetDate(), 'REDJR', null, null),
(2,'What is N Tier Architecture?','Multi-tier architecture consisting of processing, data management, presentation logically separated.',1,GetDate(), 'REDJR', null, null),
/*sql*/
(3,'What are indexes?','Indexes are way to locate records quicker than table scan, like the index in a book.',1,GetDate(), 'REDJR', null, null),
(3,'What network protocols are used to connect to SQL Server?','The protocols are: shared memory, named pipes, tcp/ip, virtual interface adaptor.',1,GetDate(), 'REDJR', null, null),
(3,'What are the types of login when connecting to SQL Server?','You can login with: windows, sql server, mapped certificate and asymmetric key.',1,GetDate(), 'REDJR', null, null),
(3,'What is an execution plan?','It is a roadmap which contains order of all steps performed in execution of query.',1,GetDate(), 'REDJR', null, null),
(3,'What is SQL?  Give some examples of SQL commands that can be used to manipulate records in a table.','Search Query Language.   Four examples of SQL commands that are used to manipulate records in a table are: select, delete, updated and insert.',1,GetDate(), 'REDJR', null, null),
(3,'Give some examples of the different types of SQL joins?','Inner Join, Outer Join, Left Outer Join, Right Outer Join, Full Join, Self Join',1,GetDate(), 'REDJR', null, null),
(3,'What is a CTE?','A CTE (Common Table Expression) defines a temporary result set which you can then use in a SELECT statement.  It becomes a convenient way to manage complicated queries.',1,GetDate(), 'REDJR', null, null),
(3,'What is a stored procedure?','A stored procedure is a prepared SQL code that you can save, so the code can be reused over and over again.',1,GetDate(), 'REDJR', null, null),
(3,'What are the two types of indexes in SQL Server?','Clustered and non-clustered.',1,GetDate(), 'REDJR', null, null),
(3,'What table command is used to delete all records and reset the primary key back to 1 for the first inserted record?','Truncate.',1,GetDate(), 'REDJR', null, null);