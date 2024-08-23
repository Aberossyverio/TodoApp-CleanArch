# 🎯 TodoApp.Core Architecture

Welcome to the `TodoApp.Core` project! This document provides an overview of the folder structure and responsibilities within the `TodoApp.Core` layer. This layer is essential for defining the core domain logic and operations of our application.

## 📂 Folder Structure

The `TodoApp.Core` layer is organized into the following key folders:

1. **Commands**
2. **Events**
3. **Models**
4. **Queries**
5. **Repositories**
6. **Services**
7. **Specifications**

---

## 📂 Folder Structure Explanation

### Commands 🛠️

The **Commands** folder defines actions for performing data operations. These commands encapsulate the data required for create, read, update, and delete (CRUD) operations. They are executed by handlers or services, providing a structured way to manage the parameters and data necessary for these actions.

### Events 🎉

The **Events** folder handles occurrences within the application. Events represent significant actions or changes that need to be processed or communicated. They play a crucial role in managing and notifying different parts of the system when important events occur, enabling the application to react accordingly.

### Models 📦

The **Models** folder defines the core data entities and their structures. Models represent the data objects used throughout the application, encapsulating the attributes and behaviors related to the domain. They form the foundation for the application's business logic and are used by repositories and services to perform operations.

### Queries 🔍

The **Queries** folder manages requests for retrieving data. Queries specify how data should be fetched from repositories, providing a structured way to request information. Services typically use queries to access data, ensuring that data retrieval is flexible and maintainable.

### Repositories 💾

The **Repositories** folder is responsible for data access and storage operations. Repositories offer interfaces for CRUD operations and abstract the details of data access. This abstraction ensures a clean separation between business logic and the underlying data layer, interacting with the `Infrastructure` layer to perform these operations.

### Services ⚙️

The **Services** folder manages the application's business logic and processes. Services implement business rules, coordinate data operations, and ensure that the application functions as required. They often use repositories to interact with data, bridging the gap between data and business logic.

### Specifications 📜

The **Specifications** folder defines rules and criteria for data validation. Specifications ensure that data meets certain criteria before processing, helping to maintain data integrity. They are used by services to validate data, ensuring that only valid data is processed according to the application's rules.

---
## 📊 Folder Comparison Table

| **Folder**         | **Purpose**                                           | **Responsibilities**                                               | **Focus**                     | **Interactions**                        | **Details**                                                                                   |
|--------------------|-------------------------------------------------------|-------------------------------------------------------------------|--------------------------------|----------------------------------------|-----------------------------------------------------------------------------------------------|
| **Commands**       |  Define commands for performing data operations.      | Encapsulate data needed for CRUD operations.                      | Operation definitions and data encapsulation. | Executed by handlers or services.      | Commands handle data operations by encapsulating the parameters needed for those actions.    |
| **Events**         |  Handle events or occurrences within the application. | Represent occurrences to be handled or notified.                 | Event management and notification. | Triggered by actions within the application. | Events facilitate communication between different parts of the system, enabling reactive features. |
| **Models**         |  Define data entities and their structures.           | Represent data objects used in the application.                  | Data structure and domain representation. | Used by repositories and services.      | Models define the core data and behavior, serving as the foundation for business logic.       |
| **Queries**        |  Manage data retrieval requests.                      | Define how to retrieve data from repositories.                    | Data retrieval and query definition. | Used by services to fetch data.         | Queries abstract data retrieval processes, making data access flexible and maintainable.     |
| **Repositories**   |  Manage data access and storage operations.           | Provide interfaces for CRUD operations and data access.            | Data access and manipulation.    | Interact with the `Infrastructure` layer. | Repositories abstract data access details, maintaining a clean separation from business logic. |
| **Services**       |  Manage business logic and processes.                 | Implement business rules and coordinate data operations.          | Business logic and process management. | Use repositories to interact with data. | Services enforce business rules and manage complex operations, bridging the gap between data and logic. |
| **Specifications** |  Define rules or criteria for validation.              | Ensure data meets defined criteria before processing.             | Data validation and business rules. | Used by services to validate data.      | Specifications enforce data integrity by defining and applying validation rules.             |

---

## 🎯 Domain Example: TodoItem

In this project, the domain being developed is **`TodoItem`**. All related functionalities—such as commands, events, models, queries, repositories, services, and specifications—are grouped within the `TodoItem` folder. This modular approach not only organizes the codebase efficiently but also ensures easier maintenance and scalability as the project evolves.

### 📏 Vertical Slicing Approach

We employ the **vertical slicing** approach in this project. This means that each domain is developed independently with its own set of commands, events, models, queries, repositories, services, and specifications. This method enhances modularity and scalability.

For instance, in this project, the `TodoItem` domain encompasses all related functionalities, which are organized within the `TodoItem` folder. This separation allows for clear boundaries and streamlined development within each domain.

Feel free to explore each folder and file to see how they contribute to the overall design of the `TodoApp.Core` layer. Happy coding! 🚀

---

## 📌 Summary

- **Commands**:  Define actions to perform operations on data.
- **Events**:  Handle and notify about occurrences in the application.
- **Models**:  Represent the data entities used in the application.
- **Queries**:  Manage requests for retrieving data.
- **Repositories**:  Provide interfaces for data access and storage.
- **Services**:  Implement business logic and processes.
- **Specifications**:  Define validation rules and criteria.

This architecture ensures a clean separation of concerns and adheres to the principles of Clean Architecture. Each folder plays a specific role in maintaining the organization and integrity of the application.

---