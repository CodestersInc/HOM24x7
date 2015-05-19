using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using BusinessLogic;

/// <summary>
/// Summary description for Utility
/// </summary> 

namespace WebUtility
{
    public class Utility
    {
        public Utility()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static Boolean replaceImage(String oldImagePath, String newImagePath)
        {
            return true;
        }

        public static Boolean isEmpty(String Text)
        {
            if (Text.CompareTo("") == 0) return true; else return false;
        }

        public static Boolean ValidateEmail(String email)
        {
            return true;
        }

        public static Boolean ValidatePhoneNumber(String number)
        {
            return true;
        }

        public static Boolean ValidateName(String name)
        {
            return true;
        }

        public static String GetSHA512Hash(String source)
        {
            using (SHA512 sha512Hash = SHA512.Create())
            {
                // Convert the input string to a byte array and compute the hash. 
                byte[] data = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(source));

                // Create a new Stringbuilder to collect the bytes 
                // and create a string.
                StringBuilder sBuilder = new StringBuilder(513);

                // Loop through each byte of the hashed data  
                // and format each one as a hexadecimal string. 
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string. 
                return sBuilder.ToString();
            }
        }

        public static Boolean CompareSHA512Hash(String Hash1, String Hash2)
        {
            if (Hash1 == Hash2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void MsgBox(String msg, Page page, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + msg.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = page.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        public static void MsgBox(String msg, Page page, Object obj, String redirectURL)
        {
            string s = "<SCRIPT language='javascript'>alert('" + msg.Replace("\r\n", "\\n").Replace("'", "") + "'); window.location='" + redirectURL + "'</SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = page.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
    }
}