# Folder Visualizer

Windows Forms application demonstrating **Composite** and **Strategy** design patterns through folder structure visualization.

## What It Does

Browse any folder on your computer and visualize it as:
- **Tree View**: Hierarchical structure with connecting lines
- **Bar Chart**: Size comparison with proportional bars

Features auto-calculating folder sizes, responsive UI, and color-coded files/folders.

## Design Patterns

### Composite Pattern
Treats files and folders uniformly in a tree structure.

```
FileSystemComponent (abstract)
├── File (leaf)
└── Folder (composite)
```

**Why?** Enables recursive size calculation and uniform handling of files/folders.

### Strategy Pattern
Swappable visualization algorithms at runtime.

```
IVisualizationStrategy (interface)
├── TreeVisualizationStrategy
└── BarChartVisualizationStrategy
```

**Why?** Add new visualizations without modifying existing code (Open/Closed Principle).

## Project Structure

```
SWE316HW2MA/
├── Composite/                   # File system hierarchy
│   ├── FileSystemComponent.cs   # Abstract component
│   ├── File.cs                  # Leaf
│   └── Folder.cs                # Composite
│
├── Strategy/                    # Visualization strategies
│   ├── IVisualizationStrategy.cs
│   ├── TreeVisualizationStrategy.cs
│   ├── BarChartVisualizationStrategy.cs
│   └── Visualizer.cs            # Context
│
├── GUI.cs                       # Main form logic
├── FileSystemLoader.cs          # Disk I/O
└── FileSystemHelper.cs          # Utilities
```

## Quick Start

**Requirements:** .NET 10.0, Windows, Visual Studio 2022

```bash
# Clone and open
git clone <repo-url>
cd SWE316HW2MA

# Build & Run
dotnet build
dotnet run
```

**Usage:**
1. Click "Browse" → Select a folder
2. Click "Tree" or "BarChart" to visualize
3. Resize window → UI adapts automatically

## Key Implementation Details

### Responsive UI
All controls use `Anchor` properties:
- `visualizationPanel`: Expands to fill available space
- `treeView1`: Resizes vertically
- `browseBtn`: Stays bottom-left

### Size Calculation
```csharp
// Composite Pattern in action
public override long GetSize()
{
    size = 0;
    foreach (FileSystemComponent child in children)
        size += child.GetSize();  // Recursive!
    return size;
}
```

### Strategy Switching
```csharp
// Runtime algorithm change
visualizer.SetStrategy(new TreeVisualizationStrategy());
visualizer.Visualize(root, panel);
```

## SOLID Principles Applied

✓ **Single Responsibility**: Each class has one job  
✓ **Open/Closed**: Add visualizations without modifying core  
✓ **Liskov Substitution**: Files/Folders interchangeable  
✓ **Interface Segregation**: Clean, focused interfaces  
✓ **Dependency Inversion**: Depends on abstractions

## Possible Extensions

- Pie chart strategy
- File type filtering
- Search functionality
- Export to PNG/SVG
- Dark mode theme

---

**Course:** SWE316 - Software Design and Architecture  
**Institution:** King Fahd University of Petroleum and Minerals (KFUPM)  
**Author:** Maryam Aladsani