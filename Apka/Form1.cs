using Api_lab2;
using Lab2;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Apka
{
    public partial class Form1 : Form
    {
        private Client client;
        private AktywnoscDB activityDB;

        public Form1()
        {
            InitializeComponent();
            client = new Client();
            activityDB = new AktywnoscDB();
            textBox2.ScrollBars = ScrollBars.Vertical;
            LoadData();
        }
        private void LoadData()
        {
            //int try parse(in: z boxa, out numberOfParticipants) 
            dataGridView1.DataSource = activityDB.aktywnosc.ToList();
            //dataGridView1.DataSource = activityDB.aktywnosc.Where(e => e.participants == numberOfParticipants).ToList();

            dataGridView1.AutoResizeColumns();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int liczbaIteracji;
                if (!int.TryParse(textBox1.Text, out liczbaIteracji))
                {
                    MessageBox.Show("Podano nieprawid�ow� liczb� iteracji.", "B��d");
                    return;
                }

                for (int i = 0; i < liczbaIteracji; i++)
                {

                    string url = "http://www.boredapi.com/api/activity/";
                    await client.GetData(url);

                    textBox2.Text = client.activity.ToString();


                    var found = activityDB.aktywnosc.FirstOrDefault(a => a.key == client.activity.key);
                    if (found == null)
                    {
                        textBox4.Text = "Trzeba doda� t� aktywno��!" + Environment.NewLine + Environment.NewLine;
                        activityDB.aktywnosc.Add(client.activity);
                        activityDB.SaveChanges();
                        LoadData();

                    }
                    else
                    {
                        textBox4.Text = "Ju� jest!!" + Environment.NewLine;
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Wyst�pi� b��d podczas pobierania aktywno�ci: {ex.Message}", "B��d");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int liczbaUczestnikow;
                if (!int.TryParse(textBox3.Text, out liczbaUczestnikow))
                {
                    MessageBox.Show("Podano nieprawid�ow� liczb� uczestnik�w.", "B��d");
                    return;
                }

                string url = "http://www.boredapi.com/api/activity/";

                await client.GetData(url);
                textBox2.Clear();


                if (client.activity != null)
                {

                    if (client.activity.participants == liczbaUczestnikow)
                    {

                        //textBox2.Text = client.activity.ToString();
                        //textBox2.Text = Environment.NewLine;


                        var found = activityDB.aktywnosc.FirstOrDefault(a => a.participants == client.activity.participants);
                        textBox2.Text = client.activity.ToString();

                        if (found == null)
                        {
                            textBox4.Text = "Trzeba doda� t� aktywno��!" + Environment.NewLine + Environment.NewLine;
                            activityDB.aktywnosc.Add(client.activity);
                            activityDB.SaveChanges();
                        }
                        else
                        {
                            textBox4.Text = "Ju� jest!!" + Environment.NewLine;
                        }
                    }
                    else
                    {
                        textBox4.AppendText($"Znaleziona aktywno�� nie ma {liczbaUczestnikow} uczestnik�w." + Environment.NewLine);
                    }
                }
                else
                {
                    textBox4.AppendText($"Brak dost�pnych aktywno�ci dla podanej liczby uczestnik�w: {liczbaUczestnikow}." + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                // Obs�uga b��d�w w przypadku nieudanej pr�by pobrania aktywno�ci
                MessageBox.Show($"Wyst�pi� b��d podczas pobierania aktywno�ci: {ex.Message}", "B��d");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            int param;
            if (!int.TryParse(textBox6.Text, out param))
            {
                MessageBox.Show("Podano nieprawid�ow� liczb� uczestnik�w.", "B��d");
                return;
            }
            dataGridView1.DataSource = activityDB.aktywnosc.Where(e => e.participants == param).ToList();



        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = activityDB.aktywnosc.ToList();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = activityDB.aktywnosc.ToList();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (var aktywnosc in activityDB.aktywnosc)
                activityDB.aktywnosc.Remove(aktywnosc);
            activityDB.SaveChanges();
           
            dataGridView1.DataSource = activityDB.aktywnosc.ToList();

        }
    }
}