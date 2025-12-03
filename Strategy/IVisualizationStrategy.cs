using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SWE316HW2MA
{
    /// <summary>
    /// IVisualizationStrategy - Strategy Interface in the Strategy Pattern
    /// Upper level for different visualization algorithms
    /// </summary>
    internal interface IVisualizationStrategy
    {
        void Visualize(FileSystemComponent root, Panel panel);
    }
}