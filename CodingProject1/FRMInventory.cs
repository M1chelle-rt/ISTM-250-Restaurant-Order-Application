using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodingProject1
{
    //AUTHOR: Michelle Thomas, Quinn Leith, Gabriel Perez, Ben Jacyno
    //COURSE: ISTM 250.501
    //FORM: FRMInventory
    //PURPOSE: The frmInventory form is used to display to the user what the inventories are for multiple different products
    //INPUT:the array strIngredientArray and decCurrentInventoryArray
    //PROCESS: uses for loops to calculate and subtract different inventories baised on what product the user purchases
    //OUTPUT: the List box that shows the user what the different inventories are
    //HONOR CODE: “On my honor, as an Aggie, I have neither given
    // nor received unauthorized aid on this academic
    // work.”
    public partial class FRMInventory : Form
    {
       //grabs the arrays and shifts them from the FRM inventory form and frm order form
        public string[] strIngredientsArr;
        private decimal[] decCurrentInventoryArr; 
        /// <summary>
        /// grabs the ingrediance and inventory array from frminventory and makes them equal to a stirng and decimal to be displayed
        /// </summary>
        /// <param name="strIngredientsArray"></param>
        /// <param name="decInventoryArray"></param>
        public FRMInventory(string[] strIngredientsArray, decimal[] decInventoryArray)
        {
            InitializeComponent();
            strIngredientsArr = strIngredientsArray;
            decCurrentInventoryArr = decInventoryArray; 
        }

    
        /// <summary>
        /// closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTNExit_Click(object sender, EventArgs e)
        {
            Close(); 
        }
        /// <summary>
        /// gets the numbers from the arrays then displayes them to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FRMInventory_Load(object sender, EventArgs e)
        {
           //clears the form
            LBXInventory.Items.Clear();
            //for loop to load the list box
            for (int i = 0; i < strIngredientsArr.Length; i++)
            {
                LBXInventory.Items.Add(strIngredientsArr[i] + "\t\t" + decCurrentInventoryArr[i]);
            }

        }

        
    }
}