using System.Data.SqlClient;
using System.Web.Http;
using WebAppForm.Models;

public class CotizacionVehiculoController : ApiController
{
    [HttpPost]
    public IHttpActionResult GuardarCotizacion([FromBody] CotizacionVehiculo cotizacion)
    {

        try
        {
            if (cotizacion == null)
            {
                return BadRequest("Datos de cotización no válidos.");
            }


            // Cadena de conexión a la base de datos
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["CotizacionVehiculoDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO CotizacionVehiculo (Nombre, ModeloVehiculo, NumeroTelefono, Direccion, InformacionEmpleo, PosicionDesempeniada, IngresoMensual, GanaPorHoraOSueldo, NumeroSeguroSocial, NumeroVIN, MillasVehiculo, DeudaPendiente, ColoresDeseados) " +
                               "VALUES (@Nombre, @ModeloVehiculo, @NumeroTelefono, @Direccion, @InformacionEmpleo, @PosicionDesempeniada, @IngresoMensual, @GanaPorHoraOSueldo, @NumeroSeguroSocial, @NumeroVIN, @MillasVehiculo, @DeudaPendiente, @ColoresDeseados)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Agregar parámetros para evitar inyección SQL
                    cmd.Parameters.AddWithValue("@Nombre", cotizacion.Nombre);
                    cmd.Parameters.AddWithValue("@ModeloVehiculo", cotizacion.ModeloVehiculo);
                    cmd.Parameters.AddWithValue("@NumeroTelefono", cotizacion.NumeroTelefono);
                    cmd.Parameters.AddWithValue("@Direccion", cotizacion.Direccion);
                    cmd.Parameters.AddWithValue("@InformacionEmpleo", cotizacion.InformacionEmpleo);
                    cmd.Parameters.AddWithValue("@PosicionDesempeniada", cotizacion.PosicionDesempeniada);
                    cmd.Parameters.AddWithValue("@IngresoMensual", cotizacion.IngresoMensual);
                    cmd.Parameters.AddWithValue("@GanaPorHoraOSueldo", cotizacion.GanaPorHoraOSueldo);
                    cmd.Parameters.AddWithValue("@NumeroSeguroSocial", cotizacion.NumeroSeguroSocial);
                    cmd.Parameters.AddWithValue("@NumeroVIN", cotizacion.NumeroVIN);
                    cmd.Parameters.AddWithValue("@MillasVehiculo", cotizacion.MillasVehiculo);
                    cmd.Parameters.AddWithValue("@DeudaPendiente", cotizacion.DeudaPendiente);
                    cmd.Parameters.AddWithValue("@ColoresDeseados", cotizacion.ColoresDeseados);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            return Ok("Datos guardados exitosamente");

        }
        catch (System.Exception ex)
        {
            return InternalServerError(ex);
        }        
    }
}
