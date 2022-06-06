using Manager.Model.Base;
using Newtonsoft.Json;

namespace InsertJson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {

            //
            Manager.Service.Service.MenuService menuService = new Manager.Service.Service.MenuService();
            var jsondata= JsonConvert.DeserializeObject<ReturnBase<List<Manager.Model.Entitys.Menu>>>(txtJson.Text);
            foreach (var item in jsondata.data)
            {
                menuService.InsertMenu(item);   
            }

        }
    }
}