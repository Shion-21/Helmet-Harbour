using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using ESCPOS_NET;
using ESCPOS_NET.Emitters;
using ESCPOS_NET.Printers;
using Helmet_Harbour_MK2.Properties;

namespace Helmet_Harbour_MK2
{
    public partial class PayConForm : Form
    {
        string mSlot, mRFID, LoggedUsername, Lplate;
        string server = Server_Settings.Default.server;
        string uid = Server_Settings.Default.uid;
        string pwd = Server_Settings.Default.pwd;
        string database = Server_Settings.Default.database;
        string conphrase, Usertype;
        string ActionName = "Payment";
        private readonly string printerName;
        private readonly EPSON e = new EPSON();
        DateTime start, end;
        double change, received;
        double Rackfee, Parkingfee;
        public PayConForm(string RFID, string Slot, string Username)
        {
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            InitializeComponent();
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {

                mySqlConnection.Open();
                string Query = "SELECT `Plate Number` FROM helmetharbour.`rfids` WHERE `RFID Number` = @RFID";
                using (var cmd = new MySqlCommand(Query, mySqlConnection))
                {
                    cmd.Parameters.AddWithValue("@RFID", RFID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Lplate = reader.GetString("Plate Number");
                        }
                        else
                        {
                            Lplate = "No license plate found";
                        }

                    }
                }
            }
            CheckUserType(RFID);
            Platelbl.Text = Lplate;
            mRFID = RFID;
            mSlot = Slot;
            LoggedUsername = Username;
            GetUserInfo();
            var printers = new string[PrinterSettings.InstalledPrinters.Count];
            PrinterSettings.InstalledPrinters.CopyTo(printers, 0);

            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                printercomboBox.Items.Add(printer);
            }

            printercomboBox.SelectedItem = new PrinterSettings().PrinterName;

            if (!UsedInRack())
            {
                Slotlbl.Text = "Parking Only";
                if (!Usertype.Equals("Passenger"))
                {
                    Feelbl.Text = Properties.Settings.Default.Parking_Fee.ToString();
                }
                else
                {
                    Feelbl.Text = "0";
                }
                
                label4.Text = "Time in";
                DateTime Activation = GetActivationTime();

                TimeSpan duration = DateTime.Now - Activation;
                double totalMinutes = duration.TotalMinutes;
                double totalHours = duration.TotalHours;
                int totalHoursWithDays = (duration.Days * 24) + duration.Hours;
                Durationlbl.Text = $"{totalHoursWithDays:D2}:{duration.Minutes:D2}:{duration.Seconds:D2}";

                return;
            }

            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                mySqlConnection.Open();
                string updateEndQuery = "UPDATE `helmet racks` SET `Time End` = NOW() WHERE `RFID #` = @RFID";
                using (var cmd = new MySqlCommand(updateEndQuery, mySqlConnection))
                {
                    cmd.Parameters.AddWithValue("@RFID", RFID);
                    cmd.ExecuteNonQuery();
                }

                string selectQuery = "SELECT `Time Start`, `Time End` FROM `helmet racks` WHERE `RFID #` = @RFID";
                using (MySqlCommand cmd = new MySqlCommand(selectQuery, mySqlConnection))
                {
                    cmd.Parameters.AddWithValue("@RFID", RFID);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("No data found.");
                            return;
                        }

