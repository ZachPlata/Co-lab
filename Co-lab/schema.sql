-- =============================================================================
-- Co-LAB: Complete Database Schema
-- Target Database: db_colab
-- For use in XAMPP phpMyAdmin / MariaDB
-- =============================================================================

CREATE DATABASE IF NOT EXISTS `db_colab` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `db_colab`;

SET FOREIGN_KEY_CHECKS = 0;

-- -----------------------------------------------------------------------------
-- 1. Table: tbl_users
-- Handles authentication, registration, forgot password, and blacklist status.
-- -----------------------------------------------------------------------------
DROP TABLE IF EXISTS `tbl_users`;
CREATE TABLE `tbl_users` (
    `UserId` INT AUTO_INCREMENT PRIMARY KEY,
    `FullName` VARCHAR(100) NOT NULL,
    `Email` VARCHAR(100) NOT NULL UNIQUE,
    `Password` VARCHAR(255) NOT NULL,
    `Role` ENUM('Student', 'Admin') DEFAULT 'Student',
    `StudentNumber` VARCHAR(20) DEFAULT NULL,
    `College` VARCHAR(100) DEFAULT NULL,
    `SecurityQuestion` VARCHAR(255) DEFAULT 'What was the name of your first pet?',
    `SecurityAnswer` VARCHAR(255) DEFAULT 'dog',
    `is_blacklisted` TINYINT(1) DEFAULT 0,
    `BanReason` VARCHAR(255) DEFAULT NULL,
    `CreatedAt` DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;

-- Populate ONLY the 5 specific users (Password: 12345678)
INSERT INTO `tbl_users` (`UserId`, `FullName`, `Email`, `Password`, `Role`, `SecurityQuestion`, `SecurityAnswer`) VALUES
(1, 'Zach Plata', 'plata.zachbenedict@ue.edu.ph', '12345678', 'Student', 'What was the name of your first pet?', 'dog'),
(2, 'Trowa Bugarin', 'bugarin.trowabarton@ue.edu.ph', '12345678', 'Student', 'What was the name of your first pet?', 'dog'),
(3, 'Gabs Katipunan', 'katipunan.karisgabriel@ue.edu.ph', '12345678', 'Student', 'What was the name of your first pet?', 'dog'),
(4, 'Andrei Sarmiento', 'sarmiento.andrei@ue.edu.ph', '12345678', 'Student', 'What was the name of your first pet?', 'dog'),
(5, 'Miguel Borja', 'borja.miguelantonio@ue.edu.ph', '12345678', 'Student', 'What was the name of your first pet?', 'dog');

-- -----------------------------------------------------------------------------
-- 2. Table: tbl_categories
-- -----------------------------------------------------------------------------
DROP TABLE IF EXISTS `tbl_categories`;
CREATE TABLE `tbl_categories` (
    `CategoryId` INT AUTO_INCREMENT PRIMARY KEY,
    `CategoryName` VARCHAR(100) NOT NULL UNIQUE
) ENGINE=InnoDB;

INSERT INTO `tbl_categories` (`CategoryId`, `CategoryName`) VALUES
(1, 'Computer Science & IT'),
(2, 'Graphic & Visual Design'),
(3, 'Engineering & Math'),
(4, 'Music & Arts'),
(5, 'Language & Writing'),
(6, 'Business & Marketing'),
(7, 'Video Editing & Multimedia');

-- -----------------------------------------------------------------------------
-- 3. Table: tbl_skills
-- -----------------------------------------------------------------------------
DROP TABLE IF EXISTS `tbl_skills`;
CREATE TABLE `tbl_skills` (
    `SkillId` INT AUTO_INCREMENT PRIMARY KEY,
    `SkillTitle` VARCHAR(150) NOT NULL,
    `Category` VARCHAR(100) NOT NULL,
    `Description` TEXT NOT NULL,
    `OfferedBy` VARCHAR(100) NOT NULL,
    `DesiredSkill` VARCHAR(150) DEFAULT 'Open to any skill',
    `DeliveryMode` ENUM('Online', 'Face-to-Face') DEFAULT 'Online',
    `Location` VARCHAR(150) DEFAULT NULL,
    `Status` ENUM('Active', 'Flagged', 'Under Review', 'Completed', 'Archived') DEFAULT 'Active',
    `CreatedAt` DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;

-- -----------------------------------------------------------------------------
-- 4. Table: tbl_traderequests
-- -----------------------------------------------------------------------------
DROP TABLE IF EXISTS `tbl_traderequests`;
CREATE TABLE `tbl_traderequests` (
    `RequestId` INT AUTO_INCREMENT PRIMARY KEY,
    `TargetSkillId` INT NOT NULL,
    `SenderName` VARCHAR(100) NOT NULL,
    `SenderEmail` VARCHAR(100) NOT NULL,
    `OfferedSkillTitle` VARCHAR(150) NOT NULL,
    `MeetingMode` ENUM('Online', 'Face-to-Face') DEFAULT 'Online',
    `Location` VARCHAR(150) DEFAULT NULL,
    `Message` TEXT,
    `Status` ENUM('Pending', 'Accepted', 'Declined', 'Completed') DEFAULT 'Pending',
    `RequestDate` DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (`TargetSkillId`) REFERENCES `tbl_skills`(`SkillId`) ON DELETE CASCADE
) ENGINE=InnoDB;

-- -----------------------------------------------------------------------------
-- 5. Table: tbl_reports
-- -----------------------------------------------------------------------------
DROP TABLE IF EXISTS `tbl_reports`;
CREATE TABLE `tbl_reports` (
    `ReportId` INT AUTO_INCREMENT PRIMARY KEY,
    `SkillId` INT DEFAULT NULL,
    `ReportedUser` VARCHAR(100) NOT NULL,
    `Reason` TEXT NOT NULL,
    `ReportDate` DATETIME DEFAULT CURRENT_TIMESTAMP,
    `Status` ENUM('Pending', 'Reviewed', 'Dismissed') DEFAULT 'Pending'
) ENGINE=InnoDB;

-- -----------------------------------------------------------------------------
-- 6. Table: tbl_tos
-- -----------------------------------------------------------------------------
DROP TABLE IF EXISTS `tbl_tos`;
CREATE TABLE `tbl_tos` (
    `TosId` INT AUTO_INCREMENT PRIMARY KEY,
    `TosContent` LONGTEXT NOT NULL,
    `LastUpdated` DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB;

INSERT INTO `tbl_tos` (`TosId`, `TosContent`) VALUES
(1, "WELCOME TO CO-LAB: UE STUDENT SKILL EXCHANGE\n\n1. ELIGIBILITY: You must be an officially enrolled student of the University of the East with a valid @ue.edu.ph email address.\n\n2. ACADEMIC INTEGRITY: Skills exchanged must focus on tutoring, mentoring, creative skills, or technical training. Directly completing someone else's graded exam, quiz, or project is strictly forbidden.\n\n3. NON-MONETARY POLICY: Co-LAB is a barter/exchange platform. Charging cash or cryptocurrency for skill sharing is prohibited.\n\n4. SAFETY & CONDUCT: Respect your fellow students. For Face-to-Face exchanges, only meet in public campus areas (Libraries, Student Centers, Cafeteria).\n\n5. VIOLATIONS: Violations will lead to immediate account suspension and blacklisting.");

SET FOREIGN_KEY_CHECKS = 1;
