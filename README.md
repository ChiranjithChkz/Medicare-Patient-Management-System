# Hospital Patient Management System 
This is a simple hospital patient management system. This is based on C-sharp language.C sharp language has Four fundamental pillar. Those are Encapsulation, Polymophism, Inheritance and lastly Abstruct.This project is focused on those four fundamental pillar. On the whole this project is a real world example of that language.
This is the flow chart of this project. Also all steps are given in the image folder.
![image alt](https://github.com/ChiranjithChkz/Medicare-Patient-Management-System/blob/main/image/Lab4_Manual_4.jpg?raw=true)
# Output in terminal: 
![image alt](https://github.com/ChiranjithChkz/Medicare-Patient-Management-System/blob/main/image/Screenshot%202026-04-08%20185130.png?raw=true)

<div align="center">

# 🏥 Hospital Patient Management System (C#)

</div>

---

> 🟦 **A structured and object-oriented Hospital Patient Management System built using C# (.NET Console Application), demonstrating strong OOP principles, custom exception handling, and clean software architecture.**

---

## ✨ Project Overview
This project is designed to manage hospital patient data efficiently, including general patients and surgery patients.  
It focuses on building a **robust, scalable, and error-safe system** using core **Object-Oriented Programming (OOP)** principles in C#.

---

## 🧠 Core OOP Concepts Implemented

### 🔷 Encapsulation
- Sensitive data is protected using private fields
- Controlled access through validated properties

### 🔷 Inheritance
- Base class `Patient` extended into specialized classes like `SurgeryPatient`
- Promotes code reuse and clean structure

### 🔷 Polymorphism
- Method overriding used for dynamic behavior
- Different patient types behave differently at runtime

### 🔷 Abstraction
- Internal complexity is hidden from the user
- Only essential operations are exposed

---

## ⚠️ Exception Handling System
- Fully implemented `try-catch` blocks
- Prevents runtime crashes and invalid operations
- Ensures system stability

---

## 🚨 Custom Exceptions
- Domain-specific exceptions created for better control
- Improves debugging and error clarity
- Example cases:
  - Invalid patient input
  - Missing required medical details
  - Incorrect insurance ID format

---

## 🛠️ Technologies Used
- 💻 Language: C#
- ⚙️ Framework: .NET Console Application
- 🧑‍💻 IDE: Visual Studio / VS Code

---

## 📂 Project Structure

lab-task/
├── lab-task.sln                # Visual Studio Solution file
├── lab-task.csproj             # Project configuration file
├── Program.cs                  # Main entry point of the application
├── Test.cs                     # Unit tests or manual test cases
│
├── Entities/
│   ├── Patient.cs              # Core Patient model
│   ├── PatientType.cs          # Enum or class defining patient categories
│   └── SafePatientList.cs      # Collection wrapper for patient management
│
├── Sections/
│   ├── GeneralSection.cs       # Logic for the General Ward
│   ├── EmergencySection.cs     # Logic for the Emergency Department
│   └── SurgerySection.cs       # Logic for the Surgery Department
│
├── Interfaces/
│   ├── IBillable.cs            # Interface for items that can be invoiced
│   ├── IInsurance.cs           # Interface for insurance processing
│   └── ITransferable.cs        # Interface for patient transfers
│
├── Services/
│   ├── HospitalReception.cs    # Management of patient intake
│   └── ApplyDiscount.cs        # Logic for billing discounts
│
└── Exceptions/                 # Custom Exception classes
    ├── BedUnavailableException.cs
    ├── InsuranceClaimRejectedException.cs
    ├── InvalidPatientDataException.cs
    └── MediCareException.cs