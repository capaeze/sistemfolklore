using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaentidad; //hacemos referencia a capaentidad//
using capanegocio;

using FontAwesome.Sharp;

namespace capapresentacion
{
    public partial class inicio : Form
    {
        private static USUARIO USUARIOACTUAL;

        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;
        public inicio (USUARIO objUSUARIO = null)

        {
            if (objUSUARIO == null) USUARIOACTUAL = new USUARIO() {Nombrecompleto = "ADMIN PREDEFINIDO",ID_usuario=1 };

            else
          
            USUARIOACTUAL = objUSUARIO;
            

            InitializeComponent();
        }

        private void inicio_Load(object sender, EventArgs e)
        {
            List<PERMISO> ListaPermisos = new CN_PERMISO().listar(USUARIOACTUAL.ID_usuario);

            foreach (IconMenuItem iconMenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.NombreMenu == iconMenu.Name);

                if(encontrado == false)
                {
                    iconMenu.Visible = false;
                }

            }

        


            lblusuario.Text = USUARIOACTUAL.Nombrecompleto; //nombre que se le asigno al usuario en la bbdd//
        }


        private void abrirformulario(IconMenuItem menu, Form formulario)
        {
            if(MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }

            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if(FormularioActivo != null) {

                FormularioActivo.Close();


            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.Gray;

            contenedor.Controls.Add(formulario);
            formulario.Show();



        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menutitulo_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void iconMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuusuarios_Click(object sender, EventArgs e)
        {
            abrirformulario((IconMenuItem)sender, new frmUSUARIOS()); //mostrara el formulario usuario si se preciona//
        }

        private void iconMenuItem2_Click(object sender, EventArgs e)
        {
            abrirformulario(menumantenedor, new frmCATEGORIAS());
        }

        private void submenuregistrar_Click(object sender, EventArgs e)
        {
            abrirformulario(menuventas, new frmVENTAS());
        }

        private void submenuverdetalle_Click(object sender, EventArgs e)
        {
            abrirformulario(menuventas, new frmDETALLEVENTAS());
        }

        private void menuclientes_Click(object sender, EventArgs e)
        {
            abrirformulario((IconMenuItem)sender, new frmclientes());
        }

        private void menuprogramacion_Click(object sender, EventArgs e)
        {
            abrirformulario((IconMenuItem)sender, new frmprogramacion());
        }

        private void menureportes_Click(object sender, EventArgs e)
        {
            abrirformulario((IconMenuItem)sender, new frmREPORTEVENTAS());
        }

        private void lblusuario_Click(object sender, EventArgs e)
        {

        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
