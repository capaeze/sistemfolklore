using capapresentacion.Utilidaes;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaentidad;
using capanegocio;
using System.Drawing.Text;

namespace capapresentacion
{
    public partial class frmUSUARIOS : Form
    {
        public frmUSUARIOS()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        

       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmUSUARIOS_Load(object sender, EventArgs e)
        {
            cboestado.Items.Add(new OpcionCombo() { Valor = 1 , Texto = "Activo" });
            cboestado.Items.Add(new OpcionCombo() { Valor = 0 , Texto = "No Activo" });
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
            cboestado.SelectedIndex = 0;


            List<ROL> listaROL = new CN_ROL().listar();

            foreach (ROL item in listaROL)
            {
                cborol.Items.Add(new OpcionCombo() { Valor = item.ID_rol, Texto = item.Descripcion });


            }
            cborol.DisplayMember = "Texto";
            cborol.ValueMember = "Valor";
            cborol.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in dgvdata.Columns) { 
            

                if (columna.Visible == true && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            
            }
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
            cbobusqueda.SelectedIndex = 0;



            //mostrar todos los usuarios//

            List<USUARIO> listaUSUARIO = new CN_USUARIO().listar();

            foreach (USUARIO item in listaUSUARIO)
            {

                dgvdata.Rows.Add(new object[] {"",item.ID_usuario,item.Documento,item.Nombrecompleto,item.correo,item.clave,

                item.oROL.ID_rol,
                item.oROL.Descripcion,
                item.Estado == true ?1:0,
                item.Estado == true ? "Activo" : "No Activo"





            });




            }
            

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

            String mensaje = String.Empty;

            USUARIO objUSUARIO = new USUARIO()
            {
                ID_usuario = Convert.ToInt32(txtid.Text),
                Documento = txtdocumento.Text,
                Nombrecompleto = txtnombrecompleto.Text,
                correo = txtcorreo.Text,
                clave = txtclave.Text,
                oROL = new ROL() {ID_rol = Convert.ToInt32(((OpcionCombo)cborol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
                
            };

            if(objUSUARIO.ID_usuario ==0)
            {

                int IDusuariogenerado = new CN_USUARIO().Registrar(objUSUARIO, out mensaje);

                if (IDusuariogenerado != 0)
                {
                    dgvdata.Rows.Add(new object[] {"",IDusuariogenerado,txtdocumento.Text,txtnombrecompleto.Text,txtcorreo.Text,txtclave.Text,

                ((OpcionCombo)cborol.SelectedItem).Valor.ToString(),
                ((OpcionCombo)cborol.SelectedItem).Texto.ToString(),
                ((OpcionCombo)cboestado.SelectedItem).Valor.ToString(),
                ((OpcionCombo)cboestado.SelectedItem).Texto.ToString(),
            });

                    Limpiar();


                }
                else
                {
                    MessageBox.Show(mensaje);
                }

            }

            else
            {
                bool resultado = new CN_USUARIO().Editar(objUSUARIO, out mensaje);

                if(resultado)
                {
                    DataGridViewRow row = dgvdata.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells[""]
                }

            }




        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtdocumento.Text = "";
            txtnombrecompleto.Text = "";
            txtcorreo.Text = "";
            txtclave.Text = "";
            txtconfirmarclave.Text = "";
            cborol.SelectedIndex = 0;
            cboestado.SelectedIndex = 0;
        }

        private void dgvdata_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.check__1_.Width;
                var h = Properties.Resources.check__1_.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check__1_, new Rectangle(x, y, w, h));
                e.Handled = true;


            }


        }

        private void dgvdata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvdata.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();

                    txtid.Text = dgvdata.Rows[indice].Cells["ID"].Value.ToString();
                    txtdocumento.Text = dgvdata.Rows[indice].Cells["Documento"].Value.ToString();
                    txtnombrecompleto.Text = dgvdata.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtcorreo.Text = dgvdata.Rows[indice].Cells["Correo"].Value.ToString();
                    txtclave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();
                    txtconfirmarclave.Text = dgvdata.Rows[indice].Cells["Clave"].Value.ToString();


                    foreach(OpcionCombo oc in cborol.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32 (dgvdata.Rows[indice].Cells["ID_rol"].Value))
                        {
                            int indice_combo = cborol.Items.IndexOf(oc);
                            cborol.SelectedIndex = indice_combo;
                            break;

                        }


                    }

                    foreach (OpcionCombo oc in cboestado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgvdata.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            int indice_combo = cboestado.Items.IndexOf(oc);
                            cboestado.SelectedIndex = indice_combo;
                            break;

                        }


                    }


                }


            }


        }

        private void btneditar_Click(object sender, EventArgs e)
        {

        }
    }
}
