using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Name_and_Address
{
    public partial class Main : Form
    {
        private Person personList = new Person();
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load_1(object sender, EventArgs e)
        {
            cmbState.DataSource = Enum.GetValues(typeof(States));

            Address myName1 = new Address
            {
                FirstName = "Joey",
                LastName = "Smith",
                address = "1 Main St",
                City = "Gurnee",
                StateUS = States.AK,
                Zipcode = "60030",
                PhoneNumber = "630-666-6566"
            };
            personList.Add(myName1);

            Address myName2 = new Address
            {
                FirstName = "Kevin",
                LastName = "Jacobs",
                address = "22 Main St",
                City = "Waukegan",
                StateUS = States.IL,
                Zipcode = "60025",
                PhoneNumber = "847-543-2000"
            };
            personList.Add(myName2);

            Address myName3 = new Address
            {
                FirstName = "Bobby",
                LastName = "Aguirre",
                address = "65 Jackson St",
                City = "Elgin",
                StateUS = States.IL,
                Zipcode = "60069",
                PhoneNumber = "847-542-3000"
            };
            personList.Add(myName3);

            personList.Sort();

            dgvInfo.DataSource = personList;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (ValidateInput())
            {
                dgvInfo.DataSource = null;
                Address myName1 = new Address
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    address = txtAddress.Text,
                    City = txtCity.Text,
                    StateUS = (States)cmbState.SelectedItem,
                    Zipcode = txtZipCode.Text,
                    PhoneNumber = txtPhoneNumber.Text
                };
                personList.Add(myName1);

                dgvInfo.DataSource = personList;

            }

            txtFirstName.Text = String.Empty;
            txtLastName.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtCity.Text = String.Empty;
            txtState.Text = String.Empty;
            txtZipCode.Text = String.Empty;
            txtPhoneNumber.Text = String.Empty;
        }

        private bool ValidateInput()
        {
            bool allValid = true;
            if (!StandardValidations.IsAlphaOnlyString(txtFirstName.Text))
            {
                txtFirstName.BackColor = Color.Red;
                MessageBox.Show("First name must contain letters only.");
                allValid = false;

            }
            else txtFirstName.BackColor = DefaultBackColor;

            if (!StandardValidations.IsAlphaOnlyString(txtLastName.Text))
            {
                txtLastName.BackColor = Color.Red;
                MessageBox.Show("Last name must contain letters only.");
                allValid = false;
            }
            else txtLastName.BackColor = DefaultBackColor;

            if (!StandardValidations.IsPhoneValid(txtPhoneNumber.Text))
            {
                txtPhoneNumber.BackColor = Color.Red;
                MessageBox.Show("Phone number must be entered - Example 800-222-5555.");
               allValid = false;
            }
            else txtPhoneNumber.BackColor = DefaultBackColor;

            if (!StandardValidations.IsUSZipCode(txtZipCode.Text))
            {
                txtZipCode.BackColor = Color.Red;
                MessageBox.Show("ZipCode must be entered - Example 60030.");
                allValid = false;
            }
            else txtZipCode.BackColor = DefaultBackColor;

            return allValid;
        }

        private int lastMatch = 0;
        private void txtState_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            string match = txtState.Text;
            txtState.CharacterCasing = CharacterCasing.Upper;

            if (txtState.Text.Length !=0)
            {
                bool found = true;
                while (found)
                {
                    if (cmbState.Items.Count == x)
                    {
                        cmbState.SelectedIndex = lastMatch;
                        found = false;
                    }
                    else
                    {
                        cmbState.SelectedIndex = x;
                        match = cmbState.SelectedValue.ToString();
                        if (match.Contains(txtState.Text))
                        {
                            lastMatch = x;
                            found = false;
                        }
                        x++;
                    }
                }
            }
            else
            {
                cmbState.SelectedIndex = 0;
            }
            
        }

        private void btnSearcLastName_Click(object sender, EventArgs e)
        {
            dgvInfo.DataSource = personList.GetRegistrations(txtSearchLastName.Text);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgvInfo.DataSource = personList;
        }
    }
}
