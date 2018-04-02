using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirebasePushNotificationService.Views
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnPush_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.FirebaseCloudController fbCloud = new Controller.FirebaseCloudController();
                  List<FirebaseCloud> dsToken = fbCloud.getListToken();
                WebRequest tRequest;
                string applicationID = "AAAAvFtefDY:APA91bE6Yoyc-ArDb6ZXnf0lq1Xb03PwuA8mtNtvnj7UVnpPHFz4IuTy8KggrmHIJHIcBL_hECSu-xKUDobEQ7eXXMLTj3wi6cUZv5eYKzvEZQwIlZi-1u2On7YjY6l0xxXm67Wb721l";
                string senser_id = "808986770486";
                //thiết lập fcm send
                tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "POST";
                tRequest.UseDefaultCredentials = true;
                tRequest.PreAuthenticate = true;
                tRequest.Credentials = CredentialCache.DefaultNetworkCredentials;
                //định dạng JSON
                tRequest.ContentType = "application/json";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senser_id));
                string[] arrRegid = dsToken.Select(x => x.Token).ToArray();
                string RegArr = string.Empty;
                RegArr = string.Join("\",\"", arrRegid);
                string postData = "{\"registration_ids\":[\"" + RegArr + "\"],\"data\":{\"message\":\"" + txtND.Text + "\",\"body\":\"" + txtND.Text + "\",\"title\":\"" + txtTitle.Text + "\",\"collapse_key\":\"" + txtND.Text + "\"}}";
                Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                tRequest.ContentLength = byteArray.Length;
                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse tpResponse = tRequest.GetResponse();

                dataStream = tpResponse.GetResponseStream();
                StreamReader tReader = new StreamReader(dataStream);
                String sResponseFromSever = tReader.ReadToEnd();
                txtKQ.Text = sResponseFromSever;
                tReader.Close();
                dataStream.Close();
                tpResponse.Close();
            }
            catch(Exception ex)
            {
                txtKQ.Text = ex.Message;
            }
        }
    }
}