﻿using System;
using System.Collections.Generic;
using System.Data;

namespace CL.Common.Print
{
    class Code128 : BarcodeCommon, IBarcode
    {
        public enum TYPES : int { DYNAMIC, A, B, C };

        private DataTable dtCode128 = new DataTable("C128");

        private List<string> formattedDataList = new List<string>();

        private List<string> encodedDataList = new List<string>();

        private DataRow startCharacterRow = null;

        private TYPES type = TYPES.DYNAMIC;


        public Code128(string input)
        {
            //Raw_Data是继承于BarcodeCommon
            Raw_Data = input;
        }

        /// <summary>
        /// Encodes data in Code128 format.
        /// </summary>
        /// <param name="input">需要编码的字符串.</param>
        /// <param name="type">编码类型 (Code 128A, Code 128B, Code 128C)</param>
        public Code128(string input, TYPES type)
        {
            this.type = type;
            Raw_Data = input;
        }

        private string Encode_Code128()
        {
            this.init_Code128();

            return GetEncoding();
        }

        private void init_Code128()
        {
            //设置大小写敏感
            this.dtCode128.CaseSensitive = true;

            //set up columns
            this.dtCode128.Columns.Add("Value1", typeof(string));
            this.dtCode128.Columns.Add("A", typeof(string));
            this.dtCode128.Columns.Add("B", typeof(string));
            this.dtCode128.Columns.Add("C", typeof(string));
            this.dtCode128.Columns.Add("Encoding", typeof(string));

            //populate data
            this.dtCode128.Rows.Add(new object[] { "0", " ", " ", "00", "11011001100" });
            this.dtCode128.Rows.Add(new object[] { "1", "!", "!", "01", "11001101100" });
            this.dtCode128.Rows.Add(new object[] { "2", "\"", "\"", "02", "11001100110" });
            this.dtCode128.Rows.Add(new object[] { "3", "#", "#", "03", "10010011000" });
            this.dtCode128.Rows.Add(new object[] { "4", "$", "$", "04", "10010001100" });
            this.dtCode128.Rows.Add(new object[] { "5", "%", "%", "05", "10001001100" });
            this.dtCode128.Rows.Add(new object[] { "6", "&", "&", "06", "10011001000" });
            this.dtCode128.Rows.Add(new object[] { "7", "'", "'", "07", "10011000100" });
            this.dtCode128.Rows.Add(new object[] { "8", "(", "(", "08", "10001100100" });
            this.dtCode128.Rows.Add(new object[] { "9", ")", ")", "09", "11001001000" });
            this.dtCode128.Rows.Add(new object[] { "10", "*", "*", "10", "11001000100" });
            this.dtCode128.Rows.Add(new object[] { "11", "+", "+", "11", "11000100100" });
            this.dtCode128.Rows.Add(new object[] { "12", ",", ",", "12", "10110011100" });
            this.dtCode128.Rows.Add(new object[] { "13", "-", "-", "13", "10011011100" });
            this.dtCode128.Rows.Add(new object[] { "14", ".", ".", "14", "10011001110" });
            this.dtCode128.Rows.Add(new object[] { "15", "/", "/", "15", "10111001100" });
            this.dtCode128.Rows.Add(new object[] { "16", "0", "0", "16", "10011101100" });
            this.dtCode128.Rows.Add(new object[] { "17", "1", "1", "17", "10011100110" });
            this.dtCode128.Rows.Add(new object[] { "18", "2", "2", "18", "11001110010" });
            this.dtCode128.Rows.Add(new object[] { "19", "3", "3", "19", "11001011100" });
            this.dtCode128.Rows.Add(new object[] { "20", "4", "4", "20", "11001001110" });
            this.dtCode128.Rows.Add(new object[] { "21", "5", "5", "21", "11011100100" });
            this.dtCode128.Rows.Add(new object[] { "22", "6", "6", "22", "11001110100" });
            this.dtCode128.Rows.Add(new object[] { "23", "7", "7", "23", "11101101110" });
            this.dtCode128.Rows.Add(new object[] { "24", "8", "8", "24", "11101001100" });
            this.dtCode128.Rows.Add(new object[] { "25", "9", "9", "25", "11100101100" });
            this.dtCode128.Rows.Add(new object[] { "26", ":", ":", "26", "11100100110" });
            this.dtCode128.Rows.Add(new object[] { "27", ";", ";", "27", "11101100100" });
            this.dtCode128.Rows.Add(new object[] { "28", "<", "<", "28", "11100110100" });
            this.dtCode128.Rows.Add(new object[] { "29", "=", "=", "29", "11100110010" });
            this.dtCode128.Rows.Add(new object[] { "30", ">", ">", "30", "11011011000" });
            this.dtCode128.Rows.Add(new object[] { "31", "?", "?", "31", "11011000110" });
            this.dtCode128.Rows.Add(new object[] { "32", "@", "@", "32", "11000110110" });
            this.dtCode128.Rows.Add(new object[] { "33", "A", "A", "33", "10100011000" });
            this.dtCode128.Rows.Add(new object[] { "34", "B", "B", "34", "10001011000" });
            this.dtCode128.Rows.Add(new object[] { "35", "C", "C", "35", "10001000110" });
            this.dtCode128.Rows.Add(new object[] { "36", "D", "D", "36", "10110001000" });
            this.dtCode128.Rows.Add(new object[] { "37", "E", "E", "37", "10001101000" });
            this.dtCode128.Rows.Add(new object[] { "38", "F", "F", "38", "10001100010" });
            this.dtCode128.Rows.Add(new object[] { "39", "G", "G", "39", "11010001000" });
            this.dtCode128.Rows.Add(new object[] { "40", "H", "H", "40", "11000101000" });
            this.dtCode128.Rows.Add(new object[] { "41", "I", "I", "41", "11000100010" });
            this.dtCode128.Rows.Add(new object[] { "42", "J", "J", "42", "10110111000" });
            this.dtCode128.Rows.Add(new object[] { "43", "K", "K", "43", "10110001110" });
            this.dtCode128.Rows.Add(new object[] { "44", "L", "L", "44", "10001101110" });
            this.dtCode128.Rows.Add(new object[] { "45", "M", "M", "45", "10111011000" });
            this.dtCode128.Rows.Add(new object[] { "46", "N", "N", "46", "10111000110" });
            this.dtCode128.Rows.Add(new object[] { "47", "O", "O", "47", "10001110110" });
            this.dtCode128.Rows.Add(new object[] { "48", "P", "P", "48", "11101110110" });
            this.dtCode128.Rows.Add(new object[] { "49", "Q", "Q", "49", "11010001110" });
            this.dtCode128.Rows.Add(new object[] { "50", "R", "R", "50", "11000101110" });
            this.dtCode128.Rows.Add(new object[] { "51", "S", "S", "51", "11011101000" });
            this.dtCode128.Rows.Add(new object[] { "52", "T", "T", "52", "11011100010" });
            this.dtCode128.Rows.Add(new object[] { "53", "U", "U", "53", "11011101110" });
            this.dtCode128.Rows.Add(new object[] { "54", "V", "V", "54", "11101011000" });
            this.dtCode128.Rows.Add(new object[] { "55", "W", "W", "55", "11101000110" });
            this.dtCode128.Rows.Add(new object[] { "56", "X", "X", "56", "11100010110" });
            this.dtCode128.Rows.Add(new object[] { "57", "Y", "Y", "57", "11101101000" });
            this.dtCode128.Rows.Add(new object[] { "58", "Z", "U", "58", "11101100010" });
            this.dtCode128.Rows.Add(new object[] { "59", "[", "[", "59", "11100011010" });
            this.dtCode128.Rows.Add(new object[] { "60", @"\", @"\", "60", "11101111010" });
            this.dtCode128.Rows.Add(new object[] { "61", "]", "]", "61", "11001000010" });
            this.dtCode128.Rows.Add(new object[] { "62", "^", "^", "62", "11110001010" });
            this.dtCode128.Rows.Add(new object[] { "63", "_", "_", "63", "10100110000" });
            this.dtCode128.Rows.Add(new object[] { "64", "\0", "`", "64", "10100001100" });
            this.dtCode128.Rows.Add(new object[] { "65", Convert.ToChar(1).ToString(), "a", "65", "10010110000" });
            this.dtCode128.Rows.Add(new object[] { "66", Convert.ToChar(2).ToString(), "b", "66", "10010000110" });
            this.dtCode128.Rows.Add(new object[] { "67", Convert.ToChar(3).ToString(), "c", "67", "10000101100" });
            this.dtCode128.Rows.Add(new object[] { "68", Convert.ToChar(4).ToString(), "d", "68", "10000100110" });
            this.dtCode128.Rows.Add(new object[] { "69", Convert.ToChar(5).ToString(), "e", "69", "10110010000" });
            this.dtCode128.Rows.Add(new object[] { "70", Convert.ToChar(6).ToString(), "f", "70", "10110000100" });
            this.dtCode128.Rows.Add(new object[] { "71", Convert.ToChar(7).ToString(), "g", "71", "10011010000" });
            this.dtCode128.Rows.Add(new object[] { "72", Convert.ToChar(8).ToString(), "h", "72", "10011000010" });
            this.dtCode128.Rows.Add(new object[] { "73", Convert.ToChar(9).ToString(), "i", "73", "10000110100" });
            this.dtCode128.Rows.Add(new object[] { "74", Convert.ToChar(10).ToString(), "j", "74", "10000110010" });
            this.dtCode128.Rows.Add(new object[] { "75", Convert.ToChar(11).ToString(), "k", "75", "11000010010" });
            this.dtCode128.Rows.Add(new object[] { "76", Convert.ToChar(12).ToString(), "l", "76", "11001010000" });
            this.dtCode128.Rows.Add(new object[] { "77", Convert.ToChar(13).ToString(), "m", "77", "11110111010" });
            this.dtCode128.Rows.Add(new object[] { "78", Convert.ToChar(14).ToString(), "n", "78", "11000010100" });
            this.dtCode128.Rows.Add(new object[] { "79", Convert.ToChar(15).ToString(), "o", "79", "10001111010" });
            this.dtCode128.Rows.Add(new object[] { "80", Convert.ToChar(16).ToString(), "p", "80", "10100111100" });
            this.dtCode128.Rows.Add(new object[] { "81", Convert.ToChar(17).ToString(), "q", "81", "10010111100" });
            this.dtCode128.Rows.Add(new object[] { "82", Convert.ToChar(18).ToString(), "r", "82", "10010011110" });
            this.dtCode128.Rows.Add(new object[] { "83", Convert.ToChar(19).ToString(), "s", "83", "10111100100" });
            this.dtCode128.Rows.Add(new object[] { "84", Convert.ToChar(20).ToString(), "t", "84", "10011110100" });
            this.dtCode128.Rows.Add(new object[] { "85", Convert.ToChar(21).ToString(), "u", "85", "10011110010" });
            this.dtCode128.Rows.Add(new object[] { "86", Convert.ToChar(22).ToString(), "v", "86", "11110100100" });
            this.dtCode128.Rows.Add(new object[] { "87", Convert.ToChar(23).ToString(), "w", "87", "11110010100" });
            this.dtCode128.Rows.Add(new object[] { "88", Convert.ToChar(24).ToString(), "x", "88", "11110010010" });
            this.dtCode128.Rows.Add(new object[] { "89", Convert.ToChar(25).ToString(), "y", "89", "11011011110" });
            this.dtCode128.Rows.Add(new object[] { "90", Convert.ToChar(26).ToString(), "z", "90", "11011110110" });
            this.dtCode128.Rows.Add(new object[] { "91", Convert.ToChar(27).ToString(), "{", "91", "11110110110" });
            this.dtCode128.Rows.Add(new object[] { "92", Convert.ToChar(28).ToString(), "|", "92", "10101111000" });
            this.dtCode128.Rows.Add(new object[] { "93", Convert.ToChar(29).ToString(), "}", "93", "10100011110" });
            this.dtCode128.Rows.Add(new object[] { "94", Convert.ToChar(30).ToString(), "~", "94", "10001011110" });

            this.dtCode128.Rows.Add(new object[] { "95", Convert.ToChar(31).ToString(), Convert.ToChar(127).ToString(), "95", "10111101000" });
            this.dtCode128.Rows.Add(new object[] { "96", Convert.ToChar(202).ToString()/*FNC3*/, Convert.ToChar(202).ToString()/*FNC3*/, "96", "10111100010" });
            this.dtCode128.Rows.Add(new object[] { "97", Convert.ToChar(201).ToString()/*FNC2*/, Convert.ToChar(201).ToString()/*FNC2*/, "97", "11110101000" });
            this.dtCode128.Rows.Add(new object[] { "98", "SHIFT", "SHIFT", "98", "11110100010" });
            this.dtCode128.Rows.Add(new object[] { "99", "CODE_C", "CODE_C", "99", "10111011110" });
            this.dtCode128.Rows.Add(new object[] { "100", "CODE_B", Convert.ToChar(203).ToString()/*FNC4*/, "CODE_B", "10111101110" });
            this.dtCode128.Rows.Add(new object[] { "101", Convert.ToChar(203).ToString()/*FNC4*/, "CODE_A", "CODE_A", "11101011110" });
            this.dtCode128.Rows.Add(new object[] { "102", Convert.ToChar(200).ToString()/*FNC1*/, Convert.ToChar(200).ToString()/*FNC1*/, Convert.ToChar(200).ToString()/*FNC1*/, "11110101110" });
            this.dtCode128.Rows.Add(new object[] { "103", "START_A", "START_A", "START_A", "11010000100" });
            this.dtCode128.Rows.Add(new object[] { "104", "START_B", "START_B", "START_B", "11010010000" });
            this.dtCode128.Rows.Add(new object[] { "105", "START_C", "START_C", "START_C", "11010011100" });
            this.dtCode128.Rows.Add(new object[] { "", "STOP", "STOP", "STOP", "11000111010" });
        }

        private List<DataRow> FindStartorCodeCharacter(string s, ref int col)
        {
            List<DataRow> rows = new List<DataRow>();

            //if two chars are numbers then START_C or CODE_C
            if (s.Length > 1 && Char.IsNumber(s[0]) && Char.IsNumber(s[1]))
            {
                if (startCharacterRow == null)
                {
                    startCharacterRow = this.dtCode128.Select("A = 'START_C'")[0];
                    rows.Add(startCharacterRow);
                }//if
                else
                    rows.Add(this.dtCode128.Select("A = 'CODE_C'")[0]);

                col = 1;
            }//if
            else
            {
                bool AFound = false;
                bool BFound = false;
                foreach (DataRow row in this.dtCode128.Rows)
                {
                    try
                    {
                        if (!AFound && s == row["A"].ToString())
                        {
                            AFound = true;
                            col = 2;

                            if (startCharacterRow == null)
                            {
                                startCharacterRow = this.dtCode128.Select("A = 'START_A'")[0];
                                rows.Add(startCharacterRow);
                            }//if
                            else
                            {
                                rows.Add(this.dtCode128.Select("B = 'CODE_A'")[0]);//first column is FNC4 so use B
                            }//else
                        }//if
                        else if (!BFound && s == row["B"].ToString())
                        {
                            BFound = true;
                            col = 1;

                            if (startCharacterRow == null)
                            {
                                startCharacterRow = this.dtCode128.Select("A = 'START_B'")[0];
                                rows.Add(startCharacterRow);
                            }//if
                            else
                                rows.Add(this.dtCode128.Select("A = 'CODE_B'")[0]);
                        }//else
                        else if (AFound && BFound)
                            break;
                    }//try
                    catch (Exception ex)
                    {
                        throw new Exception("EC128-1: " + ex.Message);
                    }//catch
                }//foreach                

                if (rows.Count <= 0)
                    throw new Exception("EC128-2: Could not determine start character.");
            }//else

            return rows;
        }

        private string CalculateCheckDigit()
        {
            string currentStartChar = formattedDataList[0];
            uint CheckSum = 0;

            for (uint i = 0; i < formattedDataList.Count; i++)
            {
                //replace apostrophes with double apostrophes for escape chars
                string s = formattedDataList[(int)i].Replace("'", "''");

                //try to find value in the A column
                DataRow[] rows = this.dtCode128.Select("A = '" + s + "'");

                //try to find value in the B column
                if (rows.Length <= 0)
                    rows = this.dtCode128.Select("B = '" + s + "'");

                //try to find value in the C column
                if (rows.Length <= 0)
                    rows = this.dtCode128.Select("C = '" + s + "'");

                uint value = UInt32.Parse(rows[0]["Value1"].ToString());
                uint addition = value * ((i == 0) ? 1 : i);
                CheckSum += addition;
            }//for

            uint Remainder = (CheckSum % 103);
            DataRow[] RetRows = this.dtCode128.Select("Value1 = '" + Remainder.ToString() + "'");
            return RetRows[0]["Encoding"].ToString();
        }

        private void BreakUpDataForEncoding()
        {
            string temp = "";
            string tempRawData = Raw_Data;

            //CODE C: adds a 0 to the front of the Raw_Data if the length is not divisible by 2
            if (this.type == TYPES.C && Raw_Data.Length % 2 > 0)
                tempRawData = "0" + Raw_Data;

            foreach (char c in tempRawData)
            {
                if (Char.IsNumber(c))
                {
                    if (temp == "")
                    {
                        temp += c;
                    }//if
                    else
                    {
                        temp += c;
                        formattedDataList.Add(temp);
                        temp = "";
                    }//else
                }//if
                else
                {
                    if (temp != "")
                    {
                        formattedDataList.Add(temp);
                        temp = "";
                    }//if
                    formattedDataList.Add(c.ToString());
                }//else
            }//foreach

            //if something is still in temp go ahead and push it onto the queue
            if (temp != "")
            {
                formattedDataList.Add(temp);
                temp = "";
            }//if
        }

        private void InsertStartandCodeCharacters()
        {
            DataRow CurrentCodeSet = null;
            string CurrentCodeString = "";

            if (this.type != TYPES.DYNAMIC)
            {
                switch (this.type)
                {
                    case TYPES.A: formattedDataList.Insert(0, "START_A");
                        break;
                    case TYPES.B: formattedDataList.Insert(0, "START_B");
                        break;
                    case TYPES.C: formattedDataList.Insert(0, "START_C");
                        break;
                    default: throw new Exception("EC128-4: Unknown start type in fixed type encoding.");
                }
            }//if
            else
            {
                try
                {
                    for (int i = 0; i < (formattedDataList.Count); i++)
                    {
                        int col = 0;
                        List<DataRow> tempStartChars = FindStartorCodeCharacter(formattedDataList[i], ref col);

                        //check all the start characters and see if we need to stay with the same codeset or if a change of sets is required
                        bool sameCodeSet = false;
                        foreach (DataRow row in tempStartChars)
                        {
                            if (row["A"].ToString().EndsWith(CurrentCodeString) || row["B"].ToString().EndsWith(CurrentCodeString) || row["C"].ToString().EndsWith(CurrentCodeString))
                            {
                                sameCodeSet = true;
                                break;
                            }//if
                        }//foreach

                        //only insert a new code char if starting a new codeset
                        //if (CurrentCodeString == "" || !tempStartChars[0][col].ToString().EndsWith(CurrentCodeString)) /* Removed because of bug */

                        if (CurrentCodeString == "" || !sameCodeSet)
                        {
                            CurrentCodeSet = tempStartChars[0];

                            bool error = true;
                            while (error)
                            {
                                try
                                {
                                    CurrentCodeString = CurrentCodeSet[col].ToString().Split(new char[] { '_' })[1];
                                    error = false;
                                }//try
                                catch
                                {
                                    error = true;

                                    if (col++ > CurrentCodeSet.ItemArray.Length)
                                        throw new Exception("No start character found in CurrentCodeSet.");
                                }//catch
                            }//while

                            formattedDataList.Insert(i++, CurrentCodeSet[col].ToString());
                        }//if

                    }//for
                }//try
                catch (Exception ex)
                {
                    throw new Exception("EC128-3: Could not insert start and code characters.\n Message: " + ex.Message);
                }//catch
            }//else
        }

        private string GetEncoding()
        {
            if (this.type == TYPES.C)
            {
                //break up data for encoding
                BreakUpDataForEncoding();
            }
            else
            {
                for (int i = 0; i < Raw_Data.Length; i++)
                {
                    formattedDataList.Add(Raw_Data[i].ToString());
                }
            }

            //insert the start characters
            InsertStartandCodeCharacters();

            string CheckDigit = CalculateCheckDigit();

            string Encoded_Data = "";
            foreach (string s in formattedDataList)
            {
                //handle exception with apostrophes in select statements
                string s1 = s.Replace("'", "''");

                DataRow[] E_Row = this.dtCode128.Select("A = '" + s1 + "'");

                if (E_Row.Length <= 0)
                {
                    E_Row = this.dtCode128.Select("B = '" + s1 + "'");

                    if (E_Row.Length <= 0)
                    {
                        E_Row = this.dtCode128.Select("C = '" + s1 + "'");
                    }//if
                }//if

                if (E_Row.Length <= 0)
                    throw new Exception("EC128-3: Could not find encoding of a value( " + s1 + " ) in the formatted data.");

                Encoded_Data += E_Row[0]["Encoding"].ToString();
                encodedDataList.Add(E_Row[0]["Encoding"].ToString());
            }//foreach

            //add the check digit
            Encoded_Data += CalculateCheckDigit();
            encodedDataList.Add(CalculateCheckDigit());

            //add the stop character
            Encoded_Data += this.dtCode128.Select("A = 'STOP'")[0]["Encoding"].ToString();
            encodedDataList.Add(this.dtCode128.Select("A = 'STOP'")[0]["Encoding"].ToString());

            //add the termination bars
            Encoded_Data += "11";
            encodedDataList.Add("11");

            return Encoded_Data;
        }

        #region IBarcode Members

        public string Encoded_Value
        {
            get { return Encode_Code128(); }
        }

        #endregion
    }//class
}
