using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SWE316HW2MA
{
    /// <summary>
    /// BarChartVisualizationStrategy - Concrete Strategy for bar chart visualization
    /// Implements IVisualizationStrategy to draw folder structure as horizontal bars
    /// Bar width is proportional to size (uses FileSystemHelper for max size)
    /// </summary>
    internal class BarChartVisualizationStrategy : IVisualizationStrategy
    {
        // [1]: Attributes
        private int barHeight;          // Height of each bar
        private int maxBarWidth;        // Maximum width for the largest item
        private int verticalSpacing;    // Space between bars
        private int currentY;           // Tracks current Y position while drawing
        private long maxSize;           // Maximum size to scale bars (from FileSystemHelper)

        // [2]: Constructors
        public BarChartVisualizationStrategy()
        {
            this.barHeight = 30;
            this.maxBarWidth = 500;
            this.verticalSpacing = 10;
        }

        public BarChartVisualizationStrategy(int barHeight, int maxBarWidth, int verticalSpacing)
        {
            this.barHeight = barHeight;
            this.maxBarWidth = maxBarWidth;
            this.verticalSpacing = verticalSpacing;
        }

        // [3]: Interface Implementation - Override Visualize()
        /// <summary>
        /// Visualizes the folder structure as a bar chart
        /// This is the main method that overrides the interface
        /// </summary>
        public void Visualize(Folder rootFolder, Panel panel)
        {
            currentY = 10; // Start from top with padding

            // Use FileSystemHelper to find max size (Separation of Concerns!)
            maxSize = FileSystemHelper.FindMaxSize(rootFolder);

            // Use FileSystemHelper to flatten structure
            List<FileSystemComponent> allItems = FileSystemHelper.FlattenStructure(rootFolder);

            // Draw all items as bars
            foreach (FileSystemComponent item in allItems)
            {
                DrawBar(item, panel);
            }
        }

        // [4]: Helper Methods
        /// <summary>
        /// Draws a single bar for a component
        /// </summary>
        private void DrawBar(FileSystemComponent component, Panel panel)
        {
            // Calculate bar width based on size
            int barWidth = CalculateBarWidth(component.GetSize());

            // Create a panel to represent the bar
            Panel bar = new Panel();
            bar.Location = new Point(10, currentY);
            bar.Size = new Size(barWidth, barHeight);

            // Different colors for folders vs files
            if (component is Folder)
            {
                bar.BackColor = Color.LightBlue;
            }
            else if (component is File)
            {
                bar.BackColor = Color.LightGreen;
            }

            bar.BorderStyle = BorderStyle.FixedSingle;

            // Create label to show name and size
            Label label = new Label();
            label.AutoSize = true;
            label.Location = new Point(barWidth + 20, currentY + 5);
            label.Text = $"{component.GetName()} ({component.GetFormattedSize()})";

            if (component is Folder)
            {
                label.Font = new Font(label.Font, FontStyle.Bold);
            }

            panel.Controls.Add(bar);
            panel.Controls.Add(label);

            currentY += barHeight + verticalSpacing;
        }

        /// <summary>
        /// Calculates the width of a bar based on size relative to max size
        /// Ensures bars are scaled proportionally
        /// </summary>
        private int CalculateBarWidth(long size)
        {
            if (maxSize == 0)
            {
                return 10; // Minimum width
            }

            double ratio = (double)size / maxSize;
            int width = (int)(ratio * maxBarWidth);

            // Ensure minimum width for visibility
            return Math.Max(width, 10);
        }
    }
}