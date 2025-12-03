using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SWE316HW2MA
{
    /// <summary>
    /// IVisualizationStrategy - Strategy Interface in the Strategy Pattern
    /// Defines the contract for different visualization algorithms
    /// </summary>
    internal interface IVisualizationStrategy
    {
        void Visualize(Folder rootFolder, Panel panel);
    }
}