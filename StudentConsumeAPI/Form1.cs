using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;

namespace StudentConsumeAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            using (HttpClient client=new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7135/");
                HttpResponseMessage response = await client.GetAsync("api/StudentAPI");
                if(response.IsSuccessStatusCode)
                {
                    string jsonData = await response.Content.ReadAsStringAsync();
                    List<Student> students = JsonConvert.DeserializeObject<List<Student>>(jsonData);
                    dataGridView1.DataSource = students;
                }
                else
                {
                    MessageBox.Show("Fail to load data");
                }

            }
        }
    }
}
