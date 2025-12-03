using System;
using System.Collections.Generic;
using System.Text;

namespace SWE316HW2MA
{
    /// <summary>
    /// FileSystemComponent - Component in the Composite Pattern
    /// Abstract base class for File and Folder
    /// </summary>
    internal abstract class FileSystemComponent
    {
        // [1]: Attributes: Common attributes for all file system components
        protected string name;
        protected long size;

        // [2]: Constructor
        public FileSystemComponent(string name)
        {
            this.name = name;
            this.size = 0;
        }

        // [4]: Abstract Methods
        public abstract string GetName();
        public abstract long GetSize();
        public abstract void Add(FileSystemComponent component);
        public abstract void Remove(FileSystemComponent component);
        public abstract FileSystemComponent GetChild(int index);
        public abstract List<FileSystemComponent> GetChildren();


        // HELPERS
        protected string FormatSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = bytes;
            int order = 0;

            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }

            return $"{len:0.##} {sizes[order]}";
        }

        public string GetFormattedSize()
        {
            return FormatSize(size);
        }
    }
}

