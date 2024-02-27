using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using capanegocio;
using capaentidad;

namespace capapresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {

            List<USUARIO> TEST = new CN_USUARIO().listar();

            USUARIO oUSUARIO = new CN_USUARIO().listar().Where(u=> u.Documento ==textdocumento.Text && u.clave ==textcontraseña.Text).FirstOrDefault();


            if (oUSUARIO != null)
            {


                inicio form = new inicio(oUSUARIO);

                form.Show();
                this.Hide();

                form.FormClosing += frm_closing;



            }

            else { 

                MessageBox.Show("usuario no encontrado","mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            
            
            }


        }
        private void frm_closing(object sender,FormClosingEventArgs e) {

            textdocumento.Text = "";
            textcontraseña.Text = "";

            this.Show();

                }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
