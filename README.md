#🚗 DVLD - Driving & Vehicle License Department System

A comprehensive **Full-Stack Desktop Application** for managing driving licenses, vehicle registrations, tests, and related services. Built from scratch using C# and SQL Server with a professional 3-tier architecture.

![DVLD Setup](https://raw.githubusercontent.com/zuhairSh/DVLD/main/Screenshots/login.png)

## 🎯 Overview

This project represents a complete, production-grade system modeled after real government operations. It handles all aspects of driving license management including applications, testing (Vision, Written, Practical), license issuance, renewal, replacement, and administrative controls.

## ✨ Key Features

**People & Users Management**
- Complete person database with image support
- Automatic photo management with duplicate prevention
- Role-based user authentication system
- Permission management (CRUD operations)
- Account security with custom login system

**Drivers & Tests System**
- Full lifecycle: Application → Vision Test → Written Test → Practical Test → License Issuance
- Sequential test enforcement (cannot skip tests)
- Test retry management and scoring
- Test appointment scheduling and tracking

**License Services**
- **Local Licenses**: Issue new licenses by category (7 vehicle classes)
- **License Renewal**: Extend existing licenses
- **Replacement Services**: Handle lost/damaged license cases
- **International Licenses**: Issue for class 3 drivers
- **License Detain/Release**: Administrative controls with audit logging

**Administrative Features**
- Complete application tracking (Pending → Approved → Rejected)
- License holder history and records
- Comprehensive reports and analytics
- Audit logging for all operations
- Data integrity with business rule validation

## 🏗️ Architecture

**3-Tier Architecture** (Presentation | Business Logic | Data Access)

```
Presentation Layer (WinForms)
        ↓
Business Logic Layer (Validation, Rules)
        ↓
Data Access Layer (SQL Server + ADO.NET)
```

## 📊 Database Schema

The system uses a relational database with 15+ tables including:
- `Persons`, `Drivers`, `Users`, `Licenses`
- `Applications`, `ApplicationTypes`
- `LocalDrivingLicenseApplications`, `InternationalLicenseApplications`
- `Tests`, `TestAppointments`, `TestTypes`
- `DetainedLicenses`, `LicenseClasses`

See `DVLD_Diagram.pdf` for the complete ER diagram 
**[DVLD System Diagram]
(https://github.com/zuhairSh/DVLD-System_RelationalSchem)**

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2019+
- .NET Framework 4.7+
- SQL Server 2016+

### Default Login
- **Username**: admin
- **Password**: (check database seed)

## 🎬 Demo

Watch the complete project walkthrough:
**[DVLD System Full Demo - Video](https://www.youtube.com/watch?v=DVLD-demo-placeholder)**
--
**[DVLD System - Images](https://www.youtube.com/watch?v=DVLD-demo-placeholder)**

## 🎓 Learning Highlights

This project demonstrates mastery of:
- Professional desktop application architecture
- Complex business logic implementation
- User control reusability and component design
- Test-driven development concepts
- Real-world system modeling
- Advanced C# features (Delegates, Events, Custom Controls)

## 📝 Project Scope

- **Development Time**: 1 month of continuous development
- **Lines of Code**: 9000+ lines (DAL, BLL, UI)

## 🔒 Security Features

- Password hashing for user authentication
- Role-based access control (RBAC)
- Audit logging for all operations
- Data validation at multiple layers
- Prevention of unauthorized license operations

## 📚 Code Quality

- **Architecture**: Strict 3-tier separation
- **Code Style**: Clean Code principles
- **Maintainability**: Highly modular and reusable components

## 🏆 Credits & Acknowledgments

Developed as part of the **Programming Advices Course 19**, with supervision from Dr. Mohamed Abu-Hadhoud. Special thanks for the foundational guidance, with significant independent implementation and enhancements beyond the curriculum.

## 📄 License

This project is for educational purposes.

---

**Made with ❤️ by [Zuhair Al Shell](https://github.com/zuhairSh) | 2026**
