# Fitness Tracker & Planner

## Overview
The **Fitness Tracker & Planner** is a C# console application designed to help users log workouts, track goals, and monitor progress over time. The project demonstrates **object-oriented programming principles** including **abstraction, encapsulation, inheritance, and polymorphism**, and is structured to be modular, maintainable, and extensible.

## Features
- Log **Cardio** and **Strength** workouts with details such as duration, distance, sets, reps, and weight.
- Maintain a **Workout Log** that tracks all workouts and allows filtering by type.
- Set and monitor **Fitness Goals** with progress tracking and completion checks.
- Generate **Weekly and Monthly summaries** using the `ProgressTracker`.
- Receive **motivational feedback** based on workout progress.
- Fully interactive console interface for entering workouts and viewing progress.

## Project Structure
FitnessTrackerPlanner/
│
├── FitnessTrackerPlanner.csproj
├── Program.cs
│
├── Controllers/
│ └── ProgramController.cs
│
└── Models/
├── FitnessTracker.cs
├── Workout.cs
├── CardioWorkout.cs
├── StrengthWorkout.cs
├── Exercise.cs
├── Goal.cs
├── User.cs
├── WorkoutLog.cs
└── ProgressTracker.cs

markdown
Copy code

### Models
- **Workout (abstract)**: Base class for all workout types.
- **CardioWorkout**: Subclass of `Workout` for cardio exercises.
- **StrengthWorkout**: Subclass of `Workout` for strength exercises.
- **Exercise**: Represents individual exercises in a strength workout.
- **User**: Represents the user, tracks workouts and goals.
- **WorkoutLog**: Manages a collection of workouts.
- **Goal**: Represents fitness goals and tracks progress.
- **ProgressTracker**: Generates weekly/monthly summaries and provides motivational feedback.
- **FitnessTracker**: Main class coordinating workouts, goals, and progress.

### Controllers
- **ProgramController**: Handles user input and orchestrates program execution.

## Getting Started

### Prerequisites
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- A terminal or IDE that supports .NET (e.g., VS Code, Visual Studio)

### Running the Program
1. Clone the repository:
   ```bash
   git clone <your-repo-url>
   cd FitnessTrackerPlanner
Build the project:

bash
Copy code
dotnet build
Run the program:

bash
Copy code
dotnet run
Usage
Enter your name when prompted.

Choose to log a Cardio or Strength workout.

Provide details such as duration, distance, sets, reps, and weights.

View your workout summaries and motivational feedback.

Goals can be added and tracked dynamically.

Design Highlights
Abstraction: The Workout class abstracts shared properties and methods for all workout types.

Encapsulation: Private member variables with public methods ensure safe access and modification.

Inheritance: CardioWorkout and StrengthWorkout inherit from Workout to reuse shared functionality.

Polymorphism: Workout references are used to handle multiple workout types uniformly.

Future Enhancements
Add data persistence using JSON or a database.

Include graphical progress charts.

Implement goal reminders and notifications.

Extend workout types (e.g., Yoga, HIIT) without modifying existing code.

Author
Alexander Kokona
CSE210 – Programming with Classes (Fall 2025)