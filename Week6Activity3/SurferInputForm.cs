using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Week6Activity3
{   public enum SurferCountryEnum {Devon,Cornwall,Sunderland}   //enumeration value type
    public partial class SurferInputForm : Form
    {
        private List<Surfboard> availableSurfboards = new List<Surfboard>();
        //Properties
        public string SurferName { get; set; }      //Getters and Setters on these propertys allow us to assign values and retrieve values
        public SurferCountryEnum  SurferCountry { get; set; }
        public string SurferStance { get; set; }
        public Surfboard SelectedSurfboard { get; set; }
        //Initializing the form
        public SurferInputForm()
        {
            InitializeComponent();
            comboBoxCountry.DataSource = Enum.GetValues(typeof(SurferCountryEnum));
            actualCheckedListBoxSurfboards.ItemCheck += actualCheckedListBoxSurfboards_ItemCheck;
        }
        //FORM Components
        
          //When submit button is clicked on this inputting form
        private void Submit_Click(object sender, EventArgs e)
        {
          //Properties for empty whitespace
        bool nEmpty = string.IsNullOrWhiteSpace(textBoxName.Text);
        bool sEmpty = string.IsNullOrWhiteSpace(textBoxStance.Text);
            try
            {
                if (nEmpty || sEmpty)
                {
                    throw new InputNullException("cmon just fill in the boxes");
                }
                SurferName = textBoxName.Text;      //Reads what user inputs and assigns it
                SurferCountry = (SurferCountryEnum)comboBoxCountry.SelectedItem;
                SurferStance = textBoxStance.Text;

                if (actualCheckedListBoxSurfboards.CheckedItems.Count > 0)
                {
                    SelectedSurfboard = (Surfboard)actualCheckedListBoxSurfboards.CheckedItems[0];
                    MessageBox.Show($"Selected Surfboard: {SelectedSurfboard}");
                }
                else
                {
                    SelectedSurfboard = null;
                    MessageBox.Show("No surfboard selected.");
                }
                DialogResult = DialogResult.OK;
                    Close();
            }
            catch (InputNullException ex)       //Exception Handling
            {
                MessageBox.Show($"Error submitting bro: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"oh no big error: + {ex.Message}");
            }
        }
          //the BUTTON to display surfboards
        private void listBoxSurfboards_Click(object sender, EventArgs e)
        {
            List<Surfboard> availableSurfboards = AvailableSurfboards.SurfboardsAvailable();
                foreach (var surfboard in availableSurfboards)
                {
                actualCheckedListBoxSurfboards.Items.Add(surfboard);
                }
        }
          //Checks what board you have selected in the list box
        private void actualCheckedListBoxSurfboards_ItemCheck(object sender, ItemCheckEventArgs selected)
        {
            int selectedIndex = selected.Index; //checks what is actually selected on the form, declared in function above

            try
            {
                if (selected.NewValue == CheckState.Checked)
                {
                    if (selectedIndex >= 0 && selectedIndex < availableSurfboards.Count)
                    {
                        SelectedSurfboard = availableSurfboards[selected.Index];  //assigns what you picked to SelectedSurfboard
                    }
                }
                else if (selected.NewValue == CheckState.Unchecked)
                {
                    SelectedSurfboard = null;       //may need InputNullException implemented into here instead
                }
            }
            catch (InputNullException ex)
            {
                MessageBox.Show("Error occured: " + ex.Message);
            }
        }
        private void actualListBoxSurfboards_Click(object sender, EventArgs e) { }
        private void actualListBoxSurfboards_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}

