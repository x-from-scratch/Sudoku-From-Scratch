# Sudoku Solver From Scratch

A Sudoku solver and playable board built with **C# and Blazor Server**. The solving logic is written from scratch. Enter a puzzle on the grid, click **Solve**, and the board fills in the solution.

🔗 **[Live Demo](https://sudoku-urix.onrender.com)** (hosted on Render's free tier, so the first load may take up to a minute)

<img width="1470" height="811" alt="Screenshot 2026-11-07 at 22 04 53" src="https://github.com/user-attachments/assets/1c7ef30b-9630-44ff-9afe-388e09b02722" />

## Features

- Interactive 9×9 grid with cell selection and highlighting
- One-click **Solve** and **Clear** buttons
- Custom solver implemented from scratch (backtracking)
- Visual feedback for invalid entries (wrong cells are highlighted)
- Automatic light and dark theme (follows the system setting)
- Responsive layout

## Tech Stack

- C# / .NET 10
- Blazor Server (`InteractiveServer` render mode)
- Plain CSS with scoped component styles (`.razor.css`), CSS variables and container queries

## Getting Started

Try it online at **https://sudoku-urix.onrender.com**, or run it locally:

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) <!-- TODO: version -->

### Run locally

```bash
git clone https://github.com/x-from-scratch/Sudoku-From-Scratch.git
cd Sudoku-From-Scratch
dotnet run
```

Then open the URL printed in the terminal (usually `https://localhost:xxxx`).

## Usage

1. Click a cell to select it.
2. Type a number from 1 to 9 to fill it in. 
3. Click **Solve** to complete the puzzle.
4. Click **Clear** to reset the board.

## Project Structure

```
Components/
├── BackEnd/
│   └── SudokuBoard.cs      # Board state and solving logic
├── SudokuGrid.razor        # 9×9 grid UI component
└── Pages/
    └── Home.razor          # Main page with Solve / Clear controls
```
## Demo

https://github.com/user-attachments/assets/dfa22a96-c4f0-4c2c-8bc6-9d6827c76e13



