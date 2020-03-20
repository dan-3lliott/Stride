CREATE TABLE Users (
    username varchar(255) NOT NULL,
    password varchar(255) NOT NULL,
    usertype varchar(255) NOT NULL,
    email varchar(255),
    PRIMARY KEY(username)
);

INSERT INTO Users VALUES ('1234567', 'password', 'student', 'matildawatkins@gmail.com'), ('counselorlogin', 'password', 'counselor', 'kpoulton-timm@graniteschools.org');

CREATE TABLE Students (
    studentnumber varchar(255) NOT NULL,
    firstname varchar(255) NOT NULL,
    lastname varchar(255) NOT NULL,
    gpa decimal(3, 2),
    eduplan varchar(255),
    college varchar(255),
    careerpath varchar(255),
    ethnicity varchar(255),
    gender varchar(255),
    FOREIGN KEY (studentnumber) REFERENCES Users(username)
);

INSERT INTO Students VALUES ('1234567', 'Matilda', 'Watkins', 4.00, 'Bachelor''s Degree', 'U of U', 'Software Development', 'White or Caucasian', 'Female');

CREATE TABLE Counselors (
    username varchar(255) NOT NULL,
    firstname varchar(255) NOT NULL,
    lastname varchar(255) NOT NULL,
    FOREIGN KEY (username) REFERENCES Users(username)
);

INSERT INTO Counselors VALUES ('counselorlogin', 'Kaye', 'Poulton-Timm');