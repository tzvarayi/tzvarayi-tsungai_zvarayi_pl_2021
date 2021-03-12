using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ExpensesManager

{
    class Expense
    {
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public Expense(DateTime date, decimal dpPrice, string category)
        {
            Date = date;
            Price = dpPrice;
            Category = category;
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pathToFile = TextBox.Text;

            if (!File.Exists(pathToFile))
            {
                throw new Exception();
            }

            var lines = File.ReadLines(pathToFile).Skip(1);
            var expenses = new List<Expense>();
            foreach (var line in lines)
            {
                var separated = line.Split('|');

                var date = DateTime.ParseExact(separated[0], "yyyy-MM-dd", null);
                var price = Convert.ToDecimal(separated[1].Replace(".", ","));
                var category = separated[2];

                var expense = new Expense(date, price, category);
                expenses.Add(expense);
            }

            var catnum = expenses.Select(x => x.Category).Distinct().Count();
            var topsum = expenses.Sum(x => x.Price);

            richTextBox.Text = $"Number of categories: {catnum}, total expenses {topsum}\n";



        }
    }
}
