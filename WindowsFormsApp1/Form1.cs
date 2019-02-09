using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            var ops = new DataOperations();

            var countries = ops.Countries();

            var index = countries
                .Select((item, pos) => new {Name = item.CountryName, Index = item.Id})
                .FirstOrDefault(item => item.Name == "Venezuela").Index -1;

            countriesComboBox.DataSource = countries;
            countriesComboBox.SelectedIndex = index;

            var contacts = ops.ContactTypes();

            index = contacts
                        .Select((item, pos) => new { Name = item.ContactTitle, Index = item.ContactTypeIdentifier })
                        .FirstOrDefault(item => item.Name == "Owner").Index - 1;

            contactTypeComboBox.DataSource = ops.ContactTypes();
            contactTypeComboBox.SelectedIndex = index;

            dataGridView1.AutoGenerateColumns = false;
        }

        private void readDataButton_Click(object sender, EventArgs e) 
        {
            var ops = new DataOperations();

            var dt = ops.ReadSpecificCustomers(contactTypeComboBox.Text, countriesComboBox.Text, revealCheckBox.Checked);
            if (ops.IsSuccessFul )
            {
                dataGridView1.DataSource = dt;

                if (revealCheckBox.Checked)
                {                   
                    Console.WriteLine(ops.CommandText);
                    MessageBox.Show("SELECT statement is now in the IDE output window");
                }
            }
            else
            {
                MessageBox.Show($"Failed to load data{Environment.NewLine}{ops.LastExceptionMessage}");
            }
        }
    }
}
