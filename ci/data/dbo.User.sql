CREATE TABLE `User` (
  `Id` char(36) NOT NULL,
  `CreateAt` datetime(6) DEFAULT NULL,
  `UpdateAt` datetime(6) DEFAULT NULL,
  `Name` varchar(60) CHARACTER SET utf8mb4 NOT NULL,
  `Email` varchar(100) CHARACTER SET utf8mb4 DEFAULT NULL,
  `Password` varchar(200) CHARACTER SET utf8mb4 NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_User_Email` (`Email`)
)
