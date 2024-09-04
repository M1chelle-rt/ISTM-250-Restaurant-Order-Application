using ISYS250HW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodingProject1
{
    public partial class FRMVendors : Form
    {

        public FRMVendors()
        {
            InitializeComponent();


            //adds the default discount options to the default discount combo boxes
            CBXDefaultDiscount.Items.Add("10");
            CBXDefaultDiscount.Items.Add("15");
            CBXDefaultDiscount.Items.Add("20");

        }
        
        //creates the list of the vendors
        private List<Vendor> lstVendors = null;
        //sets the selected index to 0 and also creates it as an integer
        private int intIndex = 0;
        //sets the new bool to see if the data is saved
        private bool boolSaved = true;


        /// <summary>
        /// fills the names of the companies into the LBXVendors list box
        /// </summary>
        private void FillItemListBox()
        {
            //clears the list box to start
           LBXVendors.Items.Clear();
            //a foreach loop that grabs all of the items in the lstVendors list  and adds the name from each.
            foreach (Vendor i in lstVendors)
            {
                //adds the vendors names into the list box.
               LBXVendors.Items.Add(i.Name + "\n");

            }

        }

        /// <summary>
        /// when the vendors form loads, the vendor information is loaded into the list and then the list box is compiled. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FRMVendors_Load(object sender, EventArgs e)
        {
           //grabs the list from the invItemsDB and brinsg them here
           lstVendors = VendorDB.GetVendors();
             // Add a statement here that gets the list of items.
            FillItemListBox();
            FillName();
            LBXVendors.SelectedIndex = intIndex; 
        }

        /// <summary>
        /// when the user clicks the previous button, the systems checks to see if the data needs to be saved and also validtates the data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNPrevious_Click(object sender, EventArgs e)
        {
            //asks if the data is saved
            if(boolSaved)
            {
                //if the data is savred then if the selected index is 0 it goes to the other end of the list and compiles that information
                if (intIndex == 0)
                {
                    intIndex = lstVendors.Count - 1;
                }
                else
                {
                    //reduces the selected index by 1
                    intIndex--;
                }
                //fills the information from the user
                FillName();
               LBXVendors.SelectedIndex = intIndex;
            }
            else
            {
                //starts a delete candidate to see if the uder wants to delete any chnages made
                DialogResult saveCandidate = MessageBox.Show("Do you want to save your changes?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);

                if (saveCandidate == DialogResult.Yes)
                    //if the user clicks yes to save chnages, the program tries to save the chnages only if the data is validated
                {
                    if (IsValidData())
                    {
                        //if the data us validated then the data is saved
                        SaveData();
                        if (intIndex == 0)
                        {
                            intIndex = lstVendors.Count - 1;
                        }
                        else
                        {
                            intIndex--;
                        }
                        FillName();
                      LBXVendors.SelectedIndex = intIndex;
                    }
                        

                }
                //if the user does not want to save chnages then the data is not saved and the user is sent to the previous selected index.
                if (saveCandidate == DialogResult.No)
                {
                    //the saved data is not quite the same which does not allow us to make a new method and call it for each item.
                    if (intIndex == 0)
                    {
                        intIndex = lstVendors.Count - 1;
                    }
                    else
                    {
                        intIndex--;
                    }
                    boolSaved = true;
                    FillName();
                   LBXVendors.SelectedIndex = intIndex;
                }
                if (saveCandidate == DialogResult.Cancel)
                {
                    //if the user cancels the save or dont save then the focous is set back onto the vendor name text box at the beginning of the form

                    TXTVendorName.Focus();
                }
            }
        }
        /// <summary>
        /// when the user clicks the next button, the code tries to validate the data and save if there are chnages made then chnages the selected index of the list box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNNext_Click(object sender, EventArgs e)
        {
            //asks if the data is saved
            if(boolSaved)
            {
                //if it is saved then the code sends the user to the next selected index
                if (intIndex == lstVendors.Count - 1)
                {
                    intIndex = 0;
                }
                else
                {
                    //increments the index to the next
                    intIndex++;
                }
                //fills the text boxes with the new xml data
                FillName();
              LBXVendors.SelectedIndex = intIndex;

            }
            else
            {
                //asks the user if they would like to save if the data is not currently saved
                DialogResult saveCandidate = MessageBox.Show("Do you want to save your changes?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);

                if (saveCandidate == DialogResult.Yes)
                {
                    //if the user selects yes top save the data then the data is validated
                    if (IsValidData())
                    {
                        //if the data is valid then the data is sent to the xml file
                        SaveData();
                        if (intIndex == lstVendors.Count - 1)
                        {
                            intIndex = 0;
                        }
                        else
                        {
                            intIndex++;
                        }
                        FillName();
                        LBXVendors.SelectedIndex = intIndex;
                    }
                }
                //if the user does not want to save the data then the user is sent to the next selected index
                if (saveCandidate == DialogResult.No)
                {
                    if (intIndex == lstVendors.Count - 1)
                    {
                        intIndex = 0;
                    }
                    else
                    {
                        intIndex++;
                    }
                    FillName();
                   LBXVendors.SelectedIndex = intIndex;
                    boolSaved = true;
                    
                }
                if (saveCandidate == DialogResult.Cancel)
                {
                    //if the user cancels the save or dont save then the focous is set back onto the vendor name text box at the beginning of the form
                    TXTVendorName.Focus();
                }
            }



        }
        /// <summary>
        /// fills the text boxes with the data from the xml file
        /// </summary>
        private void FillName()
        {
            Vendor vendorCandidate = lstVendors[intIndex];

            //adds a new section of text
            //fills the text boxes with the appropriate data gathered from the xml file
            TXTVendorName.Text = vendorCandidate.Name;
            TXTVendorAddress.Text = vendorCandidate.Address;
            TXTVendorCity.Text = vendorCandidate.City;
            TXTVendorState.Text = vendorCandidate.State;
            TXTVendorZipCode.Text = vendorCandidate.Zip;
            TXTVendorPhoneNumber.Text = vendorCandidate.Phone;
            TXTVendorYTD.Text = vendorCandidate.YTD.ToString();
            TXTComments.Text = vendorCandidate.Comment;
            TXTVendorSalesRepresentitive.Text = vendorCandidate.Contact;
            CBXDefaultDiscount.SelectedItem = vendorCandidate.DefaultDiscount.ToString();

        }

        /// <summary>
        /// when the user clicks save the data is validated then the data is saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNSave_Click(object sender, EventArgs e)
        {
            //before saving any data the data is validated then saved

                if (IsValidData())
                {
                    SaveData();

                }
           
               
            
        }
        /// <summary>
        /// saves the data 
        /// </summary>
        private void SaveData()
        {
        
           //converts the YTD and Default Disc to decimal and int
                decimal decVendorNewYTD = Convert.ToDecimal(TXTVendorYTD.Text);
                int intVendorNewDiscount = Convert.ToInt32(CBXDefaultDiscount.SelectedItem);
            //sends the data to be saved in the xml file
                Vendor editedVendor = new Vendor(TXTVendorName.Text, TXTVendorAddress.Text, TXTVendorCity.Text, TXTVendorState.Text, TXTVendorZipCode.Text, TXTVendorPhoneNumber.Text, decVendorNewYTD, TXTComments.Text, TXTVendorSalesRepresentitive.Text, intVendorNewDiscount);
                lstVendors[LBXVendors.SelectedIndex] = editedVendor;
                FillItemListBox();
                VendorDB.SaveVendors(lstVendors);
                boolSaved = true;
                //sets the selected index to whatever
                LBXVendors.SelectedIndex = intIndex;


        }
       
        /// <summary>
        /// the validation check for all the data
        /// </summary>
        /// <returns></returns>
        private bool IsValidData()
        {//sets the string error message to empty before the user 
            string strErrorMessage = "";

          //checks each validation then adds trhe error message to the stirng to be displayed
            strErrorMessage += Validation.IsPresent(TXTVendorName.Text, TXTVendorName.Tag.ToString());
            strErrorMessage += Validation.IsPresent(TXTVendorAddress.Text, TXTVendorAddress.Tag.ToString());
            strErrorMessage += Validation.IsPresent(TXTVendorCity.Text, TXTVendorCity.Tag.ToString());
            strErrorMessage += Validation.IsPresent(TXTVendorState.Text, TXTVendorState.Tag.ToString());
            strErrorMessage += Validation.IsPresent(TXTVendorPhoneNumber.Text, TXTVendorPhoneNumber.Tag.ToString());
            strErrorMessage += Validation.IsInteger(TXTVendorPhoneNumber.Text, TXTVendorPhoneNumber.Tag.ToString());
            strErrorMessage += Validation.IsPresent(TXTVendorSalesRepresentitive.Text, TXTVendorSalesRepresentitive.Tag.ToString());
            strErrorMessage += Validation.IsPresent(TXTVendorYTD.Text, TXTVendorYTD.Tag.ToString());
            strErrorMessage += Validation.IsInteger(TXTVendorYTD.Text, TXTVendorYTD.Tag.ToString());
            strErrorMessage += Validation.IsPresent(TXTVendorZipCode.Text, TXTVendorZipCode.Tag.ToString());
            strErrorMessage += Validation.ContainsNumbersAndLetter(TXTVendorZipCode.Text, TXTVendorZipCode.Tag.ToString());


            if (strErrorMessage != "")
            {
                //if the error message is not empty then there will be an error message shown
                MessageBox.Show(strErrorMessage);
                return false;
            }
            else
            {
                //if there is no error messages then there will be no error messages shown
                return true;
            }
        }
        /// <summary>
        /// if the text changes then the bool is changed to false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void TextChanged(object sender, KeyEventArgs e)
        {
            boolSaved = false;
           
        }
        /// <summary>
        /// when the user clicks exit the system it check if the data is saved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNExit_Click(object sender, EventArgs e)
        {
            if (boolSaved)
            {
                //if the data is saved then the form closes
                this.Close();
            }
            else
            {
                //if the form is not saved then the user is asked if they would like to save
                DialogResult saveCandidate = MessageBox.Show("Do you want to save your changes?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);
                //if the user clicks yes to save the data is attempted to save
                if (saveCandidate == DialogResult.Yes)
                {
                    //if the data is not bale to be saved it returns to the form and give the user an error message
                    if (IsValidData())
                    {
                        SaveData();
                        this.Close();
                    }
                }
                if (saveCandidate == DialogResult.No)
                {//if they say not then the bool is set to true then the form is closed
                    boolSaved = true;
                    this.Close();

                }
                if (saveCandidate == DialogResult.Cancel)
                {
                    //if the user selects the cancel button then the 
                    TXTVendorName.Focus();
                }
            }
        }

       
        /// <summary>
        /// if the combo box is chnaged then the user will be asked to save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxChanged(object sender, EventArgs e)
        {
            boolSaved = false;
        }
      
        /// <summary>
        /// sets the saved bool to false if the user presses a key in the text boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GBXVendorInformation_TextChanged(object sender, EventArgs e)
        {
            boolSaved = false;
        }

        private void LBXVendors_SelectedIndexChanged(object sender, EventArgs e)
        {
            // tells the user to use the buttons rather than clicking then
            LBXVendors.SelectedIndex = intIndex;
        }
    }
}
