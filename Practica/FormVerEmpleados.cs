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
    public partial class FormVerEmpleados : Form

    {
        

        public EmpleadorModel empleadorModel { get; set; }
        public FormVerEmpleados()
        {
            InitializeComponent();
           
        }


        private void FormVerEmpleados_Load(object sender, EventArgs e)
        {
            llenartabla();
        }

        private void llenartabla()
        {
            
           
            if (empleadorModel.GetAll() == null)
            {
                return;
            }
            
            dgvEmpleado.DataSource = empleadorModel.GetAll();

        }
        

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvEmpleado.Rows.Count == 0)
            {
                return;
            }
            int index = dgvEmpleado.CurrentCell.RowIndex;
            empleadorModel.Remove(index);

            dgvEmpleado.DataSource = empleadorModel.GetAll();

        }
    }
}
