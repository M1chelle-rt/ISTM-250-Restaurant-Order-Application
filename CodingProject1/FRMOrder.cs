using ISYS250HW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace CodingProject1
{
    //AUTHOR: Michelle Thomas, Quinn Leith, Gabriel Perez, Ben Jacyno
    //COURSE: ISTM 250.501
    //FORM: FRMOrder
    //PURPOSE: Allows the user to create an order for pick up or delievery Kirby's Delievery
    //INPUT: group box mailing address, group box delievery address, product, carbs, quantity
    //PROCESS: checks if user chooses takeout or delievery and ensures delievery is only to college station or bryan texas and provides the total amount owed
    //depending on the pizza and or sandwich items added to the order
    //OUTPUT: the total amount owed for the order
    //HONOR CODE: “On my honor, as an Aggie, I have neither given
    // nor received unauthorized aid on this academic
    // work.”
    public partial class FRMOrder : Form
    {
        public FRMOrder()
        {
            InitializeComponent();
        }

        string strErrorMessage = ""; //string error to display when there is invalid data entered in a field
        string strQuantityErrorMessage = ""; //string error to display when there is invalid data entered in the quantity field
        decimal decClassTotal = 0m; //used to store the subtotal for the entire order
        decimal decClassTaxAmount = 0m; //used to store the tax amount for the entire order
        decimal decClassGrandTotal = 0m; //used to store the grand total for the entire order
        public int[] intQuantityArr = new int[6]; //creates the aarray named intQuantityArr that will have 6 different styles in this case products
        //sets the different ingredients to be displayed
        string[] strIngredientsArray = { "Flour", "Yeast", "Sugar", "Oil", "Ham", "Turkey", "Scheese", "Lettuce", "Tomato", "Bacon", "Pickles", "Mayo", "Mustard", "Pepprni", "Sauce", "Gcheese", "Salt", "Pepper" };
        //sets the initial valuses then also the current values as orders are processed
        decimal[] decCurrentInventoryArray = { 200m, 50m, 30m, 25m, 10m, 10m, 20m, 14m, 14m, 10m, 20m, 15m, 12m, 20m, 60m, 25m, 10m, 10m };
        //tells the array how much to decreese from the current inventoryt array each time an item is purchased with this 2 dimensional array
        decimal[,] decIngredientAmountArray = { { 1m, 1m, 1m, 3m, 3m, 3m },
                                                { 0.5m, 0.5m, 0.5m, 2m, 2m, 2m },
                                                { 0.03m, 0.03m, 0.03m, 0.5m, 0.5m, 0.5m },
                                                { 0.05m, 0.05m, 0.05m, 0.1m, 0.1m, 0.1m },
                                                { 0.1m, 0m, 0m, 0m, 0m, 0.1m },
                                                { 0m, 0.1m, 0m, 0m, 0m, 0.1m },
                                                { 0.1m, 0.1m, 0m, 0m, 0m, 0m },
                                                { 0.25m, 0.25m, 0.3m, 0m, 0m, 0m },
                                                { 0.25m, 0.25m, 0.3m, 0m, 0m, 0.3m },
                                                { 0m, 0m, 0.1m, 0m, 0m, 0.1m },
                                                { 0.02m, 0.02m, 0m, 0m, 0m, 0m},
                                                { 0.02m, 0.02m, 0.02m, 0m, 0m, 0m },
                                                { 0.02m, 0.02m, 0.02m, 0m, 0m, 0m },
                                                { 0m, 0m, 0m, 0m, 0.3m, 0.3m },
                                                { 0m, 0m, 0m, 1m, 1m, 1m },
                                                { 0m, 0m, 0m, 0.3m, 0.2m, 0.2m },
                                                { 0.01m, 0.01m, 0.01m, 0.02m, 0.02m, 0.02m },
                                                {0.01m, 0.01m, 0.01m, 0.02m, 0.02m, 0.02m } };

        /// <summary>
        /// fills combo boxes for Products with options when form loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FRMOrder_Load(object sender, EventArgs e)
        {
            // Initialize food type combo box

            CBXProduct.Items.Add("Ham & Swiss");
            CBXProduct.Items.Add("Turkey & Provolone");
            CBXProduct.Items.Add("BLT");
            CBXProduct.Items.Add("Medium Cheese Pizza");
            CBXProduct.Items.Add("Medium Pepperoni Pizza");
            CBXProduct.Items.Add("Medium Supreme Pizza");

            PBXPizzaOrSandwich.Image = null; 

            

        }

        /// <summary>
        /// Checks to see if the Delievery option is seleted and copies the mailing address information to all of the corresponding fields if it is valid
        /// if the takeout option is selected, then it clears all of the delievry address fields and disables the group box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckChange(object sender, EventArgs e)
        {
            strErrorMessage = "";

            if (IsValidMailingData())
            {
                if (RDODelivery.Checked == true) //copies and pastes mailing textbox data to the delievery textboxes
                {
                    GBXDeliveryAddress.Enabled = true;
                    Clipboard.SetText(TXTMailingAddress.Text);
                    TXTDeliveryAddress.Text = Clipboard.GetText(TextDataFormat.Text);

                    Clipboard.SetText(TXTMailingCity.Text);
                    TXTDeliveryCity.Text = Clipboard.GetText(TextDataFormat.Text);

                    Clipboard.SetText(TXTMailingName.Text);
                    TXTDeliveryName.Text = Clipboard.GetText(TextDataFormat.Text);

                    Clipboard.SetText(TXTMailingPhoneNumber.Text);
                    TXTDeliveryPhoneNumber.Text = Clipboard.GetText(TextDataFormat.Text);

                    Clipboard.SetText(TXTMailingState.Text);
                    TXTDeliveryState.Text = Clipboard.GetText(TextDataFormat.Text);

                    Clipboard.SetText(TXTMailingSubdivision.Text);
                    TXTDeliverySubdivision.Text = Clipboard.GetText(TextDataFormat.Text);

                    Clipboard.SetText(TXTMailingZipCode.Text);
                    TXTDeliveryZipCode.Text = Clipboard.GetText(TextDataFormat.Text);

                    IsValidDeliveryData();
                }
                else
                {
                    ClearDelivery();
                }
            }

        }

        /// <summary>
        /// Sets enabled property of the group box for the delievery address infomation to false 
        /// and clears all of the fields for the delievery address information and selects takeout 
        /// </summary>
        private void ClearDelivery()
        {

            GBXDeliveryAddress.Enabled = false;
            TXTDeliveryAddress.Clear();
            TXTDeliveryName.Clear();
            TXTDeliveryCity.Clear();
            TXTDeliveryPhoneNumber.Clear();
            TXTDeliveryZipCode.Clear();
            TXTDeliveryState.Clear();
            TXTDeliverySubdivision.Clear();
            TXTMailingName.Focus();
            RDOTakeOut.Checked = true;

        }

        /// <summary>
        /// Updates the bread or crust style combo box to bread options if a sandwhich is selected in the product combobox
        /// or to crust options if a pizza is selected in the product combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FoodType_Changed(object sender, EventArgs e)
        {
            TXTQuantity.Enabled = false;
            TXTQuantity.Text = "";
            CBXBreadOrCrustStyle.Items.Clear();
            
            if (CBXProduct.SelectedIndex == -1) //checks if product is selected
            {
                MessageBox.Show("Please select an Item"); 

            }
            else if (CBXProduct.SelectedItem.ToString() == "Ham & Swiss" || CBXProduct.SelectedItem.ToString() == "Turkey & Provolone"
                || CBXProduct.SelectedItem.ToString() == "BLT")
            {
                lblBreadOrCrust.Text = "Bread:";
                CBXBreadOrCrustStyle.Enabled = true;
                CBXBreadOrCrustStyle.Items.Add("White");
                CBXBreadOrCrustStyle.Items.Add("Pumpernickle");
                CBXBreadOrCrustStyle.Items.Add("Rye");
                CBXBreadOrCrustStyle.Items.Add("Sourdough");
                CBXBreadOrCrustStyle.Items.Add("Multigrain");

                PBXPizzaOrSandwich.Image = Properties.Resources.deli;

            }
            else if (CBXProduct.SelectedItem.ToString() == "Medium Cheese Pizza" || CBXProduct.SelectedItem.ToString() == "Medium Pepperoni Pizza"
                || CBXProduct.SelectedItem.ToString() == "Medium Supreme Pizza")
            {
                lblBreadOrCrust.Text = "Crust:";
                CBXBreadOrCrustStyle.Enabled = true;
                CBXBreadOrCrustStyle.Items.Add("Original");
                CBXBreadOrCrustStyle.Items.Add("Pan");
                CBXBreadOrCrustStyle.Items.Add("Thin");
                CBXBreadOrCrustStyle.Items.Add("Wheat");
                PBXPizzaOrSandwich.Image = Properties.Resources.pizza;

            }
        }

        /// <summary>
        /// Calculates the subtotal based on the price of the product selected if the quantity entereed is valid
        /// </summary>
        public void CalculateSubtotal()
        {
            // Initialize variables
            decimal decitemCost = 0m;

            // Get the item cost based on the selected food type
            if (CBXProduct.SelectedItem.ToString() == "Ham & Swiss" || CBXProduct.SelectedItem.ToString() == "Turkey & Provolone"
                || CBXProduct.SelectedItem.ToString() == "BLT")
            {
                decitemCost = 5m; // Cost of each sandwich
            }
            else if (CBXProduct.SelectedItem.ToString() == "Medium Cheese Pizza" || CBXProduct.SelectedItem.ToString() == "Medium Pepperoni Pizza"
                || CBXProduct.SelectedItem.ToString() == "Medium Supreme Pizza")
            {
                decitemCost = 9.50m; // Cost of each pizza
            }
            else
            {
                // Food type not selected, return
                return;
            }

            // Parse quantity
            if (IsValidQuantity())
            {
                // Calculate subtotal
                try
                {
                    decimal decQuanitity = Convert.ToDecimal(TXTQuantity.Text);
                    decimal subtotal = decitemCost * decQuanitity;
                    // Display subtotal
                    subtotal.ToString("c2");
                    Subtotal_Check(subtotal);
                }
                catch (FormatException) //Catch for incorrect formatting when inputed
                {
                    MessageBox.Show("Please make sure input is nurmeric and try again.", "Entry Error");
                }
                catch (OverflowException) //Catch for value getting too large for computer to handle
                {
                    MessageBox.Show("Please enter a smaller value and try again.", "Overflow Error");
                }
                catch (DivideByZeroException) //Catch for when user tries to divide by 0
                {
                    MessageBox.Show("Divided by 0, please use non-zero numbers", "Divide by zero");
                }
                catch //Catch for anything that wasnt caught
                {
                    MessageBox.Show("An unexpected error occured. Please try again", "Unexpected Error");
                }

            }
           
           

        }

        /// <summary>
        /// if the selected food and bread/crust style is confirmed by the user then the item amount for the selecteded product is stored
        /// using the stored item amount and the quantity, the subtotal, tax amount, and grand total is updated 
        /// the item information is updated in the list box of items in the current order 
        /// and the label is updated to reflect the dcurrent subtotal, tax, and grand total
        /// </summary>
        /// <param name="subtotal"></param>
        private void Subtotal_Check(decimal subtotal)
        {
            try
            {
                string strOrderTotal = "";
                decimal decTaxPercent = 0.0825m;
                decimal decOrderAfterTax = 0m;
                //string strSubtotalMessage = ("A " + CBXProduct.SelectedItem.ToString() + " sandwich on " + CBXBreadOrCrustStyle.SelectedItem.ToString() + " will cost " + subtotal.ToString("c2"));

                //DialogResult Subtotal = MessageBox.Show(strSubtotalMessage, "Confirm product", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation); //asks user if they would like to confirm the product to add

                //if (Subtotal == DialogResult.Yes)
                //{
                    int intQuantity = Convert.ToInt32(TXTQuantity.Text);
                    decimal decitemCost = 0m;


                    if (CBXProduct.SelectedItem.ToString() == "Ham & Swiss" || CBXProduct.SelectedItem.ToString() == "Turkey & Provolone"
                    || CBXProduct.SelectedItem.ToString() == "BLT")
                    {
                        decitemCost = 5; // Cost of each sandwich
                    }
                    else if (CBXProduct.SelectedItem.ToString() == "Medium Cheese Pizza" || CBXProduct.SelectedItem.ToString() == "Medium Pepperoni Pizza"
                        || CBXProduct.SelectedItem.ToString() == "Medium Supreme Pizza")
                    {
                        decitemCost = 9.50m; // Cost of each pizza
                    }
                    else
                    {
                        // Food type not selected, return
                        return;
                    }

                    decOrderAfterTax = CalculateTotal(decTaxPercent, decOrderAfterTax, intQuantity, decitemCost);

                    strOrderTotal += "Subtotal: " + decClassTotal.ToString("c2") + "\n";
                    strOrderTotal += "Tax: " + decClassTaxAmount.ToString("c2") + "\n";
                    strOrderTotal += "Grand Total: " + decClassGrandTotal.ToString("c2");

                    LBLOrderTotal.Text = strOrderTotal;
                
            }
            catch (FormatException) //Catch for incorrect formatting when inputed
            {
                MessageBox.Show("Please make sure input is nurmeric and try again.", "Entry Error");
            }
            catch (OverflowException) //Catch for value getting too large for computer to handle
            {
                MessageBox.Show("Please enter a smaller value and try again.", "Overflow Error");
            }
            catch (DivideByZeroException) //Catch for when user tries to divide by 0
            {
                MessageBox.Show("Divided by 0, please use non-zero numbers", "Divide by zero");
            }
            catch //Catch for anything that wasnt caught
            {
                MessageBox.Show("An unexpected error occured. Please try again", "Unexpected Error");
            }


        }
        string strDisplayInputsDisplayed = "";
        /// <summary>
        /// Calculates the subtotal, tax, and the grand total and formats it to be displayed on the confirmation dialog box and the 
        /// label displaying those values
        /// </summary>
        /// <param name="decTaxPercent"></param>
        /// <param name="decOrderAfterTax"></param>
        /// <param name="intQuantity"></param>
        /// <param name="decitemCost"></param>
        /// <returns></returns>
        private decimal CalculateTotal(decimal decTaxPercent, decimal decOrderAfterTax, int intQuantity, decimal decitemCost)
        {
            string strDisplayInputs = "";
            decimal Total = (intQuantity * decitemCost);


           

            strDisplayInputs += CBXBreadOrCrustStyle.SelectedItem.ToString() + " ";
            strDisplayInputs += CBXProduct.SelectedItem.ToString() + ", ";
            strDisplayInputs += (intQuantity + "@" + decitemCost.ToString("c2") + ", total: " + Total.ToString("C2"));

            strDisplayInputsDisplayed += (strDisplayInputs + "\n");
            LSTOrder.Items.Add(strDisplayInputs);

            decClassTotal += Total; //updates the class variable of the total to be displayed to the user
            decClassTaxAmount = (decClassTotal * decTaxPercent); //sets the total tax amount to be displayed
            decClassGrandTotal = decClassTaxAmount + decClassTotal; //updates the grand total using the subtotal and tax amount

            LBLOrderTotal.Text = "";
            decimal decTax = (decClassTotal * decTaxPercent);
            decOrderAfterTax += (Total * (1 + decTaxPercent));
            return decOrderAfterTax;
        }


        /// <summary>
        /// Checks if Mailing data is valid and if the delievery data is valid if delievery is selected 
        /// and if everything is valid, it displays the total cost of the order when processed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOrderButton_Click(object sender, EventArgs e)
        {
            // Calculate subtotal and total cost
            strErrorMessage = "";
            if (IsValidMailingData())
               
            {
                if (RDOTakeOut.Checked)
                {
                    if (strDisplayInputsDisplayed != "")
                    {
                        MessageBox.Show("Todays Total is: " + decClassGrandTotal.ToString("c2")); // Format total as currency with two decimal places
                        for (int i = 0; i < intQuantityArr.Length; i++)
                        {
                            for (int j = 0; j < decCurrentInventoryArray.Length; j++)
                            {
                                decCurrentInventoryArray[j] -= (intQuantityArr[i] * decIngredientAmountArray[j, i]);
                            }

                        }
                        intQuantityArr = new int[6];
                        ClearAllData();
                    }
                    else
                    {
                        MessageBox.Show("Please select an item to purchase and add the order.");
                    }
                }
                else
                {
                    if (IsValidDeliveryData())
                    {
                        if (strDisplayInputsDisplayed != "")
                        {
                            MessageBox.Show("Todays Total is: " + decClassGrandTotal.ToString("c2")); // Format total as currency with two decimal places
                            for (int i = 0; i < intQuantityArr.Length; i++)
                            {
                                for (int j = 0; j < decCurrentInventoryArray.Length; j++)
                                {
                                    decCurrentInventoryArray[j] -= (intQuantityArr[i] * decIngredientAmountArray[j, i]);
                                }

                            }
                            intQuantityArr = new int[6];
                            ClearAllData();
                        }
                        else
                        {
                            MessageBox.Show("Please select an item to purchase.");
                        }


                    }
                    //the for loop that calculates and subtracts the number of ingreditents from the current ingredience list from above

                }
                }


        }

        /// <summary>
        /// resets to all default values for initial form, by disabling the delievery address to false, clears all fields, resets all class total price variables
        /// and clears order total label
        /// </summary>
        private void ClearAllData()
        {



            GBXDeliveryAddress.Enabled = false;
            TXTDeliveryAddress.Clear();
            TXTDeliveryName.Clear();
            TXTDeliveryCity.Clear();
            TXTDeliveryPhoneNumber.Clear();
            TXTDeliveryZipCode.Clear();
            TXTDeliveryState.Clear();
            TXTDeliverySubdivision.Clear();
            TXTMailingAddress.Clear();
            TXTMailingCity.Clear();
            TXTMailingName.Clear();
            TXTMailingPhoneNumber.Clear();
            TXTMailingState.Clear();
            TXTMailingSubdivision.Clear();
            TXTMailingZipCode.Clear();
            TXTQuantity.Clear();
            decClassTotal = 0;
            decClassTaxAmount = 0;
            decClassGrandTotal = 0;
            strDisplayInputsDisplayed = "";
            TXTQuantity.Enabled = false;
            LBLOrderTotal.Text = "";
            LSTOrder.Items.Clear();
            CBXProduct.SelectedIndex = -1;
            CBXBreadOrCrustStyle.Enabled = false;
            PBXPizzaOrSandwich.Image = null;
            CBXBreadOrCrustStyle.Items.Clear();
            intQuantityArr = new int[6];
            
            TXTMailingName.Focus();
            RDOTakeOut.Checked = true;


        }

        /// <summary>
        /// When user adds an item to the order, checks if a product and a bread or crust style is selected and if it is then 
        /// calculates the subtotal, otherwise sends error message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNAddOrder_Click(object sender, EventArgs e)
        {
            string strErrorAdd = "";
            if (CBXProduct.SelectedIndex == -1)
            {
                strErrorAdd += "Please select a product." + "\n";

            }
            if (CBXBreadOrCrustStyle.SelectedIndex == -1)
            {
                strErrorAdd += "Please select a style of carbs." + "\n";
            }
            if(TXTQuantity.Text == "")
            {
                strErrorAdd += "Please select a whole number between 1 & 1000" + "\n";
            }

            if (strErrorAdd != "")
            {
                MessageBox.Show(strErrorAdd);
            }

            else
            {
                // Calculate subtotal when quantity changes
                CalculateSubtotal();
                {
                    if (strQuantityErrorMessage == "")
                    {
                        //gets the selected index and finds what item will be subtracted from when the order is processed
                        intQuantityArr[CBXProduct.SelectedIndex] += Convert.ToInt16(TXTQuantity.Text);
                       

                        //clears out the order process
                        CBXBreadOrCrustStyle.SelectedIndex = -1;
                        CBXProduct.SelectedIndex = -1;

                        PBXPizzaOrSandwich.Image = null;
                        CBXBreadOrCrustStyle.Enabled = false;
                        TXTQuantity.Text = "";
                        TXTQuantity.Enabled = false;

                    }
                    else
                    {
                        TXTQuantity.Text = "";
                    }
                }
            }

            
        }

        #region validation
        /// <summary>
        /// Checks to see if all of the Mailing information is valid including if present and if numerical enteries are integer
        /// </summary>
        /// <returns></returns>
        private bool IsValidMailingData()
        {

            strErrorMessage += Validation.IsPresent(TXTMailingName.Text, TXTMailingName.Tag.ToString());

            strErrorMessage += Validation.IsPresent(TXTMailingPhoneNumber.Text, TXTMailingPhoneNumber.Tag.ToString());
            strErrorMessage += Validation.IsInteger(TXTMailingPhoneNumber.Text, TXTMailingPhoneNumber.Tag.ToString());
            if (Validation.IsInteger(TXTMailingPhoneNumber.Text, TXTMailingPhoneNumber.Tag.ToString()) == "")
                strErrorMessage += Validation.IsNonNegitive(TXTMailingPhoneNumber.Text, TXTMailingPhoneNumber.Tag.ToString(), 0);

            strErrorMessage += Validation.IsPresent(TXTMailingAddress.Text, TXTMailingAddress.Tag.ToString());

            strErrorMessage += Validation.IsPresent(TXTMailingCity.Text, TXTMailingCity.Tag.ToString());

            strErrorMessage += Validation.IsPresent(TXTMailingState.Text, TXTMailingState.Tag.ToString());

            strErrorMessage += Validation.IsPresent(TXTMailingZipCode.Text, TXTMailingZipCode.Tag.ToString());
            strErrorMessage += Validation.IsInteger(TXTMailingZipCode.Text, TXTMailingZipCode.Tag.ToString());
            if (Validation.IsInteger(TXTMailingZipCode.Text, TXTMailingZipCode.Tag.ToString()) == "")
                strErrorMessage += Validation.IsNonNegitive(TXTMailingZipCode.Text, TXTMailingZipCode.Tag.ToString(), 0);

            strErrorMessage += Validation.IsPresent(TXTMailingSubdivision.Text, TXTMailingSubdivision.Tag.ToString());

            if (strErrorMessage != "") //if there is an error
            {

                MessageBox.Show(strErrorMessage, "Input Error(s)");
                if (TXTDeliveryName.Text == "")
                {
                    RDOTakeOut.Checked = true;
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Checks to see if all of the Delievery information is valid including if present and if numerical enteries are integer
        /// also checks if the delievery city is either Bryan or College station and if the delievery state is TX
        /// </summary>
        /// <returns></returns>
        private bool IsValidDeliveryData()
        {
            try
            {
                strErrorMessage += Validation.IsPresent(TXTDeliveryName.Text, TXTDeliveryName.Tag.ToString());
                strErrorMessage += Validation.IsPresent(TXTDeliveryPhoneNumber.Text, TXTDeliveryPhoneNumber.Tag.ToString());
                strErrorMessage += Validation.IsInteger(TXTDeliveryPhoneNumber.Text, TXTDeliveryPhoneNumber.Tag.ToString());
                if (Validation.IsInteger(TXTDeliveryPhoneNumber.Text, TXTDeliveryPhoneNumber.Tag.ToString()) == "")
                {
                    strErrorMessage += Validation.IsNonNegitive(TXTDeliveryPhoneNumber.Text, TXTDeliveryPhoneNumber.Tag.ToString(), 0);
                }
                strErrorMessage += Validation.IsPresent(TXTDeliveryAddress.Text, TXTDeliveryAddress.Tag.ToString());
                strErrorMessage += Validation.IsPresent(TXTDeliveryCity.Text, TXTDeliveryCity.Tag.ToString());
                strErrorMessage += Validation.IsPresent(TXTDeliveryState.Text, TXTDeliveryState.Tag.ToString());
                strErrorMessage += Validation.IsPresent(TXTDeliveryZipCode.Text, TXTDeliveryZipCode.Tag.ToString());
                strErrorMessage += Validation.IsInteger(TXTDeliveryZipCode.Text, TXTDeliveryZipCode.Tag.ToString());
                if (Validation.IsInteger(TXTDeliveryZipCode.Text, TXTDeliveryZipCode.Tag.ToString()) == "")
                {
                    strErrorMessage += Validation.IsNonNegitive(TXTDeliveryZipCode.Text, TXTDeliveryZipCode.Tag.ToString(), 0);
                }
                strErrorMessage += Validation.IsPresent(TXTDeliverySubdivision.Text, TXTDeliverySubdivision.Tag.ToString());

                if (RDODelivery.Checked)
                {
                    if (Validation.IsPresent(TXTDeliveryCity.Text, TXTDeliveryCity.Tag.ToString()) == "")
                    {
                        if (TXTDeliveryCity.Text.Trim().ToLower() != "bryan" && TXTDeliveryCity.Text.Trim().ToLower() != "college station")
                        {
                            strErrorMessage += ("Delivery is only available to Bryan or College Station." + "\n");
                            TXTDeliveryCity.Clear();
                            TXTDeliveryCity.Focus();
                        }
                    }


                    if (Validation.IsPresent(TXTDeliveryState.Text, TXTDeliveryState.Tag.ToString()) == "")
                    {
                        if (TXTDeliveryState.Text.Trim().ToLower() != "tx" && TXTDeliveryState.Text.Trim().ToLower() != "")
                        {
                            strErrorMessage += ("Delivery is only available in TX." + "\n");
                            TXTDeliveryState.Clear();
                            TXTDeliveryState.Focus();
                        }
                    }

                }
            }
            catch (FormatException) //Catch for incorrect formatting when inputed
            {
                MessageBox.Show("Please make sure input is nurmeric and try again.", "Entry Error");
            }
            catch (OverflowException) //Catch for value getting too large for computer to handle
            {
                MessageBox.Show("Please enter a smaller value and try again.", "Overflow Error");
            }
            catch (DivideByZeroException) //Catch for when user tries to divide by 0
            {
                MessageBox.Show("Divided by 0, please use non-zero numbers", "Divide by zero");
            }
            catch //Catch for anything that wasnt caught
            {
                MessageBox.Show("An unexpected error occured. Please try again", "Unexpected Error");
            }

            if (strErrorMessage != "") //if there is an error
            {
                MessageBox.Show(strErrorMessage, "Input Error(s)");
                return false;
            }
            else
            {
                return true;
            }

        }

        /// <summary>
        /// checks if the quantity entered is a valid input including if it is present, an integer, and a non negative value
        /// </summary>
        /// <returns></returns>
        private bool IsValidQuantity()
        {
            strQuantityErrorMessage += Validation.IsPresent(TXTQuantity.Text, TXTQuantity.Tag.ToString());
            strQuantityErrorMessage += Validation.IsInteger(TXTQuantity.Text, TXTQuantity.Tag.ToString());
           
            if (Validation.IsInteger(TXTQuantity.Text, TXTQuantity.Tag.ToString()) == "")
            {
                strQuantityErrorMessage += Validation.IsNonNegitive(TXTQuantity.Text, TXTQuantity.Tag.ToString(), 0);
                strQuantityErrorMessage += Validation.IsWithinRange(TXTQuantity.Text, TXTQuantity.Tag.ToString(), 1m, 1000m);
            }
            if (strQuantityErrorMessage != "") //if there is an error
            {
                MessageBox.Show("Invalid Quanitity, Please enter a number between 1 & 1000." + "\n");
                return false;
            }
            else
            {
                return true;
            }

        }

        #endregion
        /// <summary>
        /// Clears all fields and resets to default values if clear fields is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNClearFields_Click(object sender, EventArgs e)
        {
            ClearAllData();
        }

        /// <summary>
        /// if the user changes the value entered in the quantity textbox, resets the error message for the quantity to empty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TXTQuantity_TextChanged(object sender, EventArgs e)
        {
            strQuantityErrorMessage = "";
        }

        /// <summary>
        /// Closes the form and catches any exceptions prior to closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNExit_Click(object sender, EventArgs e)
        {
            try
            {
               
                Close();
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("An unexpected error occured. Please try again", "Unexpected Error");
            }
            catch //Catch for anything that wasnt caught
            {
                MessageBox.Show("An unexpected error occured. Please try again", "Unexpected Error");
            }

        }

        /// <summary>
        /// Fillas all the fields so Ted will be able to grade the new stuff easier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TXTFillAllFields_Click_1(object sender, EventArgs e)
        {
            CBXBreadOrCrustStyle.Items.Clear();
            TXTMailingName.Text = "Ted Boone";
            TXTMailingPhoneNumber.Text = "9791234567";
            TXTMailingAddress.Text = "400 Bizzell St";
            TXTMailingCity.Text = "College Station";
            TXTMailingState.Text = "TX";
            TXTMailingZipCode.Text = "77840";
            TXTMailingSubdivision.Text = "Traditions";
            CBXProduct.SelectedIndex = 1;
            lblBreadOrCrust.Text = "Bread:";
            CBXBreadOrCrustStyle.Enabled = true;
            CBXBreadOrCrustStyle.Items.Add("White");
            CBXBreadOrCrustStyle.Items.Add("Pumpernickle");
            CBXBreadOrCrustStyle.Items.Add("Rye");
            CBXBreadOrCrustStyle.Items.Add("Sourdough");
            CBXBreadOrCrustStyle.Items.Add("Multigrain");
            CBXBreadOrCrustStyle.SelectedItem = "White";
            intQuantityArr = new int[6];
            PBXPizzaOrSandwich.Image = Properties.Resources.deli;
            TXTQuantity.Text = "1";



        }



        /// <summary>
        /// Displays Inventory of each material which is updated once each order is processed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNInventory_Click(object sender, EventArgs e)
        {
            FRMInventory inventory = new FRMInventory(strIngredientsArray, decCurrentInventoryArray);
            inventory.ShowDialog(); 
        }

       

      
       /// <summary>
       /// Checks the CBX carbs to enable the quantity text box only if there is something selected in the CBXCarbs combo box
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void CBXBreadOrCrustStyle_TextChanged(object sender, EventArgs e)
        {
            if (CBXBreadOrCrustStyle.SelectedIndex != -1)
            {
                TXTQuantity.Enabled = true;
            }
        }

        private void BTNVendors_Click(object sender, EventArgs e)
        {
            FRMVendors Vendors = new FRMVendors();
            Vendors.ShowDialog();
        }
        
          
        
    }
}








