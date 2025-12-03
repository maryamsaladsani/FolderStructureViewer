using SWE316HW2MA;

namespace WinFormsApp1
{
    public partial class GUI : Form
    {

        // [1]: Core Components
        private Folder rootFolder;
        private Visualizer visualizer;
        private FileSystemLoader loader;


        // [2]: Constructor
        public GUI()
        {
            InitializeComponent();

            // Initialize core components
            visualizer = new Visualizer();
            loader = new FileSystemLoader();

            MessageBox.Show("All classes loaded successfully!", "Test");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        // [4]: Browse Button Click - Load folder structure
        private void visualizationPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        // [5]: Tree Button Click - Visualize as Tree
        private void treeBtn_Click(object sender, EventArgs e)
        {
            if (rootFolder == null)
            {
                MessageBox.Show("Please select a folder first!", "No Folder Loaded",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Strategy Pattern in action!
                // Step 1: Set the strategy to Tree
                visualizer.SetStrategy(new TreeVisualizationStrategy());

                // Step 2: Visualize (SINGLE LINE CALL!)
                visualizer.Visualize(rootFolder, visualizationPanel);

                // Optional: Update status
                this.Text = $"Folder Traverser - Tree View - {rootFolder.GetFormattedSize()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error visualizing:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // [6]: Bar Chart Button Click - Visualize as Bar Chart
        private void barChartBtn_Click(object sender, EventArgs e)
        {
            if (rootFolder == null)
            {
                MessageBox.Show("Please select a folder first!", "No Folder Loaded",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Strategy Pattern in action!
                // Step 1: Set the strategy to Bar Chart
                visualizer.SetStrategy(new BarChartVisualizationStrategy());

                // Step 2: Visualize (SINGLE LINE CALL!)
                visualizer.Visualize(rootFolder, visualizationPanel);

                // Optional: Update status
                this.Text = $"Folder Traverser - Bar Chart View - {rootFolder.GetFormattedSize()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error visualizing:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select a folder to visualize";
                dialog.ShowNewFolderButton = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Show loading message (optional - update a status label if you have one)
                        this.Cursor = Cursors.WaitCursor;

                        // Step 1: Load folder structure using FileSystemLoader
                        rootFolder = loader.LoadFromPath(dialog.SelectedPath);

                        // Step 2: Calculate all sizes (SINGLE LINE CALL - Composite Pattern!)
                        rootFolder.GetSize();

                        // Step 3: Update the TreeView on the left
                        UpdateTreeView();

                        // Step 4: Enable visualization buttons
                        // Note: Update these names to match your actual button names from designer
                        // treeBtn.Enabled = true;
                        // barChartBtn.Enabled = true;

                        // Step 5: Show statistics (optional - if you have a status label)
                        int fileCount = FileSystemHelper.CountFiles(rootFolder);
                        int folderCount = FileSystemHelper.CountFolders(rootFolder);
                        string stats = $"Loaded: {fileCount} files, {folderCount} folders - Total: {rootFolder.GetFormattedSize()}";

                        // Show message
                        MessageBox.Show(stats, "Folder Loaded Successfully",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Step 6: Auto-visualize as tree
                        treeBtn_Click(sender, e);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading folder:\n{ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }

        }

        // [9]: Helper Method - Update TreeView
        /// <summary>
        /// Updates the TreeView on the left side with the folder structure
        /// </summary>
        private void UpdateTreeView()
        {
            treeView1.Nodes.Clear();

            // Create root node
            TreeNode rootNode = new TreeNode(rootFolder.GetName());
            rootNode.Tag = rootFolder; // Store reference to the folder object

            // Recursively add all children
            AddComponentToTreeNode(rootFolder, rootNode);

            // Add to TreeView and expand
            treeView1.Nodes.Add(rootNode);
            rootNode.Expand();
        }

        // [10]: Helper Method - Recursively add to TreeNode
        /// <summary>
        /// Recursively adds file system components to TreeView nodes
        /// </summary>
        private void AddComponentToTreeNode(FileSystemComponent component, TreeNode node)
        {
            if (component is Folder)
            {
                Folder folder = (Folder)component;
                List<FileSystemComponent> children = folder.GetChildren();

                foreach (FileSystemComponent child in children)
                {
                    // Create node with name and size
                    string nodeName = $"{child.GetName()} ({child.GetFormattedSize()})";
                    TreeNode childNode = new TreeNode(nodeName);
                    childNode.Tag = child; // Store reference

                    node.Nodes.Add(childNode);

                    // Recurse for folders
                    AddComponentToTreeNode(child, childNode);
                }
            }
        }
    }
}
