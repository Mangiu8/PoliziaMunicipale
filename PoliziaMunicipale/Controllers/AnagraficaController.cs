using PoliziaMunicipale.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace PoliziaMunicipale.Controllers
{
    public class AnagraficaController : Controller
    {
        // GET: Anagrafica
        [HttpGet]
        public ActionResult GetAnagrafica()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            List<Trasgressori> trasgressori = new List<Trasgressori>();

            try
            {
                connection.Open();
                string query = "SELECT * FROM DatiAnagrafici";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Trasgressori trasgressore = new Trasgressori();
                    trasgressore.IDAnagrafica = Convert.ToInt32(reader["IDAnagrafica"]);
                    trasgressore.Nome = reader["Nome"].ToString();
                    trasgressore.Cognome = reader["Cognome"].ToString();
                    trasgressore.CodiceFiscale = reader["CodiceFiscale"].ToString();
                    trasgressore.Indirizzo = reader["Indirizzo"].ToString();
                    trasgressore.Citta = reader["Citta"].ToString();
                    trasgressore.Cap = Convert.ToInt32(reader["Cap"]);
                    trasgressori.Add(trasgressore);
                }
            }
            catch (SqlException ex)
            {
                ViewBag.Error = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return View(trasgressori);
        }

        public ActionResult NewAnagrafica()
        {
            return View();
        }
        [HttpPost]

        public ActionResult NewAnagrafica(Trasgressori trasgressore)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "INSERT INTO DatiAnagrafici (Nome, Cognome, CodiceFiscale, Indirizzo, Citta, Cap) VALUES (@Nome, @Cognome, @CodiceFiscale, @Indirizzo, @Citta, @Cap)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nome", trasgressore.Nome);
                command.Parameters.AddWithValue("@Cognome", trasgressore.Cognome);
                command.Parameters.AddWithValue("@CodiceFiscale", trasgressore.CodiceFiscale);
                command.Parameters.AddWithValue("@Indirizzo", trasgressore.Indirizzo);
                command.Parameters.AddWithValue("@Citta", trasgressore.Citta);
                command.Parameters.AddWithValue("@Cap", trasgressore.Cap);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                ViewBag.Error = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return RedirectToAction("GetAnagrafica");
        }

    }
}