


using System.Data;
using System.Data.SqlClient;
using WebChungKhoan3._0.Models;
namespace WebChungKhoan3._0.Repositories
{

    public class Item
    {
        string connectionString;
        public Item(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<BANGGIATRUCTUYEN> GetOrder()
        {
            List<BANGGIATRUCTUYEN> Items = new List<BANGGIATRUCTUYEN>();
            BANGGIATRUCTUYEN item;
            var data = GetMACK();
            foreach (DataRow row in data.Rows)
            {
                item = new BANGGIATRUCTUYEN();
                {
                    item.MACK = row["MACK"].ToString();    //Console.WriteLine(item.MACK);

                    item.GIAMUATHREE = row["GIAMUATHREE"].ToString(); // Console.WriteLine(item.GIAMUAthree);
                    item.KHOILUONGMUATHREE = row["KHOILUONGMUATHREE"].ToString();
                    
                    item.GIAMUATWO = row["GIAMUATWO"].ToString();
                    item.KHOILUONGMUATWO = row["KHOILUONGMUATWO"].ToString();
                    
                    item.GIAMUAONE = row["GIAMUAONE"].ToString();
                    item.KHOILUONGMUAONE = row["KHOILUONGMUAONE"].ToString();
                    
                    item.GIAMUA = row["GIAMUA"].ToString();
                    item.KHOILUONGMUA = row["KHOILUONGMUA"].ToString();

                    item.GIABANONE = row["GIABANONE"].ToString();
                    item.KHOILUONGBANONE = row["KHOILUONGBANONE"].ToString();

                    item.GIABANTWO = row["GIABANTWO"].ToString();
                    item.KHOILUONGBANTWO = row["KHOILUONGBANTWO"].ToString();

                    item.GIABANTHREE = row["GIABANTHREE"].ToString();
                    item.KHOILUONGBANTHREE = row["KHOILUONGBANTHREE"].ToString();

                    item.TONGKHOILUONG = row["TONGKHOILUONG"].ToString();
                    
                   // Console.WriteLine(item.GIAMUA);
                    //   item.MUA2 = row["MUA2"].ToString();
                    //  item.MUA1 = row["MUA1"].ToString();
                  //  item.SOLUONGMUA3 = row["SOLUONGMỦA"].ToString();
                    

                    //Console.WriteLine(item.MACK);
                };
                Items.Add(item);
            }
            return Items;
        }
    private DataTable GetMACK()
        {
            var query = "SELECT *  FROM BANGGIATRUCTUYEN  "; //SELECT *  FROM BANGGIATRUCTUYEN ORDER by STT asc sort by stt
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                    return dt;
                }
                catch(Exception e)
                {
                    throw ;
                }
                finally
                {
                    connection.Close();
                }
            }
        }


    }
}
