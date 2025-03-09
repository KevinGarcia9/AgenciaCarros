using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;

namespace Repaso
{
    public partial class FrmVehiculo: Form
    {
        public FrmVehiculo()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmMenuPrincipal nuevoFormulario = new FrmMenuPrincipal();
            nuevoFormulario.Show();
        }

        public void MtdMostrar()
        {
            
            CD_Vehiculos mostrar = new CD_Vehiculos();
            DataTable dtMostrar = mostrar.MtMostrar();
            dtvEmpleado.DataSource = dtMostrar;
        }

        private void FrmVehiculos_Load(object sender, EventArgs e)
        {
            MtdMostrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CD_Vehiculos conn = new CD_Vehiculos();

            try
            {
                    conn.MtInsertar(
                        txtNombre.Text,
                        txtApellido.Text,
                        int.Parse( txtFechaNac.Text),
                        decimal.Parse(txtFechaContratacion.Text),
                        cbxEstado.Text
                        );

                MessageBox.Show("El Vehiculo se agregó con éxito", "Correcto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MtdMostrar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            CD_Vehiculos conn = new CD_Vehiculos();

            try
            {
                conn.MtUpdate(
                    int.Parse(txtEmpleadoID.Text),
                    txtNombre.Text,
                        txtApellido.Text,
                        int.Parse(txtFechaNac.Text),
                        decimal.Parse(txtFechaContratacion.Text),
                        cbxEstado.Text);

                MessageBox.Show("El Empleado se actualizo con éxito", "Correcto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MtdMostrar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CD_Vehiculos conn = new CD_Vehiculos();

            try
            {
                conn.MtDelete(
                    int.Parse(txtEmpleadoID.Text));

                MessageBox.Show("El Empleado se elimino con éxito", "Correcto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MtdMostrar();
        }

        private void dtvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEmpleadoID.Enabled = false;

            txtEmpleadoID.Text = dtvEmpleado.SelectedCells[0].Value.ToString();
            txtNombre.Text = dtvEmpleado.SelectedCells[1].Value.ToString();
            txtApellido.Text = dtvEmpleado.SelectedCells[2].Value.ToString();
            txtFechaNac.Text = dtvEmpleado.SelectedCells[3].Value.ToString();
            txtFechaContratacion.Text = dtvEmpleado.SelectedCells[4].Value.ToString();
           
            cbxEstado.Text = dtvEmpleado.SelectedCells[5].Value.ToString();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtEmpleadoID.ResetText();
            txtNombre.ResetText();
            txtApellido.ResetText();
            txtFechaNac.ResetText();
            txtFechaContratacion.ResetText();
           
            cbxEstado.ResetText();

        }

        private void txtFechaContratacion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
