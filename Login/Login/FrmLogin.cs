using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Login
{
    public partial class FrmLogin : Form
    {
        //Rferencia da conexao
        SqlConnection Conexao = new SqlConnection(@"Data Source=LAPTOP-FPCDKNOO;Initial Catalog=LoginApp;Integrated Security=True");
        public FrmLogin()
        {
            InitializeComponent();
            txtUsuario.Select();
            txtPassword.Select();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //verifica se nos campos há algo
        void verificar()
        {
            if (txtUsuario.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("Preencha os campos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Select();
            }
        }
        //botão entrar

        private void bntEntrar_Click_1(object sender, EventArgs e)
        {
            Conexao.Open();//abrir conexao
            verificar();
            string query = "SELECT *FROM Usuario WHERE Username = '" + txtUsuario.Text + "' AND Password = '" + txtPassword.Text + "'";
            SqlDataAdapter dp = new SqlDataAdapter(query, Conexao);
            DataTable dt = new DataTable();
            dp.Fill(dt);

            try
            {
                if (dt.Rows.Count == 1)
                {
                    FrmPrincipal principal = new FrmPrincipal();
                    this.Hide();
                    principal.Show();
                }
            }

            catch (Exception erro)
            {
                MessageBox.Show("Usuario ou Password incorreta" + erro);
                txtUsuario.Text = ""; // limpa as textbox depois de serem
                txtPassword.Text = "";
                txtUsuario.Select(); // cursor irá sinalizar a primeira textbox
            }

            Conexao.Close();//Fechar a conexao
        }

        // botão sair    
        private void bntSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
