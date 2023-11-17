CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Username VARCHAR(255) NOT NULL
);

CREATE TABLE Livestreams (
    LivestreamID INT PRIMARY KEY,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
);

CREATE TABLE Messages (
    MessageID INT PRIMARY KEY,
    UserID INT,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    MessageType VARCHAR(50) NOT NULL,
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE TextContent (
    TextContentID INT PRIMARY KEY,
    Content TEXT,
    MessageID INT,
    FOREIGN KEY (MessageID) REFERENCES Users(MessageID),
);

CREATE TABLE ImageContent (
    ImageContentID INT PRIMARY KEY,
    FilePath VARCHAR(255) NOT NULL,
    MessageID INT,
    FOREIGN KEY (MessageID) REFERENCES Messages(MessageID)
);
