using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_Lab6
{
    public partial class Form1 : Form
    {
        public List<Factory> Factories = new List<Factory>();
        private BindingSource binding;
        private IEnumerable<Factory> data;
        public Form1()
        {
            InitializeComponent();
            Factories.Add(new Factory(1500, 5));
            
            binding = new BindingSource();
            data = from fc in Factories select fc;
            binding.DataSource = data.ToList();
            dataGridView1.DataSource = binding;
        }

        private void button1_Click(object sender, EventArgs e) // Start work
        {
            Factories.Add(new Factory(1500, 5));
        }

        private void button2_Click(object sender, EventArgs e) // Stop and Save
        {
            throw new System.NotImplementedException();
        }

        private void button3_Click(object sender, EventArgs e) // Buy materials
        {
            button3.Enabled = false;
            Thread BuyingThread = new Thread(() => Factories[0].BuyMaterial());
            BuyingThread.Start();
        }

        private void button4_Click(object sender, EventArgs e) // Make Products
        {
            button4.Enabled = false;
            Thread MakingThread = new Thread(() => Factories[0].MakeProducts());
            MakingThread.Start();
        }

        private void button5_Click(object sender, EventArgs e) // Sell Products
        {
            button5.Enabled = false;
            Thread SellingThread = new Thread(() => Factories[0].SellProducts());
            SellingThread.Start();
        }

        private void button6_Click(object sender, EventArgs e) // Add 100$
        {
            Factories[0].AddMoney(100);
        }

        private void button7_Click(object sender, EventArgs e) // Add Manufactory
        {
            Factories[0].AddManufatories(1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!button3.Enabled) button3.Enabled = Factories[0].BuyDone;
            if(!button4.Enabled) button4.Enabled = Factories[0].MakeDone;
            if(!button5.Enabled) button5.Enabled = Factories[0].SellDone;
            binding.ResetBindings(true);
        }
    }
}