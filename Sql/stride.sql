CREATE TABLE Users (
    username varchar(255) NOT NULL,
    password varchar(255) NOT NULL
);


CREATE USER 'dan'@'localhost' IDENTIFIED BY 'danpassword';

GRANT CREATE, INSERT, SELECT, UPDATE ON Stride TO 'dan'@'localhost';

INSERT INTO Users VALUES ('dan', 'danpassword');

SELECT * FROM users WHERE username = 'dan' and password = 'danpassword';