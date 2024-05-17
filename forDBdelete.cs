﻿CREATE TABLE Users (
    UserID SERIAL PRIMARY KEY,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL
);

CREATE TABLE Tasks (
    TaskID SERIAL PRIMARY KEY,
    UserID INTEGER,
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    DueDate DATE NOT NULL,
    Completed BOOLEAN DEFAULT FALSE,
    FOREIGN KEY(UserID) REFERENCES Users(UserID)
);