                        start = reader.GetDateTime(0);
                        end = reader.GetDateTime(1);

                    }
                }

                TimeSpan duration = end - start;
                double totalMinutes = duration.TotalMinutes;
                double totalHours = duration.TotalHours;
                double fee = 0;
                double feeAmount = Properties.Settings.Default.Fee_Amount;
                string paymentType = Properties.Settings.Default.Payment_type;
                if (paymentType == "Per Hour") fee = (int)totalHours * feeAmount;
                else if (paymentType == "Per 30 Mins") fee = ((int)totalMinutes / 30) * feeAmount;
                else if (paymentType == "Per 15 Mins") fee = ((int)totalMinutes / 15) * feeAmount;
                else if (paymentType == "Per 10 Mins") fee = ((int)totalMinutes / 10) * feeAmount;
                else if (paymentType == "Per 5 Mins") fee = ((int)totalMinutes / 5) * feeAmount;
                else if (paymentType == "Per 1 Min") fee = (int)totalMinutes * feeAmount;
                else
                {
                    MessageBox.Show("No Valid Payment Mode");
                    return;
                }

                if (Properties.Settings.Default.Initial_Payment) fee += Properties.Settings.Default.Initial_Payment_Value;
                Rackfee = fee;
                if (!Usertype.Equals("Passenger"))fee += Properties.Settings.Default.Parking_Fee;
                Slotlbl.Text = Slot;
                Feelbl.Text = fee.ToString();
                int totalHoursWithDays = (duration.Days * 24) + duration.Hours;
                Durationlbl.Text = $"{totalHoursWithDays:D2}:{duration.Minutes:D2}:{duration.Seconds:D2}";
                

            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            if (!Access.Equals("RootAdmin"))
            {
                InsertAction(ActionName, EmpNum, "Payment process canceled");
            }
            this.Close();
        }

        private void Confirmbtn_Click(object sender, EventArgs e)
        {
            if (Amount_Received.Text.Equals(""))
            {
                MessageBox.Show("No amount entered");
                return;
            }


            if (printercomboBox.SelectedItem != null)
            {
                string selectedPrinter = printercomboBox.SelectedItem.ToString();

                Properties.Settings.Default.Printer = selectedPrinter;
                Properties.Settings.Default.Save();
            }

            double AmountReceived;
            if (!double.TryParse(Amount_Received.Text, out AmountReceived))
            {
                MessageBox.Show("Please enter a valid amount.");
                return;

            }
            double Fee;
            if (!double.TryParse(Feelbl.Text, out Fee))
            {
                MessageBox.Show("Fee is not a valid amount");
                return;

            }
            if (AmountReceived < Fee)
            {
                MessageBox.Show("Payment is less than the Fee");
                return;

            }
            change = AmountReceived - Fee;

            MessageBox.Show("Change Amount: " + change, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            InsertRecord(Fee, AmountReceived, change);

            ResetRackDbRow();
            if (!Access.Equals("RootAdmin"))
            {
                InsertAction(ActionName, EmpNum, "Processed payment");
            }

            if (!UsedInRack())
            {
                PrintParkingReceipt(Slotlbl.Text, Durationlbl.Text, Fee, change, AmountReceived, Lplate);
                this.Close();
            }
            else
            {
                PrintReceipt(Slotlbl.Text, Durationlbl.Text, Fee, change, AmountReceived, Lplate);
                this.Close();
            }

        }
        public void ResetRackDbRow()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "Update helmetharbour.`rfids` SET `Status` = 'Inactive', `Activation Time` = NULL, `Plate Number` = NULL, `TempHolder` = NULL, `HolderType` = NULL WHERE `RFID Number`= @RFID";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@RFID", mRFID);
                    command.ExecuteNonQuery();

                }
            }
            if (!UsedInRack())
            {
                this.Close();
            };
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "Update helmetharbour.`helmet racks` SET `RFID #` = '', `Time Start` = NULL, `Time End` = NULL, Duration = NULL, Fee = '', RFIDSet = '0'  WHERE `Rack Slot` = @Slot";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@Slot", mSlot);
                    command.ExecuteNonQuery();
                    this.Close();
                }
            }
        }
        string DurationHours, transactionNumber;

        private void InsertRecord(double Fee, double Amount, double Change)
        {
            string today = DateTime.Now.ToString("yyyyMMdd");
            string countQuery = "SELECT COUNT(*) FROM `records` WHERE DATE(`Date Time Recorded`) = CURDATE()";
            int countToday;


            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                mySqlConnection.Open();
                using (MySqlCommand countCmd = new MySqlCommand(countQuery, mySqlConnection))
                {
                    countToday = Convert.ToInt32(countCmd.ExecuteScalar()) + 1;
                }
                transactionNumber = $"TXN-{today}-{countToday:D5}";


                if (!UsedInRack())
                {
                    string query = "INSERT INTO `records` (`Slot`, `RFID #`, `Time Start`, `Time End`, `Duration`, `Fee`, `Date Time Recorded`, `Operator`, `Transaction Num`, `Received Amount`, `Amount Change`, `HolderType`) " +
                            "VALUES (@Slot, @RFID, @TimeStart, NOW(), @Duration, @Fee, NOW(), @User, @TransactionNum, @Received, @Change, @Type)";
                    using (MySqlCommand insertcommand = new MySqlCommand(query, mySqlConnection))
                    {
                        insertcommand.Parameters.AddWithValue("@Slot", null);
                        insertcommand.Parameters.AddWithValue("@RFID", mRFID);
                        insertcommand.Parameters.AddWithValue("@TimeStart", GetActivationTime());
                        insertcommand.Parameters.AddWithValue("@TimeEnd", end);
                        insertcommand.Parameters.AddWithValue("@Duration", Durationlbl.Text);
                        insertcommand.Parameters.AddWithValue("@Fee", "₱ " + Fee);
                        insertcommand.Parameters.AddWithValue("@User", FirstName + " " + LastName);
                        insertcommand.Parameters.AddWithValue("@TransactionNum", transactionNumber);
                        insertcommand.Parameters.AddWithValue("@Received", "₱ " + Amount);
                        insertcommand.Parameters.AddWithValue("@Change", "₱ " + change);
                        insertcommand.Parameters.AddWithValue("@Type", Usertype);
                        insertcommand.ExecuteNonQuery();
                    }
                }
                else
                {
                    string query = "INSERT INTO `records` (`Slot`, `RFID #`, `Time Start`, `Time End`, `Duration`, `Fee`, `Date Time Recorded`, `Operator`, `Transaction Num`, `Received Amount`, `Amount Change`, `HolderType`) " +
                        "VALUES (@Slot, @RFID, @TimeStart, NOW(), @Duration, @Fee, NOW(), @User, @TransactionNum, @Received, @Change, @Type)";
                    using (MySqlCommand insertcommand = new MySqlCommand(query, mySqlConnection))
                    {
                        insertcommand.Parameters.AddWithValue("@Slot", mSlot);
                        insertcommand.Parameters.AddWithValue("@RFID", mRFID);
                        insertcommand.Parameters.AddWithValue("@TimeStart", start);
                        insertcommand.Parameters.AddWithValue("@TimeEnd", end);
                        insertcommand.Parameters.AddWithValue("@Duration", Durationlbl.Text);
                        insertcommand.Parameters.AddWithValue("@Fee", "₱ " + Fee);
                        insertcommand.Parameters.AddWithValue("@User", FirstName + " " + LastName);
                        insertcommand.Parameters.AddWithValue("@TransactionNum", transactionNumber);
                        insertcommand.Parameters.AddWithValue("@Received", "₱ " + Amount);
                        insertcommand.Parameters.AddWithValue("@Change", "₱ " + change);
                        insertcommand.Parameters.AddWithValue("@Type", Usertype);
                        insertcommand.ExecuteNonQuery();
                    }
                }
            }






        }


        private void Slotlbl_Click(object sender, EventArgs e)
        {

        }

        private void PayConForm_Load(object sender, EventArgs e)
        {

        }

        private bool UsedInRack()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT 1 FROM helmetharbour.`helmet racks` WHERE `RFID #` = @RFID LIMIT 1";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@RFID", mRFID);
                    object result = command.ExecuteScalar();
                    return result != null;
                }
            }
        }
        public void PrintReceipt(string rack, string duration, double amount, double change, double received, string Plate)
        {
            PrintDocument pd = new PrintDocument();
            if (printercomboBox.SelectedItem != null)
            {
                pd.PrinterSettings.PrinterName = printercomboBox.SelectedItem.ToString();
            }
            string selectedPrinter = pd.PrinterSettings.PrinterName.ToLower();
            int paperWidth = 220;
            if (selectedPrinter.Contains("80") || selectedPrinter.Contains("76"))
            {
                paperWidth = 300;
            }
            else if (selectedPrinter.Contains("58"))
            {
                paperWidth = 220;
            }
            PaperSize paperSize = new PaperSize("AutoPOS", paperWidth, 5000);
            pd.DefaultPageSettings.PaperSize = paperSize;
            pd.DefaultPageSettings.Margins = new Margins(5, 5, 5, 20);
            pd.PrintPage += (sender, ev) =>
            {

                Font headerFont = new Font("Consolas", (paperWidth > 250) ? 12 : 10, FontStyle.Bold);
                Font font = new Font("Consolas", (paperWidth > 250) ? 10 : 8);
                float y = 10;
                float leftMargin = 5;
                int maxWidth = paperWidth - 20;
                ev.Graphics.DrawString("HELMET HARBOUR", headerFont, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString("---------------------------", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString($"Rack: {rack}", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString($"License Plate: {Plate}", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString($"Duration: {duration}", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString($"Rack Fee: ₱{Rackfee}", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString($"Parking Fee: ₱{Properties.Settings.Default.Parking_Fee}", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString($"Total: ₱{amount}", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString($"Amount Received: ₱{received}", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString($"Change: ₱{change}", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString("Date: " + DateTime.Now.ToString("g"), font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 20;
                ev.Graphics.DrawString("Thank you for using", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString("Helmet Harbour!", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 20;
            };


            pd.Print();
        }
        public void PrintParkingReceipt(string rack, string duration, double amount, double change, double received, string Plate)
        {
            PrintDocument pd = new PrintDocument();
            if (printercomboBox.SelectedItem != null)
            {
                pd.PrinterSettings.PrinterName = printercomboBox.SelectedItem.ToString();
            }
            string selectedPrinter = pd.PrinterSettings.PrinterName.ToLower();
            int paperWidth = 220;
            if (selectedPrinter.Contains("80") || selectedPrinter.Contains("76"))
            {
                paperWidth = 300;
            }
            else if (selectedPrinter.Contains("58"))
            {
                paperWidth = 220;
            }
            PaperSize paperSize = new PaperSize("AutoPOS", paperWidth, 5000);
            pd.DefaultPageSettings.PaperSize = paperSize;
            pd.DefaultPageSettings.Margins = new Margins(5, 5, 5, 20);
            pd.PrintPage += (sender, ev) =>
            {

                Font headerFont = new Font("Consolas", (paperWidth > 250) ? 12 : 10, FontStyle.Bold);
                Font font = new Font("Consolas", (paperWidth > 250) ? 10 : 8);
                float y = 10;
                float leftMargin = 5;
                int maxWidth = paperWidth - 20;
                float lineSpacing = 2;
                y += font.GetHeight(ev.Graphics) + lineSpacing;
                ev.Graphics.DrawString("HELMET HARBOUR", headerFont, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 20;
                ev.Graphics.DrawString($"Operator: {FirstName + " " + LastName}", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString("---------------------------", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString($"Rack: {rack}", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString($"License Plate: {Plate}", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString($"Duration: {duration}", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString($"Parking Fee: ₱{amount}", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString($"Amount Received: ₱{received}", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString($"Change: ₱{change}", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString("Date: " + DateTime.Now.ToString("g"), font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString($"Transaction No.:", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString($"{transactionNumber}", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 20;
                ev.Graphics.DrawString("Thank you for using", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 2;
                ev.Graphics.DrawString("Helmet Harbour!", font, Brushes.Black, leftMargin, y); y += font.GetHeight(ev.Graphics) + 20;


            };

            pd.Print();
        }

        private DateTime GetActivationTime()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT `Activation Time` FROM helmetharbour.`rfids` WHERE `RFID Number` = @RFID";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@RFID", mRFID);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime DateAndTime = reader.GetDateTime("Activation Time");
                            return DateAndTime;
                        }
                        else
                        {
                            return DateTime.MinValue;
                        }
                    }
                }
            }
        }
        string EmpNum, FirstName, LastName, Access;
        private void GetUserInfo()
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT * FROM helmetharbour.`accounts` WHERE `Username` = @Username";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@Username", LoggedUsername);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            EmpNum = reader.GetString("Employee ID");
                            FirstName = reader.GetString("First Name");
                            LastName = reader.GetString("Last Name");
                            Access = reader.GetString("Access");
                        }
                    }
                }
            }
        }
        private void InsertAction(string Action, string EmpID, string Remark)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "INSERT INTO helmetharbour.`actions log` (`Employee Number`, `User`, `Action`, `Remarks`,`Date & Time`) VALUES (@EmpID, @Username, @Action, @Remark, NOW())";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@EmpID", EmpID);
                    command.Parameters.AddWithValue("@Username", LoggedUsername);
                    command.Parameters.AddWithValue("@Action", Action);
                    command.Parameters.AddWithValue("@Remark", Remark);
                    command.ExecuteNonQuery();
                }
            }
        }
        private void invalidsymbol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void Amount_Received_TextChanged(object sender, EventArgs e)
        {

        }

        private void CheckUserType(string RFIDnum)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT `HolderType` FROM helmetharbour.`rfids` WHERE `RFID Number` = @RFID";
                mySqlConnection.Open();
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    command.Parameters.AddWithValue("@RFID", RFIDnum);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Usertype = reader.GetString("HolderType");
                        }
                        else
                        {
                            Usertype = "Driver";
                        }
                    }
                }
            }
        }
    }
}
