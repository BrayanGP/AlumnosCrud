using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlumnosCrud
{
    public partial class Form1 : Form
    {
        controlador con = new controlador();
        public Form1()
        {
            InitializeComponent();
            List<alumnos> lista = con.mostrarAlumnos();
            cbLista.DataSource = lista;
            cbLista.DisplayMember = "nombre";
            cbLista.ValueMember = "id";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
