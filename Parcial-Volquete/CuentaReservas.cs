﻿using Entidades;
using Dominio;

namespace Parcial_Volquete
{
    public partial class Cuenta_Reservas : Form
    {
        public Cuenta_Reservas()
        {
            InitializeComponent();
        }

        private void Cuenta_Reservas_Load(object sender, EventArgs e)
        {
            if (GestionUsuarios.UsuarioActual != null)
            {
                dtgAlquileres.Refresh();
                dtgAlquileres.AutoGenerateColumns = false;

                // Configura las columnas según las propiedades de tu clase Alquiler
                dtgAlquileres.Columns.Add("IdAlquiler", "Id");
                dtgAlquileres.Columns.Add("VolquetesAlquiler", "Volquetes");
                dtgAlquileres.Columns.Add("FechaEscogida", "Fecha");
                dtgAlquileres.Columns.Add("ubicacionDeEntrega", "Ubicación de entrega");
                dtgAlquileres.Columns.Add("Nombre", "Nombre");
                dtgAlquileres.Columns.Add("Email", "Email");
                dtgAlquileres.Columns.Add("numeroDeTelefono", "Teléfono");
                dtgAlquileres.Columns.Add("Duracion", "Duración");
                dtgAlquileres.Columns.Add("Precio", "Precio");
                dtgAlquileres.Columns.Add("MedioDePago", "Medio de Pago");
                dtgAlquileres.Columns.Add("estado", "Estado");


                // Configura las propiedades de las columnas según el tipo de datos
                dtgAlquileres.Columns["IdAlquiler"].DataPropertyName = "IdAlquiler";
                dtgAlquileres.Columns["VolquetesAlquiler"].DataPropertyName = "VolquetesToString";
                dtgAlquileres.Columns["FechaEscogida"].DataPropertyName = "FechaEscogida";
                dtgAlquileres.Columns["ubicacionDeEntrega"].DataPropertyName = "ubicacionDeEntrega";
                dtgAlquileres.Columns["Nombre"].DataPropertyName = "Nombre";
                dtgAlquileres.Columns["Email"].DataPropertyName = "Email";
                dtgAlquileres.Columns["numeroDeTelefono"].DataPropertyName = "numeroDeTelefono";
                dtgAlquileres.Columns["Duracion"].DataPropertyName = "Duracion";
                dtgAlquileres.Columns["Precio"].DataPropertyName = "Precio";
                dtgAlquileres.Columns["MedioDePago"].DataPropertyName = "MedioDePago";
                dtgAlquileres.Columns["estado"].DataPropertyName = "estado";

                foreach (DataGridViewColumn column in dtgAlquileres.Columns)
                {
                    column.ReadOnly = true;
                }

                dtgAlquileres.DataSource = GestionUsuarios.UsuarioActual.alquileres;

                lblNombreCuenta.Text = GestionUsuarios.UsuarioActual.id;



            }




        }

        private void dtgAlquileres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
