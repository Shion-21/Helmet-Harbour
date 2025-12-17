using MySql.Data.MySqlClient;

namespace Helmet_Harbour_MK2
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            string server = Server_Settings.Default.server;
            string uid = Server_Settings.Default.uid;
            string pwd = Server_Settings.Default.pwd;
            string database = Server_Settings.Default.database;
            string conphrase;
            conphrase = "server=" + server + ";uid=" + uid + ";pwd=" + pwd + ";database=" + database + ";";
            string AdminExist = string.Empty;
            using (MySqlConnection mySqlConnection = new MySqlConnection(conphrase))
            {
                string query = "SELECT `Access` FROM helmetharbour.`accounts` WHERE `Access` = 'RootAdmin'";
                try
                {
                    mySqlConnection.Open();
                }
                catch
                {
                    MessageBox.Show("Server is either turned off or missing");
                }
                using (MySqlCommand command = new MySqlCommand(query, mySqlConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                            AdminExist = reader["Access"].ToString();
                            if (AdminExist.Equals("RootAdmin"))
                            {
                                LoginForm loginForm = new LoginForm();
                                if (loginForm.ShowDialog() == DialogResult.OK)
                                {
                                    string username = loginForm.Username;
                                    Application.Run(new MainForm(username));
                                }
                            }
                        }
                        else
                        {
                            CreateForm createForm = new CreateForm();
                            if (createForm.ShowDialog() == DialogResult.OK)
                            {
                                string username = createForm.Username;
                                Application.Run(new MainForm(username));
                            }
                        }
                    }
                }
            }
        }
    }
}