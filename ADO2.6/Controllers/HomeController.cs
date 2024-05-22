using ADO2._6.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADO2._6.Controllers
{
    public class HomeController : Controller
    {
        private string connect = "Data Source=LARMESDESANG;Initial Catalog=ADO;Integrated Security=True;Application Name=EntityFramework;";

        [HttpGet]
        public ActionResult Index()
        {
            List<Inimene> inimesed = new List<Inimene>();

            string query = "SELECT Id, nimi, vanus FROM inimene";

            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Inimene inimene = new Inimene
                        {
                            Id = (int)reader["Id"],
                            Nimi = reader["nimi"].ToString(),
                            Vanus = reader["vanus"] as int?,
                        };
                        inimesed.Add(inimene);
                    }
                }
            }

            return View(inimesed);
        }

        [HttpPost]
        public ActionResult AddInimene(string nimi, int vanus)
        {
            InsertDB(nimi, vanus);
            return RedirectToAction("Index");
        }

        private void InsertDB(string nimi, int vanus)
        {
            using (SqlConnection connection = new SqlConnection(connect))
            {
                connection.Open();
                string query = "INSERT INTO inimene (nimi, vanus) VALUES (@nimi, @vanus)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nimi", nimi);
                command.Parameters.AddWithValue("@vanus", vanus);
                command.ExecuteNonQuery();
            }
        }
    }
}
