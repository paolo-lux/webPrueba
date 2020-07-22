using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using webPrueba.Models;

namespace webPrueba.DataAccess.Catalogs
{
    public class daSymptom
    {
        public static List<SymptomVM> GetSymptomsAll()
        {
            List<SymptomVM> res = new List<SymptomVM>();

            DataTable table = new DataTable();
            using (var con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog = Clase2002DB;"))
            using (var cmd = new SqlCommand("spSymptomGetAll", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(table);

                foreach (DataRow dr in table.Rows)
                {
                    res.Add(new SymptomVM
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        SymptomName = dr["SymptomName"].ToString(),
                        SynptomDescription = dr["SynptomDescription"].ToString(),
                        Measure = decimal.Parse(dr["Measure"].ToString()),
                        URLImage = dr["URLImage"].ToString(),
                        Active = (dr["Active"].ToString().ToUpper() == "TRUE" || dr["Active"].ToString() == "1" ? true : false)
                    });
                }

                /* Si funciona con Linq Avanzado
                res.AddRange(from DataRow dr in table.Rows
                             select new SymptomVM
                             {
                                 Id = int.Parse(dr["Id"].ToString()),
                                 SymptomName = dr["SymptomName"].ToString(),
                                 SynptomDescription = dr["SynptomDescription"].ToString(),
                                 Measure = decimal.Parse(dr["Measure"].ToString()),
                                 URLImage = dr["URLImage"].ToString(),
                                 Active = (dr["Active"].ToString().ToUpper() == "TRUE" || dr["Active"].ToString() == "1" ? true : false)
                             });
                */
            }



            return res;
        }

        public static List<Revision> GetSymptomsAllRev()
        {
            List<Revision> res = new List<Revision>();

            DataTable table = new DataTable();
            using (var con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog = Clase2002DB;"))
            using (var cmd = new SqlCommand("spSymptomGetAll", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(table);

                foreach (DataRow dr in table.Rows)
                {
                    res.Add(new Revision
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        SymptomName = dr["SymptomName"].ToString(),
                        SynptomDescription = dr["SynptomDescription"].ToString(),
                        Measure = decimal.Parse(dr["Measure"].ToString()),
                        URLImage = dr["URLImage"].ToString(),
                        Active = (dr["Active"].ToString().ToUpper() == "TRUE" || dr["Active"].ToString() == "1" ? true : false),
                        Presente = false
                    });
                }

            }



            return res;
        }


        public static SymptomVM GetSymptomsById(int Id)
        {
            SymptomVM res = new SymptomVM();

            DataTable table = new DataTable();
            using (var con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog = Clase2002DB;"))
            using (var cmd = new SqlCommand("spSymptomGetById", con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add(new SqlParameter("@Id", Id));
                cmd.CommandType = CommandType.StoredProcedure;
                da.Fill(table);

                foreach (DataRow dr in table.Rows)
                {
                    res = new SymptomVM
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        SymptomName = dr["SymptomName"].ToString(),
                        SynptomDescription = dr["SynptomDescription"].ToString(),
                        Measure = decimal.Parse(dr["Measure"].ToString()),
                        URLImage = dr["URLImage"].ToString(),
                        Active = (dr["Active"].ToString().ToUpper() == "TRUE" || dr["Active"].ToString() == "1" ? true : false)
                    };
                }

                /* Si funciona con Linq Avanzado
                res.AddRange(from DataRow dr in table.Rows
                             select new SymptomVM
                             {
                                 Id = int.Parse(dr["Id"].ToString()),
                                 SymptomName = dr["SymptomName"].ToString(),
                                 SynptomDescription = dr["SynptomDescription"].ToString(),
                                 Measure = decimal.Parse(dr["Measure"].ToString()),
                                 URLImage = dr["URLImage"].ToString(),
                                 Active = (dr["Active"].ToString().ToUpper() == "TRUE" || dr["Active"].ToString() == "1" ? true : false)
                             });
                */
            }



            return res;
        }






    }
}