using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SWE316HW2MA
{
    /// <summary>
    /// File class - Leaf in the Composite Pattern
    /// Represents a file in the file system hierarchy
    /// </summary>
    internal class File : FileSystemComponent
    {
        // [1]: Attributes: Additional attribute for File
        private string extension;

        // [2]:  Constructor
        public File(string name, long size, string extension) : base(name)
        {
            this.size = size;
            this.extension = extension;
        }


        // [3]: Gettters and Setters
        public string GetExtension()
        {
            return extension;
        }

        // [4]: Overriding Component Methods
        public override string GetName() { return name; }
        public override long GetSize() { return size; }
        public override void Add(FileSystemComponent component) { throw new NotSupportedException("Cannot add components to a File."); }
        public override void Remove(FileSystemComponent component) { throw new NotSupportedException("Cannot remove components from a File."); }
        public override FileSystemComponent GetChild(int index) { throw new NotSupportedException("File has no children."); }
        public override List<FileSystemComponent> GetChildren() { return new List<FileSystemComponent>(); }


        public override Color GetBoxColor() { return Color.LightGreen; }
        public override string GetIconKey() { return "file"; }

    }
}
