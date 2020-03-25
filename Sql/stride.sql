CREATE TABLE Users (
    username varchar(255) NOT NULL,
    password varchar(255) NOT NULL,
    usertype varchar(255) NOT NULL,
    email varchar(255),
    PRIMARY KEY(username)
);

INSERT INTO Users VALUES ('1234567', 'password', 'student', 'matildawatkins@gmail.com'), ('counselorlogin', 'password', 'counselor', 'kpoulton-timm@graniteschools.org'), ('7654321', 'password', 'student', 'zgreenberg02@gmail.com'),
                         ('1324354', 'password', 'student', 'danielli9632@granitesd.org'), ('7564534', 'password', 'student', 'wiltonmacquarrie@granitesd.org'),
                         ('4653725', 'password', 'student', 'changsmolen@granitesd.org'), ('4876231', 'password', 'student', 'kathrinreidman@granitesd.org');

CREATE TABLE Students (
    studentnumber varchar(255) NOT NULL,
    firstname varchar(255) NOT NULL,
    lastname varchar(255) NOT NULL,
    gpa decimal(3, 2),
    eduplan varchar(255),
    college varchar(255),
    major varchar(255),
    careerpath varchar(255),
    ethnicity varchar(255),
    gender varchar(255),
    ncaa varchar(255),
    firstgen varchar(255),
    onlineinterest varchar(255),
    counselor varchar(255) NOT NULL,
    FOREIGN KEY (studentnumber) REFERENCES Users(username),
    FOREIGN KEY (counselor) REFERENCES Counselors(username)
);

INSERT INTO Students VALUES ('1234567', 'Matilda', 'Watkins', 4.00, 'Bachelor''s Degree', 'U of U', 'Computer Science', 'Software Development', 'White or Caucasian', 'Female', 'No', 'Yes', 'Interested', 'counselorlogin'), ('7654321', 'Zach', 'Greenberg', 4.00, 'Bachelor''s Degree', 'MIT', 'Mechanical Engineering', 'Mechanical Engineering', 'White or Caucasian', 'Male', 'No', 'No', 'Uninterested', 'counselorlogin'),
                            ('1324354', 'Daniel', 'Elliott', 4.00, '', '', '', '', '', '', '', '', '', 'counselorlogin'), ('7564534', 'Wilton', 'Macquarrie', 3.85, 'Bachelor''s Degree', 'MIT', 'Mechanical Engineering', 'Mechanical Engineering', 'Asian', 'Male', 'Yes', 'Yes', 'Interested', 'counselorlogin'),
                            ('4653725', 'Chang', 'Smolen', 3.78, 'Associate Degree', 'U of U', 'Business', 'Marketing Analyst', 'Asian', 'Male', 'No', 'No', 'Indifferent', 'counselorlogin'), ('4876231', 'Kathy', 'Reidman', 3.93, 'Bachelor''s Degree', 'U of U', 'Computer Science', 'Data Scientist', 'White or Caucasian', 'Female', 'Yes', 'No', 'Uninterested', 'counselorlogin');

CREATE TABLE Counselors (
    username varchar(255) NOT NULL,
    firstname varchar(255) NOT NULL,
    lastname varchar(255) NOT NULL,
    phonenumber varchar(255),
    FOREIGN KEY (username) REFERENCES Users(username)
);

INSERT INTO Counselors VALUES ('counselorlogin', 'Kaye', 'Poulton-Timm', '801-123-4567');