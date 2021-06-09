using Practica.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica
{
    public partial class Form1 : Form
    {
        private EmpleadorModel empleadorModel;
        public Form1()
        {
            InitializeComponent();
            empleadorModel = new EmpleadorModel();
        }

        private void añadirEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAñadirEmpleados formEmp = new FormAñadirEmpleados();
            formEmp.EmpleadorModel = empleadorModel;
            formEmp.MdiParent = this;
            formEmp.Show();
        }

        private void verEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVerEmpleados formEmp = new FormVerEmpleados();
            formEmp.empleadorModel = empleadorModel;
            formEmp.MdiParent = this;
            formEmp.Show();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea Salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }

        }
    }
}
