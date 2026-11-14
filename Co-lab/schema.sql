-- =============================================================================
-- Co-LAB: Complete Database Schema (Updated per Blueprint)
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
    `is_verified` TINYINT(1) DEFAULT 0,
    `is_blacklisted` TINYINT(1) DEFAULT 0,
    `BanReason` VARCHAR(255) DEFAULT NULL,
    `CreatedAt` DATETIME DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;

-- Populate ONLY the 5 specific users (Password: 12345678)
INSERT INTO `tbl_users` (`UserId`, `FullName`, `Email`, `Password`, `Role`, `SecurityQuestion`, `SecurityAnswer`, `is_verified`) VALUES
(1, 'Zach Plata', 'plata.zachbenedict@ue.edu.ph', '12345678', 'Student', 'What was the name of your first pet?', 'dog', 1),
(2, 'Trowa Bugarin', 'bugarin.trowabarton@ue.edu.ph', '12345678', 'Student', 'What was the name of your first pet?', 'dog', 1),
(3, 'Gabs Katipunan', 'katipunan.karisgabriel@ue.edu.ph', '12345678', 'Student', 'What was the name of your first pet?', 'dog', 1),
(4, 'Andrei Sarmiento', 'sarmiento.andrei@ue.edu.ph', '12345678', 'Student', 'What was the name of your first pet?', 'dog', 1),
(5, 'Miguel Borja', 'borja.miguelantonio@ue.edu.ph', '12345678', 'Admin', 'What was the name of your first pet?', 'dog', 1);

-- -----------------------------------------------------------------------------
-- 2. Table: tbl_categories
-- Skill categories managed by Admin and used in dropdown filters.
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
-- 3. Table: tbl_user_skills (Student Known Skills / Bio Inventory)
-- Added per Blueprint: Skills the student knows, not yet listed in the marketplace.
-- -----------------------------------------------------------------------------
DROP TABLE IF EXISTS `tbl_user_skills`;
CREATE TABLE `tbl_user_skills` (
    `UserSkillId` INT AUTO_INCREMENT PRIMARY KEY,
    `UserId` INT NOT NULL,
    `SkillName` VARCHAR(150) NOT NULL,
    `Category` VARCHAR(100) NOT NULL,
    `ProficiencyLevel` ENUM('Beginner', 'Intermediate', 'Advanced', 'Expert') DEFAULT 'Intermediate',
    `CreatedAt` DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (`UserId`) REFERENCES `tbl_users`(`UserId`) ON DELETE CASCADE
) ENGINE=InnoDB;

-- Sample Known Skills for Students
INSERT INTO `tbl_user_skills` (`UserId`, `SkillName`, `Category`, `ProficiencyLevel`) VALUES
(1, 'C# Programming', 'Computer Science & IT', 'Advanced'),
(1, 'SQL & Database Design', 'Computer Science & IT', 'Intermediate'),
(2, 'Acoustic Guitar', 'Music & Arts', 'Intermediate'),
(3, 'Calculus & Algebra', 'Engineering & Math', 'Advanced'),
(4, 'Figma & UI Design', 'Graphic & Visual Design', 'Expert');

-- -----------------------------------------------------------------------------
-- 4. Table: tbl_skills (Marketplace Listings)
-- Created in My Listings by selecting one of the student's known skills.
-- -----------------------------------------------------------------------------
DROP TABLE IF EXISTS `tbl_skills`;
CREATE TABLE `tbl_skills` (
    `SkillId` INT AUTO_INCREMENT PRIMARY KEY,
    `UserId` INT NOT NULL,
    `UserSkillId` INT NULL,
    `SkillTitle` VARCHAR(150) NOT NULL,
    `Category` VARCHAR(100) NOT NULL,
    `Description` TEXT NOT NULL,
    `OfferedBy` VARCHAR(100) NOT NULL,
    `DesiredSkill` VARCHAR(150) DEFAULT 'Open to any skill',
    `DeliveryMode` ENUM('Online', 'Face-to-Face') DEFAULT 'Online',
    `Location` VARCHAR(150) DEFAULT NULL,
    `Status` ENUM('Active', 'Paused', 'Flagged', 'Under Review', 'Completed', 'Archived') DEFAULT 'Active',
    `CreatedAt` DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (`UserId`) REFERENCES `tbl_users`(`UserId`) ON DELETE CASCADE
) ENGINE=InnoDB;

INSERT INTO `tbl_skills` (`UserId`, `UserSkillId`, `SkillTitle`, `Category`, `Description`, `OfferedBy`, `DesiredSkill`, `DeliveryMode`, `Location`, `Status`) VALUES
(1, 1, 'C# & .NET WinForms Tutoring', 'Computer Science & IT', 'Guiding students through object-oriented programming, WinForms layouts, and SQL connectivity.', 'Zach Plata', 'Figma UI Basics', 'Online', 'Discord / Google Meet', 'Active'),
(4, 5, 'Figma UI/UX Mockups & Prototyping', 'Graphic & Visual Design', 'Will design clean user interfaces and interactive prototypes for your student projects.', 'Andrei Sarmiento', 'C# Tutoring', 'Online', 'Discord', 'Active'),
(3, 4, 'Calculus & Differential Equations', 'Engineering & Math', 'Step-by-step tutoring on derivatives, integrals, and exam prep.', 'Gabs Katipunan', 'Any Creative Skill', 'Face-to-Face', 'Tan Yan Kee Bldg 3rd Flr', 'Active'),
(2, 3, 'Beginner Guitar Lessons', 'Music & Arts', 'Learn basic chords, strumming rhythms, and fingerstyle acoustic basics.', 'Trowa Bugarin', 'Web Development', 'Face-to-Face', 'UE Student Center', 'Active');

-- -----------------------------------------------------------------------------
-- 5. Table: tbl_traderequests (Proposals between students)
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
-- 6. Table: tbl_reports (Listing & student reports)
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
-- 7. Table: tbl_notifications (User & Admin in-app notifications)
-- -----------------------------------------------------------------------------
DROP TABLE IF EXISTS `tbl_notifications`;
CREATE TABLE `tbl_notifications` (
    `NotificationId` INT AUTO_INCREMENT PRIMARY KEY,
    `UserId` INT DEFAULT NULL,
    `UserEmail` VARCHAR(100) DEFAULT NULL,
    `TargetRole` ENUM('Student', 'Admin') DEFAULT 'Student',
    `Title` VARCHAR(150) NOT NULL,
    `Message` TEXT NOT NULL,
    `Type` VARCHAR(50) DEFAULT 'Info',
    `RelatedId` INT DEFAULT NULL,
    `IsRead` TINYINT(1) DEFAULT 0,
    `CreatedAt` DATETIME DEFAULT CURRENT_TIMESTAMP,
    INDEX (`UserId`),
    INDEX (`UserEmail`),
    INDEX (`TargetRole`),
    INDEX (`IsRead`)
) ENGINE=InnoDB;

-- -----------------------------------------------------------------------------
-- 8. Table: tbl_tos (Terms of Service)
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
