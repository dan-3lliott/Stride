CREATE TABLE Users (
    username varchar(255) NOT NULL,
    password varchar(255) NOT NULL
);

CREATE USER 'dan'@'localhost' IDENTIFIED BY 'danpassword';

GRANT CREATE, INSERT, SELECT, UPDATE ON Stride TO 'dan'@'localhost';

INSERT INTO Users VALUES ('dan', 'danpassword');

SELECT * FROM users WHERE username = 'dan' and password = 'danpassword';

CREATE TABLE Students (
    studentnumber int,
    eduplan varchar(255),
    college varchar(255),
    careerpath varchar(255),
    ethnicity varchar(255),
    gender varchar(255)
);

INSERT INTO Students VALUES ('1234567', 'Advanced Degree', 'UCLA', 'Aerospace Engineering', 'White or Caucasian', 'Female')

UPDATE students SET eduplan = 'Bachelor''s Degree' WHERE studentnumber = '1234567';