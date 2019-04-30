using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        Dictionary<DateTime, string> toDoLitst = new Dictionary<DateTime, string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            try { 
            if ((txtTask.Text).Trim() == String.Empty)
            {
                MessageBox.Show("You must enter a task");
                txtTask.Select();
                txtTask.Focus();
            }
            else {
        
                toDoLitst.Add(dtpTaskDate.Value.Date, txtTask.Text);
            }
            DiplayTask();
            txtTask.Clear();
            txtTask.SelectAll();
            txtTask.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Only one task per day is allowed!","Invalid data");
            }

        }
        private void DiplayTask()
        {
            lstTasks.Items.Clear();
            foreach(var item in toDoLitst.OrderBy(kvp =>kvp.Key))
            {
                lstTasks.Items.Add(item.Key);
            }
        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
           lblTaskDetails.Text = toDoLitst[Convert.ToDateTime(lstTasks.SelectedItem)];
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you really want to remove this task?", "Remove task", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res== DialogResult.Yes) {
                toDoLitst.Remove(Convert.ToDateTime(lstTasks.SelectedItem));
                DiplayTask();
            }
           
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            string rpt = "";
            foreach (var item in toDoLitst)
            {
             rpt = rpt +   item.Key.ToShortDateString() + " "+ item.Value + Environment.NewLine;
            }
            MessageBox.Show(rpt);
        }
    }
}
