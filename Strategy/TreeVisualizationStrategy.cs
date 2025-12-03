using SWE316HW2MA;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SWE316HW2MA
{
    /// <summary>
    /// TreeVisualizationStrategy - Concrete Strategy for tree-style visualization
    /// Implements IVisualizationStrategy to draw folder structure in hierarchical tree layout
    /// Shows folders and files with indentation based on their depth level
    /// </summary>
    internal class TreeVisualizationStrategy : IVisualizationStrategy
    {
        // [1]: Attributes
        private int indentSize;        // Horizontal spacing for each level
        private int verticalSpacing;   // Vertical spacing between items
        private int currentY;          // Tracks current Y position while drawing

        // [2]: Constructors
        public TreeVisualizationStrategy()
        {
            this.indentSize = 20;
            this.verticalSpacing = 25;
        }

        public TreeVisualizationStrategy(int indentSize, int verticalSpacing)
        {
            this.indentSize = indentSize;
            this.verticalSpacing = verticalSpacing;
        }

        // [3]: Interface Implementation - Override Visualize()
        public void Visualize(Folder rootFolder, Panel panel)
        {
            currentY = 10; // Start from top with some padding
            DrawComponent(rootFolder, panel, 10, 0); // Start at level 0
        }

        // [4]: Helper Methods
        // Recursively draws a file system component and its children, This implements the tree visualization logic
        private void DrawComponent(FileSystemComponent component, Panel panel, int x, int level)
        {
            // Calculate indentation based on level
            int xPosition = x + (level * indentSize);

            // Create label for this component
            Label label = new Label();
            label.AutoSize = true;
            label.Location = new Point(xPosition, currentY);
            label.Text = $"{component.GetName()} ({component.GetFormattedSize()})";

            // Different styling for folders vs files
            if (component is Folder)
            {
                label.Font = new Font(label.Font, FontStyle.Bold);
                label.ForeColor = Color.DarkBlue;
            }
            else if (component is File)
            {
                label.ForeColor = Color.DarkGreen;
            }

            panel.Controls.Add(label);
            currentY += verticalSpacing;

            // If it's a folder, draw its children recursively
            if (component is Folder)
            {
                Folder folder = (Folder)component;
                List<FileSystemComponent> children = folder.GetChildren();

                foreach (FileSystemComponent child in children)
                {
                    DrawComponent(child, panel, x, level + 1);
                }
            }
        }
    }
}

//// // [4]: Helper Methods

//// Recursively draws a file system component and its children, This implements the tree visualization logic

//private void DrawComponent(FileSystemComponent component, Panel panel, int x, int level)

//{

//    // Calculate indentation based on level

//    int xPosition = x + (level * indentSize);

//    // Create label for this component

//    Label label = new Label();

//    label.AutoSize = true;

//    label.Location = new Point(xPosition, currentY);

//    label.Text = $"{component.GetName()} ({component.GetFormattedSize()})";

//    // Different styling for folders vs files

//    if (component is Folder)

//    {

//        label.Font = new Font(label.Font, FontStyle.Bold);

//        label.ForeColor = Color.DarkBlue;

//    }

//    else if (component is File)

//    {

//        label.ForeColor = Color.DarkGreen;

//    }

//    panel.Controls.Add(label);

//    currentY += verticalSpacing;

//    // If it's a folder, draw its children recursively

//    if (component is Folder)

//    {

//        Folder folder = (Folder)component;

//        List<FileSystemComponent> children = folder.GetChildren();

//        foreach (FileSystemComponent child in children)

//        {

//            DrawComponent(child, panel, x, level + 1);

//        }

//    }

//}



//my instructor would hit me if he saw this code, no need for if statemnts. instead, we can create a method and override twice it in file and folder classes, with this, we can distinguish, what do u see?