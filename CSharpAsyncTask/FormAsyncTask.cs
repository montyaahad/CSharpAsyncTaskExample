using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpAsyncTask
{
    public partial class FormAyncTask : Form
    {
        public FormAyncTask()
        {
            InitializeComponent();
        }

        private void btnAsyncTask_Click(object sender, EventArgs e)
        {
            Task<string> task = Task.Factory.StartNew(() => Foo(tbName.Text));

            task.ContinueWith(t => FooResult(task.Result),
                  TaskScheduler.FromCurrentSynchronizationContext());
        }

        private string Foo(string name)
        {
            Thread.Sleep(3000);

            return name;
        }

        private void FooResult(string name)
        {
            MessageBox.Show("Wake up, " + name + "!");
        }
    }
}
