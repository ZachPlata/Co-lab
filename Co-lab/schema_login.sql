-- =============================================================================
-- Co-LAB: Authentication & User System Schema
-- Target Database: db_colab
-- Compatible with LoginForm.cs, uc_Login.cs, uc_Register.cs, uc_ForgotPassword.cs
-- =============================================================================

CREATE DATABASE IF NOT EXISTS `db_colab` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `db_colab`;

-- -----------------------------------------------------------------------------
-- Table: tbl_users
-- Required columns based on the application code:
--   - UserId: Auto-increment primary key
--   - FullName: Student / Admin full name
--   - Email: @ue.edu.ph institutional email (UNIQUE)
--   - Password: Stored password (plain-text / hashed via AuthHelper)
--   - Role: 'Student' or 'Admin'
--   - StudentNumber: Optional student identification number
--   - College: Optional department / college name
--   - SecurityQuestion: Used for forgot password recovery
--   - SecurityAnswer: Lowercase answer for forgot password recovery
--   - is_blacklisted: 0 = active, 1 = suspended / banned
--   - BanReason: Text explanation if account is suspended
--   - CreatedAt: Account creation timestamp
-- -----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `tbl_users` (
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

-- -----------------------------------------------------------------------------
-- Populate ONLY the 5 specific users (Password: 12345678)
-- -----------------------------------------------------------------------------
INSERT INTO `tbl_users` (`UserId`, `FullName`, `Email`, `Password`, `Role`, `SecurityQuestion`, `SecurityAnswer`) VALUES
(1, 'Zach Plata', 'plata.zachbenedict@ue.edu.ph', '12345678', 'Student', 'What was the name of your first pet?', 'dog'),
(2, 'Trowa Bugarin', 'bugarin.trowabarton@ue.edu.ph', '12345678', 'Student', 'What was the name of your first pet?', 'dog'),
(3, 'Gabs Katipunan', 'katipunan.karisgabriel@ue.edu.ph', '12345678', 'Student', 'What was the name of your first pet?', 'dog'),
(4, 'Andrei Sarmiento', 'sarmiento.andrei@ue.edu.ph', '12345678', 'Student', 'What was the name of your first pet?', 'dog'),
(5, 'Miguel Borja', 'borja.miguelantonio@ue.edu.ph', '12345678', 'Student', 'What was the name of your first pet?', 'dog')
ON DUPLICATE KEY UPDATE 
    `FullName` = VALUES(`FullName`),
    `Password` = VALUES(`Password`),
    `Role` = VALUES(`Role`),
    `SecurityQuestion` = VALUES(`SecurityQuestion`),
    `SecurityAnswer` = VALUES(`SecurityAnswer`);

