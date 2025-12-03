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
    /// </summary>
    internal class TreeVisualizationStrategy : IVisualizationStrategy
    {
        // [1]: Attributes
        private int indentSize;        // Horizontal spacing for each level
        private int verticalSpacing;   // Vertical spacing between items
        private int currentY;          // Tracks current Y position while drawing

        // [2]: Constructor
        public TreeVisualizationStrategy()
        {
            this.indentSize = 40;
            this.verticalSpacing = 50;
        }

        // [3]: Interface Implementation - Override Visualize()
        public void Visualize(FileSystemComponent rootFolder, Panel panel)
        {
            currentY = 10; // Start from top with some padding
            DrawComponent(rootFolder, panel, 10, 0); // Start at level 0
        }

        // [4]: Helper Methods
        // Recursively draws a file system component and its children
        private void DrawComponent(FileSystemComponent component, Panel panel, int x, int level)
        {
            int xPosition = x + (level * indentSize);

            // Draw connecting lines if not root
            if (level > 0)
            {
                // Horizontal line from parent to this box
                Panel horizontalLine = new Panel();
                horizontalLine.BackColor = Color.LightGray;
                horizontalLine.Size = new Size(15, 1);
                horizontalLine.Location = new Point(xPosition - 15, currentY + 10);
                panel.Controls.Add(horizontalLine);

                // Vertical line from parent
                Panel verticalLine = new Panel();
                verticalLine.BackColor = Color.LightGray;
                verticalLine.Size = new Size(1, verticalSpacing);
                verticalLine.Location = new Point(xPosition - 15, currentY - verticalSpacing + 10);
                panel.Controls.Add(verticalLine);
            }

            // Create box/rectangle for the component
            Panel box = new Panel();
            box.BorderStyle = BorderStyle.FixedSingle;
            box.Location = new Point(xPosition, currentY);
            box.AutoSize = false;

            // Diffrentiate colors by POLYMORPHISM - No if statements!
            box.BackColor = component.GetBoxColor();

            // Create label inside the box
            Label label = new Label();
            label.AutoSize = true;
            label.Text = $"{component.GetName()} ({component.GetFormattedSize()})";
            label.Location = new Point(5, 3);
            label.Font = new Font("Segoe UI", 9);

            // Add label to box
            box.Controls.Add(label);
            box.Size = new Size(label.Width + 15, label.Height + 10);
            panel.Controls.Add(box);

            currentY += verticalSpacing;

            // USE POLYMORPHISM - Draw children if they exist
            foreach (FileSystemComponent child in component.GetChildren())
            {
                DrawComponent(child, panel, x, level + 1);
            }
        }
    }
}