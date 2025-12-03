using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SWE316HW2MA
{
    /// <summary>
    /// FileSystemLoader - Responsible for loading folder structures from disk
    /// Separates the concern of file I/O from the application logic
    /// Follows Single Responsibility Principle
    /// </summary>
    internal class FileSystemLoader
    {
        /// <summary>
        /// Loads a folder structure from the specified path
        /// </summary>
        /// <param name="path">The directory path to load</param>
        /// <returns>Folder object representing the loaded structure</returns>
        public Folder LoadFromPath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path cannot be null or empty");
            }

            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException($"Directory not found: {path}");
            }

            return TraverseDirectory(path);
        }

        /// <summary>
        /// Recursively traverses a directory and builds the folder structure
        /// </summary>
        /// <param name="path">The directory path to traverse</param>
        /// <returns>Folder object with all children loaded</returns>
        private Folder TraverseDirectory(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            Folder folder = new Folder(dirInfo.Name);

            try
            {
                // Load all files in this directory
                FileInfo[] files = dirInfo.GetFiles();
                foreach (FileInfo fileInfo in files)
                {
                    try
                    {
                        File file = new File(
                            fileInfo.Name,
                            fileInfo.Length,
                            fileInfo.Extension
                        );
                        folder.Add(file);
                    }
                    catch (Exception ex)
                    {
                        // Skip files that can't be accessed
                        Console.WriteLine($"Could not load file {fileInfo.Name}: {ex.Message}");
                    }
                }

                // Recursively load all subdirectories
                DirectoryInfo[] subDirs = dirInfo.GetDirectories();
                foreach (DirectoryInfo subDir in subDirs)
                {
                    try
                    {
                        Folder subFolder = TraverseDirectory(subDir.FullName);
                        folder.Add(subFolder);
                    }
                    catch (Exception ex)
                    {
                        // Skip directories that can't be accessed
                        Console.WriteLine($"Could not load directory {subDir.Name}: {ex.Message}");
                    }
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Access denied to {path}: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading {path}: {ex.Message}");
            }

            return folder;
        }
    }
}