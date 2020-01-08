CREATE TABLE Users (
    username varchar(255) NOT NULL,
    password varchar(255) NOT NULL,
    PRIMARY KEY(username)
);

CREATE USER 'dan'@'localhost' IDENTIFIED BY 'danpassword';

GRANT CREATE, INSERT, SELECT, UPDATE ON Stride TO 'dan'@'localhost';

INSERT INTO Users VALUES ('1234567', 'password');

CREATE TABLE Students (
    studentnumber varchar(255) NOT NULL,
    eduplan varchar(255),
    college varchar(255),
    careerpath varchar(255),
    ethnicity varchar(255),
    gender varchar(255),
    FOREIGN KEY (studentnumber) REFERENCES Users(username)
);

INSERT INTO Students VALUES ('1234567', 'Advanced Degree', 'UCLA', 'Aerospace Engineering', 'White or Caucasian', 'Female');

UPDATE students SET eduplan = 'Bachelor''s Degree' WHERE studentnumber = '1234567';