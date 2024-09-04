using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodingProject1
{
    public static class Validation
    {
        
        
        /// <summary>
        /// checks to see if the text box is present
        /// </summary>
        /// <param name="strTestValue"></param>
        /// <param name="strTextBoxName"></param>
        /// <returns></returns>
        public static string IsPresent(string strTestValue, string strTextBoxName)
        {
           
            string strMessage = "";
            if (strTestValue.Trim() == "")
            {
                strMessage = strTextBoxName + " is a required field.\n";
            }
            return strMessage;
        }

        
        /// <summary>
        /// checks to make sure the text box requested is an integer
        /// </summary>
        /// <param name="strTestValue"></param>
        /// <param name="strTextBoxName"></param>
        /// <returns></returns>
        public static string IsInteger(string strTestValue, string strTextBoxName)
        {
            string strMessage = ""; //start with error message empty
            if (!Int64.TryParse(strTestValue, out _))
            {
                strMessage = strTextBoxName + " must be a integer value.\n";
               
            }
         
            return strMessage;
        }
        /// <summary>
        /// checks the integer text boxes to make sure they are non negitive
        /// </summary>
        /// <param name="strTestValue"></param>
        /// <param name="strTextBoxName"></param>
        /// <param name="decMin"></param>
        /// <returns></returns>
        public static string IsNonNegitive(string strTestValue, string strTextBoxName, decimal decMin)
        {
            string strMessage = ""; 
            if(!(Convert.ToDecimal(strTestValue) > decMin))
            {
                strMessage += strTextBoxName + " must be a non-negative value.\n"; 
            }
            return strMessage; 
        }

        /// <summary>
        /// makes sure that any text box requested is within a certian range
        /// </summary>
        /// <param name="strTestValue"></param>
        /// <param name="strControlName"></param>
        /// <param name="decMin"></param>
        /// <param name="decMax"></param>
        /// <returns></returns>
        public static string IsWithinRange(string strTestValue, string strControlName, decimal decMin, decimal decMax)
        {

            decimal decTestNumber = Convert.ToDecimal(strTestValue);
            string strMessage = "";
            if (decTestNumber < decMin || decTestNumber > decMax)
            {
                strMessage += strControlName + " must be between " + decMin + " and " + decMax + ".\n";
            }
            return strMessage;
        }
        public static string ContainsNumbersAndLetter(string strTestValue, string strControlName)
        {
            string strMessage = "";
            foreach (char c in strTestValue)
            {
                // if the character is not a number, then we will display the error message that asks for numeric values
                if (!Char.IsNumber(c) && !Char.IsLetter(c) && !Char.IsWhiteSpace(c))
                {
                    strMessage = strControlName + "must only contain letters and numbers" + "\n";
                }
            }
            return strMessage;
        }


    }
}
