using PoliziaMunicipale.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace PoliziaMunicipale.Controllers
{
    public class AltroController : Controller
    {
        // GET: Altro
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetVerbaliMax400()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            List<Verbale> VerbaliGroup = new List<Verbale>();

            try
            {
                connection.Open();
                string query = "SELECT * from Verbali where importo > 400";
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
                    VerbaliGroup.Add(verbale);
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
            return View(VerbaliGroup);
        }
        [HttpGet]
        public ActionResult GetVerbaliDecurtamentoPuntiMaggioreDi10()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            List<Verbale> VerbaliGroup10 = new List<Verbale>();

            try
            {
                connection.Open();
                string query = "SELECT * from Verbali where DecurtamentoPunti > 2";
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
                    VerbaliGroup10.Add(verbale);
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
            return View(VerbaliGroup10);
        }

        public ActionResult VerbaliXTrasgressore()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            List<Punti> VerbalixTrasgressore = new List<Punti>();

            try
            {
                conn.Open();
                string query = "Select a.Nome, a.Cognome, Count(*) as TotaleVerbali from Verbali b " +
                    "Inner join DatiAnagrafici a On b.IDAnagrafica = a.IDAnagrafica " +
                    "Group by a.Nome, a.Cognome";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Punti punti = new Punti();
                    punti.Nome = reader["Nome"].ToString();
                    punti.Cognome = reader["Cognome"].ToString();
                    punti.TotaleVerbali = Convert.ToInt32(reader["TotaleVerbali"]);
                    VerbalixTrasgressore.Add(punti);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Errore SQL: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return View(VerbalixTrasgressore);
        }

        public ActionResult Puntidecurtati()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Polizia"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            List<Punti> puntiDecurtati = new List<Punti>();
            try
            {
                conn.Open();
                string query = "Select a.Nome, a.Cognome, Sum(b.DecurtamentoPunti) as PuntiDecurtati from DatiAnagrafici a, Verbali b where a.IDAnagrafica = b.IDAnagrafica group by a.Nome, a.Cognome";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Punti punti = new Punti();
                    punti.Nome = reader["Nome"].ToString();
                    punti.Cognome = reader["Cognome"].ToString();
                    punti.PuntiDecurtati = Convert.ToInt32(reader["PuntiDecurtati"]);
                    puntiDecurtati.Add(punti);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Errore SQL: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return View(puntiDecurtati);
        }
    }
}