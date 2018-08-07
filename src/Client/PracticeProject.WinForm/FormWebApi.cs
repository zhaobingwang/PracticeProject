using Project.Framework.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PracticeProject.WinForm
{
    public partial class FormWebApi : Form
    {
        public FormWebApi()
        {
            InitializeComponent();
        }

        private void btnTry_Click(object sender, EventArgs e)
        {
            var users = GetUsers();
            listViewUsers.Items.Clear();
            foreach (var user in users)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = user.Name;
                lv.SubItems.Add(user.CreateDate.ToString());
                lv.SubItems.Add(user.ModifyDate.ToString());
                listViewUsers.Items.Add(lv);
            }
        }

        private List<User> GetUsers()
        {
            string json = GetJsonDataFrooAPI();
            var result = JsonConvert.DeserializeObject<List<User>>(json);
            return result;
        }

        private string GetJsonDataFrooAPI()
        {
            string url = "http://localhost/Project.WebAPI/api/user/getusers?pageIndex=1&pageSize=10";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json";

            string result = string.Empty;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
