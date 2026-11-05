using Microsoft.AspNetCore.Components;

namespace Sudoku_Solver_From_Scratch.Components.BackEnd;

public class SudokuBoard
{
    public int[,] Grid { get; set; } = new int[9, 9];
    
    public bool[,] UserInput { get; set; } = new bool[9, 9];
    
    public void SetCell(int row, int col, int value)
    {
        Grid[row, col] = value;
    }

    public void SolveSudoku()
    {
        int n = Grid.GetLength(0);
        int[] row = new int[n];
        int[] col = new int[n];
        int[] box = new int[n];

        // Set the bits in bitmasks for values that are initially present
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (Grid[i, j] != 0) {
                    row[i] |= (1 << Grid[i, j]);
                    col[j] |= (1 << Grid[i, j]);
                    box[(i / 3) * 3 + j / 3] |= (1 << Grid[i, j]);
                }
            }
        }

        SolveRec(Grid, 0, 0, row, col, box);
    }

    // Imported from my github repo: https://github.com/Haydara1/cs-cli-tools/blob/master/Sudoku/Sudoku-Solver.cs
    
    // The following solver uses bit-masking and backtracking.

    // Define a function to check whether it is safe to put a number in a given position.
    private bool IsSafe(int[,] mat, int row, int col, int num)
    {
        // Check if num exists in the row or the column:
        for (int i = 0; i < 9; i++)
        {
            if (mat[row, i] == num || mat[i, col] == num)
            {
                return false;
            }
        }
        
        // Check if num exist in the 3 by 3 box:
        int startRow = row - (row % 3);
        int startColumn = col - (col % 3);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (mat[startRow + i, startColumn + j] == num)
                {
                    return false;
                }
            }
        }

        return true;
    }

    // Define a function to solve the sudoku:
    private bool SolveRec(int[,] mat, int i, int j,
        int[] row, int[] col, int[] box)
    {
        int n = mat.GetLength(0);
        
        // Reached the end:
        if (i == n - 1 && j == n)
        {
            return true;
        }
        
        // If reached the last column of the row, move to next row
        if (j == n)
        {
            i++;
            j = 0;
        }
        
        // If cell already occupied move to next cell
        if (mat[i, j] != 0)
        {
            return SolveRec(mat, i, j + 1, row, col, box);
        }

        for (int num = 1; num <= n; num++)
        {

            // If it is safe to place num at current position
            if (IsSafe(mat, i, j, num))
            {
                mat[i, j] = num;

                // Update masks for the corresponding row, column, and box
                row[i] |= (1 << num);
                col[j] |= (1 << num);
                box[i / 3 * 3 + j / 3] |= (1 << num);

                if (SolveRec(mat, i, j + 1, row, col, box))
                    return true;

                // Unmask the number num in the corresponding row, column and box masks
                mat[i, j] = 0;
                row[i] &= ~(1 << num);
                col[j] &= ~(1 << num);
                box[i / 3 * 3 + j / 3] &= ~(1 << num);
            }
        }

        return false;
    }
    
    // Clear the board:

    public void Clear()
    {
        for (int i = 0; i < Grid.GetLength(0); i++)
        {
            for (int j = 0; j < Grid.GetLength(1); j++)
            {
                Grid[i, j] = 0;
                UserInput[i, j] = false;
            }
        }
    }
        
}