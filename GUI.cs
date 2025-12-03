using SWE316HW2MA;

namespace WinFormsApp1
{
    public partial class GUI : Form
    {

        // [1]: Core Components
        private FileSystemComponent root;
        private Visualizer visualizer;
        private FileSystemLoader loader;

        // [2]: Constructor
        public GUI()
        {
            InitializeComponent();

            // Initialize core components
            visualizer = new Visualizer();
            loader = new FileSystemLoader();

            SetupTreeViewIcons();
        }



        // [3]: Area(A) - TreeView
        // Updates the TreeView on the left side with the folder structure
        private void UpdateTreeView()
        {
            treeView1.Nodes.Clear();

            // Create root node
            TreeNode rootNode = new TreeNode(root.GetName());
            rootNode.Tag = root;
            rootNode.ImageKey = root.GetIconKey();
            rootNode.SelectedImageKey = root.GetIconKey();

            // Recursively add all children
            AddComponentToTreeNode(root, rootNode);

            // Add to TreeView and expand
            treeView1.Nodes.Add(rootNode);
            rootNode.Expand();
        }

        // Helper Method: Recursively adds file system components to TreeView nodes
        private void AddComponentToTreeNode(FileSystemComponent component, TreeNode node)
        {
            
            foreach (FileSystemComponent child in component.GetChildren())
            {
                string nodeName = $"{child.GetName()} ({child.GetFormattedSize()})";
                TreeNode childNode = new TreeNode(nodeName);
                childNode.Tag = child;
                childNode.ImageKey = child.GetIconKey();
                childNode.SelectedImageKey = child.GetIconKey();

                node.Nodes.Add(childNode);
                AddComponentToTreeNode(child, childNode);
            }
        }

        private void SetupTreeViewIcons()
        {
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(16, 16);

            imageList.Images.Add("folder", SystemIcons.WinLogo.ToBitmap());
            imageList.Images.Add("file", SystemIcons.Application.ToBitmap());

            treeView1.ImageList = imageList;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        // [4]: Browse Button Click - Load folder structure
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
                        this.Cursor = Cursors.WaitCursor;

                        // Load folder structure
                        root = loader.LoadFromPath(dialog.SelectedPath);

                        // Calculate all sizes (Composite Pattern in action!)
                        root.GetSize();

                        // Update the TreeView on the left
                        UpdateTreeView();

                        // Enable visualization buttons
                        treeBtn.Enabled = true;
                        barChartBtn.Enabled = true;

                        // Auto-visualize as tree (default view)
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


        // [5]: Tree Button Click - Visualize as Tree
        private void treeBtn_Click(object sender, EventArgs e)
        {
            if (root == null)
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

                // Step 2: Visualize 
                visualizer.Visualize(root, visualizationPanel);
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
            if (root == null)
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

                // Step 2: Visualize 
                visualizer.Visualize(root, visualizationPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error visualizing:\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form1_Load(object sender, EventArgs e) { }
        private void visualizationPanel_Paint(object sender, PaintEventArgs e) { }

    }


}
