using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Week6Activity3
{
    public partial class Form1 : Form
    {
        BinaryFormatter bFormatter = new BinaryFormatter(); //for my serialization

        private List<Surfer> cornishShredderList = new List<Surfer>();
        private List<Surfer> devonShredderList = new List<Surfer>();        //Seperate lists for where the surfer is from
        private List<Surfer> sunderlandShredderList = new List<Surfer>();
        public Form1()
        {
            InitializeComponent();
            DeserializeSurfers();       //on form open, second to bottom method lets me SerializeSurfers on form close so updates are saved
            UpdateComboBox();
            this.FormClosing += Form1_FormClosing;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged; // basically just lets the user select different categorys
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (SurferInputForm surferInputForm = new SurferInputForm()) //uses my second form
            {
                DialogResult result = surferInputForm.ShowDialog(); //the USER MUST interact with the new form before returning to form1

                if (result == DialogResult.OK)
                {
                    Surfer surfer;  //assigns surfer to Surfer for the following switch statement to get user input

                    // Create surfer based on the selected country
                    switch (surferInputForm.SurferCountry)
                    {
                        case SurferCountryEnum.Devon:
                            surfer = new DevonShredder(
                                surferInputForm.SurferName,
                                surferInputForm.SurferCountry.ToString(),
                                surferInputForm.SurferStance);
                            devonShredderList.Add(surfer);
                            break;

                        case SurferCountryEnum.Cornwall:
                            surfer = new CornishShredder(
                                surferInputForm.SurferName,
                                surferInputForm.SurferCountry.ToString(),
                                surferInputForm.SurferStance);
                            cornishShredderList.Add(surfer);
                            break;

                        case SurferCountryEnum.Sunderland:
                            surfer = new SunderlandShredder(
                                surferInputForm.SurferName,
                                surferInputForm.SurferCountry.ToString(),
                                surferInputForm.SurferStance);
                            sunderlandShredderList.Add(surfer);
                            break;

                        default:
                            surfer = null;  //values are null
                            break;

                    }

                    if (surfer != null && surferInputForm.SelectedSurfboard != null)
                    {
                        surfer.AssignedSurfboard = surferInputForm.SelectedSurfboard;   //assigns board selected to surfer inputted


                    }
                    // Update the ComboBox
                    UpdateComboBox();
                    SerializeSurfers();
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                RemoveSelectedSurfer();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing surfer: {ex.Message}");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                devonShredderList.Sort();
                cornishShredderList.Sort();
                sunderlandShredderList.Sort();

                UpdateComboBox();
            }
            catch (Exception)
            {
                MessageBox.Show("Error sorting surfers");
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // SELECTION CHANGE
            if (comboBox1.SelectedItem != null)  //gets pre existing dictionary list and displays it based on which surfer is selected
            {
                KeyValuePair<string, List<SurferInfo>> selectedCategory = (KeyValuePair<string, List<SurferInfo>>)comboBox1.SelectedItem;

                // Displays surfer list below ComboBox
                DisplaySurferList(selectedCategory.Value);
            }
        }
        private void DisplaySurferList(List<SurferInfo> surferInfoList)
        {
            listBox1.Items.Clear();
            foreach (SurferInfo surferInfo in surferInfoList)
            {
                listBox1.Items.Add(surferInfo.ToString());
            }
        }
        public class SurferInfo : IComparable<SurferInfo>
        {
            public Surfer Surfer { get; set; }
            public Surfboard AssignedSurfboard { get; set; }
            public override string ToString()
            {
                return $"{Surfer} - Board: {AssignedSurfboard?.ToString() ?? "None"}" ; //Found this online, question marks are essentially a null-conditional operater
            }
            public int CompareTo(SurferInfo other)
            {
                if (other == null)  //I explained the comparing method in surfer class
                    return 1;

                return Surfer.CompareTo(other.Surfer);
            }
        }
        private List<SurferInfo> GetSurferInfoList(List<Surfer> surferList)
        {
            return surferList.Select(surfer => new SurferInfo { Surfer = surfer, AssignedSurfboard = surfer.AssignedSurfboard }).ToList();
        }
        private void UpdateComboBox()       //combo box is my main drop down list box
        {
            Dictionary<string, List<SurferInfo> > categories = new Dictionary<string, List<SurferInfo> >  //creates a dictionary list so where the surfer is from can be displayed as the dictionary key
            {
                { "CornishShredder", GetSurferInfoList(cornishShredderList) },
                { "DevonShredder", GetSurferInfoList(devonShredderList) },
                { "SunderlandShredder", GetSurferInfoList(sunderlandShredderList) }
            };

            // Display the category names in the ComboBox
            comboBox1.DataSource = new BindingSource(categories, null);  //Binding source basically acts as a gateway to 
                                                                         //Combo box and dictionary and assigning the keys to category names
            comboBox1.DisplayMember = "Key";
        }
        private void RemoveSelectedSurfer()
        {
            if (comboBox1.SelectedItem != null)
            {
                KeyValuePair<string, List<SurferInfo>> selectedCategory = (KeyValuePair<string, List<SurferInfo>>)comboBox1.SelectedItem;

                if (listBox1.SelectedIndex >= 0)
                {
                    SurferInfo selectedSurferInfo = selectedCategory.Value[listBox1.SelectedIndex];
                    Surfer selectedSurfer = selectedSurferInfo.Surfer;

                    // Determines the list to remove from based on surfer country
                    List<Surfer> selectedSurferList = null;
                    switch (selectedSurfer.Country)
                    {
                        case "Devon":
                            selectedSurferList = devonShredderList;
                            break;

                        case "Cornwall":
                            selectedSurferList = cornishShredderList;
                            break;

                        case "Sunderland":
                            selectedSurferList = sunderlandShredderList;
                            break;

                        default:
                            throw new InvalidOperationException("Invalid surfer country.");
                    }

                    // Removes the surfer from the list
                    if (selectedSurferList != null)
                    {
                        selectedSurferList.Remove(selectedSurfer);
                        UpdateComboBox();
                    }
                }
                else if (listBox1.SelectedIndex < 0)
                {
                    throw new Exception("Can't be a negative");
                }
            }
        }
        private void SerializeSurfers()
        {
            SaveList(devonShredderList, "devonSurfers.dat");        //Put seperate lists into same SaveList<T>
            SaveList(cornishShredderList, "cornishSurfers.dat");
            SaveList(sunderlandShredderList, "sunderlandSurfers.dat");
        }
        private void DeserializeSurfers()
        {
            devonShredderList = LoadList<Surfer>("devonSurfers.dat");
            cornishShredderList = LoadList<Surfer>("cornishSurfers.dat");
            sunderlandShredderList = LoadList<Surfer>("sunderlandSurfers.dat");
        }
        private void SaveList<T>(List<T> list, string fileName)     //method with filename and one of my three lists as paramters, essentially passing in my lists 
        {
            try
            {
                using (FileStream outFile = new FileStream(fileName, FileMode.Create))
                {                                                               
                    bFormatter.Serialize(outFile, list);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving: " + ex.Message);
            }
        }
        private List<T> LoadList<T>(string fileName)    //method with filename as parameter, loads list using binary formatter
        {
            List<T> list = new List<T>();
            try
            {
                if (File.Exists(fileName))
                {
                    using (FileStream inFile = new FileStream(fileName, FileMode.Open))
                    {
                        list = (List<T>)bFormatter.Deserialize(inFile);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"Error loading {fileName}");
            }
            return list;    //as its coming out of a file not in
        }
       
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerializeSurfers(); //uses method above to essentially save on close
        }
    }
}
