using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SmartValve
{
    public partial class ValveForm : Form
    {
        public ValveForm()
        {
            InitializeComponent();
            Text = "SmartValve Manager";
            
            // Initial states
            txtValveName.Enabled = false;
            btnAddAnother.Enabled = false;
            btnRemoveValve.Enabled = false;
            btnExportJson.Enabled = false;
            
            // Set placeholder text
            txtValveName.Text = "Enter Valve Name";
        }

        private void ValveForm_Load(object sender, EventArgs e)
        {
            lstValves.Items.Clear();
            foreach (var name in ValvePatternLibrary.Patterns.Keys)
            {
                lstValves.Items.Add(name);
            }
            
            // Enable buttons if there are existing patterns
            if (lstValves.Items.Count > 0)
            {
                btnRemoveValve.Enabled = true;
                btnExportJson.Enabled = true;
            }
        }

        private void btnSelectValve_Click(object sender, EventArgs e)
        {
            // Call the backend logic to select a valve in AutoCAD
            ValveFormActions.SelectValve();
            
            // Enable the name input and add button
            txtValveName.Enabled = true;
            txtValveName.Text = ""; // Clear placeholder when selecting
            btnAddAnother.Enabled = true;
        }

        private void txtValveName_TextChanged(object sender, EventArgs e)
        {
            // This method is required by the designer but can be left empty
        }
        
        private void txtValveName_Enter(object sender, EventArgs e)
        {
            // Clear placeholder text when user enters the textbox
            if (txtValveName.Text == "Enter Valve Name")
            {
                txtValveName.Text = "";
            }
        }
        
        private void txtValveName_Leave(object sender, EventArgs e)
        {
            // Restore placeholder text if textbox is empty
            if (string.IsNullOrWhiteSpace(txtValveName.Text))
            {
                txtValveName.Text = "Enter Valve Name";
            }
        }

        private void btnAddAnother_Click(object sender, EventArgs e)
        {
            // Get the valve name from the text box
            string name = txtValveName.Text.Trim();
            
            // Validate the input
            if (string.IsNullOrWhiteSpace(name) || name == "Enter Valve Name") 
            {
                MessageBox.Show("Please enter a valid valve name.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            // Check if valve name already exists
            if (lstValves.Items.Contains(name)) 
            {
                MessageBox.Show("A valve with this name already exists.", "Duplicate Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Set the valve name using backend logic
            ValveFormActions.SetValveName(name);
            
            // Add to the list box
            lstValves.Items.Add(name);

            // Reset text box to placeholder
            txtValveName.Text = "Enter Valve Name";
            
            // Enable other buttons
            btnRemoveValve.Enabled = true;
            btnExportJson.Enabled = true;
        }

        private void btnRemoveValve_Click(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (lstValves.SelectedItem != null)
            {
                // Get the selected valve name
                string name = lstValves.SelectedItem.ToString();
                
                // Remove from backend library
                ValveFormActions.RemoveValve(name);
                
                // Remove from list box
                lstValves.Items.Remove(name);
                
                // Disable buttons if no items left
                if (lstValves.Items.Count == 0)
                {
                    btnRemoveValve.Enabled = false;
                    btnExportJson.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Please select a valve to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportJson_Click(object sender, EventArgs e)
        {
            // Check if there are any valves to export
            if (lstValves.Items.Count == 0)
            {
                MessageBox.Show("No valves to export. Please add at least one valve.", "Nothing to Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            // Call the backend logic to export to JSON
            ValveFormActions.ExportToJson();
        }

        private void X_Click(object sender, EventArgs e)
        {
            // Close the form using backend logic
            ValveFormActions.CloseForm(this);
        }
        
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // This method is required by the designer but can be left empty
        }
        
        private void lstValves_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This method is required by the designer but can be left empty
            // You could add logic here to handle when a different valve is selected
        }
    }
}