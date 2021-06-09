using Practica.Model;
using Practica.poco;
using Practica.poco.Enums;
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
    public partial class FormAñadirEmpleados : Form
    {
        public EmpleadorModel EmpleadorModel { get; set; }
        public FormAñadirEmpleados()
        {
            InitializeComponent();
        }

        private void FormAñadirEmpleados_Load(object sender, EventArgs e)
        {
            cmbCargo.Items.AddRange(Enum.GetValues(typeof(Cargo))
                                       .Cast<object>()
                                       .ToArray());
            cmbCargo.SelectedIndex = 0;

            cmbProfesion.Items.AddRange(Enum.GetValues(typeof(Profesion))
                                       .Cast<object>()
                                       .ToArray());
            cmbProfesion.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string cedula = txtCedula.Text;
                string telefono = txtTelefono.Text;
                string correo = txtCorreo.Text;

                ValidateEmpleado( nombre, apellido,cedula,telefono,correo, out decimal salario);

                int index = cmbCargo.SelectedIndex;
                int index1 = cmbProfesion.SelectedIndex;
                Cargo cargo = (Cargo)Enum.GetValues(typeof(Cargo))
                                                  .GetValue(index);
                Profesion profesion = (Profesion)Enum.GetValues(typeof(Profesion))
                                                 .GetValue(index1);
                Empleado empleado = new Empleado()
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Cedula = cedula,
                    Telefono = telefono,
                    Correo = correo,
                    Cargo = cargo,
                    Profesion = profesion,
                    Salario= salario

                };

                EmpleadorModel.AddElement(empleado);
                
                if (empleado != null)
                {
                    MessageBox.Show("Empleado Guardado", "Mensaje de informacion",MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                    
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateEmpleado(string nombre, string apellido, string cedula, string telefono, string correo, out decimal salario)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El valor de Nombre es requerido!");
            }
            if (string.IsNullOrWhiteSpace(apellido))
            {
                throw new ArgumentException("El valor de Apellido es requerido!");
            }
            if (string.IsNullOrWhiteSpace(cedula))
            {
                throw new ArgumentException("El valor de N° Cedula es requerido!");
            }
            if (string.IsNullOrWhiteSpace(telefono))
            {
                throw new ArgumentException("El valor de N° Telefono es requerido!");
            }
            if (string.IsNullOrWhiteSpace(correo))
            {
                throw new ArgumentException("Direccion Correo Electronico es requerida!");
            }
            if (!decimal.TryParse(txtSalario.Text, out decimal S))
            {
                throw new ArgumentException($"El valor {txtSalario.Text} no es correcto!");
            }
            salario = S;

            if (salario <= 0 )
            {
                throw new ArgumentException("El valor no puede ser menor o igual a cero.");
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombre.Text="";
            txtApellido.Text="";
            txtCedula.Text="";
            txtTelefono.Text="";
            txtCorreo.Text = "";
            txtSalario.Text = "";
            cmbCargo.SelectedIndex = 0;
            cmbProfesion.SelectedIndex = 0;

        }
    }
}
