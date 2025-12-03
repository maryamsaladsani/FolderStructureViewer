using System;
using System.Collections.Generic;
using System.Text;

namespace SWE316HW2MA
{
    /// <summary>
    /// FileSystemHelper - Utility class for common file system operations that
    /// are not related to a specific file/folder rather than for this program
    /// Provides helper methods that can be used by multiple strategies
    /// Follows Single Responsibility and keeps strategy classes clean
    /// </summary>
    internal static class FileSystemHelper
    {

        // Finds the maximum size among all components in the folder structure
        // Useful for scaling visualizations (especially bar charts and may be future charts OCP)
        public static long FindMaxSize(FileSystemComponent root)
        {
            long maxSize = root.GetSize();
            List<FileSystemComponent> allComponents = FlattenStructure(root);

            foreach (FileSystemComponent component in allComponents)
            {
                if (component.GetSize() > maxSize)
                {
                    maxSize = component.GetSize();
                }
            }

            return maxSize;
        }

        // Flattens the folder structure into a single list
        public static List<FileSystemComponent> FlattenStructure(FileSystemComponent root)
        {
            List<FileSystemComponent> result = new List<FileSystemComponent>();
            FlattenRecursive(root, result);
            return result;
        }

        // Recursive helper for flattening the structure
        private static void FlattenRecursive(FileSystemComponent component, List<FileSystemComponent> result)
        {
            result.Add(component);

            List<FileSystemComponent> children = component.GetChildren();

            foreach (FileSystemComponent child in children)
            {
                FlattenRecursive(child, result);
            }
            
        }
    }
}