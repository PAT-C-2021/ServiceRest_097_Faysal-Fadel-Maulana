using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace ServiceRest_097_Faysal_Fadel_Maulana
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class TI_UMY : ITI_UMY
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string CreateMahasiswa(Mahasiswa mhs)
        {
            string msg = "GAGAL";
            SqlConnection sqlcon = new SqlConnection("Data Source=MSI;Initial Catalog=\"TI UMY\";Integrated Security=True");
            string query = string.Format("INSERT INTO dbo.Mahasiswa VALUES ('{0}', '{1}', '{2}', '{3}')", mhs.nim, mhs.nama, mhs.prodi, mhs.angkatan);

            SqlCommand cmd = new SqlCommand(query, sqlcon);
            try
            {
                sqlcon.Open();
                Console.WriteLine(query);
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                msg = "SUKSES";
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(query);
                msg = "GAGAL";
            }

            return msg;
        }

        public List<Mahasiswa> GetAllMahasiswa()
        {
            List<Mahasiswa> mahas = new List<Mahasiswa>();

            SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=\"TI UMY\";Integrated Security=True");
            string query = "SELECT NIM, Nama, Prodi, Angkatan FROM dbo.Mahasiswa";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Mahasiswa mhs = new Mahasiswa();
                    mhs.nim = reader.GetString(0);
                    mhs.nama = reader.GetString(1);
                    mhs.prodi = reader.GetString(2);
                    mhs.angkatan = reader.GetString(3);

                    mahas.Add(mhs);
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(query);
            }
            return mahas;
        }

        public Mahasiswa GetMahasiswaByNIM(string nim)
        {
            Mahasiswa mhs = new Mahasiswa();

            SqlConnection con = new SqlConnection("Data Source=MSI;Initial Catalog=\"TI UMY\";Integrated Security=True");
            string query = String.Format("SELECT NIM, Nama, Prodi, Angkatan FROM dbo.Mahasiswa WHERE NIM = '{0}'", nim);
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    mhs.nim = reader.GetString(0);
                    mhs.nama = reader.GetString(1);
                    mhs.prodi = reader.GetString(2);
                    mhs.angkatan = reader.GetString(3);
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(query);
            }
            return mhs;
        }
    }
}
