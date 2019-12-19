CREATE TABLE Users (
    username varchar(255) NOT NULL,
    password varchar(255) NOT NULL
);

INSERT INTO Users VALUES ('dan', 'danpassword');

SELECT * FROM users WHERE username = 'dan' and password = 'danpassword';