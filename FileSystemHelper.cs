using System;
using System.Collections.Generic;
using System.Text;

namespace SWE316HW2MA
{
    /// <summary>
    /// FileSystemHelper - Utility class for common file system operations
    /// Provides helper methods that can be used by multiple strategies
    /// Follows Single Responsibility and keeps strategy classes clean
    /// </summary>
    internal static class FileSystemHelper
    {
        /// <summary>
        /// Finds the maximum size among all components in the folder structure
        /// Useful for scaling visualizations (especially bar charts)
        /// </summary>
        /// <param name="root">The root folder to search</param>
        /// <returns>Maximum size found in bytes</returns>
        public static long FindMaxSize(Folder root)
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

        /// <summary>
        /// Flattens the folder structure into a single list
        /// Useful for operations that need to process all items sequentially
        /// </summary>
        /// <param name="root">The root folder to flatten</param>
        /// <returns>List containing all files and folders</returns>
        public static List<FileSystemComponent> FlattenStructure(Folder root)
        {
            List<FileSystemComponent> result = new List<FileSystemComponent>();
            FlattenRecursive(root, result);
            return result;
        }

        /// <summary>
        /// Recursive helper for flattening the structure
        /// </summary>
        private static void FlattenRecursive(FileSystemComponent component, List<FileSystemComponent> result)
        {
            result.Add(component);

            if (component is Folder)
            {
                Folder folder = (Folder)component;
                List<FileSystemComponent> children = folder.GetChildren();

                foreach (FileSystemComponent child in children)
                {
                    FlattenRecursive(child, result);
                }
            }
        }

        /// <summary>
        /// Counts total number of files in the folder structure
        /// </summary>
        /// <param name="root">The root folder to count</param>
        /// <returns>Total number of files</returns>
        public static int CountFiles(Folder root)
        {
            int count = 0;
            List<FileSystemComponent> allComponents = FlattenStructure(root);

            foreach (FileSystemComponent component in allComponents)
            {
                if (component is File)
                {
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Counts total number of folders in the folder structure
        /// </summary>
        /// <param name="root">The root folder to count</param>
        /// <returns>Total number of folders (including root)</returns>
        public static int CountFolders(Folder root)
        {
            int count = 0;
            List<FileSystemComponent> allComponents = FlattenStructure(root);

            foreach (FileSystemComponent component in allComponents)
            {
                if (component is Folder)
                {
                    count++;
                }
            }

            return count;
        }
    }
}