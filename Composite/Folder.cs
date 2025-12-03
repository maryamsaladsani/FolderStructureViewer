using System;
using System.Collections.Generic;
using System.Text;

namespace SWE316HW2MA
{
    /// <summary>
    /// Folder class - Composite in the Composite Pattern
    /// Represents a folder in the file system hierarchy that can contain files and other folders
    /// </summary>
    internal class Folder : FileSystemComponent
    {
        // [1]: Attributes: Additional attribute for Folder
        private List<FileSystemComponent> children;

        // [2]: Constructor
        public Folder(string name) : base(name)
        {
            this.children = new List<FileSystemComponent>();
        }

        // [3]: Getters and Setters
        // (No additional getters/setters needed for this class)

        // [4]: Overriding Component Methods
        public override string GetName()
        {
            return name;
        }

        public override long GetSize()
        {
            size = 0;
            foreach (FileSystemComponent child in children)
            {
                size += child.GetSize();
            }
            return size;
        }

        public override void Add(FileSystemComponent component)
        {
            children.Add(component);
        }

        public override void Remove(FileSystemComponent component)
        {
            children.Remove(component);
        }

        public override FileSystemComponent GetChild(int index)
        {
            if (index >= 0 && index < children.Count)
            {
                return children[index];
            }
            throw new ArgumentOutOfRangeException("Index is out of range.");
        }

        public override List<FileSystemComponent> GetChildren()
        {
            return children;
        }
    }
}

  