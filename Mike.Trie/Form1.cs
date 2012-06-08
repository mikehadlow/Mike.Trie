using System.Linq;
using System.Windows.Forms;

namespace Mike.Trie
{
    public partial class MainForm : Form
    {
        private readonly Trie trie = new Trie();

        public MainForm()
        {
            InitializeComponent();
            LoadWords();
        }

        public void LoadWords()
        {
            statusLabel.Text = "Loading Words";
            foreach (var word in WordLoader.LoadWords())
            {
                trie.Add(word);
            }
            statusLabel.Text = "Words Loaded";
        }

        private void TextBoxTextChanged(object sender, System.EventArgs e)
        {
            var results = trie.Find(textBox.Text).Take(100);

            listBox.Items.Clear();
            foreach (var result in results)
            {
                listBox.Items.Add(result);
            }
        }

        private void label1_Click(object sender, System.EventArgs e)
        {

        }
    }
}
