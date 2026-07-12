# 🚗 Driving & Vehicle License Department (DVLD) System

An enterprise-grade desktop application built with C# and .NET Framework to automate and streamline the management of driving license services. This project implements a robust **3-Tier Architecture** to ensure high data integrity, security, and scalability[span_0](start_span)[span_0](end_span).

## 📋 Project Overview
The **DVLD System** provides a digital transformation for licensing authorities. It manages the full lifecycle of a license, from personal record registration to the issuance of professional licenses, ensuring every step is documented and validated against strict business rules[span_1](start_span)[span_1](end_span).

## 🛠 Tech Stack
*   **Language:** C# (.NET Framework)
*   **UI:** Windows Forms
*   **Database:** SQL Server (ADO.NET)
*   **Design Pattern:** 3-Tier Architecture (Presentation, BLL, DAL)

---

## 🚀 System Modules & Showcase

### 1. Authentication & Core Interface
Secure access control and the main dashboard for navigation.
![Login Screen](images/login_1.png)
![Main Dashboard](images/main_screen.png)
*   **Features:** Secure login, session management, and role-based access[span_2](start_span)[span_2](end_span).

### 2. Person Management (The Foundation)
A centralized module to manage all individuals in the system.
![Person List](images/person_1.png)
![Person Details](images/person_2.png)
![Add/Edit Person](images/person_3.png)
![Person Search & Filtering](images/person_4.png)
*   **Features:** National ID integration, duplication prevention, and advanced filtering capabilities[span_3](start_span)[span_3](end_span).

### 3. User Management
System user administration with strict security protocols.
![User List](images/user_1.png)
![User Details](images/user_2.png)
![Add/Edit User](images/user_3.png)
![Change Password/Security](images/user_4.png)
*   **Features:** Role mapping to Persons, account activation, and high-security credential management[span_4](start_span)[span_4](end_span).

---

## 🏗 Architectural Strength
The system is built on **3-Tier Architecture**[span_5](start_span)[span_5](end_span):
*   **Presentation Layer:** Intuitive UI with real-time input validation[span_6](start_span)[span_6](end_span).
*   **Business Layer (BLL):** Enforces complex logic like age requirements and license eligibility[span_7](start_span)[span_7](end_span).
*   **Data Access Layer (DAL):** Secure communication with SQL Server via Stored Procedures[span_8](start_span)[span_8](end_span).

## 🛣 Roadmap & Future Scope
*   [ ] **License Classes Management:** Defining categories, fees, and validity[span_9](start_span)[span_9](end_span).
*   [ ] **Testing System:** Scheduling vision, written, and practical tests[span_10](start_span)[span_10](end_span).
*   [ ] **License Services:** New, Renewal, Replacement, and International licenses[span_11](start_span)[span_11](end_span).
*   [ ] **Restriction Management:** License locking and unlocking[span_12](start_span)[span_12](end_span).

## 🛡 Auditing
Transparency is at our core: every transaction, update, or deletion is timestamped and attributed to the specific user, ensuring full accountability across all system operations[span_13](start_span)[span_13](end_span).
