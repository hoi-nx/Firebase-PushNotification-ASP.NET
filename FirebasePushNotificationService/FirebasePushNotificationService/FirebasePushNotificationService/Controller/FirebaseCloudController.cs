using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FirebasePushNotificationService.Controller
{
    public class FirebaseCloudController : ApiController
    {
        [HttpPost]
        public bool saveToken(string token)
        {
            try
            {
                MTokenDataContext context = new MTokenDataContext();
                FirebaseCloud tokenD = context.FirebaseClouds.FirstOrDefault(x => x.Token == token);
                if (tokenD != null)
                {
                    return false;
                }
                FirebaseCloud firebase = new FirebaseCloud();
                firebase.Token = token;
                context.FirebaseClouds.InsertOnSubmit(firebase);
                context.SubmitChanges();
                return true;
            }
            catch
            {

            }
            return false;

        }

        [HttpGet]

        public List<FirebaseCloud> getListToken()
        {
            MTokenDataContext m = new MTokenDataContext();
            List<FirebaseCloud> firebaseClouds = m.FirebaseClouds.ToList();

            return firebaseClouds;
        }
    }
}
