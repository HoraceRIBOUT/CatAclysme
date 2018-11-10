using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step {

    public Utils.StepType type = Utils.StepType.Description;
    public string[,] grid;
    public uint y; // strange value due to the CSV_reader.

    public Step(string[,] grid, uint y) {
        type = Utils.stringToEnum(grid[0, y]);
        this.grid = grid;
        this.y = y;
    }

    public string get(int i)
    {
        return grid[i, y];
    }

}
