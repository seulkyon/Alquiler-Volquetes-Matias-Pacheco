using System.Runtime.InteropServices;
using Entidades;

namespace Parcial_Volquete
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
            try
            {
                GestionUsuarios.CargarUsuariosDesdeJSON();

            }
            catch (Exception ex)
            {
                GestionUsuarios.GuardarUsuariosEnJSON();
            }


        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);



        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            foreach (UsuarioFinal usuario in GestionUsuarios.Usuarios)
            {
                if (txtUser.Text == usuario.id && txtPassword.Text == usuario.contraseņa)
                {
                    VentanaEmergente ve = new VentanaEmergente("Log In", "Usuario logueado con exito");
                    ve.ShowDialog();
                    if (ve.DialogResult == DialogResult.OK)
                    {
                        GestionUsuarios.IniciarSesion(usuario);
                        Menu mp = new Menu();
                        mp.Show();
                        this.Hide();
                    }
                }
            }





        }
        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.LightGray;

            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Contraseņa")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Contraseņa";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            GestionUsuarios.GuardarUsuariosEnJSON();
            Application.Exit();
        }

        private void btnUserAutomatico_Click(object sender, EventArgs e)
        {
            txtUser.Text = "user";
            txtPassword.Text = "pass";

        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            GestionUsuarios.CargarAdminDesdeJSON();
            foreach(Administrador admin in GestionUsuarios.Admins) 
            {
                GestionUsuarios.IniciarSesionAdmin(admin);
                Menu mp = new Menu();
                mp.Show();
                this.Hide();
            }
        }
    }
}