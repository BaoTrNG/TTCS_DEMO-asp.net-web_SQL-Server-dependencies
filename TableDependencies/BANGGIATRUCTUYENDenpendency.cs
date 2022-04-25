using WebChungKhoan3._0.Models;
using WebChungKhoan3._0.Hubs;
using TableDependency.SqlClient;

namespace WebChungKhoan3._0.TableDependencies
{
    
    public class BANGGIATRUCTUYENDenpendency
    {
        SqlTableDependency<BANGGIATRUCTUYEN> tableDependency;
        DashBoardHub boardHub;

        public BANGGIATRUCTUYENDenpendency(DashBoardHub boardHub)
        {
            this.boardHub = boardHub;
        } 
        public void SubscribeTableDenpendency()
        {
            string connectionstr = "Data Source=M15R2;Initial Catalog=ChungKhoan;User ID=TTCS;Password=123";
            tableDependency = new SqlTableDependency<BANGGIATRUCTUYEN>(connectionstr);
           tableDependency.OnChanged += TableDependency_OnChanged;
           tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();

        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(BANGGIATRUCTUYEN)} SqlTableDependency error: {e.Error.Message}");
        }
        private void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<BANGGIATRUCTUYEN> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                boardHub.SendOrder();
            }
        }
    }
}
