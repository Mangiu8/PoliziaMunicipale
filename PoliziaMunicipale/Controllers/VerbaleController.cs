using PoliziaMunicipale.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace PoliziaMunicipale.Controllers
{
    public class VerbaleController : Controller
    {
        //GET: Verbale
        [HttpGet]
        public ActionResult GetVerbali()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            List<Verbale> Verbali = new List<Verbale>();

            try
            {
                connection.Open();
                string query = "SELECT * FROM Verbali";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Verbale verbale = new Verbale();
                    verbale.IDVerbale = Convert.ToInt32(reader["IDVerbale"]);
                    verbale.IDAnagrafica = Convert.ToInt32(reader["IDAnagrafica"]);
                    verbale.IDViolazione = Convert.ToInt32(reader["IDViolazione"]);
                    verbale.DataViolazione = Convert.ToDateTime(reader["DataViolazione"]);
                    verbale.IndirizzoViolazione = reader["IndirizzoViolazione"].ToString();
                    verbale.NominativoAgente = reader["NominativoAgente"].ToString();
                    verbale.DataTrascrizioneVerbale = Convert.ToDateTime(reader["DataTrascrizioneVerbale"]);
                    verbale.Importo = Convert.ToInt32(reader["Importo"]);
                    verbale.DecurtamentoPunti = Convert.ToInt32(reader["DecurtamentoPunti"]);
                    Verbali.Add(verbale);
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
            return View(Verbali);
        }

        public ActionResult NewVerbale()
        {
            return View();
        }
        [HttpPost]

        public ActionResult NewVerbale(Verbale verbale)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "INSERT INTO Verbali (IDAnagrafica, IDViolazione, DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti) VALUES (@IDAnagrafica, @IDViolazione, @DataViolazione, @IndirizzoViolazione, @NominativoAgente, @DataTrascrizioneVerbale, @Importo, @DecurtamentoPunti)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDAnagrafica", verbale.IDAnagrafica);
                command.Parameters.AddWithValue("@IDViolazione", verbale.IDViolazione);
                command.Parameters.AddWithValue("@DataViolazione", verbale.DataViolazione);
                command.Parameters.AddWithValue("@IndirizzoViolazione", verbale.IndirizzoViolazione);
                command.Parameters.AddWithValue("@NominativoAgente", verbale.NominativoAgente);
                command.Parameters.AddWithValue("@DataTrascrizioneVerbale", verbale.DataTrascrizioneVerbale);
                command.Parameters.AddWithValue("@Importo", verbale.Importo);
                command.Parameters.AddWithValue("@DecurtamentoPunti", verbale.DecurtamentoPunti);
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
            return RedirectToAction("GetVerbali");
        }

        [HttpGet]
        public ActionResult GetContestazione()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            List<Verbale> Contestazioni = new List<Verbale>();

            try
            {
                connection.Open();
                string query = "SELECT * FROM Verbali WHERE Contestazioni = 1";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Verbale verbale = new Verbale();
                    verbale.IDVerbale = Convert.ToInt32(reader["IDVerbale"]);
                    verbale.IDAnagrafica = Convert.ToInt32(reader["IDAnagrafica"]);
                    verbale.IDViolazione = Convert.ToInt32(reader["IDViolazione"]);
                    verbale.DataViolazione = Convert.ToDateTime(reader["DataViolazione"]);
                    verbale.IndirizzoViolazione = reader["IndirizzoViolazione"].ToString();
                    verbale.NominativoAgente = reader["NominativoAgente"].ToString();
                    verbale.DataTrascrizioneVerbale = Convert.ToDateTime(reader["DataTrascrizioneVerbale"]);
                    verbale.Importo = Convert.ToInt32(reader["Importo"]);
                    verbale.DecurtamentoPunti = Convert.ToInt32(reader["DecurtamentoPunti"]);
                    Contestazioni.Add(verbale);
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
            return View(Contestazioni);
        }
    }
}