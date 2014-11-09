using System;
using System.Collections.Generic;
using System.Threading;
using voidsoft.Sunrise.Core;

namespace ExtenderTest
{
	public partial class Form1 : BusinessSearchForm
	{
		public Form1()
		{
			InitializeComponent();

			UseThreadPoolSearch = true;
		}

		public override void SearchOnThreadPool(string searchItem, ref object dataSource)
		{
			//string[] a = new string[] { "trickster", "bala", "portocala" };

			List<string> a = new List<string>();
			a.Add("ala");
			a.Add("bala");
			a.Add("portocala");

			//  MessageBox.Show(System.Threading.Thread.CurrentThread.IsThreadPoolThread.ToString());

			dataSource = a;

			//System.Threading.Thread.Sleep(10000);

			object x = a;

			base.SearchOnThreadPool(searchItem, ref x);
		}

		public override void Search(string searchItem)
		{
			string[] a = {"ala", "bala", "portocala"};

			Thread.Sleep(5000);

			dataGridView.DataSource = a;

			base.Search(searchItem);
		}

		private void buttonSearch_Click(object sender, EventArgs e)
		{
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			string[] a = {"dfsDF", "fsdf", "ffg"};

			dataGrid1.DataSource = a;
		}
	}
}