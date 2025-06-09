CREATE DATABASE Malshinon;

CREATE TABLE People(

	Id INT  PRIMARY KEY AUTO_INCREMENT,


	FirstName VARCHAR(255) NOT NULL UNIQUE,


	LastName VARCHAR(255) NOT NULL,


	SecretCode VARCHAR(255) UNIQUE, 


	Type ENUM("reporter", "target","both","potential_agent"),  


	num_reports INT DEFAULT 0,


	num_mentions INT DEFAULT 0
	
	);
	

CREATE TABLE IntelReports(
	
	Id INT AUTO_INCREMENT  Primary Key, 
 
	Reporter_id INT,
	
	Foreign Key (Reporter_id) REFERENCES People(Id),

	Target_id INT, 
	
	Foreign Key (Target_id) REFERENCES People(Id),

	Text TEXT NOT NULL,

	Timestamp DATETIME DEFAULT NOW()

	);