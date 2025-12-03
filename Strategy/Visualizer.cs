using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SWE316HW2MA
{
    /// <summary>
    /// Visualizer - Context in the Strategy Pattern
    /// Acts as a wrapper that uses the strategy interface to delegate visualization
    /// This class separates the visualization logic from the main application
    /// </summary>
    internal class Visualizer
    {
        // [1]: Attributes
        private IVisualizationStrategy strategy;

        // [2]: Constructors
        public Visualizer()
        {
            // default strategy is Tree
            this.strategy = new TreeVisualizationStrategy();
        }

        public Visualizer(IVisualizationStrategy strategy)
        {
            this.strategy = strategy;
        }

        // [3]: Methods
        public void SetStrategy(IVisualizationStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Visualize(FileSystemComponent root, Panel panel)
        {
            if (strategy == null)
            {
                throw new InvalidOperationException("Strategy not set. Please call SetStrategy() first.");
            }

            // Clear the panel before drawing
            panel.Controls.Clear();

            // Delegate to the strategy - this is the Strategy Pattern in action!
            strategy.Visualize(root, panel);
        }
    }
}